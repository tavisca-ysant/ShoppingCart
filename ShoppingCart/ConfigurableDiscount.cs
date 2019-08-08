using System.Collections.Generic;

namespace ShoppingCart
{
    public class ConfigurableDiscount : IDiscount
    {
        private static Dictionary<string, double> _discountMap = new Dictionary<string, double>();
        private double _discountPercentage = 5;
        public double GetDiscountedTotal(List<CartItem> cartItemList)
        {
            double BilledAmount = 0;
            foreach(var item in cartItemList)
            {
                BilledAmount += item.TotalCost;
            }
            
            return BilledAmount - BilledAmount * (_discountPercentage / 100);
        }

        public void SetDiscount(double discount)
        {
            if (discount >= 0 && discount < 100)
                _discountPercentage = discount;
            else
                throw new InvalidDiscountException();
        }
        
    }

}
