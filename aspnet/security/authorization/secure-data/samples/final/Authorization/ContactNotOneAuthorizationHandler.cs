using System;
using System.Threading.Tasks;
using ContactManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace ContactManager.Authorization
{
    public class ContactHasOneAuthorizationHandler 
                : AuthorizationHandler<OperationAuthorizationRequirement, Contact>
    {        

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            OperationAuthorizationRequirement requirement, Contact resource)
        {
            if (resource == null)
            {
                return Task.FromResult(0);
            }

            // Return if we haven't requested this requirement.
            if (string.CompareOrdinal(requirement.Name, Constants.ContainsOne) != 0)
            {
                return Task.FromResult(0);
            }

            if (!resource.Address.Contains("1"))
            {
                context.Fail();
            }
            return Task.FromResult(0);
        }
    }
}