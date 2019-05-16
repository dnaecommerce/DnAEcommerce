using Xunit;
using DnAStore.Models;

namespace XUnitTest_DnAStore
{
	public class UnitTests_Products
	{
		[Fact]
		public void CanGetSetID()
		{
            Product product = new Product();
            Assert.Equal(0, product.ID);
            product.ID = 1;
            Assert.Equal(1, product.ID);
		}
        
        [Fact]
		public void CanGetSetSku()
		{
            Product product = new Product();
            Assert.Null(product.Sku);
            product.Sku = "TestSku";
            Assert.Equal("TestSku", product.Sku);
		}

        [Fact]
		public void CanGetSetName()
		{
            Product product = new Product();
            Assert.Null(product.Name);
            product.Name = "TestName";
            Assert.Equal("TestName", product.Name);
		}

        [Fact]
		public void CanGetSetPrice()
		{
            Product product = new Product();
            Assert.Equal(0, product.Price);
            product.Price = 1.00m;
            Assert.Equal(1.00m, product.Price);
		}

        [Fact]
		public void CanGetSetDescription()
		{
            Product product = new Product();
            Assert.Null(product.Description);
            product.Description = "TestDescription";
            Assert.Equal("TestDescription", product.Description);
		}

        [Fact]
		public void CanGetSetImage()
		{
            Product product = new Product();
            Assert.Null(product.Image);
            product.Image = "TestImage";
            Assert.Equal("TestImage", product.Image);
		}


        
	}
}
