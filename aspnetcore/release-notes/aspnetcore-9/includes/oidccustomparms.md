### OIDC and OAuth Parameter Customization

The OAuth and OIDC authentication handlers now have a new `AdditionalAuthorizationParameters` option to make it easy to customize authorization message parameters that are usually included as part of the redirect query string. Previously this would have required a custom `OnRedirectToIdentityProvider` callback or overridden `BuildChallengeUrl` method in a custom hander. For example:

```csharp
builder.Services.AddAuthentication().AddOpenIdConnect(options =>
{
    options.Events.OnRedirectToIdentityProvider = context =>
    {
        context.ProtocolMessage.SetParameter("prompt", "login");
        context.ProtocolMessage.SetParameter("audience", "https://api.example.com");
        return Task.CompletedTask;
    };
});
```

Now becomes:

```csharp
builder.Services.AddAuthentication().AddOpenIdConnect(options =>
{
    options.AdditionalAuthorizationParameters.Add("prompt", "login");
    options.AdditionalAuthorizationParameters.Add("audience", "https://api.example.com");
});
```
