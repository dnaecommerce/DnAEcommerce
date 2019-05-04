using DnAStore.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnAStore.Models
{
    public class DBRoleInitializer
    {

        private static List<IdentityRole> RoleList = new List<IdentityRole>()
        {
            new IdentityRole { Name = Roles.Admin, NormalizedName = Roles.Admin.ToUpper() },
            new IdentityRole { Name = Roles.Member, NormalizedName = Roles.Member.ToUpper() }
        };

        public static void SeedRoles(IServiceProvider serviceProvider)
        {
            using (var _context = new UserDBContext(serviceProvider.GetRequiredService<DbContextOptions<UserDBContext>>()))
            {
                _context.Database.EnsureCreated();
                AddRoles(_context);
            }
        }

        public static void AddRoles(UserDBContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            foreach (var role in RoleList)
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }

    }
}
