:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

<a name="kestrel"></a>

## Kestrel endpoint configuration

Kestrel specific endpoint configuration overrides all [cross-server](xref:fundamentals/servers/index) endpoint configurations. Cross-server endpoint configurations include:

* [UseUrls](xref:fundamentals/host/web-host#server-urls)
* `--urls` on the [command line](xref:fundamentals/configuration/index#command-line)
* The [environment variable](xref:fundamentals/configuration/index#environment-variables) `ASPNETCORE_URLS`

Consider the following `appsettings.json` file used in an ASP.NET Core web app:

[!code-json[](~/fundamentals/configuration/index/samples_snippets/5.x/appsettings.json?highlight=2-8)]

When the preceding highlighted markup is used in an ASP.NET Core web app ***and*** the app is launched on the command line with the following cross-server endpoint configuration:

`dotnet run --urls="https://localhost:7777"`

Kestrel binds to the endpoint configured specifically for Kestrel in the `appsettings.json` file (`https://localhost:9999`) and not `https://localhost:7777`.

Consider the Kestrel specific endpoint configured as an environment variable:

`set Kestrel__Endpoints__Https__Url=https://localhost:8888`

In the preceding environment variable, `Https` is the name of the Kestrel specific endpoint. The preceding `appsettings.json` file also defines a Kestrel specific endpoint named `Https`. By [default](#default-host-configuration), environment variables using the [Environment Variables configuration provider](#evcp) are read after `appsettings.{Environment}.json`, therefore, the preceding environment variable is used for the `Https` endpoint.

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"

## GetValue

<xref:Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue%2A?displayProperty=nameWithType> extracts a single value from configuration with a specified key and converts it to the specified type. This method is an extension method for <xref:Microsoft.Extensions.Configuration.IConfiguration>:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/Pages/TestNum.cshtml.cs?name=snippet)]

In the preceding code,  if `NumberKey` isn't found in the configuration, the default value of `99` is used.

## GetSection, GetChildren, and Exists

For the examples that follow, consider the following `MySubsection.json` file:

[!code-json[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/MySubsection.json)]

The following code adds `MySubsection.json` to the configuration providers:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/ProgramJSONsection.cs?name=snippet)]

### GetSection

<xref:Microsoft.Extensions.Configuration.IConfiguration.GetSection%2A?displayProperty=nameWithType> returns a configuration subsection with the specified subsection key.

The following code returns values for `section1`:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/Pages/TestSection.cshtml.cs?name=snippet)]

The following code returns values for `section2:subsection0`:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/Pages/TestSection2.cshtml.cs?name=snippet)]

`GetSection` never returns `null`. If a matching section isn't found, an empty `IConfigurationSection` is returned.

When `GetSection` returns a matching section, <xref:Microsoft.Extensions.Configuration.IConfigurationSection.Value> isn't populated. A <xref:Microsoft.Extensions.Configuration.IConfigurationSection.Key> and <xref:Microsoft.Extensions.Configuration.IConfigurationSection.Path> are returned when the section exists.

### GetChildren and Exists

The following code calls <xref:Microsoft.Extensions.Configuration.IConfiguration.GetChildren%2A?displayProperty=nameWithType> and returns values for `section2:subsection0`:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/Pages/TestSection4.cshtml.cs?name=snippet)]

The preceding code calls <xref:Microsoft.Extensions.Configuration.ConfigurationExtensions.Exists%2A?displayProperty=nameWithType> to verify the  section exists:

 <a name="boa"></a>

## Bind an array

The <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind%2A?displayProperty=nameWithType> supports binding arrays to objects using array indices in configuration keys. Any array format that exposes a numeric key segment is capable of array binding to a [POCO](https://wikipedia.org/wiki/Plain_Old_CLR_Object) class array.

Consider `MyArray.json` from the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/configuration/index/samples/3.x/ConfigSample):

[!code-json[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/MyArray.json)]

The following code adds `MyArray.json` to the configuration providers:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/ProgramJSONarray.cs?name=snippet)]

The following code reads the configuration and displays the values:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/Pages/Array.cshtml.cs?name=snippet)]

The preceding code returns the following output:

```text
Index: 0  Value: value00
Index: 1  Value: value10
Index: 2  Value: value20
Index: 3  Value: value40
Index: 4  Value: value50
```

