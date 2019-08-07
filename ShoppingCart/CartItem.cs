using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart
{
    public class CartItem
    {
        public Product Product { private set; get; }
        public int Quantity { set; get; }
        public double TotalCost { private set; get; }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            TotalCost = Product.Price * Quantity;
        }

        public string ProductName
        {
            get => Product.Name;
        }

        public override bool Equals(object obj)
        {
            var item = obj as CartItem;
            return item != null &&
                   ProductName == item.ProductName;
        }
    }
}
