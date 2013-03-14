#!/usr/bin/python2.6
# Copyright 2010 Google Inc. All Rights Reserved.
#
#  Licensed under the Apache License, Version 2.0 (the "License");
#  you may not use this file except in compliance with the License.
#  You may obtain a copy of the License at
#
#      http://www.apache.org/licenses/LICENSE-2.0
#
#  Unless required by applicable law or agreed to in writing, software
#  distributed under the License is distributed on an "AS IS" BASIS,
#  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
#  See the License for the specific language governing permissions and
#  limitations under the License.


"""Command line tool to run the Google API library generator.
Usage:
$ PYTHONPATH=$(/bin/pwd)/src \
  $(/bin/pwd)/src/googleapis/codegen/generate_library.py \
    --api_name=plus --api_version=v1 --output_dir=plus_lib
"""

__author__ = 'aiuto@google.com (Tony Aiuto)'

import collections
import json


import httplib2

from google.apputils import app
import gflags as flags
from googleapis.codegen import generator_lookup
from googleapis.codegen.filesystem_library_package import FilesystemLibraryPackage
from googleapis.codegen.tar_library_package import TarLibraryPackage
from googleapis.codegen.targets import Targets
from googleapis.codegen.zip_library_package import ZipLibraryPackage

FLAGS = flags.FLAGS


flags.DEFINE_string(
    'api_name',
    None,
    'API to generate for.  E.g. "plus".')
flags.DEFINE_string(
    'api_version',
    None,
    'version of "api_name" to generate for.  E.g. "v1".')
flags.DEFINE_string(
    'discovery_server',
    'www.googleapis.com',
    'The discovery server to use for loading "api_name"')
flags.DEFINE_string(
    'discovery_version',
    'v1',
    'The discovery version to use for loading "api_name"')
flags.DEFINE_boolean(
    'include_timestamp',
    False,
    'Adds a timestamp to the generated source files.')
flags.DEFINE_string(
    'input',
    None,
    'A discovery document captured from a discovery service.')
flags.DEFINE_enum(
    'language',
    'java',
    generator_lookup.SupportedLanguages(),
    'Target language for the generated library')
flags.DEFINE_string(
    'language_variant',
    'default',
    'which variant of "language" to generate for. E.g. "stable" vs. "head".')
flags.DEFINE_string(
    'output_dir',
    None,
    'A path to a directory where the generated files will be created.')
flags.DEFINE_string(
    'output_file',
    None,
    'An output file path to contain the archive for the generated library.'
    ' The contents of the file are determined by the output_format parameter')
flags.DEFINE_enum(
    'output_format',
    'zip',
    ['zip', 'tgz', 'tar'],
    'What format to use for --output_file.')
flags.DEFINE_enum(
    'output_type',
    'plain',
    ['plain', 'full'],
    'What kind of output to make.'
    ' plain=just the source,'
    ' full=turn on all the optional parts (useful for testing the generator).'
    )
flags.DEFINE_string(
    'package_path',
    None,
    'Use an alternate path for the generated code. This must be a file path'
    ' using "/" as a separator, not "."'
    )
flags.DEFINE_bool('version_package', False, 'Put API version in package paths')

flags.DECLARE_key_flag('api_name')
flags.DECLARE_key_flag('api_version')
flags.DECLARE_key_flag('discovery_server')
flags.DECLARE_key_flag('discovery_version')
flags.DECLARE_key_flag('include_timestamp')
flags.DECLARE_key_flag('input')
flags.DECLARE_key_flag('language')
flags.DECLARE_key_flag('language_variant')
flags.DECLARE_key_flag('output_dir')
flags.DECLARE_key_flag('output_file')
flags.DECLARE_key_flag('output_format')
flags.DECLARE_key_flag('output_type')
flags.DECLARE_key_flag('package_path')
flags.DECLARE_key_flag('version_package')


