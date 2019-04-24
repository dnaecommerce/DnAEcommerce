using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Data
{
    public class DnAProductDBContext : DbContext
    {

        public DnAProductDBContext(DbContextOptions<DnAProductDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        // Database Tables


    }
}
