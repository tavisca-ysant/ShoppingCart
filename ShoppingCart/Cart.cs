using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart
{
    public class Cart
    {
        private List<CartItem> _cartProducts = new List<CartItem>();
        private CartStatus _cartStatus = CartStatus.Empty;

        public CartStatus CartStatus
        {
            get => _cartStatus;
            set => _cartStatus = value;
        }
        public List<CartItem> CartProducts
        {
            get => _cartProducts;
        }
    }
}
