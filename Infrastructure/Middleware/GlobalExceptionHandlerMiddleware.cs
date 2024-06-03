using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.Configuration.ControllerExtensions;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Domain.Repositories;
using Infrastructure.Repositories;
using Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Middleware
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, ApplicationDbContext dbcontext)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, dbcontext);
            }
        }


        private async Task HandleExceptionAsync(HttpContext context, Exception exception, ApplicationDbContext dbcontext)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            string message = "Internal Server Error";

            if(exception is FileNotFoundException)
            {
                statusCode = HttpStatusCode.NotFound;
                message = exception.Message ?? "File Not Found";
            }
            else if (exception is ArgumentException || exception is ArgumentNullException || exception is ArgumentOutOfRangeException)
            {
                statusCode = HttpStatusCode.BadRequest;
                message = exception.Message ?? "Bad Request";
            }
            else if (exception is UnauthorizedAccessException)
            {
                statusCode = HttpStatusCode.Unauthorized;
                message = exception.Message ?? "Unauthorized";
            }
            else if (exception is ValidationException)
            {
                statusCode = HttpStatusCode.BadRequest;
                message = exception.Message ?? "Not Valid";
            }

            if (statusCode == HttpStatusCode.InternalServerError)
            {
                LogException(exception, dbcontext);
            }
            var responseDto = new ResponseDto(statusCode, message);
            var jsonResponse = JsonConvert.SerializeObject(responseDto);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(jsonResponse);
        }
        private void LogException(Exception exception, ApplicationDbContext dbcontext)
        {
            try
            {
                _logger.LogError(exception, "Unhandled exception caught.");
                Console.WriteLine($"\n Exception Message: {exception.Message}");
                Console.WriteLine($"\n Inner Exception: {exception.InnerException}");
                Console.WriteLine($"\n StackTrace exception: {exception.StackTrace}");

                var newLogException = new LogException
                {
                    Timestamp = DateTime.Now,
                    Message = exception.Message,
                    InnerException = exception.InnerException?.ToString() ?? string.Empty,
                    StackTrace = exception.StackTrace?.ToString() ?? string.Empty,
                };
            }
            catch (Exception)
            {
                return;
            }            
        }

    }
}
