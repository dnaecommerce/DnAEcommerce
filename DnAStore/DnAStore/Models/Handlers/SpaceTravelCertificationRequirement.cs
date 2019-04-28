using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models.Handlers
{
    public class SpaceTravelCertificationRequirement : AuthorizationHandler<SpaceTravelCertificationRequirement>, IAuthorizationRequirement
    {
        private bool _stcRequired;

        public SpaceTravelCertificationRequirement(bool stcRequired)
        {
            _stcRequired = stcRequired;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SpaceTravelCertificationRequirement requirement)
        {
            if (!context.User.HasClaim( c => c.Type == "SpaceTravelCertified"))
            {
                return Task.CompletedTask;
            }

            bool SpaceTravelCertified = bool.Parse(context.User.FindFirst(c => c.Type == "SpaceTravelCertified").Value);

            if (SpaceTravelCertified == _stcRequired) context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
