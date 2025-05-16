### Support for IOpenApiDocumentProvider in the DI container.

ASP.NET Core in .NET 10 supports [IOpenApiDocumentProvider](https://source.dot.net/#Microsoft.AspNetCore.OpenApi/Services/IOpenApiDocumentProvider.cs) in the dependency injection (DI) container. Developers can inject `IOpenApiDocumentProvider` into their apps and use it to access the OpenAPI document. This approach is useful for accessing OpenAPI documents outside the context of HTTP requests, such as in background services or custom middleware.

Previously, running application startup logic without launching an HTTP server could be done by using `HostFactoryResolver` with a no-op `IServer` implementation. The new feature simplifies this process by providing a streamlined API inspired by Aspire's <xref:Aspire.Hosting.Publishing.IDistributedApplicationPublisher>, which is part of Aspire's framework for distributed application hosting and publishing.

For more information, see [dotnet/aspnetcore #61463](https://github.com/dotnet/aspnetcore/pull/61463).
