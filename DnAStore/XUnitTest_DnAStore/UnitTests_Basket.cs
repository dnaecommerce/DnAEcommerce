using DnAStore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTest_DnAStore
{
    public class UnitTests_Basket
    {
        [Fact]
        public static void TestGetID()
        {
            Basket basket = new Basket();
            Assert.Equal(0, basket.ID);
            basket.ID = 1;
            Assert.Equal(1, basket.ID);
        }

        [Fact]
        public static void TestGetSetUserName()
        {
            Basket basket = new Basket();
            Assert.Null(basket.UserName);
            basket.UserName = "TestUserName";
            Assert.Equal("TestUserName", basket.UserName);
        }

        [Fact]
        public static void TestGetSubtotal()
        {
            Basket basket = new Basket();
            Assert.Equal(0, basket.Subtotal);
            basket.Subtotal = 1.00m;
            Assert.Equal(1.00m, basket.Subtotal);
        }

        [Fact]
        public static void TestGetBasketItems()
        {
            Basket basket = new Basket();
            Assert.Null(basket.BasketItems);
            basket.BasketItems = new List<BasketItem>();
            Assert.Empty(basket.BasketItems);
        }

    }
}
