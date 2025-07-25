ASP.NET Core provides the following benefits:

:::moniker range=">= aspnetcore-6.0"

<!-- AUTHOR NOTE: >=6.0 content showcases Blazor and 
                  Minimal APIs, demotes RP/MVC -->

* A unified story for building web apps, web APIs, IoT (Internet of Things) apps, and mobile backends.
* Architected for testability.
* Create rich interactive web UI with [Blazor](xref:blazor/index) using [C#](/dotnet/csharp/)&mdash;no JavaScript required. Reuse your Blazor components to build native mobile and desktop apps with [Blazor Hybrid](xref:blazor/hybrid/index).
* [Minimal APIs](xref:fundamentals/minimal-apis) are a simplified approach for building fast web APIs with minimal code and configuration by fluently declaring API routes and endpoints.
* Ability to develop and run on Windows, macOS, and Linux.
* Open-source and [community-focused](https://dotnet.microsoft.com/platform/community).
* Integrate seamlessly with popular client-side frameworks and libraries, including [Angular](/visualstudio/javascript/tutorial-asp-net-core-with-angular), [React](/visualstudio/javascript/tutorial-asp-net-core-with-react), [Vue](/visualstudio/javascript/tutorial-asp-net-core-with-vue), and [Bootstrap](https://getbootstrap.com/). 
* Add real-time web functionality to apps using [SignalR](xref:signalr/index).
* Support for hosting Remote Procedure Call (RPC) services using [gRPC](xref:grpc/introduction).
* Built-in security features for [authentication](xref:security/authentication/index) and [authorization](xref:security/authorization/introduction).
* A cloud-ready, environment-based [configuration system](xref:fundamentals/configuration/index).
* Built-in [dependency injection](xref:fundamentals/dependency-injection).
* A lightweight, [high-performance](https://github.com/aspnet/benchmarks), and modular HTTP request pipeline.
* Ability to host in the cloud or on-premises with the following:
  * [Kestrel](xref:fundamentals/servers/kestrel)
  * [Azure App Service](https://azure.microsoft.com/products/app-service)
  * [IIS](xref:host-and-deploy/iis/index)
  * [HTTP.sys](xref:fundamentals/servers/httpsys)
  * [Nginx](xref:host-and-deploy/linux-nginx)
  * [Docker](xref:host-and-deploy/docker/index)
* [Side-by-side versioning](/dotnet/standard/choosing-core-framework-server#choose-net).
* Tooling that simplifies modern web development.

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"

<!-- AUTHOR NOTE: >=3.0 <6.0 content showcases Blazor, 
                  demotes RP/MVC, doesn't mention  
                  Minimal APIs -->

* A unified story for building web apps, web APIs, Azure IoT (Internet of Things) apps, and mobile backends.
* Architected for testability.
* [Blazor](xref:blazor/index) lets you create rich interactive client-side UIs using [.NET](/dotnet/standard/tour)/[C#](/dotnet/csharp/) with wide browser support based on HTML/JavaScript, including mobile browsers. You can also build hybrid desktop and mobile apps with .NET and Blazor.
* Supports [Razor Pages](xref:razor-pages/index) and [Model-View-Controller (MVC)](xref:mvc/overview) app development.
* Ability to develop and run on Windows, macOS, and Linux.
* Open-source and [community-focused](https://live.asp.net/).
* Integrate seamlessly with popular client-side frameworks and libraries, including [Angular](/visualstudio/javascript/tutorial-asp-net-core-with-angular), [React](/visualstudio/javascript/tutorial-asp-net-core-with-react), [Vue](/visualstudio/javascript/tutorial-asp-net-core-with-vue), and [Bootstrap](https://getbootstrap.com/). 
* Support for hosting Remote Procedure Call (RPC) services using [gRPC](xref:grpc/index).
* A cloud-ready, environment-based [configuration system](xref:fundamentals/configuration/index).
* Built-in [dependency injection](xref:fundamentals/dependency-injection).
* A lightweight, [high-performance](https://github.com/aspnet/benchmarks), and modular HTTP request pipeline.
* Ability to host in the cloud or on-premises with the following:
  * [Kestrel](xref:fundamentals/servers/kestrel)
  * [Azure App Service](https://azure.microsoft.com/products/app-service)
  * [IIS](xref:host-and-deploy/iis/index)
  * [HTTP.sys](xref:fundamentals/servers/httpsys)
  * [Nginx](xref:host-and-deploy/linux-nginx)
  * [Docker](xref:host-and-deploy/docker/index)
* [Side-by-side versioning](/dotnet/standard/choosing-core-framework-server#choose-net).
* Tooling that simplifies modern web development.

:::moniker-end

:::moniker range="< aspnetcore-3.0"

<!-- AUTHOR NOTE: >=3.0 <6.0 content focuses on RP/MVC, no Blazor, no Minimal APIs -->

* A unified story for building web apps, web APIs, Azure IoT (Internet of Things) apps, and mobile backends.
* Architected for testability.
* Develop apps and APIs using [Razor Pages](xref:razor-pages/index) and [Model-View-Controller (MVC)](xref:mvc/overview) frameworks.
* Ability to develop and run on Windows, macOS, and Linux.
* Open-source and [community-focused](https://live.asp.net/).
* Integrate seamlessly with popular client-side frameworks and libraries, including [Angular](/visualstudio/javascript/tutorial-asp-net-core-with-angular), [React](/visualstudio/javascript/tutorial-asp-net-core-with-react), [Vue](/visualstudio/javascript/tutorial-asp-net-core-with-vue), and [Bootstrap](https://getbootstrap.com/). 
* Support for hosting Remote Procedure Call (RPC) services using [gRPC](xref:grpc/index).
* A cloud-ready, environment-based [configuration system](xref:fundamentals/configuration/index).
* Built-in [dependency injection](xref:fundamentals/dependency-injection).
* A lightweight, [high-performance](https://github.com/aspnet/benchmarks), and modular HTTP request pipeline.
* Ability to host in the cloud or on-premises with the following:
  * [Kestrel](xref:fundamentals/servers/kestrel)
  * [Azure App Service](https://azure.microsoft.com/products/app-service)
  * [IIS](xref:host-and-deploy/iis/index)
  * [HTTP.sys](xref:fundamentals/servers/httpsys)
  * [Nginx](xref:host-and-deploy/linux-nginx)
  * [Docker](xref:host-and-deploy/docker/index)
* [Side-by-side versioning](/dotnet/standard/choosing-core-framework-server#choose-net).
* Tooling that simplifies modern web development.

:::moniker-end
