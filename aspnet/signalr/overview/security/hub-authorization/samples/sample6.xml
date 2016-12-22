public class SampleHub : Hub
{
    public override Task OnConnected()
    {
        return Clients.All.joined(GetAuthInfo());
    }

    protected object GetAuthInfo()
    {
        var user = Context.User;
        return new
        {
            IsAuthenticated = user.Identity.IsAuthenticated,
            IsAdmin = user.IsInRole("Admin"),
            UserName = user.Identity.Name
        };
    }
}