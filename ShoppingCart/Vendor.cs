using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart
{
    public class Vendor
    {
        public void SetCategoryDiscount(Category category, double discount)
        {
            var categoryDiscount = (CategoricalDiscount)DiscountFactory.GetDiscountType("category");
            categoryDiscount.SetDiscount(category, discount);
        }

        public void SetConfigurableDiscount(double discount)
        {
            var configurableDiscount = (ConfigurableDiscount)DiscountFactory.GetDiscountType("category");
            configurableDiscount.SetDiscount(discount);
        }

    }
}
