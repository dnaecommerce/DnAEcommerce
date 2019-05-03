using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnAStore.Data;
using Microsoft.AspNetCore.Identity;
using DnAStore.Models;

namespace DnAStore.Components
{
    public class BasketComponent : ViewComponent
    {

        private ProductDBContext _context;
        private UserManager<User> _userManager;

        public BasketComponent(ProductDBContext context)
        {
            _context = context;
        }

        //public async Task<IViewComponentResult> InvokeAsync(string username)
        //{
        //    Basket basket = await _context.Baskets.FindByUser(username);
        //    var basketItems = await _context.BasketItems.FindByBasketId(basket.Id);

        //    return View(basketItems);
        //}
    }
}
