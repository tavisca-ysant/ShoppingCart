using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart
{
    public class CategoricalDiscount
    {
        private static Dictionary<Category, double> _discountMap = new Dictionary<Category, double>()
        {
            {Category.Dairy, 10 },
            {Category.Educational, 5 },
            {Category.Gadgets, 8 }
        };

        public void UpdateDiscount(Category category, double discount)
        {
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
    }
}
