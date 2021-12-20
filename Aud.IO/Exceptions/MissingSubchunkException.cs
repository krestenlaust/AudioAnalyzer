namespace Aud.IO.Exceptions
{
    public class MissingSubchunkException : System.Exception
    {
        public MissingSubchunkException(string message)
            : base(message) { }
    }
}
