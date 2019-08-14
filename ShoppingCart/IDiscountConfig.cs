using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart
{
    public interface IDiscountConfig
    {
        void SetDiscount(Product product, double discount);
    }
}
