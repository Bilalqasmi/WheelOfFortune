using BlazorApp.Shared;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;

namespace Api
{
    public class HttpTrigger
    {

        public HttpTrigger()
        {

        }

        [Function("ValidateCoupon")]
        public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequestData req)
        {

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<CouponRequest>(requestBody);

            var result = req.CreateResponse();

            if (data is null)
            {
                result.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return result;
            }

            ApiResponse response = data.CouponCode switch
            {
                "WINNER123" => new ApiResponse(true,"Vous avez gagné !","Un voyage à Bali")
                ,
                "USED123" => new ApiResponse(false,"Le bon a déjà été validé.", "", true)
                ,
                _ => new ApiResponse(false, "Vous avez perdu.","")
            };

            result.StatusCode = System.Net.HttpStatusCode.OK;
            await result.WriteAsJsonAsync(response);
            return result;
        }
    }
}
