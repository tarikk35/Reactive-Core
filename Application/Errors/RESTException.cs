using System;
using System.Net;

namespace Application.Errors
{
    public class RESTException : Exception
    {
        public RESTException(HttpStatusCode code,object errors=null)
        {
            Code = code;
            Errors = errors;
        }

        public HttpStatusCode Code { get; }
        public object Errors { get; }
    }
}