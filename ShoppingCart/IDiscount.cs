using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart
{
    public interface IDiscount
    {
        double GetDiscountedTotal(List<CartItem> cartItemList);
    }

}
