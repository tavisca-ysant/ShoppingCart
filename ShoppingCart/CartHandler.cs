﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart
{
    public class CartHandler
    {
        private Cart _cart;
                
        public CartHandler(Cart cart)
        {
            _cart = cart;
            _cart.CartStatus = CartStatus.Active;
        }

        public bool CartContainsItem(CartItem cartItem)
        {
            for(int i = 0; i < _cart.CartStorage.Count; i++)
            {
                if (_cart.CartStorage[i].ProductName.Equals(cartItem.ProductName))
                    return true;
            }
            return false;
        }

        public void AddToCart(CartItem cartItem)
        {
            if (_cart.CartStatus != CartStatus.Active)
                throw new InvalidCartStateException();
            if (CartContainsItem(cartItem))
            {
                var index = _cart.CartStorage.FindIndex(Item => Item.Equals(cartItem));
                _cart.CartStorage[index].Quantity = _cart.CartStorage[index].Quantity + cartItem.Quantity;

            }
            else
                _cart.CartStorage.Add(cartItem);
        }

        public double GetDiscount(Category category)
        {
           return CategoricalDiscount.GetDiscountPercentage(category);
        }

        public double GetAmountToBePaid()
        {
            double finalAmountToBePaid = 0;
            _cart.CartStatus = CartStatus.Paid;
           // var index = 0;
            foreach(var item in _cart.CartStorage)
            {
                var discount = GetDiscount(item.Product.Category);
                finalAmountToBePaid += item.TotalCost - ((item.TotalCost * discount) / 100);
            }
            return finalAmountToBePaid;
        }

        

        public void RemoveFromCart(CartItem cartItem)
        {
            if (_cart.CartStatus != CartStatus.Active)
                throw new InvalidCartStateException();
            if (!CartContainsItem(cartItem))
                throw new ProductDoesNotExistException();
            var index = _cart.CartStorage.FindIndex(Item => Item.Equals(cartItem));
            var ItemQuantity = _cart.CartStorage[index].Quantity;
            if (ItemQuantity < cartItem.Quantity)
                throw new InsufficientProductQuantityException();
            else if (ItemQuantity > cartItem.Quantity)
                _cart.CartStorage[index].Quantity = ItemQuantity - cartItem.Quantity;
            else
                _cart.CartStorage.RemoveAt(index);
        }
    }
}
