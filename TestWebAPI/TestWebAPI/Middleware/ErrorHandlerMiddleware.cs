﻿using System.Net;
using Newtonsoft.Json;

namespace TestWebAPI.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestDelegate> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<RequestDelegate> logger)
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
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                switch (error)
                {
                    case AddException e:
                        //custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                        case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                        default:
                        //unhandeled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonConvert.SerializeObject(new { message = error.Message });
                _logger.LogError(result);
                await response.WriteAsync(result);
            }
        }
    }
}