using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DnAStore.Pages.Admin
{
	[Authorize(Roles = "Admin")]
    public class DashboardModel : PageModel
    {
		public void OnGet()
        {

        }
    }
}