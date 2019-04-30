using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DnAStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DnAStore.Controllers
{
    public class SpaceTravelerController : Controller
    {
		private UserManager<User> _userManager;

		public SpaceTravelerController(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		/// <summary>
		/// Route to Space Travelers view (gated by custom SpaceTravelCertified policy)
		/// </summary>
		/// <returns>SpaceTravelers view</returns>
		[Authorize(Policy = "SpaceTravelCertified")]
        public async Task<IActionResult> SpaceTravelers()
        {
			//TODO Display list (or just number) of other space travel-certified users
			//List<User> travelers = await _userManager.Users.ToListAsync();
			//var result = travelers.Where(user => user.SpaceTravelCertified == true);

			return View(/*result*/);
        }
    }
}
