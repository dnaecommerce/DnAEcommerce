using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnAStore.Models;
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
			if (true)
			{

			}
		}
	}
}
