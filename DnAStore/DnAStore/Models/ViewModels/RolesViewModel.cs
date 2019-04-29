using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models.ViewModels
{
	public class RolesViewModel
	{
		[Required]
		[Display(Name = "Email to Add/Remove from Admin List")]
		[EmailAddress]
		public string Email { get; set; }

		public List<User> Admins { get; set; }
	}
}
