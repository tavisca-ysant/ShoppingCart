using System;
using System.Runtime.Serialization;

namespace ShoppingCart
{
    [Serializable]
    internal class InvalidDiscountException : Exception
    {
        public InvalidDiscountException()
        {
        }

        public InvalidDiscountException(string message) : base(message)
        {
        }

        public InvalidDiscountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDiscountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}