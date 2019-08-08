using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart
{
    public class DiscountFactory
    {
        public static IDiscount GetDiscountType(string discountType)
        {
            switch (discountType)
            {
                case "fixed": return new FixedDiscount();
                case "configurable": return new ConfigurableDiscount();
                case "category": return new CategoricalDiscount();
                
            }
            throw new InvalidDiscountTypeException();
        }
    }
}
