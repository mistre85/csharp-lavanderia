using System.Runtime.Serialization;

namespace csharp_lavanderia.Exceptions
{
    public class ProgrammaSelezionatoInesistenteException : Exception
    {
        public ProgrammaSelezionatoInesistenteException()
        {
        }

        public ProgrammaSelezionatoInesistenteException(string? message) : base(message)
        {
        }

        public ProgrammaSelezionatoInesistenteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ProgrammaSelezionatoInesistenteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}