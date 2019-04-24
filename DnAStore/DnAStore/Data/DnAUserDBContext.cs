using DnAStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Data
{
    public class DnAUserDBContext : IdentityDbContext<User>
    {

        public DnAUserDBContext(DbContextOptions<DnAUserDBContext> options) : base(options)
        {

        }
        
    }
}
