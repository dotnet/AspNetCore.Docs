using System;

namespace WebApiSample.Exceptions
{
    // <snippet_HttpResponseException>
    public class HttpResponseException : Exception
    {
        public int Status { get; set; } = 500;

        public object Value { get; set; }
    }
    // </snippet_HttpResponseException>
}
