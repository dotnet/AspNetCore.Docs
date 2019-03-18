namespace PoliciesAuthApp1.Services.Requirements
{
    #region snippet_MinimumAgeRequirementClass
    using Microsoft.AspNetCore.Authorization;

    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public int MinimumAge { get; }

        public MinimumAgeRequirement(int minimumAge)
        {
            MinimumAge = minimumAge;
        }
    }
    #endregion
}
