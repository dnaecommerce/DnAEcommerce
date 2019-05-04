using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DnAStore.Models;
using DnAStore.Models.Interfaces;
using DnAStore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace DnAStore.Controllers
{
	public class BasketController : Controller
	{
		private readonly IBasketManager _basketManager;
		private readonly IBasketItemManager _basketItemManager;
		private SignInManager<User> _signInManager;

		public BasketController(IBasketManager basketManager, IBasketItemManager basketItemManager, SignInManager<User> signInManager)
		{
			_basketManager = basketManager;
			_basketItemManager = basketItemManager;
			_signInManager = signInManager;
		}

		[HttpPost]
		public async Task<IActionResult> AddToBasket(int productId, string username)
		{
			if (!_signInManager.IsSignedIn(User))
			{
				return RedirectToAction("Login", "Account");
			}

			//Get user's basket by username
			Basket basket = await _basketManager.FindBasketByUserLazy(username);

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
				basket = await _basketManager.FindBasketByUserLazy(username);
			}

			// Check basketitems basket ID and product ID
			BasketItem basketItem = await _basketItemManager.FindBasketItem(basket.ID, productId);

			// If item doesn't already exist, create it; otherwise update it
			if (basketItem == null)
			{
				basketItem = new BasketItem()
				{
					ID = 0,
					BasketID = basket.ID,
					ProductID = productId,
					Quantity = 1
				};

				await _basketItemManager.CreateBasketItem(basketItem);
			}
			else
			{
				basketItem.Quantity++;
				await _basketItemManager.UpdateBasketItem(basketItem.ID, basketItem);
			}

			// Redirect to Shop action on Shop page
			return RedirectToAction("Shop", "Shop");
		}
	}
}