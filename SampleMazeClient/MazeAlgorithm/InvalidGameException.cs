using System;
using System.Runtime.Serialization;

namespace Vital.Games
{
    [Serializable]
    public class InvalidGameException : ApplicationException
    {
        public InvalidGameException()
        {
        }

        public InvalidGameException(string message) : base(message)
        {
        }

        public InvalidGameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidGameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}