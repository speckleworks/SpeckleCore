using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO.Compression;
using System.IO;
using System.Text;

namespace SpeckleCore
{

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "11.3.3.0")]
    public partial class SpeckleApiClient
    {
        private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;
        private string _baseUrl = "http://localhost:8080/api";
        private string _authToken = "";
        private bool _UseGzip = true;

        public SpeckleApiClient(bool useGzip = true)
        {
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(() =>
            {
                var settings = new Newtonsoft.Json.JsonSerializerSettings();
                UpdateJsonSerializerSettings(settings);
                return settings;
            });
            UseGzip = useGzip;
        }

        public bool UseGzip
        {
            get { return _UseGzip; }
            set { _UseGzip = value; }
        }

        public string BaseUrl
        {
            get { return _baseUrl; }
            set { _baseUrl = value; }
        }

        public string AuthToken
        {
            get { return _authToken; }
            set { _authToken = value; }
        }

        partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);

        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url);

        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder);

        partial void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response);

        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
        {
            if (AuthToken != "")
                request.Headers.Add("Authorization", AuthToken);

            if (UseGzip && request.Method != HttpMethod.Get)
                request.Content = new GzipContent(request.Content);
        }

        private HttpClient GetHttpClient()
        {
            var handler = new HttpClientHandler();
            handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip;
            return new HttpClient(handler, true);
        }
    }
}
