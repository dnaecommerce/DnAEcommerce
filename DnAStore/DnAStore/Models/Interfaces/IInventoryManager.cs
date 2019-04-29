using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models.Interfaces
{
    public interface IInventoryManager
    {
        Task CreateProduct(Product product);
        Task<Product> GetProductByID(int id);
        Task<List<Product>> GetAllProducts();
        Task UpdateProduct(int id, Product product);
        Task DeleteProduct(Product product);
    }
}
