using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace KestrelSample.Snippets;

public static class Program
{
    public static void Http3(string[] args)
    {
        // <snippet_Http3>
        var builder = WebApplication.CreateBuilder(args);

        builder.WebHost.ConfigureKestrel((context, options) =>
        {
            options.ListenAnyIP(5001, listenOptions =>
            {
                listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
                listenOptions.UseHttps();
            });
        });
        // </snippet_Http3>
    }
}
