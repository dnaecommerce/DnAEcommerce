using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DnAStore.Models;
using DnAStore.Models.Interfaces;

namespace DnAStore.Components
{
    public class BasketComponent : ViewComponent
    {

		private readonly IBasketManager _basketManager;
		private readonly IBasketItemManager _basketItemManager;

        public BasketComponent(IBasketManager basketManager, IBasketItemManager basketItemManager)
        {
			_basketManager = basketManager;
			_basketItemManager = basketItemManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string username)
        {
            Basket basket = await _basketManager.FindBasketByUserEager(username);
            if (basket == null) return View(new List<BasketItem>());

            return View(basket.BasketItems);
        }
    }
}
