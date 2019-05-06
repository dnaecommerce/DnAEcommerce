using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DnAStore.Models;
using DnAStore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DnAStore.Controllers
{
	public class AccountController : Controller
	{
		private UserManager<User> _userManager;
		private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
		{
			_userManager = userManager;
			_signInManager = signInManager;
            _emailSender = emailSender;
		}

        /// <summary>
        /// Register Route
        /// </summary>
        /// <returns>Register View</returns>
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

        /// <summary>
        /// Register Post Route
        /// </summary>
        /// <param name="rvm">User Information Model</param>
        /// <returns>Redirect To Home on Success or Register on Failure</returns>
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
                    SpaceTravelCertified = rvm.SpaceTravelCertified,
				};

				var result = await _userManager.CreateAsync(user, rvm.Password);

				if (result.Succeeded)
				{
					Claim nameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

					Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

					Claim spaceTravelClaim = new Claim("SpaceTravelCertified", user.SpaceTravelCertified.ToString());

					List<Claim> claims = new List<Claim> { nameClaim, emailClaim, spaceTravelClaim };

					await _userManager.AddClaimsAsync(user, claims);

					// Sign user in
					await _signInManager.SignInAsync(user, isPersistent: false);

                    if (rvm.Email.ToLower() == "amanda@codefellows.com")
                    {
                        await _userManager.AddToRoleAsync(user, Roles.Admin);
                    }

                    await _userManager.AddToRoleAsync(user, Roles.Member);

					// Redirect to Index action on Home page
					return RedirectToAction("Index", "Home");
				}

                await _emailSender.SendEmailAsync(rvm.Email, "Thanks For Registering", "<p>Welcome to the site.</p>");

			}
			return View(rvm);
		}

        /// <summary>
        /// Login Route
        /// </summary>
        /// <returns>Login View</returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Login Post Route
        /// </summary>
        /// <param name="lvm">User Information Model</param>
        /// <returns>Redirect to Home on Success or Login on Failure.</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            return View(lvm);
        }

        /// <summary>
        /// Signs the user out.
        /// </summary>
        /// <returns>Redirect to Home</returns>
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
	}
}
