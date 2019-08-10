using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ShoppingCart
{
    public sealed class CategoricalDiscount : IDiscount
    {
        private static CategoricalDiscount _categoricalDiscount = null;
        private CategoricalDiscount()
        {

        }
        private static Dictionary<Category, double> _discountMap = new Dictionary<Category, double>();

        public static CategoricalDiscount GetInstance()
        {
            //Singleton design pattern used for categorical discount as it wont
            //change frequently
            if (_categoricalDiscount == null)
                _categoricalDiscount = new CategoricalDiscount();

            return _categoricalDiscount;
        }

        public void SetDiscount(Category category, double discount)
        {
            if (discount < 0 || discount >= 100)
                throw new InvalidDiscountException();
            if (!_discountMap.ContainsKey(category))
                _discountMap.Add(category, discount);
            else
                _discountMap[category] = discount;
        }

        public static double GetDiscountPercentage(Category category)
        {
            var exists = _discountMap.TryGetValue(category, out double discount);
            if(exists)
                return discount;
            throw new InvalidProductCategoryException();
        }

        public double GetDiscountedTotal(List<CartItem> cartItemList)
        {
            double finalAmountToBePaid = 0;
            
            // var index = 0;
            foreach (var item in cartItemList)
            {
                var discount = GetDiscountPercentage(item.Product.Category);
                finalAmountToBePaid += item.TotalCost - ((item.TotalCost * discount) / 100);
            }
            return finalAmountToBePaid;
        }

        
    }
}
