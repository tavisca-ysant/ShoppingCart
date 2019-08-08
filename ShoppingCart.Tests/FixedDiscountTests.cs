using System;
using System.Collections.Generic;
using Xunit;

namespace ShoppingCart.Tests
{
    public class FixedDiscountTests
    {
        private static Product product1 = new Product("mobile", 10000);
        private static Product product2 = new Product("laptop", 40000);

        private static Product product3 = new Product("book", 1000);

        private CartItem cartItem1 = new CartItem(product1, 2);
        private CartItem cartItem2 = new CartItem(product2, 1);
        private CartItem cartItem3 = new CartItem(product3, 4);
        private List<CartItem> cartList = new List<CartItem>();
        
        [Fact]
        public void Check_for_fixed_discount()
        {
            cartList.Add(cartItem1);
            cartList.Add(cartItem2);
            cartList.Add(cartItem3);
            var Discount = DiscountFactory.GetDiscountType("fixed");
            Assert.Equal(57600, Discount.GetDiscountedTotal(cartList));
        }

    }
}
