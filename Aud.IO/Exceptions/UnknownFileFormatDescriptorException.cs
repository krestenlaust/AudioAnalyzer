using System;

namespace Aud.IO.Exceptions
{
    public class UnknownFileFormatDescriptorException : Exception
    {
        public UnknownFileFormatDescriptorException(string message) : base(message) { }
    }
}
