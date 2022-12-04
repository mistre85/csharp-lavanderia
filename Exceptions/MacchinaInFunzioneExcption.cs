using System.Runtime.Serialization;

namespace csharp_lavanderia.Exceptions
{
  
    public class MacchinaInFunzioneExcption : Exception
    {
        public MacchinaInFunzioneExcption()
        {
        }

        public MacchinaInFunzioneExcption(string? message) : base(message)
        {
        }

        public MacchinaInFunzioneExcption(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MacchinaInFunzioneExcption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}