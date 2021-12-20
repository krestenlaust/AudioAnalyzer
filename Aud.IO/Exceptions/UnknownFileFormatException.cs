namespace Aud.IO.Exceptions
{
    /// <summary>
    /// Exception thrown when the file format declared in the file is unexpected.
    /// </summary>
    public class UnknownFileFormatException : System.Exception
    {
        public UnknownFileFormatException(string message)
            : base(message) { }
    }
}
