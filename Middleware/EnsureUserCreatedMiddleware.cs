using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;
using WebGate.Api.Extensions;

namespace WebGate.Api.Middleware
{
    public class EnsureUserCreatedMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger _logger;

        public EnsureUserCreatedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

    }
}
