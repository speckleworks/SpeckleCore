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

        /// <summary>UserRegister</summary>
        /// <returns>New user successfully registered.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseAccountRegister> UserRegisterAsync(PayloadAccountRegister body)
        {
            return UserRegisterAsync(body, System.Threading.CancellationToken.None);
        }

        /// <summary>UserRegister</summary>
        /// <returns>New user successfully registered.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseAccountRegister UserRegister(PayloadAccountRegister body)
        {
            return System.Threading.Tasks.Task.Run(async () => await UserRegisterAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>UserRegister</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>New user successfully registered.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseAccountRegister> UserRegisterAsync(PayloadAccountRegister body, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/accounts/register");

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));

                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseAccountRegister);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseAccountRegister>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Failed to register a new user.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseAccountRegister);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>UserLogin</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseAccountLogin> UserLoginAsync(PayloadAccountLogin body)
        {
            return UserLoginAsync(body, System.Threading.CancellationToken.None);
        }


        /// <summary>UserLogin</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseAccountLogin UserLogin(PayloadAccountLogin body)
        {
            return System.Threading.Tasks.Task.Run(async () => await UserLoginAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>UserLogin</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseAccountLogin> UserLoginAsync(PayloadAccountLogin body, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/accounts/login");

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseAccountLogin);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseAccountLogin>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseAccountLogin);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>UserStreamsGet</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseAccountStreams> UserStreamsGetAsync()
        {
            return UserStreamsGetAsync(System.Threading.CancellationToken.None);
        }


        /// <summary>UserStreamsGet</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseAccountStreams UserStreamsGet()
        {
            return System.Threading.Tasks.Task.Run(async () => await UserStreamsGetAsync(System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }


        /// <summary>UserStreamsGet</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseAccountStreams> UserStreamsGetAsync(System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/accounts/streams");

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseAccountStreams);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseAccountStreams>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unautorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseAccountStreams);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>UserClientsGet</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseAccountClients> UserClientsGetAsync()
        {
            return UserClientsGetAsync(System.Threading.CancellationToken.None);
        }


        /// <summary>UserClientsGet</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseAccountClients UserClientsGet()
        {
            return System.Threading.Tasks.Task.Run(async () => await UserClientsGetAsync(System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>UserClientsGet</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseAccountClients> UserClientsGetAsync(System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/accounts/clients");

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseAccountClients);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseAccountClients>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseAccountClients);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>UserGetProfile</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseAccountProfile> UserGetProfileAsync()
        {
            return UserGetProfileAsync(System.Threading.CancellationToken.None);
        }

        /// <summary>UserGetProfile</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseAccountProfile UserGetProfile()
        {
            return System.Threading.Tasks.Task.Run(async () => await UserGetProfileAsync(System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>UserGetProfile</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseAccountProfile> UserGetProfileAsync(System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/accounts/profile");

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseAccountProfile);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseAccountProfile>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseAccountProfile);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>UserUpdate</summary>
        /// <returns>All good.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseBase> UserUpdateAsync(PayloadAccountUpdate body)
        {
            return UserUpdateAsync(body, System.Threading.CancellationToken.None);
        }

        /// <summary>UserUpdate</summary>
        /// <returns>All good.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseBase UserUpdate(PayloadAccountUpdate body)
        {
            return System.Threading.Tasks.Task.Run(async () => await UserUpdateAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>UserUpdate</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>All good.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseBase> UserUpdateAsync(PayloadAccountUpdate body, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/accounts/profile");

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PUT");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseBase);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>ClientCreate</summary>
        /// <returns>Successfully creates a new client.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseClientCreate> ClientCreateAsync(PayloadClientCreate body)
        {
            return ClientCreateAsync(body, System.Threading.CancellationToken.None);
        }

        /// <summary>ClientCreate</summary>
        /// <returns>Successfully creates a new client.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseClientCreate ClientCreate(PayloadClientCreate body)
        {
            return System.Threading.Tasks.Task.Run(async () => await ClientCreateAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>ClientCreate</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Successfully creates a new client.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseClientCreate> ClientCreateAsync(PayloadClientCreate body, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/clients");

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseClientCreate);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseClientCreate>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseClientCreate);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>ClientGet</summary>
        /// <param name="clientId">the client's id.</param>
        /// <returns>Client got.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseClientGet> ClientGetAsync(string clientId)
        {
            return ClientGetAsync(clientId, System.Threading.CancellationToken.None);
        }

        /// <summary>ClientGet</summary>
        /// <param name="clientId">the client's id.</param>
        /// <returns>Client got.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseClientGet ClientGet(string clientId)
        {
            return System.Threading.Tasks.Task.Run(async () => await ClientGetAsync(clientId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }


        /// <summary>ClientGet</summary>
        /// <param name="clientId">the client's id.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Client got.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseClientGet> ClientGetAsync(string clientId, System.Threading.CancellationToken cancellationToken)
        {
            if (clientId == null)
                throw new System.ArgumentNullException("clientId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/clients/{clientId}");
            urlBuilder_.Replace("{clientId}", System.Uri.EscapeDataString(System.Convert.ToString(clientId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseClientGet);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseClientGet>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseClientGet);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>ClientUpdate</summary>
        /// <param name="clientId">the client's id.</param>
        /// <returns>All good.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseBase> ClientUpdateAsync(PayloadClientUpdate body, string clientId)
        {
            return ClientUpdateAsync(body, clientId, System.Threading.CancellationToken.None);
        }

        /// <summary>ClientUpdate</summary>
        /// <param name="clientId">the client's id.</param>
        /// <returns>All good.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseBase ClientUpdate(PayloadClientUpdate body, string clientId)
        {
            return System.Threading.Tasks.Task.Run(async () => await ClientUpdateAsync(body, clientId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>ClientUpdate</summary>
        /// <param name="clientId">the client's id.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>All good.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseBase> ClientUpdateAsync(PayloadClientUpdate body, string clientId, System.Threading.CancellationToken cancellationToken)
        {
            if (clientId == null)
                throw new System.ArgumentNullException("clientId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/clients/{clientId}");
            urlBuilder_.Replace("{clientId}", System.Uri.EscapeDataString(System.Convert.ToString(clientId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PUT");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseBase);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>ClientDelete</summary>
        /// <param name="clientId">the client's id.</param>
        /// <returns>Computer is benevolent.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseBase> ClientDeleteAsync(string clientId)
        {
            return ClientDeleteAsync(clientId, System.Threading.CancellationToken.None);
        }

        /// <summary>ClientDelete</summary>
        /// <param name="clientId">the client's id.</param>
        /// <returns>Computer is benevolent.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseBase ClientDelete(string clientId)
        {
            return System.Threading.Tasks.Task.Run(async () => await ClientDeleteAsync(clientId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>ClientDelete</summary>
        /// <param name="clientId">the client's id.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Computer is benevolent.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseBase> ClientDeleteAsync(string clientId, System.Threading.CancellationToken cancellationToken)
        {
            if (clientId == null)
                throw new System.ArgumentNullException("clientId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/clients/{clientId}");
            urlBuilder_.Replace("{clientId}", System.Uri.EscapeDataString(System.Convert.ToString(clientId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("DELETE");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Computer is confused.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Computer says you\'re not authorised.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Computer can\'t find shit.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseBase);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>StreamCreate</summary>
        /// <returns>Initialises a stream in the db. You get back the 'streamId'.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseStreamCreate> StreamCreateAsync(PayloadStreamCreate payloadStreamCreate = null)
        {
            return StreamCreateAsync(System.Threading.CancellationToken.None, payloadStreamCreate);
        }

        /// <summary>StreamCreate</summary>
        /// <returns>Initialises a stream in the db. You get back the 'streamId'.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseStreamCreate StreamCreate(PayloadStreamCreate payloadStreamCreate = null)
        {
            return System.Threading.Tasks.Task.Run(async () => await StreamCreateAsync(System.Threading.CancellationToken.None, payloadStreamCreate)).GetAwaiter().GetResult();
        }

        /// <summary>StreamCreate</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Initialises a stream in the db. You get back the 'streamId'.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseStreamCreate> StreamCreateAsync(System.Threading.CancellationToken cancellationToken, PayloadStreamCreate payloadStreamCreate = null)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams");

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(payloadStreamCreate, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;

                    if (payloadStreamCreate == null)
                        content_ = new System.Net.Http.StringContent(string.Empty);

                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseStreamCreate);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseStreamCreate>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseStreamCreate);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>StreamGet</summary>
        /// <param name="streamId">The stream's id.</param>
        /// <returns>Success whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseStreamGet> StreamGetAsync(string streamId)
        {
            return StreamGetAsync(streamId, System.Threading.CancellationToken.None);
        }

        /// <summary>StreamGet</summary>
        /// <param name="streamId">The stream's id.</param>
        /// <returns>Success whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseStreamGet StreamGet(string streamId)
        {
            return System.Threading.Tasks.Task.Run(async () => await StreamGetAsync(streamId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>StreamGet</summary>
        /// <param name="streamId">The stream's id.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseStreamGet> StreamGetAsync(string streamId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseStreamGet);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseStreamGet>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Stream not found.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseStreamGet);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>StreamUpdate</summary>
        /// <param name="streamId">The stream's id.</param>
        /// <returns>On success</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseStreamUpdate> StreamUpdateAsync(PayloadStreamUpdate body, string streamId)
        {
            return StreamUpdateAsync(body, streamId, System.Threading.CancellationToken.None);
        }


        /// <summary>StreamUpdate</summary>
        /// <param name="streamId">The stream's id.</param>
        /// <returns>On success</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseStreamUpdate StreamUpdate(PayloadStreamUpdate body, string streamId)
        {
            return System.Threading.Tasks.Task.Run(async () => await StreamUpdateAsync(body, streamId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>StreamUpdate</summary>
        /// <param name="streamId">The stream's id.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>On success</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseStreamUpdate> StreamUpdateAsync(PayloadStreamUpdate body, string streamId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PUT");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseStreamUpdate);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseStreamUpdate>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Status 401", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Status 404", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseStreamUpdate);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>StreamDelete</summary>
        /// <param name="streamId">The stream's id.</param>
        /// <returns>Success whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseBase> StreamDeleteAsync(string streamId)
        {
            return StreamDeleteAsync(streamId, System.Threading.CancellationToken.None);
        }

        /// <summary>StreamDelete</summary>
        /// <param name="streamId">The stream's id.</param>
        /// <returns>Success whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseBase StreamDelete(string streamId)
        {
            return System.Threading.Tasks.Task.Run(async () => await StreamDeleteAsync(streamId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }


        /// <summary>StreamDelete</summary>
        /// <param name="streamId">The stream's id.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseBase> StreamDeleteAsync(string streamId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("DELETE");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseBase);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>StreamGetName</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseStreamNameGet> StreamGetNameAsync(string streamId)
        {
            return StreamGetNameAsync(streamId, System.Threading.CancellationToken.None);
        }

        /// <summary>StreamGetName</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseStreamNameGet StreamGetName(string streamId)
        {
            return System.Threading.Tasks.Task.Run(async () => await StreamGetNameAsync(streamId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>StreamGetName</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseStreamNameGet> StreamGetNameAsync(string streamId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/name");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseStreamNameGet);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseStreamNameGet>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseStreamNameGet);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>StreamUpdateName</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseBase> StreamUpdateNameAsync(PayloadStreamNameUpdate body, string streamId)
        {
            return StreamUpdateNameAsync(body, streamId, System.Threading.CancellationToken.None);
        }


        /// <summary>StreamUpdateName</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseBase StreamUpdateName(PayloadStreamNameUpdate body, string streamId)
        {
            return System.Threading.Tasks.Task.Run(async () => await StreamUpdateNameAsync(body, streamId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>StreamUpdateName</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseBase> StreamUpdateNameAsync(PayloadStreamNameUpdate body, string streamId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/name");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PUT");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseBase);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>GetLayers</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseStreamLayersGet> GetLayersAsync(string streamId)
        {
            return GetLayersAsync(streamId, System.Threading.CancellationToken.None);
        }

        /// <summary>GetLayers</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseStreamLayersGet GetLayers(string streamId)
        {
            return System.Threading.Tasks.Task.Run(async () => await GetLayersAsync(streamId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>GetLayers</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseStreamLayersGet> GetLayersAsync(string streamId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/layers");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseStreamLayersGet);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseStreamLayersGet>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseStreamLayersGet);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>AddLayers</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseBase> AddLayersAsync(PayloadMultipleLayers body, string streamId)
        {
            return AddLayersAsync(body, streamId, System.Threading.CancellationToken.None);
        }


        /// <summary>AddLayers</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseBase AddLayers(PayloadMultipleLayers body, string streamId)
        {
            return System.Threading.Tasks.Task.Run(async () => await AddLayersAsync(body, streamId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>AddLayers</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseBase> AddLayersAsync(PayloadMultipleLayers body, string streamId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/layers");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseBase);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>ReplaceLayers</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseBase> ReplaceLayersAsync(PayloadMultipleLayers body, string streamId)
        {
            return ReplaceLayersAsync(body, streamId, System.Threading.CancellationToken.None);
        }

        /// <summary>ReplaceLayers</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseBase ReplaceLayers(PayloadMultipleLayers body, string streamId)
        {
            return System.Threading.Tasks.Task.Run(async () => await ReplaceLayersAsync(body, streamId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>ReplaceLayers</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseBase> ReplaceLayersAsync(PayloadMultipleLayers body, string streamId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/layers");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PUT");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseBase);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>MergeLayers</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseBase> MergeLayersAsync(PayloadMultipleLayers body, string streamId)
        {
            return MergeLayersAsync(body, streamId, System.Threading.CancellationToken.None);
        }

        /// <summary>MergeLayers</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseBase MergeLayers(PayloadMultipleLayers body, string streamId)
        {
            return System.Threading.Tasks.Task.Run(async () => await MergeLayersAsync(body, streamId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>MergeLayers</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseBase> MergeLayersAsync(PayloadMultipleLayers body, string streamId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/layers");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PATCH");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseBase);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>DeleteLayers</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseBase> DeleteLayersAsync(string streamId)
        {
            return DeleteLayersAsync(streamId, System.Threading.CancellationToken.None);
        }

        /// <summary>DeleteLayers</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseBase DeleteLayers(string streamId)
        {
            return System.Threading.Tasks.Task.Run(async () => await DeleteLayersAsync(streamId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>DeleteLayers</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseBase> DeleteLayersAsync(string streamId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/layers");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("DELETE");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseBase);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>GetSingleLayer</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <returns>Successful whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseSingleLayer> GetSingleLayerAsync(string streamId, string layerId)
        {
            return GetSingleLayerAsync(streamId, layerId, System.Threading.CancellationToken.None);
        }

        /// <summary>GetSingleLayer</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Successful whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseSingleLayer> GetSingleLayerAsync(string streamId, string layerId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            if (layerId == null)
                throw new System.ArgumentNullException("layerId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/layers/{layerId}");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{layerId}", System.Uri.EscapeDataString(System.Convert.ToString(layerId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseSingleLayer);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseSingleLayer>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorized whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseSingleLayer);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>ReplaceSingleLayer</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <returns>Successful whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseBase> ReplaceSingleLayerAsync(PayloadSingleLayer body, string streamId, string layerId)
        {
            return ReplaceSingleLayerAsync(body, streamId, layerId, System.Threading.CancellationToken.None);
        }

        /// <summary>ReplaceSingleLayer</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Successful whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseBase> ReplaceSingleLayerAsync(PayloadSingleLayer body, string streamId, string layerId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            if (layerId == null)
                throw new System.ArgumentNullException("layerId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/layers/{layerId}");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{layerId}", System.Uri.EscapeDataString(System.Convert.ToString(layerId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PUT");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorized whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseBase);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>UpdateSingleLayer</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <returns>Successful whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseBase> UpdateSingleLayerAsync(PayloadSingleLayer body, string streamId, string layerId)
        {
            return UpdateSingleLayerAsync(body, streamId, layerId, System.Threading.CancellationToken.None);
        }

        /// <summary>UpdateSingleLayer</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Successful whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseBase> UpdateSingleLayerAsync(PayloadSingleLayer body, string streamId, string layerId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            if (layerId == null)
                throw new System.ArgumentNullException("layerId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/layers/{layerId}");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{layerId}", System.Uri.EscapeDataString(System.Convert.ToString(layerId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PATCH");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorized whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseBase);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>DeleteSingleLayer</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <returns>Successful whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseBase> DeleteSingleLayerAsync(string streamId, string layerId)
        {
            return DeleteSingleLayerAsync(streamId, layerId, System.Threading.CancellationToken.None);
        }

        /// <summary>DeleteSingleLayer</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Successful whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseBase> DeleteSingleLayerAsync(string streamId, string layerId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            if (layerId == null)
                throw new System.ArgumentNullException("layerId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/layers/{layerId}");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{layerId}", System.Uri.EscapeDataString(System.Convert.ToString(layerId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("DELETE");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorized whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseBase);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>GetLayerObjects</summary>
        /// <param name="query">Filter by field values, get or omit specific fields & sort.</param>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <returns>Success whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseGetObjects> GetLayerObjectsAsync(string query, string streamId, string layerId)
        {
            return GetLayerObjectsAsync(query, streamId, layerId, System.Threading.CancellationToken.None);
        }

        /// <summary>GetLayerObjects</summary>
        /// <param name="query">Filter by field values, get or omit specific fields & sort.</param>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseGetObjects> GetLayerObjectsAsync(string query, string streamId, string layerId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            if (layerId == null)
                throw new System.ArgumentNullException("layerId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/layers/{layerId}/objects?");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{layerId}", System.Uri.EscapeDataString(System.Convert.ToString(layerId, System.Globalization.CultureInfo.InvariantCulture)));
            if (query != null) urlBuilder_.Append(query);

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseGetObjects);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseGetObjects>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorized whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseGetObjects);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>AddLayerObjects</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <returns>Success whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponsePostObjects> AddLayerObjectsAsync(PayloadMultipleObjects body, string streamId, string layerId)
        {
            return AddLayerObjectsAsync(body, streamId, layerId, System.Threading.CancellationToken.None);
        }

        /// <summary>AddLayerObjects</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponsePostObjects> AddLayerObjectsAsync(PayloadMultipleObjects body, string streamId, string layerId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            if (layerId == null)
                throw new System.ArgumentNullException("layerId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/layers/{layerId}/objects");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{layerId}", System.Uri.EscapeDataString(System.Convert.ToString(layerId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponsePostObjects);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponsePostObjects>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorized whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponsePostObjects);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>ReplaceLayerObjects</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <returns>Success whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponsePostObjects> ReplaceLayerObjectsAsync(PayloadMultipleObjects body, string streamId, string layerId)
        {
            return ReplaceLayerObjectsAsync(body, streamId, layerId, System.Threading.CancellationToken.None);
        }

        /// <summary>ReplaceLayerObjects</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponsePostObjects> ReplaceLayerObjectsAsync(PayloadMultipleObjects body, string streamId, string layerId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            if (layerId == null)
                throw new System.ArgumentNullException("layerId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/layers/{layerId}/objects");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{layerId}", System.Uri.EscapeDataString(System.Convert.ToString(layerId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PUT");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponsePostObjects);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponsePostObjects>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorized whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponsePostObjects);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>DeleteLayerObjects</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <returns>Success whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseBase> DeleteLayerObjectsAsync(PayloadMultipleObjectIds body, string streamId, string layerId)
        {
            return DeleteLayerObjectsAsync(body, streamId, layerId, System.Threading.CancellationToken.None);
        }

        /// <summary>DeleteLayerObjects</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseBase> DeleteLayerObjectsAsync(PayloadMultipleObjectIds body, string streamId, string layerId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            if (layerId == null)
                throw new System.ArgumentNullException("layerId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/layers/{layerId}/objects");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{layerId}", System.Uri.EscapeDataString(System.Convert.ToString(layerId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Method = new System.Net.Http.HttpMethod("DELETE");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorized whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseBase);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>GetObjects</summary>
        /// <param name="query">Filter by field values, get or omit specific fields & sort.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseGetObjects> GetStreamObjectsAsync(string query, string streamId)
        {
            return GetStreamObjectsAsync(query, streamId, System.Threading.CancellationToken.None);
        }

        /// <summary>GetObjects</summary>
        /// <param name="query">Filter by field values, get or omit specific fields & sort.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseGetObjects> GetStreamObjectsAsync(string query, string streamId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/objects?");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));
            if (query != null) urlBuilder_.Append(query);

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseGetObjects);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseGetObjects>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseGetObjects);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>AddObjects</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponsePostObjects> AddObjectsAsync(PayloadMultipleObjects body, string streamId)
        {
            return AddObjectsAsync(body, streamId, System.Threading.CancellationToken.None);
        }

        /// <summary>AddObjects</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponsePostObjects> AddObjectsAsync(PayloadMultipleObjects body, string streamId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/objects");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponsePostObjects);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponsePostObjects>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponsePostObjects);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>ReplaceObjects</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponsePostObjects> ReplaceObjectsAsync(PayloadMultipleObjects body, string streamId)
        {
            return ReplaceObjectsAsync(body, streamId, System.Threading.CancellationToken.None);
        }

        /// <summary>ReplaceObjects</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponsePostObjects> ReplaceObjectsAsync(PayloadMultipleObjects body, string streamId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/objects");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PUT");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponsePostObjects);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponsePostObjects>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponsePostObjects);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>DeleteObjects</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseBase> DeleteObjectsAsync(string streamId)
        {
            return DeleteObjectsAsync(streamId, System.Threading.CancellationToken.None);
        }

        /// <summary>DeleteObjects</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseBase> DeleteObjectsAsync(string streamId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/objects");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("DELETE");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseBase);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>ObjectDeleteFromStream</summary>
        /// <param name="objectId">The `objectId` that you want to remove.</param>
        /// <returns>Woot! Operation succeeded!</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseBase> ObjectDeleteFromStreamAsync(string streamId, string objectId)
        {
            return ObjectDeleteFromStreamAsync(streamId, objectId, System.Threading.CancellationToken.None);
        }

        /// <summary>ObjectDeleteFromStream</summary>
        /// <param name="objectId">The `objectId` that you want to remove.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Woot! Operation succeeded!</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseBase> ObjectDeleteFromStreamAsync(string streamId, string objectId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            if (objectId == null)
                throw new System.ArgumentNullException("objectId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/objects/{objectId}");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{objectId}", System.Uri.EscapeDataString(System.Convert.ToString(objectId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("DELETE");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseBase);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>StreamClone</summary>
        /// <param name="streamId">The stream's id.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseStreamClone> StreamCloneAsync(string streamId)
        {
            return StreamCloneAsync(streamId, System.Threading.CancellationToken.None);
        }

        /// <summary>StreamClone</summary>
        /// <param name="streamId">The stream's id.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseStreamClone> StreamCloneAsync(string streamId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/clone");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(string.Empty);
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseStreamClone);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseStreamClone>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseStreamClone);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>StreamDiff</summary>
        /// <param name="streamId">The stream's id.</param>
        /// <param name="otherId">The stream you want to diff against.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseStreamDiff> StreamDiffAsync(string streamId, string otherId)
        {
            return StreamDiffAsync(streamId, otherId, System.Threading.CancellationToken.None);
        }

        /// <summary>StreamDiff</summary>
        /// <param name="streamId">The stream's id.</param>
        /// <param name="otherId">The stream you want to diff against.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseStreamDiff> StreamDiffAsync(string streamId, string otherId, System.Threading.CancellationToken cancellationToken)
        {
            if (streamId == null)
                throw new System.ArgumentNullException("streamId");

            if (otherId == null)
                throw new System.ArgumentNullException("otherId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/streams/{streamId}/diff/{otherId}");
            urlBuilder_.Replace("{streamId}", System.Uri.EscapeDataString(System.Convert.ToString(streamId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{otherId}", System.Uri.EscapeDataString(System.Convert.ToString(otherId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseStreamDiff);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseStreamDiff>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseStreamDiff);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>ObjectCreate</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponsePostObject> ObjectCreateAsync(PayloadSingleObject body)
        {
            return ObjectCreateAsync(body, System.Threading.CancellationToken.None);
        }

        /// <summary>ObjectCreate</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponsePostObject> ObjectCreateAsync(PayloadSingleObject body, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/objects");

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponsePostObject);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponsePostObject>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponsePostObject);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>ObjectGet</summary>
        /// <param name="query">Specify which fields to retrieve or omit.</param>
        /// <returns>Object found</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseObjectGet> ObjectGetAsync(string query, string objectId)
        {
            return ObjectGetAsync(query, objectId, System.Threading.CancellationToken.None);
        }

        /// <summary>ObjectGet</summary>
        /// <param name="query">Specify which fields to retrieve or omit.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Object found</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseObjectGet> ObjectGetAsync(string query, string objectId, System.Threading.CancellationToken cancellationToken)
        {
            if (objectId == null)
                throw new System.ArgumentNullException("objectId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/objects/{objectId}?");
            urlBuilder_.Replace("{objectId}", System.Uri.EscapeDataString(System.Convert.ToString(objectId, System.Globalization.CultureInfo.InvariantCulture)));
            if (query != null) urlBuilder_.Append(query);

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseObjectGet);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseObjectGet>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "404")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("Status 404", status_, responseData_, headers_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseObjectGet);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>ObjectUpdate</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseBase> ObjectUpdateAsync(PayloadSingleObject body, string objectId)
        {
            return ObjectUpdateAsync(body, objectId, System.Threading.CancellationToken.None);
        }

        /// <summary>ObjectUpdate</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseBase> ObjectUpdateAsync(PayloadSingleObject body, string objectId, System.Threading.CancellationToken cancellationToken)
        {
            if (objectId == null)
                throw new System.ArgumentNullException("objectId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/objects/{objectId}");
            urlBuilder_.Replace("{objectId}", System.Uri.EscapeDataString(System.Convert.ToString(objectId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("PUT");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseBase);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>ObjectDelete</summary>
        /// <returns>Done deal yo!</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponseBase> ObjectDeleteAsync(string objectId)
        {
            return ObjectDeleteAsync(objectId, System.Threading.CancellationToken.None);
        }

        /// <summary>ObjectDelete</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Done deal yo!</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseBase> ObjectDeleteAsync(string objectId, System.Threading.CancellationToken cancellationToken)
        {
            if (objectId == null)
                throw new System.ArgumentNullException("objectId");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/objects/{objectId}");
            urlBuilder_.Replace("{objectId}", System.Uri.EscapeDataString(System.Convert.ToString(objectId, System.Globalization.CultureInfo.InvariantCulture)));

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("DELETE");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseBase);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }


        public System.Threading.Tasks.Task<ResponseGetObjects> ObjectGetBulkAsync(string query, PayloadObjectGetBulk body)
        {
            return ObjectGetBulkAsync(query, body, System.Threading.CancellationToken.None);
        }

        /// <summary>ObjectGetBulk</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponseGetObjects> ObjectGetBulkAsync(string query, PayloadObjectGetBulk body, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/objects/getbulk?");
            if (query != null) urlBuilder_.Append(query);

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseGetObjects);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseGetObjects>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponseGetObjects);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }



        /// <summary>ObjectCreateBulk</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public System.Threading.Tasks.Task<ResponsePostObjects> ObjectCreateBulkAsync(PayloadMultipleObjects body)
        {
            return ObjectCreateBulkAsync(body, System.Threading.CancellationToken.None);
        }

        /// <summary>ObjectCreateBulk</summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public async System.Threading.Tasks.Task<ResponsePostObjects> ObjectCreateBulkAsync(PayloadMultipleObjects body, System.Threading.CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(BaseUrl).Append("/objects/bulk");

            var client_ = GetHttpClient();
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                    content_.Headers.ContentType.MediaType = "application/json";
                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;

                        ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString();
                        if (status_ == "200")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponsePostObjects);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponsePostObjects>(responseData_, _settings.Value);
                                return result_;
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                        }
                        else
                        if (status_ == "400")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Fail whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ == "401")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            var result_ = default(ResponseBase);
                            try
                            {
                                result_ = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseBase>(responseData_, _settings.Value);
                            }
                            catch (System.Exception exception)
                            {
                                throw new SwaggerException("Could not deserialize the response body.", status_, responseData_, headers_, exception, this);
                            }
                            throw new SwaggerException<ResponseBase>("Unauthorised whale.", status_, responseData_, headers_, result_, null, this);
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new SwaggerException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", status_, responseData_, headers_, null, this);
                        }

                        return default(ResponsePostObjects);
                    }
                    finally
                    {
                        if (response_ != null)
                            response_.Dispose();
                    }
                }
            }
            finally
            {
                if (client_ != null)
                    client_.Dispose();
            }
        }

        /// <summary>GetSingleLayer</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <returns>Successful whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseSingleLayer GetSingleLayer(string streamId, string layerId)
        {
            return System.Threading.Tasks.Task.Run(async () => await GetSingleLayerAsync(streamId, layerId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>ReplaceSingleLayer</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <returns>Successful whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseBase ReplaceSingleLayer(PayloadSingleLayer body, string streamId, string layerId)
        {
            return System.Threading.Tasks.Task.Run(async () => await ReplaceSingleLayerAsync(body, streamId, layerId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>UpdateSingleLayer</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <returns>Successful whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseBase UpdateSingleLayer(PayloadSingleLayer body, string streamId, string layerId)
        {
            return System.Threading.Tasks.Task.Run(async () => await UpdateSingleLayerAsync(body, streamId, layerId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>DeleteSingleLayer</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <returns>Successful whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseBase DeleteSingleLayer(string streamId, string layerId)
        {
            return System.Threading.Tasks.Task.Run(async () => await DeleteSingleLayerAsync(streamId, layerId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>GetLayerObjects</summary>
        /// <param name="query">Filter by field values, get or omit specific fields & sort.</param>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <returns>Success whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseGetObjects GetLayerObjects(string query, string streamId, string layerId)
        {
            return System.Threading.Tasks.Task.Run(async () => await GetLayerObjectsAsync(query, streamId, layerId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>AddLayerObjects</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <returns>Success whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponsePostObjects AddLayerObjects(PayloadMultipleObjects body, string streamId, string layerId)
        {
            return System.Threading.Tasks.Task.Run(async () => await AddLayerObjectsAsync(body, streamId, layerId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>ReplaceLayerObjects</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <returns>Success whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponsePostObjects ReplaceLayerObjects(PayloadMultipleObjects body, string streamId, string layerId)
        {
            return System.Threading.Tasks.Task.Run(async () => await ReplaceLayerObjectsAsync(body, streamId, layerId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>DeleteLayerObjects</summary>
        /// <param name="layerId">Layer guid or name. In case of name, the first layer of that name is selected.</param>
        /// <returns>Success whale.</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseBase DeleteLayerObjects(PayloadMultipleObjectIds body, string streamId, string layerId)
        {
            return System.Threading.Tasks.Task.Run(async () => await DeleteLayerObjectsAsync(body, streamId, layerId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>GetObjects</summary>
        /// <param name="query">Filter by field values, get or omit specific fields & sort.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseGetObjects GetStreamObjects(string query, string streamId)
        {
            return System.Threading.Tasks.Task.Run(async () => await GetStreamObjectsAsync(query, streamId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>AddObjects</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponsePostObjects AddObjects(PayloadMultipleObjects body, string streamId)
        {
            return System.Threading.Tasks.Task.Run(async () => await AddObjectsAsync(body, streamId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>ReplaceObjects</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponsePostObjects ReplaceObjects(PayloadMultipleObjects body, string streamId)
        {
            return System.Threading.Tasks.Task.Run(async () => await ReplaceObjectsAsync(body, streamId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>DeleteObjects</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseBase DeleteObjects(string streamId)
        {
            return System.Threading.Tasks.Task.Run(async () => await DeleteObjectsAsync(streamId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>ObjectDeleteFromStream</summary>
        /// <param name="objectId">The `objectId` that you want to remove.</param>
        /// <returns>Woot! Operation succeeded!</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseBase ObjectDeleteFromStream(string streamId, string objectId)
        {
            return System.Threading.Tasks.Task.Run(async () => await ObjectDeleteFromStreamAsync(streamId, objectId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>StreamClone</summary>
        /// <param name="streamId">The stream's id.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseStreamClone StreamClone(string streamId)
        {
            return System.Threading.Tasks.Task.Run(async () => await StreamCloneAsync(streamId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>StreamDiff</summary>
        /// <param name="streamId">The stream's id.</param>
        /// <param name="otherId">The stream you want to diff against.</param>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseStreamDiff StreamDiff(string streamId, string otherId)
        {
            return System.Threading.Tasks.Task.Run(async () => await StreamDiffAsync(streamId, otherId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>ObjectCreate</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponsePostObject ObjectCreate(PayloadSingleObject body)
        {
            return System.Threading.Tasks.Task.Run(async () => await ObjectCreateAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>ObjectGet</summary>
        /// <param name="query">Specify which fields to retrieve or omit.</param>
        /// <returns>Object found</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseObjectGet ObjectGet(string query, string objectId)
        {
            return System.Threading.Tasks.Task.Run(async () => await ObjectGetAsync(query, objectId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>ObjectUpdate</summary>
        /// <returns>Status 200</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseBase ObjectUpdate(PayloadSingleObject body, string objectId)
        {
            return System.Threading.Tasks.Task.Run(async () => await ObjectUpdateAsync(body, objectId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        /// <summary>ObjectDelete</summary>
        /// <returns>Done deal yo!</returns>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        public ResponseBase ObjectDelete(string objectId)
        {
            return System.Threading.Tasks.Task.Run(async () => await ObjectDeleteAsync(objectId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
    }
}
