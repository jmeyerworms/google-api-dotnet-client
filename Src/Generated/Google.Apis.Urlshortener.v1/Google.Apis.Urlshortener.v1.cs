// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
// the License. You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
// an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
// specific language governing permissions and limitations under the License.

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by google-apis-code-generator 1.5.1
//     C# generator version: 1.36.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

/**
 * \brief
 *   URL Shortener API Version v1
 *
 * \section ApiInfo API Version Information
 *    <table>
 *      <tr><th>API
 *          <td><a href='https://developers.google.com/url-shortener/v1/getting_started'>URL Shortener API</a>
 *      <tr><th>API Version<td>v1
 *      <tr><th>API Rev<td>20150519 (138)
 *      <tr><th>API Docs
 *          <td><a href='https://developers.google.com/url-shortener/v1/getting_started'>
 *              https://developers.google.com/url-shortener/v1/getting_started</a>
 *      <tr><th>Discovery Name<td>urlshortener
 *    </table>
 *
 * \section ForMoreInfo For More Information
 *
 * The complete API documentation for using URL Shortener API can be found at
 * <a href='https://developers.google.com/url-shortener/v1/getting_started'>https://developers.google.com/url-shortener/v1/getting_started</a>.
 *
 * For more information about the Google APIs Client Library for .NET, see
 * <a href='https://developers.google.com/api-client-library/dotnet/get_started'>
 * https://developers.google.com/api-client-library/dotnet/get_started</a>
 */

namespace Google.Apis.Urlshortener.v1
{
    /// <summary>The Urlshortener Service.</summary>
    public class UrlshortenerService : Google.Apis.Services.BaseClientService
    {
        /// <summary>The API version.</summary>
        public const string Version = "v1";

        /// <summary>The discovery version used to generate this service.</summary>
        public static Google.Apis.Discovery.DiscoveryVersion DiscoveryVersionUsed =
            Google.Apis.Discovery.DiscoveryVersion.Version_1_0;

        /// <summary>Constructs a new service.</summary>
        public UrlshortenerService() :
            this(new Google.Apis.Services.BaseClientService.Initializer()) {}

        /// <summary>Constructs a new service.</summary>
        /// <param name="initializer">The service initializer.</param>
        public UrlshortenerService(Google.Apis.Services.BaseClientService.Initializer initializer)
            : base(initializer)
        {
            url = new UrlResource(this);
        }

        /// <summary>Gets the service supported features.</summary>
        public override System.Collections.Generic.IList<string> Features
        {
            get { return new string[0]; }
        }

        /// <summary>Gets the service name.</summary>
        public override string Name
        {
            get { return "urlshortener"; }
        }

        /// <summary>Gets the service base URI.</summary>
        public override string BaseUri
        {
            get { return "https://www.googleapis.com/urlshortener/v1/"; }
        }

        /// <summary>Gets the service base path.</summary>
        public override string BasePath
        {
            get { return "urlshortener/v1/"; }
        }

        #if !NET40
        /// <summary>Gets the batch base URI; <c>null</c> if unspecified.</summary>
        public override string BatchUri
        {
            get { return "https://www.googleapis.com/batch/urlshortener/v1"; }
        }

        /// <summary>Gets the batch base path; <c>null</c> if unspecified.</summary>
        public override string BatchPath
        {
            get { return "batch/urlshortener/v1"; }
        }
        #endif

        /// <summary>Available OAuth 2.0 scopes for use with the URL Shortener API.</summary>
        public class Scope
        {
            /// <summary>Manage your goo.gl short URLs</summary>
            public static string Urlshortener = "https://www.googleapis.com/auth/urlshortener";

        }



        private readonly UrlResource url;

        /// <summary>Gets the Url resource.</summary>
        public virtual UrlResource Url
        {
            get { return url; }
        }
    }

    ///<summary>A base abstract class for Urlshortener requests.</summary>
    public abstract class UrlshortenerBaseServiceRequest<TResponse> : Google.Apis.Requests.ClientServiceRequest<TResponse>
    {
        ///<summary>Constructs a new UrlshortenerBaseServiceRequest instance.</summary>
        protected UrlshortenerBaseServiceRequest(Google.Apis.Services.IClientService service)
            : base(service)
        {
        }

        /// <summary>Data format for the response.</summary>
        /// [default: json]
        [Google.Apis.Util.RequestParameterAttribute("alt", Google.Apis.Util.RequestParameterType.Query)]
        public virtual System.Nullable<AltEnum> Alt { get; set; }

