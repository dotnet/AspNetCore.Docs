using Microsoft.AspNetCore.Authorization;

internal class MinimumAgeRequirement : IAuthorizationRequirement
{
    private int v;

    public MinimumAgeRequirement(int v)
    {
        this.v = v;
    }
    public MinimumAgeRequirement()
    {
        //
    }
}