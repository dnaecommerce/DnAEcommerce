using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DnAStore.Models;
using DnAStore.Models.Interfaces;

namespace DnAStore.Controllers
{
	public class BasketController : Controller
	{
		private readonly IBasketManager _basketManager;
		private readonly IBasketItemManager _basketItemManager;

		public BasketController(IBasketManager basketManager, IBasketItemManager basketItemManager)
		{
			_basketManager = basketManager;
			_basketItemManager = basketItemManager;
		}

		[HttpPost]
		public async Task<EmptyResult> AddToBasket(int productId, string username)
		{
			//Get user's basket by username
			Basket basket = await _basketManager.FindByUser(username);

			// If basket for user doesn't exist yet, create one
			if (basket == null)
			{
				basket = new Basket()
				{
					ID = 0,
					UserName = username,
					Subtotal = 0,
					BasketItems = new List<BasketItem>()
				};

				await _basketManager.CreateBasket(basket);

				// Gets the new basket with assigned ID from DB
				basket = await _basketManager.FindByUser(username);
			}

			// Check basketitems basket ID and product ID
			var result = await _basketItemManager.FindAllByBasketId(basket.ID);
			BasketItem basketItem = result.

			// Add product by id to basket


			// Returns nothing (similar to void return)
			return new EmptyResult();
		}

	}
}