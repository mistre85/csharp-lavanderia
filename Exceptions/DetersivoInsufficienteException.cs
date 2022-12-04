using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lavanderia.Exceptions
{
    public class DetersivoInsufficienteException : Exception
    {
        public DetersivoInsufficienteException()
        {
         
        }

        public DetersivoInsufficienteException(string? message) : base(message)
        {
        }

        public DetersivoInsufficienteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DetersivoInsufficienteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}


