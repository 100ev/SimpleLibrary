using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace TestWebAPI.Middleware
{
    public class GetExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestDelegate> _logger;

        public GetExceptionMiddleware(RequestDelegate next, ILogger<RequestDelegate> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {   
            
        }
    }
}
