using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

public class MyClaimsTransformation : IClaimsTransformation
{
    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        if (!principal.HasClaim(claim => claim.Type == "myNewClaim"))
        {
            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim("myNewClaim", "myClaimValue"));
            principal.AddIdentity(identity);
        }

        return Task.FromResult(principal);
    }
}
