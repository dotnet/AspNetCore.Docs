[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class AuthorizeClaimsAttribute : AuthorizeAttribute
{
    protected override bool UserAuthorized(System.Security.Principal.IPrincipal user)
    {
        if (user == null)
        {
            throw new ArgumentNullException("user");
        }

        var principal = user as ClaimsPrincipal;

        if (principal != null)
        {
            Claim authenticated = principal.FindFirst(ClaimTypes.Authentication);
            if (authenticated != null && authenticated.Value == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}