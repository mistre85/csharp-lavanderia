using System.Runtime.Serialization;

[Serializable]
public class LivelloNegativoSerbatoioExcpetion : Exception
{
    public LivelloNegativoSerbatoioExcpetion()
    {
    }

    public LivelloNegativoSerbatoioExcpetion(string? message) : base(message)
    {
    }

    public LivelloNegativoSerbatoioExcpetion(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected LivelloNegativoSerbatoioExcpetion(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}