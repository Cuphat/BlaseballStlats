using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BlaseballStlats.Util;
using Newtonsoft.Json;

namespace BlaseballStlats.DataControllers
{
    public class ApiControllerBase
    {
        protected readonly HttpClient Client = new();

        protected Uri Endpoint { get; }

        protected string Authorization
        {
            get => _authorization;
            set
            {
                _authorization = value;
                SetAuthorizationHeader();
            }
        }
        private string _authorization;

        protected string AuthorizationType
        {
            get => _authorizationType;
            set
            {
                _authorizationType = value;
                SetAuthorizationHeader();
            }
        }
        private string _authorizationType = "Basic";

        public ApiControllerBase(Uri endpoint)
        {
            Endpoint = endpoint;
        }

        public ApiControllerBase(string authorization)
        {
            Authorization = authorization;
        }

        public ApiControllerBase(string authorization, string authorizationType)
        {
            AuthorizationType = authorizationType; // Set AuthorizationType before Authorization
            Authorization = authorization;
        }

        public ApiControllerBase(Uri endpoint, string authorization)
        {
            Endpoint = endpoint;
            Authorization = authorization;
        }

        public ApiControllerBase(Uri endpoint, string authorization, string authorizationType)
        {
            Endpoint = endpoint;
            AuthorizationType = authorizationType; // Set AuthorizationType before Authorization
            Authorization = authorization;
        }

        private void SetAuthorizationHeader()
        {
            if (Authorization != null && AuthorizationType != null)
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthorizationType, Authorization);
            else if (Authorization != null)
                Client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(Authorization);
            else
                Client.DefaultRequestHeaders.Authorization = null;
        }

        // Enum containing which request type we are sending.
        protected enum ApiRequestType
        {
            Get,
            Post,
            Put,
            Delete
        }

        // Takes a request type, returns a delegate method.
        protected virtual Func<Uri, object, string, Task<HttpResponseMessage>> ApiRequest(ApiRequestType requestType)
        {
            return requestType switch
            {
                ApiRequestType.Get => ApiGet,
                ApiRequestType.Post => ApiPost,
                ApiRequestType.Put => ApiPut,
                ApiRequestType.Delete => ApiDelete,
                _ => null
            };
        }

        // Delegate methods for each request type.
        protected virtual async Task<HttpResponseMessage> ApiGet(Uri endpointUri, object obj = null, string mediaType = null)
            => await ApiRequest(ApiRequestType.Get, endpointUri, null, null);
        protected virtual async Task<HttpResponseMessage> ApiPost(Uri endpointUri, object obj, string mediaType = null)
            => await ApiRequest(ApiRequestType.Post, endpointUri, obj, mediaType);
        protected virtual async Task<HttpResponseMessage> ApiPut(Uri endpointUri, object obj, string mediaType = null)
            => await ApiRequest(ApiRequestType.Put, endpointUri, obj, mediaType);
        protected virtual async Task<HttpResponseMessage> ApiDelete(Uri endpointUri, object obj = null, string mediaType = null)
            => await ApiRequest(ApiRequestType.Delete, endpointUri, obj, mediaType);

        // Send the request, get a response.
        protected virtual async Task<HttpResponseMessage> ApiRequest(ApiRequestType method, Uri endpointUri, object obj = null, string mediaType = null)
        {
            HttpContent httpContent = null;
            if (obj != null)
            {
                if (!(obj is string stringData))
                {
                    stringData = JsonConvert.SerializeObject(obj);
                    mediaType ??= "application/json";
                }
                httpContent = new StringContent(stringData, Encoding.UTF8, mediaType);
            }

            switch (method)
            {
                case ApiRequestType.Get:
                    return await Client.GetAsync(endpointUri);
                case ApiRequestType.Post:
                    return await Client.PostAsync(endpointUri, httpContent);
                case ApiRequestType.Put:
                    return await Client.PutAsync(endpointUri, httpContent);
                case ApiRequestType.Delete:
                    if (httpContent == null)
                        return await Client.DeleteAsync(endpointUri);
                    var request = new HttpRequestMessage
                    {
                        Content = httpContent,
                        Method = HttpMethod.Delete,
                        RequestUri = endpointUri
                    };
                    return await Client.SendAsync(request);
                default:
                    throw new ArgumentOutOfRangeException(nameof(method), method, null);
            }
        }

        // Our main method to send an API Request and return an generic type object.
        protected virtual async Task<T> ApiRequest<T>(ApiRequestType requestType, Uri endpointUri, object obj, string mediaType, string dumpFileName, bool deserializedDump)
        {
            var response = await ApiRequest(requestType)(endpointUri, obj, mediaType);
            var content = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(content)) return default;

            if (!string.IsNullOrEmpty(dumpFileName))
            {
                dumpFileName = dumpFileName.Replace('\\', '/');
                var directories = dumpFileName.Contains('/') ? dumpFileName.Substring(0, dumpFileName.LastIndexOf('/')) : null;
                if (directories != null) Directory.CreateDirectory(directories);
                if (dumpFileName.EndsWith(".gz") || dumpFileName.EndsWith(".gzip"))
                    CompressionUtil.WriteGzipText(dumpFileName, content);
                else
                    await File.WriteAllTextAsync(dumpFileName, content);
            }

            var returnObject = JsonConvert.DeserializeObject<T>(content);

            if (deserializedDump && !string.IsNullOrEmpty(dumpFileName))
            {
                var deserializedFileName = dumpFileName.Insert(dumpFileName.LastIndexOf(".", StringComparison.Ordinal), "_deserialized");
                var deserializedText = JsonConvert.SerializeObject(returnObject, Formatting.Indented);
                if (dumpFileName.EndsWith(".gz") || dumpFileName.EndsWith(".gzip"))
                    CompressionUtil.WriteGzipText(deserializedFileName, deserializedText);
                else
                    await File.WriteAllTextAsync(deserializedFileName, deserializedText);
            }

            return returnObject;
        }

        // Generic GET returning object.
        protected virtual async Task<T> ApiGet<T>(Uri endpointUri, string dumpFileName = null, bool deserializedDump = false)
            => await ApiRequest<T>(ApiRequestType.Get, endpointUri, null, null, dumpFileName, deserializedDump);

        // Generic POST returning object.
        protected virtual async Task<T> ApiPost<T>(Uri endpointUri, object obj, string mediaType = null, string dumpFileName = null, bool deserializedDump = false)
            => await ApiRequest<T>(ApiRequestType.Post, endpointUri, obj, mediaType, dumpFileName, deserializedDump);

        // Generic PUT returning object.
        protected virtual async Task<T> ApiPut<T>(Uri endpointUri, object obj, string mediaType = null, string dumpFileName = null, bool deserializedDump = false)
            => await ApiRequest<T>(ApiRequestType.Put, endpointUri, obj, mediaType, dumpFileName, deserializedDump);

        // Generic DELETE returning object.
        protected virtual async Task<T> ApiDelete<T>(Uri endpointUri, object obj, string mediaType = null, string dumpFileName = null, bool deserializedDump = false)
            => await ApiRequest<T>(ApiRequestType.Delete, endpointUri, obj, mediaType, dumpFileName, deserializedDump);

    }
}
