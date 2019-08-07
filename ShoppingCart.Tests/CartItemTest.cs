using System;
using Xunit;

namespace ShoppingCart.Tests
{
    public class CartItemTest
    {
        private CartItem _cartItem;
        [Theory]
        [InlineData("mobile", 8000)]
        [InlineData("pen", 10)]
        public void Check_for_correct_product_name(string ProductName, double Price)
        {
            Product product = new Product(ProductName, Price);
            _cartItem = new CartItem(product, 2);
            Assert.Equal(ProductName, _cartItem.ProductName);
        }
        [Theory]
        [InlineData("milk", 80, 3)]
        [InlineData("laptop", 50000, 4)]
        public void Check_for_total_price_of_Product(string ProductName, double Price, int Quantity)
        {
            Product product = new Product(ProductName, Price);
            _cartItem = new CartItem(product, Quantity);
            Assert.Equal(Price * Quantity, _cartItem.TotalCost);
        }

        [Theory]
        [InlineData("mobile", 8000, 3)]
        [InlineData("cheese", 100, 4)]
        public void Check_whether_cart_items_are_same(string ProductName, double Price, int Quantity)
        {
            Product product = new Product(ProductName, Price);
            _cartItem = new CartItem(product, Quantity);
            Assert.True(new CartItem(new Product(ProductName, Price), Quantity).Equals(_cartItem));
        }

    }
}
