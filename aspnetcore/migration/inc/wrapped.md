# Wrapped ASP.NET Core Session State

This implementation wraps the session provided on ASP.NET Core so that it can be used with the adapters. The session will be using the same backing store as `Microsoft.AspNetCore.Http.ISession` but will provide strongly-typed access to its members.

Configuration for ASP.NET Core would look similar to the following:

```csharp
builder.Services.AddSystemWebAdapters()
    .AddJsonSessionSerializer(options =>
    {
        // Serialization/deserialization requires each session key to be registered to a type
        options.RegisterKey<int>("test-value");
        options.RegisterKey<SessionDemoModel>("SampleSessionItem");
    })
    .WrapAspNetCoreSession();
```

The framework app would not need any changes to enable this behavior.