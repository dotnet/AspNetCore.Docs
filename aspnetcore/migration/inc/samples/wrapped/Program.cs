var builder = WebApplication.CreateBuilder(args);

// <snippet_WrapAspNetCoreSession>
builder.Services.AddSystemWebAdapters()
    .AddJsonSessionSerializer(options =>
    {
        // Serialization/deserialization requires each session key to be registered to a type
        options.RegisterKey<int>("test-value");
        options.RegisterKey<SessionDemoModel>("SampleSessionItem");
    })
    .WrapAspNetCoreSession();
// </snippet_WrapAspNetCoreSession>

var app = builder.Build();
app.Run();
