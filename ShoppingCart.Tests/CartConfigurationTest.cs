using System;
using Xunit;
using System.Text;

namespace ShoppingCart.Tests
{
    public class CartConfigurationTest
    {
        [Theory]
        [InlineData("iPhone")]
        [InlineData("trousers")]

        public void Check_discounts_for_individual_products(string ProductName)
        {
            Assert.Equal(10, Vendor.GetDiscountPercentage(ProductName));
        }

    }
}
