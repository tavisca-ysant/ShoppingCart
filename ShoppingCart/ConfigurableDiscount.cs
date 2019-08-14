using System.Collections.Generic;

namespace ShoppingCart
{
    public class ConfigurableDiscount : IDiscount
    {
        private static Dictionary<string, double> _discountMap = new Dictionary<string, double>();
        private static ConfigurableDiscount _configurableDiscount = null;
        private double _discountPercentage = 5;

        private ConfigurableDiscount()
        {

        }

        public static ConfigurableDiscount GetInstance()
        {
            if (_configurableDiscount == null)
                _configurableDiscount = new ConfigurableDiscount();
            return _configurableDiscount;
        }

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
