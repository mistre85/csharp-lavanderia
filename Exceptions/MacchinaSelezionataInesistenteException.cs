using System.Runtime.Serialization;

[Serializable]
internal class MacchinaSelezionataInesistenteException : Exception
{
    public MacchinaSelezionataInesistenteException()
    {
    }

    public MacchinaSelezionataInesistenteException(string? message) : base(message)
    {
    }

    public MacchinaSelezionataInesistenteException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected MacchinaSelezionataInesistenteException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}