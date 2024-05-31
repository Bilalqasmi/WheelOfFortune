using BlazorApp.Shared;
namespace BlazorApp.Client.Services.Contracts
{
    public interface ICodeValidationService
    {
        Task<ApiResponse> CheckCodeValidation(CouponRequest request);
    }
}
