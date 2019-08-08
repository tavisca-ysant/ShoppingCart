using System;
using System.Collections.Generic;
using Xunit;

namespace ShoppingCart.Tests
{
    public class DiscountFactoryTests
    {
        [Fact]
        public void Check_for_valid_discount_type()
        {
            Assert.IsType<CategoricalDiscount>(DiscountFactory.GetDiscountType("category"));
        }

        [Fact]
        public void Check_for_invalid_discount_type()
        {
            Assert.Throws<InvalidDiscountTypeException>(() => DiscountFactory.GetDiscountType("aaa"));
        }
    }
}
