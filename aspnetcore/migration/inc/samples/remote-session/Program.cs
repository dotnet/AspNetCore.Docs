var builder = WebApplication.CreateBuilder(args);

// <snippet_Serialization>
builder.Services.AddSystemWebAdapters()
    .AddSessionSerializer(options =>
    {
        // Customize session serialization here
    });
// </snippet_Serialization>

// <snippet_Configuration>
builder.Services.AddSystemWebAdapters()
    .AddJsonSessionSerializer(options =>
    {
        // Serialization/deserialization requires each session key to be registered to a type
        options.RegisterKey<int>("test-value");
        options.RegisterKey<SessionDemoModel>("SampleSessionItem");
    })
    .AddRemoteAppClient(options =>
    {
        // Provide the URL for the remote app that has enabled session querying
        options.RemoteAppUrl = new(builder.Configuration["ReverseProxy:Clusters:fallbackCluster:Destinations:fallbackApp:Address"]);

        // Provide a strong API key that will be used to authenticate the request on the remote app for querying the session
        options.ApiKey = builder.Configuration["RemoteAppApiKey"];
    })
    .AddSessionClient();
// </snippet_Configuration>

var app = builder.Build();

// <snippet_RequireSystemWebAdapterSession>
app.MapDefaultControllerRoute()
    .RequireSystemWebAdapterSession();
// </snippet_RequireSystemWebAdapterSession>

app.Run();
