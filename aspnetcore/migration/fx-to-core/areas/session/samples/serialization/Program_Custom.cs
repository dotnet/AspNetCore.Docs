var builder = WebApplication.CreateBuilder(args);

// <snippet_Serialization>
builder.Services.AddSystemWebAdapters()
    .AddSessionSerializer();

builder.Services.AddSingleton<ISessionKeySerializer, CustomSessionKeySerializer>();
// </snippet_Serialization>

var app = builder.Build();
app.Run();

// <snippet_CustomSerializer>
sealed class CustomSessionKeySerializer : ISessionKeySerializer
{
    public bool TryDeserialize(string key, byte[] bytes, out object? obj)
    {
        // Custom deserialization logic
    }

    public bool TrySerialize(string key, object? value, out byte[] bytes)
    {
        // Custom serialization logic
    }
}
// </snippet_CustomSerializer>
