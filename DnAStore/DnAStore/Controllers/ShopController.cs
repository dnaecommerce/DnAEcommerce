using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnAStore.Models;
using DnAStore.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DnAStore.Controllers
{
    public class ShopController : Controller
    {

		private readonly IInventoryManager _inventory;

		public ShopController(IInventoryManager inventory)
		{
			_inventory = inventory;
		}

        public async Task<IActionResult> Shop()
        {
			List<Product> products = await _inventory.GetAllProducts();
			return View(products);
        }
    }
}