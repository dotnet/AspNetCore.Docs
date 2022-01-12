## Multiple authentication providers

When the app requires multiple providers, chain the provider extension methods from [AddAuthentication](/dotnet/api/microsoft.extensions.dependencyinjection.authenticationservicecollectionextensions.addauthentication):

[!code-csharp[](~/security/authentication/social/index/Program.cs?name=snippet1&highlight=19-44)]
