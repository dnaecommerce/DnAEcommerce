﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DnAStore.Models;
using DnAStore.Models.Interfaces;

namespace DnAStore.Pages.User
{
	[Authorize(Roles = "Member")]
	public class ProfileModel : PageModel
    {

		private UserManager<Models.User> _userManager;

        private IOrderManager _orderManager;

		[BindProperty]
		public Models.User AppUser { get; set; }

		[BindProperty]
		public string oldPass { get; set; }

		[BindProperty]
		public string newPass { get; set; }

		[BindProperty]
		public string confirmPass { get; set; }

        public List<Order> Orders { get; set; }

		// Constructor
		public ProfileModel(UserManager<Models.User> userManager, IOrderManager orderManager)
		{
			_userManager = userManager;
            _orderManager = orderManager;
		}

        public async Task OnGet()
        {
			string nameOfCurrentUser = User.Identity.Name;
			AppUser = await _userManager.FindByNameAsync(nameOfCurrentUser);
            Orders = await _orderManager.GetUserLastFiveEager(nameOfCurrentUser);
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			string nameOfCurrentUser = User.Identity.Name;
			var user = await _userManager.FindByNameAsync(nameOfCurrentUser);

			user.FirstName = AppUser.FirstName;
			user.LastName = AppUser.LastName;

			await _userManager.UpdateAsync(user);

			return RedirectToPage();
		}

		public async Task<IActionResult> OnPostChangePassword()
		{
			string nameOfCurrentUser = User.Identity.Name;
			AppUser = await _userManager.FindByNameAsync(nameOfCurrentUser);

			if (newPass.Equals(confirmPass))
			{
				await _userManager.ChangePasswordAsync(AppUser, oldPass, newPass);
			}

			return RedirectToPage();
		}
	}
}
