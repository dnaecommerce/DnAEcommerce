using DnAStore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTest_DnAStore
{
    public class UnitTests_OrderItemItem
    {
        [Fact]
        public static void TestGetSetID()
        {
            OrderItem orderItem = new OrderItem();
            Assert.Equal(0, orderItem.ID);
            orderItem.ID = 1;
            Assert.Equal(1, orderItem.ID);
        }

        [Fact]
        public static void TestGetSetOrderID()
        {
            OrderItem orderItem = new OrderItem();
            Assert.Equal(0, orderItem.OrderID);
            orderItem.OrderID = 1;
            Assert.Equal(1, orderItem.OrderID);
        }

        [Fact]
        public static void TestGetSetProductID()
        {
            OrderItem orderItem = new OrderItem();
            Assert.Equal(0, orderItem.ProductID);
            orderItem.ProductID = 1;
            Assert.Equal(1, orderItem.ProductID);
        }

        [Fact]
        public static void TestGetSetQuantity()
        {
            OrderItem orderItem = new OrderItem();
            Assert.Equal(0, orderItem.Quantity);
            orderItem.Quantity = 1;
            Assert.Equal(1, orderItem.Quantity);
        }

        [Fact]
        public static void TestGetSetOrder()
        {
            OrderItem orderItem = new OrderItem();
            Assert.Null(orderItem.Order);
            orderItem.Order = new Order { ID = 1 };
            Assert.Equal(1, orderItem.Order.ID);
        }

        [Fact]
        public static void TestGetSetProduct()
        {
            OrderItem orderItem = new OrderItem();
            Assert.Null(orderItem.Product);
            orderItem.Product = new Product { ID = 1 };
            Assert.Equal(1, orderItem.Product.ID);
        }


    }
}
