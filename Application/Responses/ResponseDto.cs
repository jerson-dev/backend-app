using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public class ResponseDto<T>
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }

        public ResponseDto(HttpStatusCode code, string message, object? data)
        {
            Code = code;
            Message = message;
            Data = data;
        }
    }

    public class ResponseDto(HttpStatusCode code, string message, object? data = null)
    {
        public HttpStatusCode Code { get; set; } = code;
        public string Message { get; set; } = message;
        public object? Data { get; set; } = data;
    }
}
