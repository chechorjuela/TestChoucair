using System.Net;

namespace TestChoucair.Application.Dto{
    public class BaseResponse<T>{
        public T Data { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }

    }


}