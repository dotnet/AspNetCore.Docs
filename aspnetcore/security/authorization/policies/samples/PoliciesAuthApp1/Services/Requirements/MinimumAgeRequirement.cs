namespace PoliciesAuthApp1.Services.Requirements
{
    #region snippet_MinimumAgeRequirementClass
    using Microsoft.AspNetCore.Authorization;

    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        public int MinimumAge { get; set; }

        public MinimumAgeRequirement(int minimumAge)
        {
            MinimumAge = minimumAge;
        }
    }
    #endregion
}
