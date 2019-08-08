﻿using System;
using System.Runtime.Serialization;

namespace ShoppingCart
{
    [Serializable]
    public class InvalidProductQuantityException : Exception
    {
        public InvalidProductQuantityException()
        {
        }

        public InvalidProductQuantityException(string message) : base(message)
        {
        }

        public InvalidProductQuantityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidProductQuantityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}