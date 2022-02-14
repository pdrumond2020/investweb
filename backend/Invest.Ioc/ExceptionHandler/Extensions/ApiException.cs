using System;
using System.Net;

namespace Invest.Ioc.ExceptionHandler.Extensions
{
    [Serializable]
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public ApiException()
        { }

        public ApiException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public ApiException(HttpStatusCode statusCode, string message) : base(message)
        {
            this.StatusCode = statusCode;
        }

        public ApiException(string message, HttpStatusCode statusCode, Exception innerException = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public ApiException(string message) : base(message)
        {
            StatusCode = HttpStatusCode.InternalServerError;
        }

        public ApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApiException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}