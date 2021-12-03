using System;

namespace Aud.IO.Exceptions
{
    public class UnknownFileFormatException : Exception
    {
        public UnknownFileFormatException(string message) : base(message) { }
    }
}
