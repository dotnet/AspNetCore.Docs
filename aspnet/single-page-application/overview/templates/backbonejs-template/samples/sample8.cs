public class SessionsController : ApiController
{
    private readonly Func<string, string, bool, bool> signIn;
    private readonly Action signOut;

    public SessionsController() : this(WebSecurity.Login, WebSecurity.Logout)
    {
    }

    public SessionsController(
        Func<string, string, bool, bool> signIn,
        Action signOut)
    {
      this.signIn = signIn;
      this.signOut = signOut;
    }

    // Rest of the code
}