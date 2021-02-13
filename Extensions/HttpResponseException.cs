using System;
using System.Net;

namespace AppWeb.Configurations
{
    public class HttpResponseException: Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public HttpResponseException(HttpStatusCode statusCode, string content) : base(content)
        {
            StatusCode = statusCode;
        }
    }
}
