using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DnAStore.Data;
using DnAStore.Models;
using DnAStore.Models.Interfaces;

namespace DnAStore.Pages.Admin
{
    [Authorize(Roles = Roles.Admin)]
    public class IndexModel : PageModel
    {
        private readonly IProductManager _productManager;

        public IndexModel(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _productManager.GetAllProducts();
        }
    }
}
