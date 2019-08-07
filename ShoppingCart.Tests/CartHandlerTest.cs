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

        [Fact]

        public void Check_availability_for_cart_item_milk()
        {
            _cartHandler.AddToCart(item1);
            Assert.True(_cartHandler.CartContainsItem(item1));
        }

        [Fact]

        public void Check_availability_for_cart_item_mobile()
        {
            _cartHandler.AddToCart(item2);
            Assert.True(_cartHandler.CartContainsItem(item2));
        }

        [Fact]
        public void Remove_item_from_cart_with_valid_quantity()
        {
            _cartHandler.AddToCart(item1);
            CartItem itemToRemove = new CartItem(product1, 2);
            _cartHandler.RemoveFromCart(itemToRemove);
            var Index = _cart.CartProducts.FindIndex(item => item.Equals(itemToRemove));
            Assert.Equal(1, _cart.CartProducts[Index].Quantity);
        }


        [Fact]
        public void Remove_item_from_cart_with_less_available_quantity()
        {
            _cartHandler.AddToCart(item1);
            CartItem itemToRemove = new CartItem(product1, 4);

            Assert.Throws<InsufficientProductQuantityException>(() => _cartHandler.RemoveFromCart(itemToRemove));
        }

        [Fact]
        public void Remove_item_from_cart_completely()
        {
            _cartHandler.AddToCart(item1);
            CartItem itemToRemove = new CartItem(product1, 3);
            _cartHandler.RemoveFromCart(itemToRemove);
            Assert.False(_cartHandler.CartContainsItem(itemToRemove));
        }

        [Fact]
        public void Remove_a_non_existing_product()
        {
            Assert.Throws<ProductDoesNotExistException>(() => _cartHandler.RemoveFromCart(item2));
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

        [Theory]
        [InlineData(Category.Dairy, 10)]
        [InlineData(Category.Educational, 5)]
        [InlineData(Category.Gadgets, 8)]
        public void Check_discount_of_an_item(Category category, int Discount)
        {
            Assert.Equal(Discount, _cartHandler.GetDiscount(category));
        }

        [Fact]
        public void Total_discounted_price()
        {
            _cartHandler.AddToCart(item1);
            _cartHandler.AddToCart(item2);
            
            Assert.Equal(10010, _cartHandler.GetAmountToBePaid());
        }
    }
}
