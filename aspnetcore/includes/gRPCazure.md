## gPRC not supported on Azure App Service

> [!WARNING]
> [ASP.NET Core gPRC](xref:grpc/index) is not currently supported on Azure App Service or IIS. The HTTP/2 implementation of Http.Sys does not support HTTP response trailing headers which gRPC relies on. For more information, see [this GitHub issue](https://github.com/aspnet/AspNetCore/issues/9020).
