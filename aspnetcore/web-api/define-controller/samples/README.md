# ASP.NET Core Web API Controller Sample

This sample app consists of the following projects:

- **WebApiSample.Api.22*: An ASP.NET Core 2.2 project targeting .NET Core 2.2.
- **WebApiSample.Api.21**: An ASP.NET Core 2.1 project targeting .NET Core 2.1.
- **WebApiSample.Api.Pre21**: An ASP.NET Core 2.0 project targeting .NET Core 2.0.
- **WebApiSample.DataAccess**: A .NET Standard 2.0 class library serving as a data access tier for the 2 Web API projects.

This sample illustrates variations of Web API controller creation:

- [Derive class from ControllerBase](https://docs.microsoft.com/aspnet/core/web-api#derive-class-from-controllerbase)
- [Annotate class with ApiControllerAttribute](https://docs.microsoft.com/aspnet/core/web-api#annotate-class-with-apicontrollerattribute)
