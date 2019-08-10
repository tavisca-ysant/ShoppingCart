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
                case "configurable": ConfigurableDiscount.GetInstance();break;
                case "category": CategoricalDiscount.GetInstance();break;
            }
            throw new InvalidDiscountTypeException();
        }
    }
}
