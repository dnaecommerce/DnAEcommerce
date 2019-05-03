using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DnAStore.Models;
using DnAStore.Data;
using DnAStore.Models.Interfaces;
using DnAStore.Models.Services;
using DnAStore.Models.Handlers;
using Microsoft.AspNetCore.Authorization;

namespace DnAStore
{
    public class Startup
    {
		public IConfiguration Configuration { get; }
		public IHostingEnvironment Environment { get; }
		
		public Startup(IHostingEnvironment environment)
		{
			Environment = environment;
			var builder = new ConfigurationBuilder().AddEnvironmentVariables();
			builder.AddUserSecrets<Startup>();
			Configuration = builder.Build();
		}

		// This method gets called by the runtime and is used to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

			// Database connection strings
			var connectionString_UserDB = Environment.IsDevelopment() ? Configuration["ConnectionStrings:DefaultConnection_Users"] : Configuration["ConnectionStrings:ProductionConnection_Users"];

			var connectionString_ProductsDB = Environment.IsDevelopment() ? Configuration["ConnectionStrings:DefaultConnection_Products"] : Configuration["ConnectionStrings:ProductionConnection_Products"];

			services.AddDbContext<UserDBContext>(options => options.UseSqlServer(connectionString_UserDB));
			services.AddDbContext<ProductDBContext>(options => options.UseSqlServer(connectionString_ProductsDB));

			// Add AspNetCore Identity
			services.AddIdentity<User, IdentityRole>()
				.AddRoles<IdentityRole>() // Actually need this, given the AddIdentity line above ?
				.AddEntityFrameworkStores<UserDBContext>()
				.AddDefaultTokenProviders();

			// Custom policies
            services.AddAuthorization(options =>
			{
               options.AddPolicy("SpaceTravelCertified", policy => policy.Requirements.Add(new SpaceTravelCertificationRequirement(true)));
			});

			// Mappings for dependency injection and Repository design pattern
            services.AddScoped<IProductManager, ProductService>();
            services.AddScoped<IAuthorizationHandler, SpaceTravelCertificationHandler>();
		}

        // This method gets called by the runtime and is used to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

			app.UseStaticFiles();
			app.UseAuthentication(); // Must be above where the default route is specified
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
