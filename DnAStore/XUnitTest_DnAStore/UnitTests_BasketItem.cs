using DnAStore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTest_DnAStore
{
    public class UnitTests_BasketItem
    {
        [Fact]
        public static void TestGetSetID()
        {
            BasketItem basketItem = new BasketItem();
            Assert.Equal(0, basketItem.ID);
            basketItem.ID = 1;
            Assert.Equal(1, basketItem.ID);
        }

        [Fact]
        public static void TestGetSetBasketID()
        {
            BasketItem basketItem = new BasketItem();
            Assert.Equal(0, basketItem.BasketID);
            basketItem.BasketID = 1;
            Assert.Equal(1, basketItem.BasketID);
        }

        [Fact]
        public static void TestGetSetProductID()
        {
            BasketItem basketItem = new BasketItem();
            Assert.Equal(0, basketItem.ProductID);
            basketItem.ProductID = 1;
            Assert.Equal(1, basketItem.ProductID);
        }

        [Fact]
        public static void TestGetSetQuantity()
        {
            BasketItem basketItem = new BasketItem();
            Assert.Equal(0, basketItem.Quantity);
            basketItem.Quantity = 1;
            Assert.Equal(1, basketItem.Quantity);
        }

        [Fact]
        public static void TestGetSetBasket()
        {
            BasketItem basketItem = new BasketItem();
            Assert.Null(basketItem.Basket);
            basketItem.Basket = new Basket { ID = 1 };
            Assert.Equal(1, basketItem.Basket.ID);
        }

        [Fact]
        public static void TestGetSetProduct()
        {
            BasketItem basketItem = new BasketItem();
            Assert.Null(basketItem.Product);
            basketItem.Product = new Product { ID = 1 };
            Assert.Equal(1, basketItem.Product.ID);
        }

    }
}
