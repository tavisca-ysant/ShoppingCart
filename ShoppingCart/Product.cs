namespace ShoppingCart
{
    public class Product
    {
        public string Name { get;  }
        
        public double Price { get;  }
        public Category Category
        {
            get;
        }
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
            Category = ProductCategoryFactory.GetCategory(Name);
        }
    }
}