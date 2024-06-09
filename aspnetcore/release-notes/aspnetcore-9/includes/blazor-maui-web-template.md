### .NET MAUI Blazor hybrid and web solution template

A new solution template makes it easier to create .NET MAUI native and Blazor web client apps that share the same UI. This template shows how to create client apps that can target Android, iOS, Mac, Windows, and Web while maximizing code reuse. 

Key features of this template include:

* The ability to choose a Blazor interactive render mode for the web app.
* Automatic creation of the appropriate projects, including a Blazor Web App and a .NET MAUI Blazor Hybrid app.
* The created projects are wired up to use a shared Razor Class Library that contains all of the UI components and pages.
* Sample code that demonstrates how to use service injection to provide different interface implementations for the Blazor Hybrid and Blazor Web App. In .NET 8 this is a manual process documented in [Build a .NET MAUI Blazor Hybrid app with a Blazor Web App](https://aka.ms/maui-blazor-web).

To get started, install the [.NET 9 SDK](https://get.dot.net/9) and install the .NET MAUI workload, which contains the template.

```dotnetcli
dotnet workload install maui
```

Then create the template from the command line like this:

```dotnetcli
dotnet new maui-blazor-web
```

The template is also available in Visual Studio.
> [!NOTE]
> Currently Blazor hybrid apps throw an exception if the Blazor rendering modes are defined at the page/component level. For more information, see [#51235](https://github.com/dotnet/aspnetcore/issues/51235).
