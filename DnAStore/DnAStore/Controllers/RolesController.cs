using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DnAStore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using DnAStore.Models;

namespace DnAStore.Controllers
{

	[Authorize(Policy = "RequireAdminRole")]
	public class RolesController : Controller
    {

		private UserManager<User> _userManager;

		public RolesController(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		[Authorize]
		[HttpGet]
		public IActionResult Roles()
        {
            return View();
        }

		// TODO Finish adding functionality for adding new admins
		[Authorize(Policy = "RequireAdminRole")]
		[HttpPost]
		public async Task<IActionResult> Roles(RolesViewModel rolesvm)
		{
			if (ModelState.IsValid)
			{
				var result = await _userManager.FindByEmailAsync(rolesvm.Email);

				if (result != null)
				{
					// Assign claim to specified user by email address
					Claim adminRoleClaim = new Claim(ClaimTypes.Role, "Admin", ClaimValueTypes.Email);

					if (!(await _userManager.IsInRoleAsync(result, "Admin")))
					{
						await _userManager.AddClaimAsync(result, adminRoleClaim);
					} 
				}

			}
			return View(rolesvm);
		}

		// TODO Finish adding functionality for adding new admins
		//[Authorize(Policy = "RequireAdminRole")]
		//[HttpDelete]

    }
}