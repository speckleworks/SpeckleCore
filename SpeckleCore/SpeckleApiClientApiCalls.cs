using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeckleCore
{
  public partial class SpeckleApiClient
  {
    /// <summary>UserRegister</summary>
    /// <returns>New user successfully registered.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseUser> UserRegisterAsync( User body )
    {
      return UserRegisterAsync( body, System.Threading.CancellationToken.None );
    }

    /// <summary>UserRegister</summary>
    /// <returns>New user successfully registered.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseUser> UserRegisterAsync( User body, System.Threading.CancellationToken cancellationToken )
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/accounts/register" );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          var content_ = new System.Net.Http.StringContent( Newtonsoft.Json.JsonConvert.SerializeObject( body, _settings.Value ) );
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse( "application/json" );
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod( "POST" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseUser );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseUser>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Failed to register a new user.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseUser );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>UserLogin</summary>
    /// <param name="body">The only required elements are email and password.</param>
    /// <returns>You've logged in.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseUser> UserLoginAsync( User body )
    {
      return UserLoginAsync( body, System.Threading.CancellationToken.None );
    }

    /// <summary>UserLogin</summary>
    /// <param name="body">The only required elements are email and password.</param>
    /// <returns>You've logged in.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseUser> UserLoginAsync( User body, System.Threading.CancellationToken cancellationToken )
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/accounts/login" );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          var content_ = new System.Net.Http.StringContent( Newtonsoft.Json.JsonConvert.SerializeObject( body, _settings.Value ) );
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse( "application/json" );
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod( "POST" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseUser );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseUser>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseUser );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>UserSearch</summary>
    /// <returns>New user successfully registered.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseUser> UserSearchAsync( User user )
    {
      return UserSearchAsync( user, System.Threading.CancellationToken.None );
    }

    /// <summary>UserSearch</summary>
    /// <returns>New user successfully registered.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseUser> UserSearchAsync( User user, System.Threading.CancellationToken cancellationToken )
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/accounts/search" );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          var content_ = new System.Net.Http.StringContent( Newtonsoft.Json.JsonConvert.SerializeObject( user, _settings.Value ) );
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse( "application/json" );
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod( "POST" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseUser );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseUser>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseUser );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>UserGet</summary>
    /// <returns>New user successfully registered.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseUser> UserGetAsync( )
    {
      return UserGetAsync( System.Threading.CancellationToken.None );
    }

    /// <summary>UserGet</summary>
    /// <returns>New user successfully registered.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseUser> UserGetAsync( System.Threading.CancellationToken cancellationToken )
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/accounts" );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "GET" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseUser );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseUser>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseUser );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>UserUpdateProfile</summary>
    /// <returns>Things are looking good yo.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseBase> UserUpdateProfileAsync( User user )
    {
      return UserUpdateProfileAsync( user, System.Threading.CancellationToken.None );
    }

    /// <summary>UserUpdateProfile</summary>
    /// <returns>Things are looking good yo.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseBase> UserUpdateProfileAsync( User user, System.Threading.CancellationToken cancellationToken )
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/accounts" );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          var content_ = new System.Net.Http.StringContent( Newtonsoft.Json.JsonConvert.SerializeObject( user, _settings.Value ) );
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse( "application/json" );
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod( "PUT" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseBase );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>UserGetProfileById</summary>
    /// <returns>New user successfully registered.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseUser> UserGetProfileByIdAsync( string userId )
    {
      return UserGetProfileByIdAsync( userId, System.Threading.CancellationToken.None );
    }

    /// <summary>UserGetProfileById</summary>
    /// <returns>New user successfully registered.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseUser> UserGetProfileByIdAsync( string userId, System.Threading.CancellationToken cancellationToken )
    {
      if ( userId == null )
        throw new System.ArgumentNullException( "userId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/accounts/{userId}" );
      urlBuilder_.Replace( "{userId}", System.Uri.EscapeDataString( ConvertToString( userId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "GET" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseUser );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseUser>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseUser );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>ClientGetAll</summary>
    /// <returns>All the users's clients.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseClient> ClientGetAllAsync( )
    {
      return ClientGetAllAsync( System.Threading.CancellationToken.None );
    }

    /// <summary>ClientGetAll</summary>
    /// <returns>All the users's clients.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseClient> ClientGetAllAsync( System.Threading.CancellationToken cancellationToken )
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/clients" );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "GET" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseClient );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseClient>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseClient );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>ClientCreate</summary>
    /// <returns>All the users's clients.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseClient> ClientCreateAsync( AppClient client )
    {
      return ClientCreateAsync( client, System.Threading.CancellationToken.None );
    }

    /// <summary>ClientCreate</summary>
    /// <returns>All the users's clients.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseClient> ClientCreateAsync( AppClient client, System.Threading.CancellationToken cancellationToken )
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/clients" );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          var content_ = new System.Net.Http.StringContent( Newtonsoft.Json.JsonConvert.SerializeObject( client, _settings.Value ) );
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse( "application/json" );
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod( "POST" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseClient );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseClient>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseClient );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>ClientUpdate</summary>
    /// <returns>All the users's clients.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseClient> ClientUpdateAsync( string clientId, AppClient client )
    {
      return ClientUpdateAsync( clientId, client, System.Threading.CancellationToken.None );
    }

    /// <summary>ClientUpdate</summary>
    /// <returns>All the users's clients.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseClient> ClientUpdateAsync( string clientId, AppClient client, System.Threading.CancellationToken cancellationToken )
    {
      if ( clientId == null )
        throw new System.ArgumentNullException( "clientId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/clients/{clientId}" );
      urlBuilder_.Replace( "{clientId}", System.Uri.EscapeDataString( ConvertToString( clientId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          var content_ = new System.Net.Http.StringContent( Newtonsoft.Json.JsonConvert.SerializeObject( client, _settings.Value ) );
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse( "application/json" );
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod( "PUT" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseClient );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseClient>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseClient );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>ClientGet</summary>
    /// <returns>The client.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseClient> ClientGetAsync( string clientId )
    {
      return ClientGetAsync( clientId, System.Threading.CancellationToken.None );
    }

    /// <summary>ClientGet</summary>
    /// <returns>The client.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseClient> ClientGetAsync( string clientId, System.Threading.CancellationToken cancellationToken )
    {
      if ( clientId == null )
        throw new System.ArgumentNullException( "clientId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/clients/{clientId}" );
      urlBuilder_.Replace( "{clientId}", System.Uri.EscapeDataString( ConvertToString( clientId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "GET" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseClient );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseClient>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseClient );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>ClientDelete</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseBase> ClientDeleteAsync( string clientId )
    {
      return ClientDeleteAsync( clientId, System.Threading.CancellationToken.None );
    }

    /// <summary>ClientDelete</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseBase> ClientDeleteAsync( string clientId, System.Threading.CancellationToken cancellationToken )
    {
      if ( clientId == null )
        throw new System.ArgumentNullException( "clientId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/clients/{clientId}" );
      urlBuilder_.Replace( "{clientId}", System.Uri.EscapeDataString( ConvertToString( clientId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "DELETE" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseBase );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>ProjectGetAll</summary>
    /// <returns>All the users's projects.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseProject> ProjectGetAllAsync( )
    {
      return ProjectGetAllAsync( System.Threading.CancellationToken.None );
    }

    /// <summary>ProjectGetAll</summary>
    /// <returns>All the users's projects.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseProject> ProjectGetAllAsync( System.Threading.CancellationToken cancellationToken )
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/projects" );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "GET" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseProject );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseProject>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseProject );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>ProjectCreate</summary>
    /// <returns>All the users's clients.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseProject> ProjectCreateAsync( Project project )
    {
      return ProjectCreateAsync( project, System.Threading.CancellationToken.None );
    }

    /// <summary>ProjectCreate</summary>
    /// <returns>All the users's clients.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseProject> ProjectCreateAsync( Project project, System.Threading.CancellationToken cancellationToken )
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/projects" );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          var content_ = new System.Net.Http.StringContent( Newtonsoft.Json.JsonConvert.SerializeObject( project, _settings.Value ) );
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse( "application/json" );
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod( "POST" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseProject );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseProject>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseProject );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>ProjectUpdate</summary>
    /// <returns>All the users's projects.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseProject> ProjectUpdateAsync( string projectId, Project project )
    {
      return ProjectUpdateAsync( projectId, project, System.Threading.CancellationToken.None );
    }

    /// <summary>ProjectUpdate</summary>
    /// <returns>All the users's projects.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseProject> ProjectUpdateAsync( string projectId, Project project, System.Threading.CancellationToken cancellationToken )
    {
      if ( projectId == null )
        throw new System.ArgumentNullException( "projectId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/projects/{projectId}" );
      urlBuilder_.Replace( "{projectId}", System.Uri.EscapeDataString( ConvertToString( projectId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          var content_ = new System.Net.Http.StringContent( Newtonsoft.Json.JsonConvert.SerializeObject( project, _settings.Value ) );
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse( "application/json" );
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod( "PUT" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseProject );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseProject>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseProject );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>ProjectGet</summary>
    /// <returns>The client.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseProject> ProjectGetAsync( string projectId )
    {
      return ProjectGetAsync( projectId, System.Threading.CancellationToken.None );
    }

    /// <summary>ProjectGet</summary>
    /// <returns>The client.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseProject> ProjectGetAsync( string projectId, System.Threading.CancellationToken cancellationToken )
    {
      if ( projectId == null )
        throw new System.ArgumentNullException( "projectId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/projects/{projectId}" );
      urlBuilder_.Replace( "{projectId}", System.Uri.EscapeDataString( ConvertToString( projectId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "GET" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseProject );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseProject>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseProject );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>ProjectDelete</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseBase> ProjectDeleteAsync( string projectId )
    {
      return ProjectDeleteAsync( projectId, System.Threading.CancellationToken.None );
    }

    /// <summary>ProjectDelete</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseBase> ProjectDeleteAsync( string projectId, System.Threading.CancellationToken cancellationToken )
    {
      if ( projectId == null )
        throw new System.ArgumentNullException( "projectId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/projects/{projectId}" );
      urlBuilder_.Replace( "{projectId}", System.Uri.EscapeDataString( ConvertToString( projectId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "DELETE" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseBase );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>CommentCreate</summary>
    /// <param name="resourceType">The resource type you want to comment on.</param>
    /// <param name="resourceId">The resource id you want to comment on. In the case of streams, it must be a streamId.</param>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseComment> CommentCreateAsync( ResourceType resourceType, string resourceId, Comment comment )
    {
      return CommentCreateAsync( resourceType, resourceId, comment, System.Threading.CancellationToken.None );
    }

    /// <summary>CommentCreate</summary>
    /// <param name="resourceType">The resource type you want to comment on.</param>
    /// <param name="resourceId">The resource id you want to comment on. In the case of streams, it must be a streamId.</param>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseComment> CommentCreateAsync( ResourceType resourceType, string resourceId, Comment comment, System.Threading.CancellationToken cancellationToken )
    {
      if ( resourceType == null )
        throw new System.ArgumentNullException( "resourceType" );

      if ( resourceId == null )
        throw new System.ArgumentNullException( "resourceId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/comments/{resourceType}/{resourceId}" );
      urlBuilder_.Replace( "{resourceType}", System.Uri.EscapeDataString( ConvertToString( resourceType, System.Globalization.CultureInfo.InvariantCulture ) ) );
      urlBuilder_.Replace( "{resourceId}", System.Uri.EscapeDataString( ConvertToString( resourceId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          var content_ = new System.Net.Http.StringContent( Newtonsoft.Json.JsonConvert.SerializeObject( comment, _settings.Value ) );
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse( "application/json" );
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod( "POST" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseComment );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseComment>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseComment );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>CommentGetFromResource</summary>
    /// <param name="resourceType">The resource type you want to comment on.</param>
    /// <param name="resourceId">The resource id you want to comment on. In the case of streams, it must be a streamId.</param>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseComment> CommentGetFromResourceAsync( ResourceType resourceType, string resourceId )
    {
      return CommentGetFromResourceAsync( resourceType, resourceId, System.Threading.CancellationToken.None );
    }

    /// <summary>CommentGetFromResource</summary>
    /// <param name="resourceType">The resource type you want to comment on.</param>
    /// <param name="resourceId">The resource id you want to comment on. In the case of streams, it must be a streamId.</param>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseComment> CommentGetFromResourceAsync( ResourceType resourceType, string resourceId, System.Threading.CancellationToken cancellationToken )
    {
      if ( resourceType == null )
        throw new System.ArgumentNullException( "resourceType" );

      if ( resourceId == null )
        throw new System.ArgumentNullException( "resourceId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/comments/{resourceType}/{resourceId}" );
      urlBuilder_.Replace( "{resourceType}", System.Uri.EscapeDataString( ConvertToString( resourceType, System.Globalization.CultureInfo.InvariantCulture ) ) );
      urlBuilder_.Replace( "{resourceId}", System.Uri.EscapeDataString( ConvertToString( resourceId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "GET" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseComment );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseComment>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseComment );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>CommentGet</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseComment> CommentGetAsync( string commentId )
    {
      return CommentGetAsync( commentId, System.Threading.CancellationToken.None );
    }

    /// <summary>CommentGet</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseComment> CommentGetAsync( string commentId, System.Threading.CancellationToken cancellationToken )
    {
      if ( commentId == null )
        throw new System.ArgumentNullException( "commentId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/comments/{commentId}" );
      urlBuilder_.Replace( "{commentId}", System.Uri.EscapeDataString( ConvertToString( commentId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "GET" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseComment );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseComment>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseComment );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>CommentUpdate</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseBase> CommentUpdateAsync( string commentId, Comment comment )
    {
      return CommentUpdateAsync( commentId, comment, System.Threading.CancellationToken.None );
    }

    /// <summary>CommentUpdate</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseBase> CommentUpdateAsync( string commentId, Comment comment, System.Threading.CancellationToken cancellationToken )
    {
      if ( commentId == null )
        throw new System.ArgumentNullException( "commentId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/comments/{commentId}" );
      urlBuilder_.Replace( "{commentId}", System.Uri.EscapeDataString( ConvertToString( commentId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          var content_ = new System.Net.Http.StringContent( Newtonsoft.Json.JsonConvert.SerializeObject( comment, _settings.Value ) );
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse( "application/json" );
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod( "PUT" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseBase );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>CommentDelete</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseBase> CommentDeleteAsync( string commentId )
    {
      return CommentDeleteAsync( commentId, System.Threading.CancellationToken.None );
    }

    /// <summary>CommentDelete</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseBase> CommentDeleteAsync( string commentId, System.Threading.CancellationToken cancellationToken )
    {
      if ( commentId == null )
        throw new System.ArgumentNullException( "commentId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/comments/{commentId}" );
      urlBuilder_.Replace( "{commentId}", System.Uri.EscapeDataString( ConvertToString( commentId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "DELETE" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseBase );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>StreamsGetAll</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseStream> StreamsGetAllAsync( )
    {
      return StreamsGetAllAsync( System.Threading.CancellationToken.None );
    }

    /// <summary>StreamsGetAll</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseStream> StreamsGetAllAsync( System.Threading.CancellationToken cancellationToken )
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/streams" );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "GET" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseStream );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseStream>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseStream );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>StreamCreate</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseStream> StreamCreateAsync( SpeckleStream stream )
    {
      return StreamCreateAsync( stream, System.Threading.CancellationToken.None );
    }

    /// <summary>StreamCreate</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseStream> StreamCreateAsync( SpeckleStream stream, System.Threading.CancellationToken cancellationToken )
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/streams" );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          var content_ = new System.Net.Http.StringContent( Newtonsoft.Json.JsonConvert.SerializeObject( stream, _settings.Value ) );
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse( "application/json" );
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod( "POST" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseStream );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseStream>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseStream );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>StreamGet</summary>
    /// <param name="query">Specifiy which fields to retrieve, ie `?fields=layers,baseProperties`.</param>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseStream> StreamGetAsync( string streamId, string query )
    {
      return StreamGetAsync( streamId, query, System.Threading.CancellationToken.None );
    }

    /// <summary>StreamGet</summary>
    /// <param name="query">Specifiy which fields to retrieve, ie `?fields=layers,baseProperties`.</param>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseStream> StreamGetAsync( string streamId, string query, System.Threading.CancellationToken cancellationToken )
    {
      if ( streamId == null )
        throw new System.ArgumentNullException( "streamId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/streams/{streamId}?" );
      urlBuilder_.Replace( "{streamId}", System.Uri.EscapeDataString( ConvertToString( streamId, System.Globalization.CultureInfo.InvariantCulture ) ) );
      if ( query != null ) urlBuilder_.Append( query );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "GET" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseStream );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseStream>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseStream );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>StreamUpdate</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseBase> StreamUpdateAsync( string streamId, SpeckleStream stream )
    {
      return StreamUpdateAsync( streamId, stream, System.Threading.CancellationToken.None );
    }

    /// <summary>StreamUpdate</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseBase> StreamUpdateAsync( string streamId, SpeckleStream stream, System.Threading.CancellationToken cancellationToken )
    {
      if ( streamId == null )
        throw new System.ArgumentNullException( "streamId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/streams/{streamId}" );
      urlBuilder_.Replace( "{streamId}", System.Uri.EscapeDataString( ConvertToString( streamId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          var content_ = new System.Net.Http.StringContent( Newtonsoft.Json.JsonConvert.SerializeObject( stream, _settings.Value ) );
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse( "application/json" );
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod( "PUT" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseBase );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>StreamDelete</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseBase> StreamDeleteAsync( string streamId )
    {
      return StreamDeleteAsync( streamId, System.Threading.CancellationToken.None );
    }

    /// <summary>StreamDelete</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseBase> StreamDeleteAsync( string streamId, System.Threading.CancellationToken cancellationToken )
    {
      if ( streamId == null )
        throw new System.ArgumentNullException( "streamId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/streams/{streamId}" );
      urlBuilder_.Replace( "{streamId}", System.Uri.EscapeDataString( ConvertToString( streamId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "DELETE" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseBase );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>StreamGetObjects</summary>
    /// <param name="query">Specifiy which fields to retrieve, filters, limits, etc.</param>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseObject> StreamGetObjectsAsync( string streamId, string query )
    {
      return StreamGetObjectsAsync( streamId, query, System.Threading.CancellationToken.None );
    }

    /// <summary>StreamGetObjects</summary>
    /// <param name="query">Specifiy which fields to retrieve, filters, limits, etc.</param>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseObject> StreamGetObjectsAsync( string streamId, string query, System.Threading.CancellationToken cancellationToken )
    {
      if ( streamId == null )
        throw new System.ArgumentNullException( "streamId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/streams/{streamId}/objects?" );
      urlBuilder_.Replace( "{streamId}", System.Uri.EscapeDataString( ConvertToString( streamId, System.Globalization.CultureInfo.InvariantCulture ) ) );
      if ( query != null ) urlBuilder_.Append( query );


      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "GET" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseObject );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseObject>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseObject );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>StreamClone</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseStreamClone> StreamCloneAsync( string streamId )
    {
      return StreamCloneAsync( streamId, System.Threading.CancellationToken.None );
    }

    /// <summary>StreamClone</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseStreamClone> StreamCloneAsync( string streamId, System.Threading.CancellationToken cancellationToken )
    {
      if ( streamId == null )
        throw new System.ArgumentNullException( "streamId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/streams/{streamId}/clone" );
      urlBuilder_.Replace( "{streamId}", System.Uri.EscapeDataString( ConvertToString( streamId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "POST" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseStreamClone );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseStreamClone>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseStreamClone );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>StreamDiff</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseStreamDiff> StreamDiffAsync( string streamId, string otherStreamId )
    {
      return StreamDiffAsync( streamId, otherStreamId, System.Threading.CancellationToken.None );
    }

    /// <summary>StreamDiff</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseStreamDiff> StreamDiffAsync( string streamId, string otherStreamId, System.Threading.CancellationToken cancellationToken )
    {
      if ( streamId == null )
        throw new System.ArgumentNullException( "streamId" );

      if ( otherStreamId == null )
        throw new System.ArgumentNullException( "otherStreamId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/streams/{streamId}/diff/{otherStreamId}" );
      urlBuilder_.Replace( "{streamId}", System.Uri.EscapeDataString( ConvertToString( streamId, System.Globalization.CultureInfo.InvariantCulture ) ) );
      urlBuilder_.Replace( "{otherStreamId}", System.Uri.EscapeDataString( ConvertToString( otherStreamId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "GET" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseStreamDiff );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseStreamDiff>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseStreamDiff );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>ObjectCreate</summary>
    /// <returns>All the users's projects.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseObject> ObjectCreateAsync( System.Collections.Generic.IEnumerable<SpeckleObject> objects )
    {
      return ObjectCreateAsync( objects, System.Threading.CancellationToken.None );
    }

    /// <summary>ObjectCreate</summary>
    /// <returns>All the users's projects.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseObject> ObjectCreateAsync( System.Collections.Generic.IEnumerable<SpeckleObject> objects, System.Threading.CancellationToken cancellationToken )
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/objects" );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          var content_ = new System.Net.Http.StringContent( Newtonsoft.Json.JsonConvert.SerializeObject( objects, _settings.Value ) );
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse( "application/json" );
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod( "POST" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseObject );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseObject>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseObject );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>ObjectUpdate</summary>
    /// <returns>All the users's projects.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseObject> ObjectUpdateAsync( string objectId, SpeckleObject @object )
    {
      return ObjectUpdateAsync( objectId, @object, System.Threading.CancellationToken.None );
    }

    /// <summary>ObjectUpdate</summary>
    /// <returns>All the users's projects.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseObject> ObjectUpdateAsync( string objectId, SpeckleObject @object, System.Threading.CancellationToken cancellationToken )
    {
      if ( objectId == null )
        throw new System.ArgumentNullException( "objectId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/objects/{objectId}" );
      urlBuilder_.Replace( "{objectId}", System.Uri.EscapeDataString( ConvertToString( objectId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          var content_ = new System.Net.Http.StringContent( Newtonsoft.Json.JsonConvert.SerializeObject( @object, _settings.Value ) );
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse( "application/json" );
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod( "PUT" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseObject );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseObject>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseObject );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>ObjectGet</summary>
    /// <returns>The client.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseObject> ObjectGetAsync( string objectId )
    {
      return ObjectGetAsync( objectId, System.Threading.CancellationToken.None );
    }

    /// <summary>ObjectGet</summary>
    /// <returns>The client.</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseObject> ObjectGetAsync( string objectId, System.Threading.CancellationToken cancellationToken )
    {
      if ( objectId == null )
        throw new System.ArgumentNullException( "objectId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/objects/{objectId}" );
      urlBuilder_.Replace( "{objectId}", System.Uri.EscapeDataString( ConvertToString( objectId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "GET" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseObject );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseObject>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseObject );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>ObjectDelete</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseBase> ObjectDeleteAsync( string objectId )
    {
      return ObjectDeleteAsync( objectId, System.Threading.CancellationToken.None );
    }

    /// <summary>ObjectDelete</summary>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseBase> ObjectDeleteAsync( string objectId, System.Threading.CancellationToken cancellationToken )
    {
      if ( objectId == null )
        throw new System.ArgumentNullException( "objectId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/objects/{objectId}" );
      urlBuilder_.Replace( "{objectId}", System.Uri.EscapeDataString( ConvertToString( objectId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          request_.Method = new System.Net.Http.HttpMethod( "DELETE" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseBase );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>ObjectUpdateProperties</summary>
    /// <param name="@object">An object that holds the keys you want to modify or add.</param>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseBase> ObjectUpdatePropertiesAsync( string objectId, object @object )
    {
      return ObjectUpdatePropertiesAsync( objectId, @object, System.Threading.CancellationToken.None );
    }

    /// <summary>ObjectUpdateProperties</summary>
    /// <param name="@object">An object that holds the keys you want to modify or add.</param>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseBase> ObjectUpdatePropertiesAsync( string objectId, object @object, System.Threading.CancellationToken cancellationToken )
    {
      if ( objectId == null )
        throw new System.ArgumentNullException( "objectId" );

      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/objects/{objectId}/properties" );
      urlBuilder_.Replace( "{objectId}", System.Uri.EscapeDataString( ConvertToString( objectId, System.Globalization.CultureInfo.InvariantCulture ) ) );

      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          var content_ = new System.Net.Http.StringContent( Newtonsoft.Json.JsonConvert.SerializeObject( @object, _settings.Value ) );
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse( "application/json" );
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod( "PUT" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseBase );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    /// <summary>ObjectGetBulk</summary>
    /// <param name="query">Specifiy which fields to retrieve, filters, limits, etc. For example, `?fields=type,properties,hash&type=Circle`</param>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    public System.Threading.Tasks.Task<ResponseObject> ObjectGetBulkAsync( string[ ] ObjectIds, string query )
    {
      return ObjectGetBulkAsync( ObjectIds, query, System.Threading.CancellationToken.None );
    }

    /// <summary>ObjectGetBulk</summary>
    /// <param name="query">Specifiy which fields to retrieve, filters, limits, etc. For example, `?fields=type,properties,hash&type=Circle`</param>
    /// <returns>All good!</returns>
    /// <exception cref="SpeckleException">A server side error occurred.</exception>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    public async System.Threading.Tasks.Task<ResponseObject> ObjectGetBulkAsync( string[ ] ObjectIds, string query, System.Threading.CancellationToken cancellationToken )
    {
      var urlBuilder_ = new System.Text.StringBuilder();
      urlBuilder_.Append( BaseUrl != null ? BaseUrl.TrimEnd( '/' ) : "" ).Append( "/objects/getbulk?" );
      if ( query != null ) urlBuilder_.Append( query );


      var client_ = new System.Net.Http.HttpClient();
      try
      {
        using ( var request_ = new System.Net.Http.HttpRequestMessage() )
        {
          var content_ = new System.Net.Http.StringContent( Newtonsoft.Json.JsonConvert.SerializeObject( ObjectIds, _settings.Value ) );
          content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse( "application/json" );
          request_.Content = content_;
          request_.Method = new System.Net.Http.HttpMethod( "POST" );
          request_.Headers.Accept.Add( new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue( "application/json" ) );

          PrepareRequest( client_, request_, urlBuilder_ );
          var url_ = urlBuilder_.ToString();
          request_.RequestUri = new System.Uri( url_, System.UriKind.RelativeOrAbsolute );
          PrepareRequest( client_, request_, url_ );

          var response_ = await client_.SendAsync( request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken ).ConfigureAwait( false );
          try
          {
            var headers_ = System.Linq.Enumerable.ToDictionary( response_.Headers, h_ => h_.Key, h_ => h_.Value );
            if ( response_.Content != null && response_.Content.Headers != null )
            {
              foreach ( var item_ in response_.Content.Headers )
                headers_[ item_.Key ] = item_.Value;
            }

            ProcessResponse( client_, response_ );

            var status_ = ( ( int ) response_.StatusCode ).ToString();
            if ( status_ == "200" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseObject );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseObject>( responseData_, _settings.Value );
                return result_;
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
            }
            else
            if ( status_ == "400" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              var result_ = default( ResponseBase );
              try
              {
                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>( responseData_, _settings.Value );
              }
              catch ( System.Exception exception_ )
              {
                throw new SpeckleException( "Could not deserialize the response body.", ( int ) response_.StatusCode, responseData_, headers_, exception_ );
              }
              throw new SpeckleException<ResponseBase>( "Fail whale.", ( int ) response_.StatusCode, responseData_, headers_, result_, null );
            }
            else
            if ( status_ != "200" && status_ != "204" )
            {
              var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait( false );
              throw new SpeckleException( "The HTTP status code of the response was not expected (" + ( int ) response_.StatusCode + ").", ( int ) response_.StatusCode, responseData_, headers_, null );
            }

            return default( ResponseObject );
          }
          finally
          {
            if ( response_ != null )
              response_.Dispose();
          }
        }
      }
      finally
      {
        if ( client_ != null )
          client_.Dispose();
      }
    }

    private string ConvertToString( object value, System.Globalization.CultureInfo cultureInfo )
    {
      if ( value is System.Enum )
      {
        string name = System.Enum.GetName( value.GetType(), value );
        if ( name != null )
        {
          var field = System.Reflection.IntrospectionExtensions.GetTypeInfo( value.GetType() ).GetDeclaredField( name );
          if ( field != null )
          {
            var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute( field, typeof( System.Runtime.Serialization.EnumMemberAttribute ) )
                as System.Runtime.Serialization.EnumMemberAttribute;
            if ( attribute != null )
            {
              return attribute.Value;
            }
          }
        }
      }
      else if ( value is byte[ ] )
      {
        return System.Convert.ToBase64String( ( byte[ ] ) value );
      }
      else if ( value.GetType().IsArray )
      {
        var array = System.Linq.Enumerable.OfType<object>( ( System.Array ) value );
        return string.Join( ",", System.Linq.Enumerable.Select( array, o => ConvertToString( o, cultureInfo ) ) );
      }

      return System.Convert.ToString( value, cultureInfo );
    }
  }
}
