# Blazor WebAssembly Sample App

This sample illustrates the use of Blazor scenarios described in the Blazor documentation.

## Call web API example

The web API example requires a running web API based on the sample app for the <a href="https://docs.microsoft.com/aspnet/core/tutorials/first-web-api">Tutorial: Create a web API with ASP.NET Core MVC</a> topic. The sample app makes requests to the web API at `https://localhost:10000/api/todo`. If a different web API address is used, update the `ServiceEndpoint` constant value in the Razor component's `@functions` block.</p>

The sample app makes a <a href="https://docs.microsoft.com/aspnet/core/security/cors">cross-origin resource sharing (CORS)</a> request from `http://localhost:5000` or `https://localhost:5001` to the web API. Credentials (authorization cookies/headers) are permitted. Add the following CORS middleware configuration to the web API's `Startup.Configure` method before it calls `UseMvc`:</p>

```csharp
app.UseCors(policy => 
    policy.WithOrigins("http://localhost:5000", "https://localhost:5001")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization)
    .AllowCredentials());
```

Adjust the domains and ports of `WithOrigins` as needed for the Blazor app.

The web API is configured for CORS to permit authorization cookies/headers and requests from client code, but the web API as created by the tutorial doesn't actually authorize requests. See the <a href="https://docs.microsoft.com/aspnet/core/security/">ASP.NET Core Security and Identity articles</a> for implementation guidance.
