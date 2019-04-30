using DnAStore.Data;
using DnAStore.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models.Services
{
    public class InventoryService : IInventoryManager
    {
        private readonly ProductDBContext _context;

        public InventoryService(ProductDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a database entry containing information provided as a new product.
        /// </summary>
        /// <param name="product">The product that needs to be added to the database</param>
        /// <returns>An asynchronous task</returns>
        public async Task CreateProduct(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Finds and removes a database entry for a product that is being deleted.
        /// </summary>
        /// <param name="product">The product to be deleted</param>
        /// <returns>An asynchronous task</returns>
        public async Task DeleteProduct(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all products in the database and returns them as a list.
        /// </summary>
        /// <returns>The list of all products</returns>
        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return products;
        }

        /// <summary>
        /// Gets a specific product from the database and returns it.
        /// </summary>
        /// <param name="id">The ID of the specific product</param>
        /// <returns>The requested product</returns>
        public async Task<Product> GetProductByID(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        /// <summary>
        /// Updates a specific product in the database after verifying the ID matches the product being sent.
        /// </summary>
        /// <param name="id">The ID of the product to be updated</param>
        /// <param name="product">The product data being placed in the database</param>
        /// <returns>An asynchronous task</returns>
        public async Task UpdateProduct(int id, Product product)
        {
            if (product.ID == id)
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
