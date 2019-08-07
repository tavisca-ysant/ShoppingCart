using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart
{
    public class ProductCategoryFactory
    {
        public static Category GetCategory(string productName)
        {
            switch (productName)
            {
                case "milk":
                case "cheese": return Category.Dairy;
                case "book":
                case "pen": return Category.Educational;
                case "mobile":
                case "laptop": return Category.Gadgets;
                default:
                    throw new InvalidProductCategoryException();
            }

        }
    }
}
