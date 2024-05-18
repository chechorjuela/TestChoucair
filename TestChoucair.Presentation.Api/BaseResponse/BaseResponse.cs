using TestChoucair.Application.Dto;
using System.Net;

namespace TestChoucair.Presentation.BaseResponse
{
    public static class BaseResponseResult
    {
        public static BaseResponse<T> CreateResponse<T>(T data, HttpStatusCode statusCode, string message = "")
        {
            return new BaseResponse<T>
            {
                Data = data,
                StatusCode = statusCode,
                Message = message
            };
        }
    }
}
