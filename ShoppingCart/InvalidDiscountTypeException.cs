using System;
using System.Runtime.Serialization;

namespace ShoppingCart
{
    [Serializable]
    public class InvalidDiscountTypeException : Exception
    {
        public InvalidDiscountTypeException()
        {
        }

        public InvalidDiscountTypeException(string message) : base(message)
        {
        }

        public InvalidDiscountTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDiscountTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}