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
using Microsoft.Extensions.Configuration;
using DnAStore.Models.Utilities;
using Microsoft.WindowsAzure.Storage.Blob;

namespace DnAStore.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly IProductManager _productManager;

        public Blob BlobImage { get; set; }

        public DeleteModel(IProductManager productManager, IConfiguration configuration)
        {
            _productManager = productManager;
            BlobImage = new Blob(configuration);
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _productManager.GetProductByID((int)id);


            var container = await BlobImage.GetContainer("product-image-asset-blob");

            string[] imageURIArray = Product.Image.Split("/");
            string imageName = imageURIArray[imageURIArray.Length - 1];

            CloudBlob image = await BlobImage.GetBlob(imageName, container.Name);

            if (image != null) await image.DeleteAsync();

            if (Product != null)
            {
                await _productManager.DeleteProduct(Product);
            }

            return RedirectToPage("./Index");
        }
    }
}
