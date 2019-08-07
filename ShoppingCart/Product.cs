namespace ShoppingCart
{
    public class Product
    {
        public string Name { get;  }
        private Category _category;
        public double Price { get;  }
        public Category Category
        {
            get => _category;
        }
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
            _category = ProductCategoryFactory.GetCategory(Name);
        }
    }
}