In the preceding output, Index 3 has value `value40`, corresponding to `"4": "value40",` in `MyArray.json`. The bound array indices are continuous and not bound to the configuration key index. The configuration binder isn't capable of binding null values or creating null entries in bound objects

The  following code loads the `array:entries` configuration with the <xref:Microsoft.Extensions.Configuration.MemoryConfigurationBuilderExtensions.AddInMemoryCollection%2A> extension method:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/ProgramArray.cs?name=snippet)]

The following code reads the configuration in the `arrayDict` `Dictionary` and displays the values:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/Pages/Array.cshtml.cs?name=snippet)]

The preceding code returns the following output:

```text
Index: 0  Value: value0
Index: 1  Value: value1
Index: 2  Value: value2
Index: 3  Value: value4
Index: 4  Value: value5
```

Index &num;3 in the bound object holds the configuration data for the `array:4` configuration key and its value of `value4`. When configuration data containing an array is bound, the array indices in the configuration keys are used to iterate the configuration data when creating the object. A null value can't be retained in configuration data, and a null-valued entry isn't created in a bound object when an array in configuration keys skip one or more indices.

The missing configuration item for index &num;3 can be supplied before binding to the `ArrayExample` instance by any configuration provider that reads the index &num;3 key/value pair. Consider the following `Value3.json` file from the sample download:

[!code-json[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/Value3.json)]

The following code includes configuration for `Value3.json` and the `arrayDict` `Dictionary`:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/ProgramArray.cs?name=snippet2)]

The following code reads the preceding configuration and displays the values:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/Pages/Array.cshtml.cs?name=snippet)]

The preceding code returns the following output:

```text
Index: 0  Value: value0
Index: 1  Value: value1
Index: 2  Value: value2
Index: 3  Value: value3
Index: 4  Value: value4
Index: 5  Value: value5
```

Custom configuration providers aren't required to implement array binding.

## Custom configuration provider

The sample app demonstrates how to create a basic configuration provider that reads configuration key-value pairs from a database using [Entity Framework (EF)](/ef/core/).

The provider has the following characteristics:

* The EF in-memory database is used for demonstration purposes. To use a database that requires a connection string, implement a secondary `ConfigurationBuilder` to supply the connection string from another configuration provider.
* The provider reads a database table into configuration at startup. The provider doesn't query the database on a per-key basis.
* Reload-on-change isn't implemented, so updating the database after the app starts has no effect on the app's configuration.

Define an `EFConfigurationValue` entity for storing configuration values in the database.

`Models/EFConfigurationValue.cs`:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigurationSample/Models/EFConfigurationValue.cs?name=snippet1)]

Add an `EFConfigurationContext` to store and access the configured values.

`EFConfigurationProvider/EFConfigurationContext.cs`:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigurationSample/EFConfigurationProvider/EFConfigurationContext.cs?name=snippet1)]

Create a class that implements <xref:Microsoft.Extensions.Configuration.IConfigurationSource>.

`EFConfigurationProvider/EFConfigurationSource.cs`:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigurationSample/EFConfigurationProvider/EFConfigurationSource.cs?name=snippet1)]

Create the custom configuration provider by inheriting from <xref:Microsoft.Extensions.Configuration.ConfigurationProvider>. The configuration provider initializes the database when it's empty. Since configuration keys are case-insensitive, the dictionary used to initialize the database is created with the case-insensitive comparer ([StringComparer.OrdinalIgnoreCase](xref:System.StringComparer.OrdinalIgnoreCase)).

`EFConfigurationProvider/EFConfigurationProvider.cs`:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigurationSample/EFConfigurationProvider/EFConfigurationProvider.cs?name=snippet1)]

An `AddEFConfiguration` extension method permits adding the configuration source to a `ConfigurationBuilder`.

`Extensions/EntityFrameworkExtensions.cs`:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigurationSample/Extensions/EntityFrameworkExtensions.cs?name=snippet1)]

The following code shows how to use the custom `EFConfigurationProvider` in `Program.cs`:

[!code-csharp[](~/fundamentals/configuration/index/samples_snippets/3.x/ConfigurationSample/Program.cs?highlight=7-8)]

<a name="acs"></a>

## Access configuration in Startup

The following code displays configuration data in `Startup` methods:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/StartupKey.cs?name=snippet&highlight=13,18)]

