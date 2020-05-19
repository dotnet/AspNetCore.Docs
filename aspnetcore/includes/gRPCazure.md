> [!WARNING]
> [ASP.NET Core gRPC](xref:grpc/index) is not currently supported on Azure App Service or IIS. The HTTP/2 implementation of Http.Sys does not support HTTP response trailing headers which gRPC relies on. For more information, see [this GitHub issue](https://github.com/dotnet/AspNetCore/issues/9020).
