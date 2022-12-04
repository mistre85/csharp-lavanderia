using System.Runtime.Serialization;

namespace csharp_lavanderia.Exceptions
{
   
    public class ProgrammaNonSelezionatoException : Exception
    {
        public ProgrammaNonSelezionatoException()
        {
        }

        public ProgrammaNonSelezionatoException(string? message) : base(message)
        {
        }

        public ProgrammaNonSelezionatoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProgrammaNonSelezionatoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}