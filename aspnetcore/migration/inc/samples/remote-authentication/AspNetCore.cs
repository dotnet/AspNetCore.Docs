var builder = WebApplication.CreateBuilder(args);

// <snippet_AddSystemWebAdapters>
builder.Services.AddSystemWebAdapters()
    .AddRemoteAppClient(options =>
    {
        options.RemoteAppUrl = new Uri(builder.Configuration
            ["ReverseProxy:Clusters:fallbackCluster:Destinations:fallbackApp:Address"]);
        options.ApiKey = builder.Configuration["RemoteAppApiKey"];
    })
    .AddAuthenticationClient(true);
// </snippet_AddSystemWebAdapters>

var app = builder.Build();

// <snippet_UseAuthentication>
app.UseAuthentication();
// </snippet_UseAuthentication>

app.Run();
