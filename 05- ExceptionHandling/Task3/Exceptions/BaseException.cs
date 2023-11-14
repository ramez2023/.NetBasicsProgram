using System;

namespace Task3.Exceptions
{
    public class BaseException : Exception
    {
        public string Message { get; set; }
        public int Code { get; set; }

        public BaseException()
        { }

        public BaseException(string message)
            : base(message)
        { }
    }
}
