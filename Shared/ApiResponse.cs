using System;

namespace BlazorApp.Shared
{
    public class ApiResponse
    {
        public ApiResponse() { }

        public ApiResponse(bool isSuccess, string message, string prize, bool isUsed = false)
        {
            IsSuccess = isSuccess;
            Message = message;
            Prize = prize;
            IsUsed = isUsed;
        }
        public bool IsSuccess { get; set; }
        public bool IsUsed { get; set; }
        public string Message { get; set; }
        public string Prize { get; set; }
    }
}