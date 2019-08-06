using System;
using Xunit;
using System.Text;

namespace ShoppingCart.Tests
{
    public class CartHandlerTests
    {
        private static Cart _cart = new Cart();
        private static CartHandler _cartHandler = new CartHandler(_cart);
        private static CartItem item1 = new CartItem(new Product("iPhone", 70000), 2);
        private static CartItem item2 = new CartItem(new Product("trousers", 1000), 3);
        
        public void AddProducts()
        {
            _cartHandler.AddToCart(item1);
            _cartHandler.AddToCart(item2);
        }

        [Fact]

        public void Check_availability_for_cart_item_iPhone()
        {
            _cartHandler.AddToCart(item1);
            Assert.True(_cartHandler.CartContainsItem(item1));
        }

        [Fact]

        public void Check_availability_for_cart_item_trousers()
        {
            _cartHandler.AddToCart(item2);
            Assert.True(_cartHandler.CartContainsItem(item2));
        }

        

        [Fact]
        public void Check_total_amount_to_be_paid_for_individual_products()
        {
            AddProducts();
            Assert.Equal(2700, _cartHandler.GetAmountToBePaidForProduct("trousers"));
        }

    }
}
