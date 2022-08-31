using Microsoft.AspNetCore.Mvc.Routing;

public sealed class HttpConnectAttribute : HttpMethodAttribute
{
    private static readonly IEnumerable<string> _supportedMethods = new[] { "CONNECT" };

    public HttpConnectAttribute() 
        : base(_supportedMethods) 
    { 
    }

    public HttpConnectAttribute(string template)
        : base(_supportedMethods, template)
    {
    }
}