def main(unused_argv):
  if not (FLAGS.api_name or FLAGS.input):
    raise app.UsageError('You must specify one of --api_name or --input')
  if not (FLAGS.output_dir or FLAGS.output_file):
    raise app.UsageError(
        'You must specify one of --output_dir or --output_file')
  if FLAGS.output_dir and FLAGS.output_file:
    raise app.UsageError(
        'You can only specify one of --output_dir or --output_file')

  # Get the discovery document
  if FLAGS.api_name:
    if not FLAGS.api_version:
      raise app.UsageError('You must specify --api_version with --api_name')
    content = GetApiDiscovery(FLAGS.api_name, FLAGS.api_version)
  else:
    f = open(FLAGS.input)
    content = f.read()
    f.close()
  discovery_doc = json.loads(content, object_pairs_hook=collections.OrderedDict)

  package_writer = GetPackageWriter(FLAGS.output_dir, FLAGS.output_file)

  Generate(discovery_doc=discovery_doc,
           package_writer=package_writer,
           include_timestamp=FLAGS.include_timestamp,
           version_package=FLAGS.version_package,
           package_path=FLAGS.package_path,
           output_type=FLAGS.output_type,
           language=FLAGS.language,
           language_variant=FLAGS.language_variant)
  return 0


def Generate(discovery_doc, package_writer,
             include_timestamp=False,
             version_package=False,
             package_path=None,
             output_type='plain',
             language='java',
             language_variant='default',
             callback=None):
  """Generate a library package from discovery and options."""
  options = {
      # Include other files needed to compile (e.g. base jar files)
      'include_dependencies': False,
      # Include the timestamp in the generated library
      'include_timestamp': include_timestamp,
      # Put API version in the package
      'version_package': version_package,
      # Custom package name
      'package_path': package_path,
      }
  if output_type == 'full':
    options['include_dependencies'] = True

  # determine language version from language variant.
  language_variations = Targets().VariationsForLanguage(language)
  features = language_variations.GetFeatures(language_variant)
  if not features:
    raise app.UsageError('Unsupported language variant: '
                         '%s/%s/features.json is missing' %
                         language, language_variant)
  try:
    generator_class = generator_lookup.GetGeneratorByLanguage(
        features.get('generator', language))
  except ValueError:
    raise app.UsageError('Unsupported language: %s' % language)

  generator = generator_class(discovery_doc, options=options)
  generator.SetTemplateDir(features.template_dir)
  generator.SetFeatures(features)
  generator.GeneratePackage(package_writer)
  package_writer.DoneWritingArchive()
  if callback:
    callback(discovery_doc=discovery_doc,
             package_writer=package_writer,
             include_timestamp=include_timestamp,
             version_package=version_package,
             package_path=package_path,
             output_type=output_type,
             language=language,
             language_variant=language_variant)


def GetPackageWriter(output_dir=None, output_file=None, output_format=None):
  """Get an output writer for a package."""
  if output_dir is None:
    output_dir = FLAGS.output_dir
  if output_file is None:
    output_file = FLAGS.output_file
  if output_format is None:
    output_format = FLAGS.output_format

  if output_dir:
    package_writer = FilesystemLibraryPackage(output_dir)
  else:
    out = open(output_file, 'w')
    if output_format == 'tgz':
      package_writer = TarLibraryPackage(out)
    elif output_format == 'tar':
      package_writer = TarLibraryPackage(out, compress=False)
    else:
      package_writer = ZipLibraryPackage(out)
  return package_writer


def GetApiDiscovery(api_name, api_version):
  """Get a discovery doc from the discovery server."""
  api_path = 'apis/%s/%s/rest' % (api_name, api_version)

  discovery_url = 'https://%s/discovery/%s/%s' % (
      FLAGS.discovery_server, FLAGS.discovery_version, api_path)
  http = httplib2.Http()
  _, content = http.request(discovery_url)
  discovery_doc = json.loads(content)
  error = discovery_doc.get('error')
  if error:
    raise app.Error(error)
  return content


if __name__ == '__main__':
  app.run()
