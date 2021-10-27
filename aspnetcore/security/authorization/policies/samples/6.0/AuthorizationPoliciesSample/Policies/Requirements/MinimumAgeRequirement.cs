
namespace AuthorizationPoliciesSample.Policies.Requirements;

#region snippet_noNamespace
using Microsoft.AspNetCore.Authorization;

public class MinimumAgeRequirement : IAuthorizationRequirement
{
    public MinimumAgeRequirement(int minimumAge) =>
        MinimumAge = minimumAge;

    public int MinimumAge { get; }
}
#endregion
