using System;
using System.Runtime.Serialization;

namespace ShoppingCart
{
    [Serializable]
    public class ProductDoesNotExistException : Exception
    {
        public ProductDoesNotExistException()
        {
        }

        public ProductDoesNotExistException(string message) : base(message)
        {
        }

        public ProductDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProductDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}