using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DnAStore.Models;

namespace DnAStore.Pages.User
{
	[Authorize(Roles = "Member")]
	public class ProfileModel : PageModel
    {

		private UserManager<Models.User> _userManager;

		[BindProperty]
		public Models.User AppUser { get; set; } 


		public ProfileModel(UserManager<Models.User> userManager)
		{
			_userManager = userManager;
		}


        public async Task OnGet()
        {
			string nameOfCurrentUser = User.Identity.Name;
			AppUser = await _userManager.FindByNameAsync(nameOfCurrentUser);
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

			return Page();
		}
    }
}
