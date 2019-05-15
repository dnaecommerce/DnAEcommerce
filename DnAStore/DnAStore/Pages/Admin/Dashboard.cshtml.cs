using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnAStore.Models;
using DnAStore.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DnAStore.Pages.Admin
{
	[Authorize(Roles = "Admin")]
    public class DashboardModel : PageModel
    {

		private IOrderManager _orders;

		[BindProperty]
		public Order Order { get; set; } 

		[FromRoute]
		public int ID { get; set; }

		public DashboardModel(IOrderManager orders)
		{
			_orders = orders;
		}


		public void OnGet()
        {
			
        }
    }
}
