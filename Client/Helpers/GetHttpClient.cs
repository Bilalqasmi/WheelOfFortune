

using System.Net.Http;

namespace BlazorApp.Client.Helpers
{
    public class GetHttpClient(IHttpClientFactory httpClientFactory)
    {
        private const string HeaderKey = "Authorization";

        public HttpClient GetPublicHttpClient()
        {
            var client = httpClientFactory.CreateClient("SystemApiClient");
            client.DefaultRequestHeaders.Remove(HeaderKey);
            return client;
        }
    }
}
