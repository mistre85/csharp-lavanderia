using System.Runtime.Serialization;

[Serializable]
internal class GettoneRifiutatoException : Exception
{
    public GettoneRifiutatoException()
    {
    }

    public GettoneRifiutatoException(string? message) : base(message)
    {
    }

    public GettoneRifiutatoException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected GettoneRifiutatoException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}