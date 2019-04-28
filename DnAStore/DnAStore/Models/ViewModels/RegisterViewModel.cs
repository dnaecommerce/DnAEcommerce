using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

        [Required]
        [Display(Name = "Space Travel Certified")]
        public bool SpaceTravelCertified { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(16, ErrorMessage = "The {0} must be between {2} and {1} characters long", MinimumLength = 6)]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		[Compare("Password", ErrorMessage = "The passwords do not match")]
		public string ConfirmPassword { get; set; }
	}
}
