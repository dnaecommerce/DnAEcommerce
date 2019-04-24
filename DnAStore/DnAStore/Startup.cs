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

		// This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

			var connectionString_ProductsDB = Environment.IsDevelopment() ? Configuration["ConnectionStrings:ProductionConnection"] : Configuration["ConnectionStrings:ProductionConfiguration"];
			var connectionString_UserDB = Environment.IsDevelopment() ? Configuration["ConnectionStrings:ProductionConnection"] : Configuration["ConnectionStrings:ProductionConnection"];

			services.AddDbContext<UserDBContext>(options => options.UseSqlServer(connectionString_UserDB));
			services.AddDbContext<ProductDBContext>(options => options.UseSqlServer(connectionString_ProductsDB));

			services.AddIdentity<User, IdentityRole>()
				.AddEntityFrameworkStores<UserDBContext>()
				.AddDefaultTokenProviders();

            services.AddScoped<IInventoryManager, InventoryService>();
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

			app.UseStaticFiles();
			app.UseAuthentication();
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
