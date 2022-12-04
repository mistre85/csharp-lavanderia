using System.Runtime.Serialization;

[Serializable]
public class GettoniInsufficientiException : Exception
{
    private string v;
    private int numeroGettoni;

    public GettoniInsufficientiException()
    {
    }

    public GettoniInsufficientiException(string? message) : base(message)
    {
    }

    public GettoniInsufficientiException(string v, int numeroGettoni)
    {
        this.v = v;
        this.numeroGettoni = numeroGettoni;
    }

    public GettoniInsufficientiException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected GettoniInsufficientiException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}