using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public static class ControllerExtensions
    {
        public static IActionResult CreateResponse(this Controller controller, HttpStatusCode statusCode, string message, object? data = null)
        {
            var responseDto = new ResponseDto(statusCode, message, data);
            return controller.StatusCode((int)statusCode, responseDto);
        }

        public class ResponseDto(HttpStatusCode code, string message, object? data = null)
        {
            public HttpStatusCode Code { get; set; } = code;
            public string Message { get; set; } = message;
            public object? Data { get; set; } = data;
        }
    }
}
