using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DnAStore.Controllers
{

	[Authorize(Policy = "RequireAdminRole")]
	public class AdminRoleController : Controller
    {

		[Authorize]
		[HttpGet]
		public IActionResult Roles()
        {
            return View();
        }

		// TODO Finish adding functionality for adding new admins
		[Authorize(Policy = "RequireAdminRole")]
		[HttpPost]
		public IActionResult Roles(string user)
		{
			return View();
		}

		// TODO Finish adding functionality for adding new admins
		[Authorize(Policy = "RequireAdminRole")]
		[HttpDelete]

    }
}