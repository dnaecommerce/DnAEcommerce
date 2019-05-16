using DnAStore.Models;
using System.Collections.Generic;
using Xunit;

namespace XUnitTest_DnAStore
{
    public class UnitTests_Order
    {
        [Fact]
        public static void TestGetSetID()
        {
            Order order = new Order();
            Assert.Equal(0, order.ID);
            order.ID = 1;
            Assert.Equal(1, order.ID);
        }

        [Fact]
        public static void TestGetSetUserName()
        {
            Order order = new Order();
            Assert.Null(order.UserName);
            order.UserName = "TestUserName";
            Assert.Equal("TestUserName", order.UserName);
        }

        [Fact]
        public static void TestGetSetFirstName()
        {
            Order order = new Order();
            Assert.Null(order.FirstName);
            order.FirstName = "TestFirstName";
            Assert.Equal("TestFirstName", order.FirstName);
        }

        [Fact]
        public static void TestGetSetLastName()
        {
            Order order = new Order();
            Assert.Null(order.LastName);
            order.LastName = "TestLastName";
            Assert.Equal("TestLastName", order.LastName);
        }

        [Fact]
        public static void TestGetSetAddress()
        {
            Order order = new Order();
            Assert.Null(order.Address);
            order.Address = "TestAddress";
            Assert.Equal("TestAddress", order.Address);
        }

        [Fact]
        public static void TestGetSetCity()
        {
            Order order = new Order();
            Assert.Null(order.City);
            order.City = "TestCity";
            Assert.Equal("TestCity", order.City);
        }

        [Fact]
        public static void TestGetSetState()
        {
            Order order = new Order();
            Assert.Null(order.State);
            order.State = "TestState";
            Assert.Equal("TestState", order.State);
        }

        [Fact]
        public static void TestGetSetPostalCode()
        {
            Order order = new Order();
            Assert.Null(order.PostalCode);
            order.PostalCode = "TestPostalCode";
            Assert.Equal("TestPostalCode", order.PostalCode);
        }

        [Fact]
        public static void TestGetSetPhoneNumber()
        {
            Order order = new Order();
            Assert.Null(order.PhoneNumber);
            order.PhoneNumber = "TestPhoneNumber";
            Assert.Equal("TestPhoneNumber", order.PhoneNumber);
        }

        [Fact]
        public static void TestGetSetSubtotal()
        {
            Order order = new Order();
            Assert.Equal(0, order.Subtotal);
            order.Subtotal = 1.00m;
            Assert.Equal(1.00m, order.Subtotal);
        }

        [Fact]
        public static void TestGetSetFinalTotal()
        {
            Order order = new Order();
            Assert.Equal(0, order.FinalTotal);
            order.FinalTotal = 1.00m;
            Assert.Equal(1.00m, order.FinalTotal);
        }

        [Fact]
        public static void TestGetSetTransactionNumber()
        {
            Order order = new Order();
            Assert.Null(order.TransactionNumber);
            order.TransactionNumber = "TestTransactionNumber";
            Assert.Equal("TestTransactionNumber", order.TransactionNumber);
        }

        [Fact]
        public static void TestGetSetOrderDateTime()
        {
            Order order = new Order();
            System.DateTime date = new System.DateTime();
            order.OrderDateTime = date;
            Assert.Equal(date, order.OrderDateTime);
        }

        [Fact]
        public static void TestGetSetOrderItems()
        {
            Order order = new Order();
            Assert.Null(order.OrderItems);
            order.OrderItems = new List<OrderItem>();
            Assert.Empty(order.OrderItems);
        }

    }
}
