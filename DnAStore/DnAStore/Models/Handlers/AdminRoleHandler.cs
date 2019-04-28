using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace DnAStore.Models.Handlers
{
	public class AdminRoleHandler : AuthorizationHandler<AdminRoleRequirement>
	{
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRoleRequirement requirement)
		{
			throw new NotImplementedException();
		}
	}
}
