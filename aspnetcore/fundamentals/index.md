---
título: Fundamentos ASP.NET Core
autor: rick-anderson
tradutor: calkines
descrição: Este artigo fornece uma visão geral dos conceitos fundamentais a serem entendidos na criação de aplicações ASP.NET Core. 
palavras-chave: ASP.NET Core,fundamentals,overview
ms.autor: riande
gerente: wpickett
ms.data: 08/18/2017
ms.tópico: get-started-article
ms.assetid: a19b7836-63e4-44e8-8250-50d426dd1070
ms.tecnologia: aspnet
ms.produto: asp.net-core
uid: fundamentals/index
ms.custom: H1Hack27Feb2017
---

# Visão geral sobre os fundamentos do ASP.NET Core

Uma aplicação ASP.NET Core é um aplicativo de console que cria um servidor web em seu método `Main`:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!código-csharp[Main](../getting-started/sample/aspnetcoreapp/Program2x.cs)]

O método `Main` invoca o `WebHost.CreateDefaultBuilder`, que segue o Padrão de Construção para criar um host de aplicação web. O construtor tem métodos que definem o servidor web (por exemplo, `UseKestrel`) e a classe Startup (`UseStartup`). No exemplo anterior, um servidor web [Kestrel](xref:fundamentals/servers/kestrel) é automaticamente alocado. O host web do ASP.NET Core tentará executar via IIS, se este estiver disponível. Outros servidores web, como um [HTTP.sys](xref:fundamentals/servers/httpsys), podem ser usados ao invocar o método de extensão apropriado. `UseStartup` será explicado depois, na próxima seção.

`IWebHostBuilder`, o tipo de retorno da invocação ao `WebHost.CreateDefaultBuilder` fornece muitos métodos opcionais. Muitos destes métodos incluem `UseHttpSys` para hospedar a aplicação no HTTP.sys, e `UseContextRoot` para especificar o diretório de conteúdo raiz. Os métodos `Build` e `Run` criam o objeto `IWebHost` que hospedará a aplicação e começará a escutar as requisições HTTP.

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!código-csharp[Main](../getting-started/sample/aspnetcoreapp/Program.cs)]

O método `Main` usa o `WebHostBuilder`, que segue o Padrão de Construção para criar um host de aplicação web. O construtor tem métodos que definem o servidor web (por exemplo, `UseKestrel`) e a classe Startup (`UseStartup`). No exemplo sguinte, o servidor web [Kestrel](xref:fundamentals/servers/kestrel) é usado. Outros servidores web, como [WebListener](xref:fundamentals/servers/weblistener), podem ser usados invocando o método de extensão apropriado. `UseStartup` será explicado depois, na seção seguinte.

O `WebHostBuilder` fornece diversos métodos opcionais, incluindo `UseIISIntegration` para hosts que usam IIS e IIS Express, e `UseContextRoot` para especificar o diretório de conteúdo raiz. Os métodos `Build` e `Run` constroem o objeto `IWebHost` que hospedará a aplicação e começará a escutar as requisições HTTP.

---

## Startup

The `UseStartup` method on `WebHostBuilder` specifies the `Startup` class for your app:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-csharp[Main](../getting-started/sample/aspnetcoreapp/Program2x.cs?highlight=10&range=6-17)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](../getting-started/sample/aspnetcoreapp/Program.cs?highlight=7&range=6-17)]

---

The `Startup` class is where you define the request handling pipeline and where any services needed by the application are configured. The `Startup` class must be public and contain the following methods:

```csharp
public class Startup
{
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app)
    {
    }
}
```

* `ConfigureServices` defines the [Services](#services) used by your application (such as ASP.NET Core MVC, Entity Framework Core, Identity, etc.).

* `Configure` defines the [middleware](xref:fundamentals/middleware) in the request pipeline.

For more information, see [Application startup](xref:fundamentals/startup).

## Services

A service is a component that is intended for common consumption in an application. Services are made available through [dependency injection](xref:fundamentals/dependency-injection) (DI). ASP.NET Core includes a native inversion of control (IoC) container that supports [constructor injection](xref:mvc/controllers/dependency-injection#constructor-injection) by default. The native container can be replaced with your container of choice. In addition to its loose coupling benefit, DI makes services available throughout your application. For example, [logging](xref:fundamentals/logging) is available throughout your application.

For more information, see [Dependency injection](xref:fundamentals/dependency-injection).

## Middleware

In ASP.NET Core, you compose your request pipeline using [Middleware](xref:fundamentals/middleware). ASP.NET Core middleware performs asynchronous logic on an `HttpContext` and then either invokes the next middleware in the sequence or terminates the request directly. A middleware component called "XYZ" is added by invoking a `UseXYZ` extension method in the `Configure` method.

ASP.NET Core comes with a rich set of built-in middleware:

* [Static files](xref:fundamentals/static-files)

* [Routing](xref:fundamentals/routing)

* [Authentication](xref:security/authentication/index)

You can use any [OWIN](http://owin.org)-based middleware with ASP.NET Core, and you can write your own custom middleware.

For more information, see [Middleware](xref:fundamentals/middleware) and [Open Web Interface for .NET (OWIN)](xref:fundamentals/owin).

## Servers

The ASP.NET Core hosting model does not directly listen for requests; rather, it relies on an HTTP server implementation to forward the request to the application. The forwarded request is wrapped as a set of feature objects that you can access through interfaces. The application composes this set into an `HttpContext`. ASP.NET Core includes a managed, cross-platform web server, called [Kestrel](xref:fundamentals/servers/kestrel). Kestrel is typically run behind a production web server like [IIS](https://www.iis.net/) or [nginx](http://nginx.org).

For more information, see [Servers](xref:fundamentals/servers/index) and [Hosting](xref:fundamentals/hosting).

## Content root

The content root is the base path to any content used by the app, such as views, [Razor Pages](xref:mvc/razor-pages/index), and static assets. By default, the content root is the same as application base path for the executable hosting the application. An alternative location for content root is specified with `WebHostBuilder`.

## Web root

The web root of an application is the directory in the project containing public, static resources like CSS, JavaScript, and image files. By default, the static files middleware will only serve files from the web root directory and its sub-directories. See [working with static files](xref:fundamentals/static-files) for more info. The web root path defaults to */wwwroot*, but you can specify a different location using the `WebHostBuilder`.

## Configuration

ASP.NET Core uses a new configuration model for handling simple name-value pairs. The new configuration model is not based on `System.Configuration` or *web.config*; rather, it pulls from an ordered set of configuration providers. The built-in configuration providers support a variety of file formats (XML, JSON, INI) and environment variables to enable environment-based configuration. You can also write your own custom configuration providers.

For more information, see [Configuration](xref:fundamentals/configuration).

## Environments

Environments, like "Development" and "Production", are a first-class notion in ASP.NET Core and can be set using environment variables.

For more information, see [Working with Multiple Environments](xref:fundamentals/environments).

## .NET Core vs. .NET Framework runtime

An ASP.NET Core application can target the .NET Core or .NET Framework runtime. For more information, see [Choosing between .NET Core and .NET Framework](https://docs.microsoft.com/dotnet/articles/standard/choosing-core-framework-server).

## Additional information

See also the following topics:

- [Error Handling](xref:fundamentals/error-handling)
- [File Providers](xref:fundamentals/file-providers)
- [Globalization and localization](xref:fundamentals/localization)
- [Logging](xref:fundamentals/logging)
- [Managing Application State](xref:fundamentals/app-state)
