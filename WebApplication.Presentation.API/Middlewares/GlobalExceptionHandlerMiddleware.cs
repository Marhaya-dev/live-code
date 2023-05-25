using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;
using System;
using System.Text.Json;
using System.Data.SqlClient;

namespace TaskMaster.Presentation.API.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionHandlerMiddleware> logger
        )
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (SqlException ex)
            {
                _logger.LogError($@"[Message:{ex.Message}]");
                _logger.LogError($@"[StackTrace:{ex.StackTrace}]");

                await ReturnHttpResponse(context, (int)HttpStatusCode.BadRequest, $"{ex.Message}.");
            }
            catch (Exception ex)
            {
                _logger.LogError($@"[Message:{ex.Message}]");
                _logger.LogError($@"[StackTrace:{ex.StackTrace}]");

                await ReturnHttpResponse(context, (int)HttpStatusCode.InternalServerError, $"{ex.Message}");
            }
        }

        private static Task ReturnHttpResponse(HttpContext context, int statusCode, string message)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var result = JsonSerializer.Serialize(new
            {
                statusCode = statusCode,
                message = message
            });

            return context.Response.WriteAsync(result);
        }
    }
}
