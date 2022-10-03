﻿using System.Net;

namespace TestWebAPIModel.Responses
{
    public class BaseResponse
    {
        public HttpStatusCode HttpStatusCode { get; init; }
        public string Message { get; set; }
    }
}
