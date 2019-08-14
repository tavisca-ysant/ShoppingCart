using System.Collections.Generic;

namespace ShoppingCart
{
    public class FixedDiscount : IDiscount
    {
        private const double DiscountPercentage = 10;
        public double GetDiscountedTotal(List<CartItem> cartItemList)
        {
            double total = 0;
            foreach(var item in cartItemList)
            {
                total += item.TotalCost;
            }
            return total - total * (DiscountPercentage / 100);
        }
    }

}