        /// <summary>Data format for the response.</summary>
        public enum AltEnum
        {
            /// <summary>Responses with Content-Type of application/json</summary>
            [Google.Apis.Util.StringValueAttribute("json")]
            Json,
        }

        /// <summary>Selector specifying which fields to include in a partial response.</summary>
        [Google.Apis.Util.RequestParameterAttribute("fields", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string Fields { get; set; }

        /// <summary>API key. Your API key identifies your project and provides you with API access, quota, and reports.
        /// Required unless you provide an OAuth 2.0 token.</summary>
        [Google.Apis.Util.RequestParameterAttribute("key", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string Key { get; set; }

        /// <summary>OAuth 2.0 token for the current user.</summary>
        [Google.Apis.Util.RequestParameterAttribute("oauth_token", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string OauthToken { get; set; }

        /// <summary>Returns response with indentations and line breaks.</summary>
        /// [default: true]
        [Google.Apis.Util.RequestParameterAttribute("prettyPrint", Google.Apis.Util.RequestParameterType.Query)]
        public virtual System.Nullable<bool> PrettyPrint { get; set; }

        /// <summary>An opaque string that represents a user for quota purposes. Must not exceed 40
        /// characters.</summary>
        [Google.Apis.Util.RequestParameterAttribute("quotaUser", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string QuotaUser { get; set; }

        /// <summary>Deprecated. Please use quotaUser instead.</summary>
        [Google.Apis.Util.RequestParameterAttribute("userIp", Google.Apis.Util.RequestParameterType.Query)]
        public virtual string UserIp { get; set; }

        /// <summary>Initializes Urlshortener parameter list.</summary>
        protected override void InitParameters()
        {
            base.InitParameters();

            RequestParameters.Add(
                "alt", new Google.Apis.Discovery.Parameter
                {
                    Name = "alt",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = "json",
                    Pattern = null,
                });
            RequestParameters.Add(
                "fields", new Google.Apis.Discovery.Parameter
                {
                    Name = "fields",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            RequestParameters.Add(
                "key", new Google.Apis.Discovery.Parameter
                {
                    Name = "key",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            RequestParameters.Add(
                "oauth_token", new Google.Apis.Discovery.Parameter
                {
                    Name = "oauth_token",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            RequestParameters.Add(
                "prettyPrint", new Google.Apis.Discovery.Parameter
                {
                    Name = "prettyPrint",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = "true",
                    Pattern = null,
                });
            RequestParameters.Add(
                "quotaUser", new Google.Apis.Discovery.Parameter
                {
                    Name = "quotaUser",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
            RequestParameters.Add(
                "userIp", new Google.Apis.Discovery.Parameter
                {
                    Name = "userIp",
                    IsRequired = false,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null,
                });
        }
    }

    /// <summary>The "url" collection of methods.</summary>
    public class UrlResource
    {
        private const string Resource = "url";

        /// <summary>The service which this resource belongs to.</summary>
        private readonly Google.Apis.Services.IClientService service;

        /// <summary>Constructs a new resource.</summary>
        public UrlResource(Google.Apis.Services.IClientService service)
        {
            this.service = service;

        }


        /// <summary>Expands a short URL or gets creation time and analytics.</summary>
        /// <param name="shortUrl">The short URL, including the protocol.</param>
        public virtual GetRequest Get(string shortUrl)
        {
            return new GetRequest(service, shortUrl);
        }

        /// <summary>Expands a short URL or gets creation time and analytics.</summary>
        public class GetRequest : UrlshortenerBaseServiceRequest<Google.Apis.Urlshortener.v1.Data.Url>
        {
            /// <summary>Constructs a new Get request.</summary>
            public GetRequest(Google.Apis.Services.IClientService service, string shortUrl)
                : base(service)
            {
                ShortUrl = shortUrl;
                InitParameters();
            }


            /// <summary>The short URL, including the protocol.</summary>
            [Google.Apis.Util.RequestParameterAttribute("shortUrl", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string ShortUrl { get; private set; }

            /// <summary>Additional information to return.</summary>
            [Google.Apis.Util.RequestParameterAttribute("projection", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<ProjectionEnum> Projection { get; set; }

            /// <summary>Additional information to return.</summary>
            public enum ProjectionEnum
            {
                /// <summary>Returns only click counts.</summary>
                [Google.Apis.Util.StringValueAttribute("ANALYTICS_CLICKS")]
                ANALYTICSCLICKS,
                /// <summary>Returns only top string counts.</summary>
                [Google.Apis.Util.StringValueAttribute("ANALYTICS_TOP_STRINGS")]
                ANALYTICSTOPSTRINGS,
                /// <summary>Returns the creation timestamp and all available analytics.</summary>
                [Google.Apis.Util.StringValueAttribute("FULL")]
                FULL,
            }


            ///<summary>Gets the method name.</summary>
            public override string MethodName
            {
                get { return "get"; }
            }

            ///<summary>Gets the HTTP method.</summary>
            public override string HttpMethod
            {
                get { return "GET"; }
            }

            ///<summary>Gets the REST path.</summary>
            public override string RestPath
            {
                get { return "url"; }
            }

            /// <summary>Initializes Get parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add(
                    "shortUrl", new Google.Apis.Discovery.Parameter
                    {
                        Name = "shortUrl",
                        IsRequired = true,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                RequestParameters.Add(
                    "projection", new Google.Apis.Discovery.Parameter
                    {
                        Name = "projection",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
            }

        }

        /// <summary>Creates a new short URL.</summary>
        /// <param name="body">The body of the request.</param>
        public virtual InsertRequest Insert(Google.Apis.Urlshortener.v1.Data.Url body)
        {
            return new InsertRequest(service, body);
        }

        /// <summary>Creates a new short URL.</summary>
        public class InsertRequest : UrlshortenerBaseServiceRequest<Google.Apis.Urlshortener.v1.Data.Url>
        {
            /// <summary>Constructs a new Insert request.</summary>
            public InsertRequest(Google.Apis.Services.IClientService service, Google.Apis.Urlshortener.v1.Data.Url body)
                : base(service)
            {
                Body = body;
                InitParameters();
            }



            /// <summary>Gets or sets the body of this request.</summary>
            Google.Apis.Urlshortener.v1.Data.Url Body { get; set; }

            ///<summary>Returns the body of the request.</summary>
            protected override object GetBody() { return Body; }

            ///<summary>Gets the method name.</summary>
            public override string MethodName
            {
                get { return "insert"; }
            }

            ///<summary>Gets the HTTP method.</summary>
            public override string HttpMethod
            {
                get { return "POST"; }
            }

            ///<summary>Gets the REST path.</summary>
            public override string RestPath
            {
                get { return "url"; }
            }

            /// <summary>Initializes Insert parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

            }

        }

        /// <summary>Retrieves a list of URLs shortened by a user.</summary>
        public virtual ListRequest List()
        {
            return new ListRequest(service);
        }

        /// <summary>Retrieves a list of URLs shortened by a user.</summary>
        public class ListRequest : UrlshortenerBaseServiceRequest<Google.Apis.Urlshortener.v1.Data.UrlHistory>
        {
            /// <summary>Constructs a new List request.</summary>
            public ListRequest(Google.Apis.Services.IClientService service)
                : base(service)
            {
                InitParameters();
            }


            /// <summary>Additional information to return.</summary>
            [Google.Apis.Util.RequestParameterAttribute("projection", Google.Apis.Util.RequestParameterType.Query)]
            public virtual System.Nullable<ProjectionEnum> Projection { get; set; }

            /// <summary>Additional information to return.</summary>
            public enum ProjectionEnum
            {
                /// <summary>Returns short URL click counts.</summary>
                [Google.Apis.Util.StringValueAttribute("ANALYTICS_CLICKS")]
                ANALYTICSCLICKS,
                /// <summary>Returns short URL click counts.</summary>
                [Google.Apis.Util.StringValueAttribute("FULL")]
                FULL,
            }

            /// <summary>Token for requesting successive pages of results.</summary>
            [Google.Apis.Util.RequestParameterAttribute("start-token", Google.Apis.Util.RequestParameterType.Query)]
            public virtual string StartToken { get; set; }


            ///<summary>Gets the method name.</summary>
            public override string MethodName
            {
                get { return "list"; }
            }

            ///<summary>Gets the HTTP method.</summary>
            public override string HttpMethod
            {
                get { return "GET"; }
            }

            ///<summary>Gets the REST path.</summary>
            public override string RestPath
            {
                get { return "url/history"; }
            }

            /// <summary>Initializes List parameter list.</summary>
            protected override void InitParameters()
            {
                base.InitParameters();

                RequestParameters.Add(
                    "projection", new Google.Apis.Discovery.Parameter
                    {
                        Name = "projection",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
                RequestParameters.Add(
                    "start-token", new Google.Apis.Discovery.Parameter
                    {
                        Name = "start-token",
                        IsRequired = false,
                        ParameterType = "query",
                        DefaultValue = null,
                        Pattern = null,
                    });
            }

        }
    }
}

namespace Google.Apis.Urlshortener.v1.Data
{    

    public class AnalyticsSnapshot : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>Top browsers, e.g. "Chrome"; sorted by (descending) click counts. Only present if this data is
        /// available.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("browsers")]
        public virtual System.Collections.Generic.IList<StringCount> Browsers { get; set; } 

        /// <summary>Top countries (expressed as country codes), e.g. "US" or "DE"; sorted by (descending) click counts.
        /// Only present if this data is available.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("countries")]
        public virtual System.Collections.Generic.IList<StringCount> Countries { get; set; } 

        /// <summary>Number of clicks on all goo.gl short URLs pointing to this long URL.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("longUrlClicks")]
        public virtual System.Nullable<long> LongUrlClicks { get; set; } 

        /// <summary>Top platforms or OSes, e.g. "Windows"; sorted by (descending) click counts. Only present if this
        /// data is available.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("platforms")]
        public virtual System.Collections.Generic.IList<StringCount> Platforms { get; set; } 

        /// <summary>Top referring hosts, e.g. "www.google.com"; sorted by (descending) click counts. Only present if
        /// this data is available.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("referrers")]
        public virtual System.Collections.Generic.IList<StringCount> Referrers { get; set; } 

        /// <summary>Number of clicks on this short URL.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("shortUrlClicks")]
        public virtual System.Nullable<long> ShortUrlClicks { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    public class AnalyticsSummary : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>Click analytics over all time.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("allTime")]
        public virtual AnalyticsSnapshot AllTime { get; set; } 

        /// <summary>Click analytics over the last day.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("day")]
        public virtual AnalyticsSnapshot Day { get; set; } 

        /// <summary>Click analytics over the last month.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("month")]
        public virtual AnalyticsSnapshot Month { get; set; } 

        /// <summary>Click analytics over the last two hours.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("twoHours")]
        public virtual AnalyticsSnapshot TwoHours { get; set; } 

        /// <summary>Click analytics over the last week.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("week")]
        public virtual AnalyticsSnapshot Week { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    public class StringCount : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>Number of clicks for this top entry, e.g. for this particular country or browser.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("count")]
        public virtual System.Nullable<long> Count { get; set; } 

        /// <summary>Label assigned to this top entry, e.g. "US" or "Chrome".</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    public class Url : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>A summary of the click analytics for the short and long URL. Might not be present if not requested
        /// or currently unavailable.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("analytics")]
        public virtual AnalyticsSummary Analytics { get; set; } 

        /// <summary>Time the short URL was created; ISO 8601 representation using the yyyy-MM-dd'T'HH:mm:ss.SSSZZ
        /// format, e.g. "2010-10-14T19:01:24.944+00:00".</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("created")]
        public virtual string Created { get; set; } 

        /// <summary>Short URL, e.g. "http://goo.gl/l6MS".</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public virtual string Id { get; set; } 

        /// <summary>The fixed string "urlshortener#url".</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>Long URL, e.g. "http://www.google.com/". Might not be present if the status is "REMOVED".</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("longUrl")]
        public virtual string LongUrl { get; set; } 

        /// <summary>Status of the target URL. Possible values: "OK", "MALWARE", "PHISHING", or "REMOVED". A URL might
        /// be marked "REMOVED" if it was flagged as spam, for example.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("status")]
        public virtual string Status { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }    

    public class UrlHistory : Google.Apis.Requests.IDirectResponseSchema
    {
        /// <summary>A list of URL resources.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("items")]
        public virtual System.Collections.Generic.IList<Url> Items { get; set; } 

        /// <summary>Number of items returned with each full "page" of results. Note that the last page could have fewer
        /// items than the "itemsPerPage" value.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("itemsPerPage")]
        public virtual System.Nullable<int> ItemsPerPage { get; set; } 

        /// <summary>The fixed string "urlshortener#urlHistory".</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("kind")]
        public virtual string Kind { get; set; } 

        /// <summary>A token to provide to get the next page of results.</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("nextPageToken")]
        public virtual string NextPageToken { get; set; } 

        /// <summary>Total number of short URLs associated with this user (may be approximate).</summary>
        [Newtonsoft.Json.JsonPropertyAttribute("totalItems")]
        public virtual System.Nullable<int> TotalItems { get; set; } 

        /// <summary>The ETag of the item.</summary>
        public virtual string ETag { get; set; }
    }
}
