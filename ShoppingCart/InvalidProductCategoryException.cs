using System;
using System.Runtime.Serialization;

namespace ShoppingCart
{
    [Serializable]
    public class InvalidProductCategoryException : Exception
    {
        public InvalidProductCategoryException()
        {
        }

        public InvalidProductCategoryException(string message) : base(message)
        {
        }

        public InvalidProductCategoryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidProductCategoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}