using System;
using Xunit;
using System.Text;

namespace ShoppingCart.Tests
{
    public class CartHandlerTest
    {
        private static Cart _cart = new Cart();
        private static CartHandler _cartHandler = new CartHandler(_cart);
        private static Product product1 = new Product("milk", 300);
        private static Product product2 = new Product("mobile",5000);
        private static CartItem item1 = new CartItem(product1, 3);
        private static CartItem item2 = new CartItem(product2, 2);
        public void AddProducts()
        {
            _cartHandler.AddToCart(item1);
            _cartHandler.AddToCart(item2);
        }

        [Theory]
        [InlineData(CartStatus.Empty)]
        [InlineData(CartStatus.Paid)]
        public void Invalid_cart_state_while_adding_to_cart(CartStatus cartStatus)
        {
            _cart.CartStatus = cartStatus;
            Assert.Throws<InvalidCartStateException>(() => _cartHandler.AddToCart(item1));
        }

        [Theory]
        [InlineData(CartStatus.Empty)]
        [InlineData(CartStatus.Paid)]
        public void Invalid_cart_state_while_removing_from_cart(CartStatus cartStatus)
        {
            _cart.CartStatus = cartStatus;
            Assert.Throws<InvalidCartStateException>(() => _cartHandler.RemoveFromCart(item1));
        }

    }
}
