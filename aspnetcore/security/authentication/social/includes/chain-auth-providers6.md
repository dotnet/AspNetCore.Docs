## Multiple authentication providers

When the app requires multiple providers, chain the provider extension methods from <xref:Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication%2A>:

[!code-csharp[](~/security/authentication/social/index/Program.cs?highlight=19-44)]
