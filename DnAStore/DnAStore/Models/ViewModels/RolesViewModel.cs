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
		[EmailAddress]
		public string Email { get; set; }


	}
}
