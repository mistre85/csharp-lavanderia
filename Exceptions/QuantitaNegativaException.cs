using System.Runtime.Serialization;

[Serializable]
internal class QuantitaNegativaException : Exception
{
    public QuantitaNegativaException()
    {
    }

    public QuantitaNegativaException(string? message) : base(message)
    {
    }

    public QuantitaNegativaException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected QuantitaNegativaException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}