using System;
using System.Net;

namespace Weather_API.Exceptions
{
    public class HttpException : Exception
    {
        public BadResult _badResult { get; set; }
        public HttpStatusCode _statusCode { get; set; }
        public HttpException(HttpStatusCode statusCode, BadResult badResult):base("Http error")
        {
            _badResult = badResult;
            _statusCode = statusCode;
        }
    }
}
