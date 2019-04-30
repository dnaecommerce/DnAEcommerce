using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models.Handlers
{
    public class SpaceTravelCertificationHandler : AuthorizationHandler<SpaceTravelCertificationRequirement>
    {

		/// <summary>
		/// Handles authorization of user based on custom SpaceTravelCertified claim
		/// </summary>
		/// <param name="context">Built-in AspNetCore authorization handler context</param>
		/// <param name="requirement">custom policy requirement</param>
		/// <returns>CompletedTask</returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SpaceTravelCertificationRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "SpaceTravelCertified"))
            {
                return Task.CompletedTask;
            }

            bool SpaceTravelCertified = bool.Parse(context.User.FindFirst(c => c.Type == "SpaceTravelCertified").Value);

			if (SpaceTravelCertified == requirement.StcRequired)
			{
				context.Succeed(requirement);
			}
            return Task.CompletedTask;
        }
    }
}
