using System;

namespace MultiTable
{
    public class UnsupportedTypeException : Exception
    {
        public UnsupportedTypeException() { }

        public UnsupportedTypeException(string message)
            : base(message) { }

        public UnsupportedTypeException(string message, Exception inner)
            : base(message, inner) { }
    }
}
