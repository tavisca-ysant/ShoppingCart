using System;
using System.Runtime.Serialization;

namespace ShoppingCart
{
    [Serializable]
    public class InvalidCartStateException : Exception
    {
        public InvalidCartStateException()
        {
        }

        public InvalidCartStateException(string message) : base(message)
        {
        }

        public InvalidCartStateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCartStateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}