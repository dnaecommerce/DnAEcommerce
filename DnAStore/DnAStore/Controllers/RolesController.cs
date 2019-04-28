using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DnAStore.Controllers
{

	[Authorize(Policy="AdminRole")]
    public class RolesController : Controller
    {

		public IActionResult Index()
        {
            return View();
        }

		[Authorize]
		public IActionResult Roles()
		{
			return View();
		}
    }
}