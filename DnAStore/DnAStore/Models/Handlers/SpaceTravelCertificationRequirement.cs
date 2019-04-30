using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models.Handlers
{
    public class SpaceTravelCertificationRequirement : IAuthorizationRequirement
    {
        public bool StcRequired;

        public SpaceTravelCertificationRequirement(bool stcRequired)
        {
            StcRequired = stcRequired;
        }
    }
}
