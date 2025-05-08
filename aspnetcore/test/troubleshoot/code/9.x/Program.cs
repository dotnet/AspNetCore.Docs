using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.IISIntegration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

if (app.Environment.IsDevelopment())
{
    app.Run(async (context) =>
    {
        var sb = new StringBuilder();
        var nl = System.Environment.NewLine;
        var rule = string.Concat(nl, new string('-', 40), nl);


        var authSchemeProvider = app.Services.
                       GetRequiredService<IAuthenticationSchemeProvider>();

        sb.Append($"Request{rule}");
        sb.Append($"{DateTimeOffset.Now}{nl}");
        sb.Append($"{context.Request.Method} {context.Request.Path}{nl}");
        sb.Append($"Scheme: {context.Request.Scheme}{nl}");
        sb.Append($"Host: {context.Request.Headers["Host"]}{nl}");
        sb.Append($"PathBase: {context.Request.PathBase.Value}{nl}");
        sb.Append($"Path: {context.Request.Path.Value}{nl}");
        sb.Append($"Query: {context.Request.QueryString.Value}{nl}{nl}");

        sb.Append($"Connection{rule}");
        sb.Append($"RemoteIp: {context.Connection.RemoteIpAddress}{nl}");
        sb.Append($"RemotePort: {context.Connection.RemotePort}{nl}");
        sb.Append($"LocalIp: {context.Connection.LocalIpAddress}{nl}");
        sb.Append($"LocalPort: {context.Connection.LocalPort}{nl}");
        sb.Append($"ClientCert: {context.Connection.ClientCertificate}{nl}{nl}");

        sb.Append($"Identity{rule}");
        sb.Append($"User: {context.User.Identity.Name}{nl}");
        var scheme = await authSchemeProvider
            .GetSchemeAsync(IISDefaults.AuthenticationScheme);
        sb.Append($"DisplayName: {scheme?.DisplayName}{nl}{nl}");

        sb.Append($"Headers{rule}");
        foreach (var header in context.Request.Headers)
        {
            sb.Append($"{header.Key}: {header.Value}{nl}");
        }
        sb.Append(nl);

        sb.Append($"WebSockets{rule}");
        if (context.Features.Get<IHttpUpgradeFeature>() != null)
        {
            sb.Append($"Status: Enabled{nl}{nl}");
        }
        else
        {
            sb.Append($"Status: Disabled{nl}{nl}");
        }

        sb.Append($"Configuration{rule}");
        var config = builder.Configuration;

         foreach (var pair in config.AsEnumerable())
        {
            sb.Append($"{pair.Key}: {pair.Value}{nl}"); 
        }
        sb.Append(nl);
        sb.Append(nl);

        sb.Append($"Environment Variables{rule}");
        var vars = System.Environment.GetEnvironmentVariables();
        foreach (var key in vars.Keys.Cast<string>().OrderBy(key => key,
            StringComparer.OrdinalIgnoreCase))
        {
            var value = vars[key];
            sb.Append($"{key}: {value}{nl}");
        }

        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync(sb.ToString());
    });
}

app.Run();
