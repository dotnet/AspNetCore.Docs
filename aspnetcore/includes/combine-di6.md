---
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
<a name="csc"></a>

Consider the following which registers services and configures options:

[!code-csharp[](~/fundamentals/configuration/index/samples/6.x/ConfigSample/program.cs?name=snippet2)]

Related groups of registrations can be moved to an extension method to register services. For example, the configuration services are added to the following class:

[!code-csharp[](~/fundamentals/configuration/index/samples/6.x/ConfigSample/Options/MyConfigServiceCollectionExtensions.cs)]

The remaining services are registered in a similar class. The following code uses the new extension methods to register the services:

[!code-csharp[](~/fundamentals/configuration/index/samples/6.x/ConfigSample/program.cs?name=snippet3)]

**_Note:_** Each `services.Add{GROUP_NAME}` extension method adds and potentially configures services. For example, <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A> adds the services MVC controllers with views require, and <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddRazorPages%2A> adds the services Razor Pages requires. We recommended that apps follow the naming convention of creating extension methods in the <xref:Microsoft.Extensions.DependencyInjection?displayProperty=fullName> namespace. Creating extension methods in the `Microsoft.Extensions.DependencyInjection` namespace:

* Encapsulates groups of service registrations.
* Provides convenient [IntelliSense](/visualstudio/ide/using-intellisense) access to the service.
