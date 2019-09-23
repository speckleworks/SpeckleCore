using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO.Compression;
using System.IO;
using System.Text;


namespace SpeckleCore
{
  [System.CodeDom.Compiler.GeneratedCode( "NSwag", "11.3.3.0" )]
  public partial class SpeckleApiClient
  {
    private System.Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

    partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings );

    partial void PrepareRequest( System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url );

    partial void PrepareRequest( System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder );

    partial void ProcessResponse( System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response );

    partial void ProcessResponse( HttpClient client, HttpResponseMessage response )
    {

    }

    partial void PrepareRequest( HttpClient client, HttpRequestMessage request, string url )
    {
      // Try and attach the auth token if present
      if ( AuthToken != "" && AuthToken != null )
        request.Headers.Add( "Authorization", AuthToken );

      // Let the server know about our aspiration to accept gzipped content.
      request.Headers.Add( "Accept-Encoding", "gzip" );

      // If actually sending a payload, deflate it.
      if ( UseGzip && request.Method != HttpMethod.Get )
        request.Content = new GzipContent( request.Content );
    }

    private HttpClient GetHttpClient(double timeoutMillisecondsOverride = 0)
    {
      var handler = new HttpClientHandler
      {
        AutomaticDecompression = System.Net.DecompressionMethods.GZip
      };
      return new HttpClient(handler, true)
      {
        Timeout = TimeSpan.FromMilliseconds(timeoutMillisecondsOverride == 0 ? defaultTimeoutMilliseconds : timeoutMillisecondsOverride)
      };
    }
  }
}
