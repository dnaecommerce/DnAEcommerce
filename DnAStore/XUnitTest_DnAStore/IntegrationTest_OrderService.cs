using DnAStore.Data;
using DnAStore.Models;
using DnAStore.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest_DnAStore
{
    public class IntegrationTest_OrderService
    {
        [Fact]
        public static void TestGetOrders()
        {
            DbContextOptions<ProductDBContext> options = new DbContextOptionsBuilder<ProductDBContext>().UseInMemoryDatabase("TestGetOrders").Options;

            using (ProductDBContext context = new ProductDBContext(options))
            {

                Product product = new Product()
                {
                    ID = 0,
                    Sku = "Test/Sku/Test",
                    Name = "TestProduct",
                    Description = "TestProduct",
                    Price = 1.00m,
                    Image = "TestImage"
                };
                context.Add(product);

                Order order = new Order
                {
                    ID = 0,
                    UserName = "TestOrder",
                    Subtotal = 2.00m,
                    OrderItems = new List<OrderItem>()
                };
                context.Add(order);

                Order order2 = new Order
                {
                    ID = 0,
                    UserName = "TestOrder2",
                    Subtotal = 2.00m,
                    OrderItems = new List<OrderItem>()
                };
                context.Add(order2);

                OrderItem orderItem = new OrderItem
                {
                    OrderID = order.ID,
                    ProductID = product.ID,
                    Quantity = 2,
                    Product = product,
                    Order = order,

                };
                context.Add(orderItem);

                context.SaveChanges();

                OrderService os = new OrderService(context);

                List<Order> test = os.GetAllOrders();

                Assert.Equal(2, test.Count);
            }
        }

        [Fact]
        public static async Task TestGetAllUserOrdersEager()
        {
            DbContextOptions<ProductDBContext> options = new DbContextOptionsBuilder<ProductDBContext>().UseInMemoryDatabase("TestGetOrdersEager").Options;

            using (ProductDBContext context = new ProductDBContext(options))
            {

                Product product = new Product()
                {
                    ID = 0,
                    Sku = "Test/Sku/Test",
                    Name = "TestProduct",
                    Description = "TestProduct",
                    Price = 1.00m,
                    Image = "TestImage"
                };
                context.Add(product);

                Order order = new Order
                {
                    ID = 0,
                    UserName = "TestOrder",
                    Subtotal = 2.00m,
                    OrderItems = new List<OrderItem>()
                };
                context.Add(order);

                Order order2 = new Order
                {
                    ID = 0,
                    UserName = "TestOrder2",
                    Subtotal = 2.00m,
                    OrderItems = new List<OrderItem>()
                };
                context.Add(order2);

                OrderItem orderItem = new OrderItem
                {
                    OrderID = order.ID,
                    ProductID = product.ID,
                    Quantity = 2,
                    Product = product,
                    Order = order,

                };
                context.Add(orderItem);

                context.SaveChanges();

                OrderService os = new OrderService(context);

                List<Order> test = await os.GetAllUserOrdersEager("TestOrder");

                Assert.Equal(2, test[0].Subtotal);
            }
        }

        [Fact]
        public static async Task TestGetOrderByIDLazy()
        {
            DbContextOptions<ProductDBContext> options = new DbContextOptionsBuilder<ProductDBContext>().UseInMemoryDatabase("TestGetOrderByIDLazy").Options;

            using (ProductDBContext context = new ProductDBContext(options))
            {

                Product product = new Product()
                {
                    ID = 0,
                    Sku = "Test/Sku/Test",
                    Name = "TestProduct",
                    Description = "TestProduct",
                    Price = 1.00m,
                    Image = "TestImage"
                };
                context.Add(product);

                Order order = new Order
                {
                    ID = 0,
                    UserName = "TestOrder",
                    Subtotal = 2.00m,
                    OrderItems = new List<OrderItem>()
                };
                context.Add(order);

                Order order2 = new Order
                {
                    ID = 0,
                    UserName = "TestOrder",
                    Subtotal = 1.00m,
                    OrderItems = new List<OrderItem>()
                };
                context.Add(order2);

                OrderItem orderItem = new OrderItem
                {
                    OrderID = order.ID,
                    ProductID = product.ID,
                    Quantity = 2,
                    Product = product,
                    Order = order,

                };
                context.Add(orderItem);

                context.SaveChanges();

                OrderService os = new OrderService(context);

                Order test = await os.GetOrderByIDLazy(6);

                Assert.Equal(1, test.Subtotal);
            }
        }

        [Fact]
        public static async Task TestGetOrderByIDEager()
        {
            DbContextOptions<ProductDBContext> options = new DbContextOptionsBuilder<ProductDBContext>().UseInMemoryDatabase("TestGetOrderByIDEager").Options;

            using (ProductDBContext context = new ProductDBContext(options))
            {

                Product product = new Product()
                {
                    ID = 0,
                    Sku = "Test/Sku/Test",
                    Name = "TestProduct",
                    Description = "TestProduct",
                    Price = 1.00m,
                    Image = "TestImage"
                };
                context.Add(product);

                Order order = new Order
                {
                    ID = 0,
                    UserName = "TestOrder",
                    Subtotal = 2.00m,
                    OrderItems = new List<OrderItem>()
                };
                context.Add(order);

                Order order2 = new Order
                {
                    ID = 0,
                    UserName = "TestOrder",
                    Subtotal = 2.00m,
                    OrderItems = new List<OrderItem>()
                };
                context.Add(order2);

                OrderItem orderItem = new OrderItem
                {
                    OrderID = order.ID,
                    ProductID = product.ID,
                    Quantity = 2,
                    Product = product,
                    Order = order,

                };
                context.Add(orderItem);

                context.SaveChanges();

                OrderService os = new OrderService(context);

                Order test = await os.GetOrderByIDEager(7);

                Assert.Equal(1, test.OrderItems[0].Product.Price);
            }
        }

        [Fact]
        public static async Task TestUpdateOrder()
        {
            DbContextOptions<ProductDBContext> options = new DbContextOptionsBuilder<ProductDBContext>().UseInMemoryDatabase("TestUpdateOrder").Options;

            using (ProductDBContext context = new ProductDBContext(options))
            {

                Product product = new Product()
                {
                    ID = 0,
                    Sku = "Test/Sku/Test",
                    Name = "TestProduct",
                    Description = "TestProduct",
                    Price = 1.00m,
                    Image = "TestImage"
                };
                context.Add(product);

                Order order = new Order
                {
                    ID = 0,
                    UserName = "TestOrder",
                    Subtotal = 2.00m,
                    OrderItems = new List<OrderItem>()
                };
                context.Add(order);

                OrderItem orderItem = new OrderItem
                {
                    OrderID = order.ID,
                    ProductID = product.ID,
                    Quantity = 2,
                    Product = product,
                    Order = order,

                };
                context.Add(orderItem);

                context.SaveChanges();

                order.Subtotal = 3m;

                OrderService os = new OrderService(context);

                await os.UpdateOrder(order);

                List<Order> test = await context.Orders.ToListAsync();
                Assert.Equal(3, test[0].Subtotal);
            }
        }

    }
}
