using System.Runtime.Serialization;

[Serializable]
internal class LivelloMassimoSerbatoioException : Exception
{
    public LivelloMassimoSerbatoioException()
    {
    }

    public LivelloMassimoSerbatoioException(string? message) : base(message)
    {
    }

    public LivelloMassimoSerbatoioException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected LivelloMassimoSerbatoioException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}