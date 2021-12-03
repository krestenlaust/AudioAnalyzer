using System;

namespace Aud.IO.Exceptions
{
    public class MissingSubchunkException : Exception
    {
        public MissingSubchunkException(string message) : base(message) { }
    }
}
