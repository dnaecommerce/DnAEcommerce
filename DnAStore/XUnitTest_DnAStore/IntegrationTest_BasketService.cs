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
    public class IntegrationTest_BasketService
    {

        [Fact]
        public static async Task TestFindBasketByUserLazy()
        {
            DbContextOptions<ProductDBContext> options = new DbContextOptionsBuilder<ProductDBContext>().UseInMemoryDatabase("TestFindBasketByUserLazy").Options;

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

                Basket basket = new Basket
                {
                    ID = 0,
                    UserName = "TestBasket",
                    Subtotal = 2.00m,
                    BasketItems = new List<BasketItem>()
                };
                context.Add(basket);

                BasketItem basketItem = new BasketItem
                {
                    BasketID = basket.ID,
                    ProductID = product.ID,
                    Quantity = 2,
                    Product = product,
                    Basket = basket,

                };
                context.Add(basketItem);

                context.SaveChanges();

                BasketService bs = new BasketService(context);

                Basket test = await bs.FindBasketByUserLazy("TestBasket");

                Assert.Equal(2, test.Subtotal);
            }
        }

        [Fact]
        public static async Task TestFindBasketByUserEager()
        {
            DbContextOptions<ProductDBContext> options = new DbContextOptionsBuilder<ProductDBContext>().UseInMemoryDatabase("TestFindBasketByUserEager").Options;

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

                Basket basket = new Basket
                {
                    ID = 0,
                    UserName = "TestBasket",
                    Subtotal = 2.00m,
                    BasketItems = new List<BasketItem>()
                };
                context.Add(basket);

                BasketItem basketItem = new BasketItem
                {
                    BasketID = basket.ID,
                    ProductID = product.ID,
                    Quantity = 2,
                    Product = product,
                    Basket = basket,

                };
                context.Add(basketItem);

                context.SaveChanges();

                BasketService bs = new BasketService(context);

                Basket test = await bs.FindBasketByUserEager("TestBasket");

                Assert.Equal(1, test.BasketItems[0].Product.Price);
            }
        }

        [Fact]
        public static async Task TestCreateBasket()
        {
            DbContextOptions<ProductDBContext> options = new DbContextOptionsBuilder<ProductDBContext>().UseInMemoryDatabase("TestCreateBasket").Options;

            using (ProductDBContext context = new ProductDBContext(options))
            {
                Basket basket = new Basket
                {
                    ID = 0,
                    UserName = "TestBasket",
                    Subtotal = 2.00m,
                    BasketItems = new List<BasketItem>()
                };

                BasketService bs = new BasketService(context);

                await bs.CreateBasket(basket);

                List<Basket> baskets = await context.Baskets.ToListAsync();

                Assert.Equal(2, baskets[0].Subtotal);
            }
        }

        [Fact]
        public static async Task TestUpdateBasket()
        {
            DbContextOptions<ProductDBContext> options = new DbContextOptionsBuilder<ProductDBContext>().UseInMemoryDatabase("TestUpdateBasket").Options;

            using (ProductDBContext context = new ProductDBContext(options))
            {
                Basket basket = new Basket
                {
                    ID = 0,
                    UserName = "TestBasket",
                    Subtotal = 2.00m,
                    BasketItems = new List<BasketItem>()
                };

                BasketService bs = new BasketService(context);

                context.Add(basket);
                context.SaveChanges();

                List<Basket> baskets = await context.Baskets.ToListAsync();

                Assert.Equal(2, baskets[0].Subtotal);

                basket.Subtotal = 0m;
                await bs.UpdateBasket(basket);

                baskets = await context.Baskets.ToListAsync();

                Assert.Equal(0, baskets[0].Subtotal);
            }
        }

        [Fact]
        public static async Task TestDeleteBasket()
        {
            DbContextOptions<ProductDBContext> options = new DbContextOptionsBuilder<ProductDBContext>().UseInMemoryDatabase("TestDeleteBasket").Options;

            using (ProductDBContext context = new ProductDBContext(options))
            {
                Basket basket = new Basket
                {
                    ID = 0,
                    UserName = "TestBasket",
                    Subtotal = 2.00m,
                    BasketItems = new List<BasketItem>()
                };

                BasketService bs = new BasketService(context);

                context.Add(basket);
                context.SaveChanges();

                List<Basket> baskets = await context.Baskets.ToListAsync();

                Assert.Equal(2, baskets[0].Subtotal);

                bs.DeleteBasket(basket.ID);

                baskets = await context.Baskets.ToListAsync();

                Assert.Empty(baskets);
            }
        }

    }
}
