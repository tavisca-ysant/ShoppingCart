﻿using System;
using System.Runtime.Serialization;

namespace ShoppingCart
{
    [Serializable]
    public class InsufficientProductQuantityException : Exception
    {
        public InsufficientProductQuantityException()
        {
        }

        public InsufficientProductQuantityException(string message) : base(message)
        {
        }

        public InsufficientProductQuantityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsufficientProductQuantityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}