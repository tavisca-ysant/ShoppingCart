using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart
{
    public class Vendor
    {
        private static Dictionary<string, double> _discountMap = new Dictionary<string, double>()
        {
            { "iPhone", 10 },
            {"trousers", 10 }
         };

        public static double GetDiscountPercentage(string ProductName)
        {
            _discountMap.TryGetValue(ProductName, out double Discount);
            return Discount;
        }
    }
}
