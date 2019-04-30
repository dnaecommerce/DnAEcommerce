using DnAStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Data
{
    public class UserDBContext : IdentityDbContext<User>
    {

        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }
    }
}
