namespace PoliciesAuthApp1.Services.Handlers
{
    // <snippet_BadgeEntryHandlerClass>
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using PoliciesAuthApp1.Services.Requirements;

    public class BadgeEntryHandler : AuthorizationHandler<BuildingEntryRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       BuildingEntryRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == "BadgeId" &&
                                           c.Issuer == "http://microsoftsecurity"))
            {
                context.Succeed(requirement);
            }

            //TODO: Use the following if targeting a version of
            //.NET Framework older than 4.6:
            //      return Task.FromResult(0);
            return Task.CompletedTask;
        }
    }
    // </snippet_BadgeEntryHandlerClass>
}
