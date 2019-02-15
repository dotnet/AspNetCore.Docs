namespace PoliciesAuthApp1.Services.Handlers
{
    #region snippet_BadgeEntryHandlerClass
    using Microsoft.AspNetCore.Authorization;
    using PoliciesAuthApp1.Services.Requirements;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class BadgeEntryHandler : AuthorizationHandler<BuildingEntryRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       BuildingEntryRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == ClaimTypes.BadgeId &&
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
    #endregion
}
