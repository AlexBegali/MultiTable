using System;

namespace MultiTable
{
    public class EmptyEnumException : Exception
    {
        public EmptyEnumException() { }

        public EmptyEnumException(string message)
            : base(message) { }

        public EmptyEnumException(string message, Exception inner)
            : base(message, inner) { }
    }
}
