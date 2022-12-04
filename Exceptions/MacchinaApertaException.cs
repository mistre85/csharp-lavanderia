using System.Runtime.Serialization;

[Serializable]
internal class MacchinaApertaException : Exception
{
    public MacchinaApertaException()
    {
    }

    public MacchinaApertaException(string? message) : base(message)
    {
    }

    public MacchinaApertaException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected MacchinaApertaException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}