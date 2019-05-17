using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;
using DnAStore.Data;
using DnAStore.Models;
using DnAStore.Models.Interfaces;
using DnAStore.Models.Utilities;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace DnAStore.Pages.Admin
{
    [Authorize(Roles = Roles.Admin)]
    public class CreateModel : PageModel
    {
        private readonly IProductManager _productManager;

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public Blob BlobImage { get; set; }

        public CreateModel(IProductManager productManager, IConfiguration configuration)
        {
            _productManager = productManager;
            BlobImage = new Blob(configuration);
        }

        public IActionResult OnGet()
        {
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Image != null)
            {
                var filePath = Path.GetTempFileName();

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                var container = await BlobImage.GetContainer("product-image-asset-blob");

                BlobImage.UploadFile(container, Image.FileName, filePath);

                CloudBlob blob = await BlobImage.GetBlob(Image.FileName, container.Name);

                Product.Image = blob.Uri.AbsoluteUri;

            }
            await _productManager.CreateProduct(Product);

            return RedirectToPage("./Index");
        }
    }
}