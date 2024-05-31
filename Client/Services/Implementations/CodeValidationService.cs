using BlazorApp.Client.Helpers;
using BlazorApp.Client.Services.Contracts;
using BlazorApp.Shared;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BlazorApp.Client.Services.Implementations
{
    public class CodeValidationService(GetHttpClient getHttpClient) : ICodeValidationService
    {
        public const string CodeValidationUrl = "api/validatecoupon";

        private readonly JsonSerializerSettings _defaultJsonSerializerSettings = new JsonSerializerSettings
        {
            DateFormatString = "yyyy_MM-ddTHH:mm:ss"
        };

        public async Task<ApiResponse> CheckCodeValidation(CouponRequest request)
        {
            try
            {
                var httpClient = getHttpClient.GetPublicHttpClient();

                var result = await httpClient.PostAsJsonAsync($"{CodeValidationUrl}", request);

                var responseBody = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ApiResponse>(responseBody, _defaultJsonSerializerSettings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
