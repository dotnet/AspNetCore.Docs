public class MyModule : IHttpModule
{
    public void Dispose()
    {
        //clean-up code here.
    }
    public void Init(HttpApplication context)
    {
        // An example of how you can handle AuthenticateRequest events.
        context.AuthenticateRequest += ctx_AuthRequest;
    }
    void ctx_AuthRequest(object sender, EventArgs e)
    {
        // Handle event.
    }
}