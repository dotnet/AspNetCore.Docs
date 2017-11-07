using Microsoft.AspNetCore.Authorization;
using ResourceBasedAuthApp2.Models;
using System.Threading.Tasks;

namespace ResourceBasedAuthApp2.Services
{
    #region snippet_HandlerAndRequirement
    public class DocumentAuthorizationHandler : AuthorizationHandler<SameAuthorRequirement, Document>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       SameAuthorRequirement requirement,
                                                       Document resource)
        {
            if (context.User.Identity?.Name == resource.Author)
            {
                context.Succeed(requirement);
            }

            // TODO: Use the following when targeting .NET Framework:
            // return Task.FromResult(0);
            return Task.CompletedTask;
        }
    }

    public class SameAuthorRequirement : IAuthorizationRequirement { }
    #endregion
}
