## Support for IOpenApiDocumentProvider in the DI container.
<!-- https://github.com/dotnet/aspnetcore/pull/61463 -->
ASP.NET has added support for `IOpenApiDocumentProvider` in the DI container.
This allows you to inject the `IOpenApiDocumentProvider` into your application and use it to access the OpenAPI document.
This is useful for scenarios where you need to access the OpenAPI document outside of the context of an HTTP request,
such as in a background service or a custom middleware.
