using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DnAStore.Data;
using DnAStore.Models;
using DnAStore.Models.Interfaces;

namespace DnAStore.Pages.Admin
{
    [Authorize(Roles = Roles.Admin)]
    public class EditModel : PageModel
    {
        private readonly IProductManager _productManager;

        public EditModel(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _productManager.GetProductByID((int)id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productManager.UpdateProduct(Product.ID, Product);

            return RedirectToPage("./Index");
        }
    }
}
