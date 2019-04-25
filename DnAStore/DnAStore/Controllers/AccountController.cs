using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DnAStore.Models;
using DnAStore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DnAStore.Controllers
{
	public class AccountController : Controller
	{
		private UserManager<User> _userManager;
		private SignInManager<User> _signInManager;

		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel rvm)
		{
			if (ModelState.IsValid)
			{
				User user = new User
				{
					UserName = rvm.Email,
					Email = rvm.Email,
					FirstName = rvm.FirstName,
					LastName = rvm.LastName,
				};

				var result = await _userManager.CreateAsync(user, rvm.Password);

				if (result.Succeeded)
				{
					Claim nameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

					Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

					List<Claim> claims = new List<Claim> { nameClaim, emailClaim };

					await _userManager.AddClaimsAsync(user, claims);

					// Sign user in
					await _signInManager.SignInAsync(user, isPersistent: false);

					// Redirect to home page
					return RedirectToAction("Index", "Home");
				}
			}
			return View(rvm);
		}
	}
}