For an example of accessing configuration using startup convenience methods, see [App startup: Convenience methods](xref:fundamentals/startup#convenience-methods).

## Access configuration in Razor Pages

The following code displays configuration data in a Razor Page:

[!code-cshtml[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/Pages/Test5.cshtml)]

In the following code, `MyOptions` is added to the service container with <xref:Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions.Configure%2A> and bound to configuration:

[!code-csharp[](~/fundamentals/configuration/options/samples/3.x/OptionsSample/Startup3.cs?name=snippet_Example2)]

The following markup uses the [`@inject`](xref:mvc/views/razor#inject) Razor directive to resolve and display the options values:

[!code-cshtml[](~/fundamentals/configuration/options/samples/3.x/OptionsSample/Pages/Test3.cshtml)]

## Access configuration in a MVC view file

The following code displays configuration data in a MVC view:

[!code-cshtml[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/Views/Home2/Index.cshtml)]

## Configure options with a delegate

Options configured in a delegate override values set in the configuration providers.

Configuring options with a delegate is demonstrated as Example 2 in the sample app.

In the following code, an <xref:Microsoft.Extensions.Options.IConfigureOptions%601> service is added to the service container. It uses a delegate to configure values for `MyOptions`:

[!code-csharp[](~/fundamentals/configuration/options/samples/3.x/OptionsSample/Startup2.cs?name=snippet_Example2)]

The following code displays the options values:

[!code-csharp[](~/fundamentals/configuration/options/samples/3.x/OptionsSample/Pages/Test2.cshtml.cs?name=snippet)]

In the preceding example, the values of `Option1` and `Option2` are specified in `appsettings.json` and then overridden by the configured delegate.

<a name="hvac"></a>

## Host versus app configuration

Before the app is configured and started, a *host* is configured and launched. The host is responsible for app startup and lifetime management. Both the app and the host are configured using the configuration providers described in this topic. Host configuration key-value pairs are also included in the app's configuration. For more information on how the configuration providers are used when the host is built and how configuration sources affect host configuration, see <xref:fundamentals/index#host>.

<a name="dhc"></a>

## Default host configuration

For details on the default configuration when using the [Web Host](xref:fundamentals/host/web-host), see the [ASP.NET Core 2.2 version of this topic](?view=aspnetcore-2.2&preserve-view=true).

* Host configuration is provided from:
  * Environment variables prefixed with `DOTNET_` (for example, `DOTNET_ENVIRONMENT`) using the [Environment Variables configuration provider](#evcp). The prefix (`DOTNET_`) is stripped when the configuration key-value pairs are loaded.
  * Command-line arguments using the Command-line configuration provider.
* Web Host default configuration is established (`ConfigureWebHostDefaults`):
  * Kestrel is used as the web server and configured using the app's configuration providers.
  * Add Host Filtering Middleware.
  * Add Forwarded Headers Middleware if the `ASPNETCORE_FORWARDEDHEADERS_ENABLED` environment variable is set to `true`.
  * Enable IIS integration.

## Other configuration

This topic only pertains to *app configuration*. Other aspects of running and hosting ASP.NET Core apps are configured using configuration files not covered in this topic:

* `launch.json`/`launchSettings.json` are tooling configuration files for the Development environment, described:
  * In <xref:fundamentals/environments#development>.
  * Across the documentation set where the files are used to configure ASP.NET Core apps for Development scenarios.
* `web.config` is a server configuration file, described in the following topics:
  * <xref:host-and-deploy/iis/index>
  * <xref:host-and-deploy/aspnet-core-module>

Environment variables set in `launchSettings.json` override those set in the system environment.

For more information on migrating app configuration from earlier versions of ASP.NET, see <xref:migration/proper-to-2x/index#store-configurations>.

## Add configuration from an external assembly

An <xref:Microsoft.AspNetCore.Hosting.IHostingStartup> implementation allows adding enhancements to an app at startup from an external assembly outside of the app's `Startup` class. For more information, see <xref:fundamentals/configuration/platform-specific-configuration>.

## Additional resources

* [Configuration source code](https://github.com/dotnet/runtime/tree/main/src/libraries/Microsoft.Extensions.Configuration)
* <xref:fundamentals/configuration/options>
* <xref:blazor/fundamentals/configuration>

:::moniker-end
