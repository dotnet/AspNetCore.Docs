---
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
The preferred way to read related configuration values is using the [options pattern](xref:fundamentals/configuration/options). For example, to read the following configuration values:

```json
  "Position": {
    "Title": "Editor",
    "Name": "Joe Smith"
  }
```

Create the following `PositionOptions` class:

[!code-csharp[](~/fundamentals/configuration/index/samples/6.x/ConfigSample/Options/PositionOptions.cs?name=snippet)]

An options class:

* Must be non-abstract with a public parameterless constructor.
* All public read-write properties of the type are bound.
* Fields are ***not*** bound. In the preceding code, `Position` is not bound. The `Position` field is used so the string `"Position"` doesn't need to be hard coded in the app when binding the class to a configuration provider.

The following code:

* Calls [ConfigurationBinder.Bind](xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind*) to bind the `PositionOptions` class to the `Position` section.
* Displays the `Position` configuration data.

[!code-csharp[](~/fundamentals/configuration/index/samples/6.x/ConfigSample/Pages/Test22.cshtml.cs?name=snippet)]

In the preceding code, by default, changes to the JSON configuration file after the app has started are read.

[`ConfigurationBinder.Get<T>`](xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get*) binds and returns the specified type. `ConfigurationBinder.Get<T>` may be more convenient than using `ConfigurationBinder.Bind`. The following code shows how to use `ConfigurationBinder.Get<T>` with the `PositionOptions` class:

[!code-csharp[](~/fundamentals/configuration/index/samples/6.x/ConfigSample/Pages/Test21.cshtml.cs?name=snippet)]

In the preceding code, by default, changes to the JSON configuration file after the app has started are read.

An alternative approach when using the ***options pattern*** is to bind the `Position` section and add it to the [dependency injection service container](xref:fundamentals/dependency-injection). In the following code, `PositionOptions` is added to the service container with <xref:Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions.Configure*> and bound to configuration:

[!code-csharp[](~/fundamentals/configuration/index/samples/6.x/ConfigSample/Program.cs?name=snippet)]

Using the preceding code, the following code reads the position options:

[!code-csharp[](~/fundamentals/configuration/index/samples/6.x/ConfigSample/Pages/Test2.cshtml.cs?name=snippet)]

In the preceding code, changes to the JSON configuration file after the app has started are ***not*** read. To read changes after the app has started, use [IOptionsSnapshot](xref:fundamentals/configuration/options#ios).
