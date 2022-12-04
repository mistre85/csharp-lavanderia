using System.Runtime.Serialization;

[Serializable]
public class AmmorbidenteInsufficienteException : Exception
{
    public AmmorbidenteInsufficienteException()
    {
    }

    public AmmorbidenteInsufficienteException(string? message) : base(message)
    {
    }

    public AmmorbidenteInsufficienteException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected AmmorbidenteInsufficienteException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}