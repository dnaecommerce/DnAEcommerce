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

		/// <summary>
		/// Route to Shop view
		/// </summary>
		/// <returns>Shop view</returns>
        public async Task<IActionResult> Shop()
        {
			List<Product> products = await _inventory.GetAllProducts();
			return View(products);
        }

		/// <summary>
		/// Route to product's Details view
		/// </summary>
		/// <param name="id">product ID</param>
		/// <returns>asynchronous task</returns>
		public async Task<IActionResult> Details(int id)
		{
			if (id < 1)
			{
				return NotFound();
			}

			var product = await _inventory.GetProductByID(id);

			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		[HttpPost]
		public async Task<IActionResult> AddToBasket(int id)
		{

		}
    }
}