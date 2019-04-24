using DnAStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Data
{
    public class ProductDBContext : DbContext
    {

        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        // Database Tables
        public DbSet<Product> Products;

    }
}
