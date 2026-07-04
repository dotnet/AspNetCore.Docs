### Support for `IOpenApiDocumentProvider` in the DI container

ASP.NET Core in .NET 10 supports <xref:Microsoft.AspNetCore.OpenApi.IOpenApiDocumentProvider> in the dependency injection (DI) container. Inject the interface to access the OpenAPI document. This approach is useful for accessing OpenAPI documents outside the context of HTTP requests, such as in background services or custom middleware.

Previously, running app startup logic without launching an HTTP server could be accomplished using [`HostFactoryResolver`](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.Extensions.HostFactoryResolver/src/HostFactoryResolver.cs) with a no-op <xref:Microsoft.AspNetCore.Hosting.Server.IServer> implementation. The new feature simplifies this process.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

For more information, see [Add IOpenApiDocumentProvider interface and implementation (`dotnet/aspnetcore` #61463)](https://github.com/dotnet/aspnetcore/pull/61463).
