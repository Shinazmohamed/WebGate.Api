using Microsoft.AspNetCore.Cors.Infrastructure;
using Newtonsoft.Json;
using System.Net;
using WebGate.Shared;

namespace WebGate.Api.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _logger = logger.CreateLogger<CustomExceptionHandlerMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Unhandled exception caught");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var error = new Error(Shared.Enums.StatusCode.UnhandledException, exception);
            var response = new ApiResponse<Error>(error);

            var jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            var result = JsonConvert.SerializeObject(response, jsonSettings);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.Headers[CorsConstants.AccessControlAllowOrigin] = CorsConstants.AnyOrigin;
            await context.Response.WriteAsync(result);
        }
    }
}
