using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api
{
    public class ValidateCoupon
    {
        private readonly ILogger _logger;

        public ValidateCoupon(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HttpTrigger>();
        }


        [Function("ValidateCoupon")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestData req,
        ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<CouponRequest>(requestBody);

            if (data is null)
                return new BadRequestResult();

            ApiResponse response = data.CouponCode switch
            {
                "WINNER123" => new ApiResponse
                {
                    IsSuccess = true,
                    Message = "Vous avez gagné !",
                    Prize = "Un voyage à Bali"
                },
                "USED123" => new ApiResponse
                {
                    IsSuccess = false,
                    Message = "Le bon a déjà été validé.",
                    Prize = null
                },
                _ => new ApiResponse
                {
                    IsSuccess = false,
                    Message = "Vous avez perdu.",
                    Prize = null
                },
            };
            return new OkObjectResult(response);
        }
    }
}
