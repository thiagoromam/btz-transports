using System;

namespace BtzTransports.Exceptions
{
    public class CommonException : Exception
    {
        public CommonException() { }
        public CommonException(string message, Exception inner = null)
            : base(message, inner) { }
    }
}
