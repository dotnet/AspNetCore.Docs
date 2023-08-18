---
title: Detect changes with change tokens in ASP.NET Core
author: rick-anderson
description: Learn how to use change tokens to track changes.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.date: 10/07/2019
uid: fundamentals/change-tokens
---
# Detect changes with change tokens in ASP.NET Core

:::moniker range=">= aspnetcore-3.0"

A *change token* is a general-purpose, low-level building block used to track state changes.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/change-tokens/samples/) ([how to download](xref:index#how-to-download-a-sample))

## IChangeToken interface

<xref:Microsoft.Extensions.Primitives.IChangeToken> propagates notifications that a change has occurred. `IChangeToken` resides in the <xref:Microsoft.Extensions.Primitives?displayProperty=fullName> namespace. The [Microsoft.Extensions.Primitives](https://www.nuget.org/packages/Microsoft.Extensions.Primitives/) NuGet package is implicitly provided to the ASP.NET Core apps.

`IChangeToken` has two properties:

* <xref:Microsoft.Extensions.Primitives.IChangeToken.ActiveChangeCallbacks> indicate if the token proactively raises callbacks. If `ActiveChangedCallbacks` is set to `false`, a callback is never called, and the app must poll `HasChanged` for changes. It's also possible for a token to never be cancelled if no changes occur or the underlying change listener is disposed or disabled.
* <xref:Microsoft.Extensions.Primitives.IChangeToken.HasChanged> receives a value that indicates if a change has occurred.

The `IChangeToken` interface includes the [RegisterChangeCallback(Action\<Object>, Object)](xref:Microsoft.Extensions.Primitives.IChangeToken.RegisterChangeCallback*) method, which registers a callback that's invoked when the token has changed. `HasChanged` must be set before the callback is invoked.

## ChangeToken class

<xref:Microsoft.Extensions.Primitives.ChangeToken> is a static class used to propagate notifications that a change has occurred. `ChangeToken` resides in the <xref:Microsoft.Extensions.Primitives?displayProperty=fullName> namespace. The [Microsoft.Extensions.Primitives](https://www.nuget.org/packages/Microsoft.Extensions.Primitives/) NuGet package is implicitly provided to the ASP.NET Core apps.

The [ChangeToken.OnChange(Func\<IChangeToken>, Action)](xref:Microsoft.Extensions.Primitives.ChangeToken.OnChange*) method registers an `Action` to call whenever the token changes:

* `Func<IChangeToken>` produces the token.
* `Action` is called when the token changes.

The [ChangeToken.OnChange\<TState>(Func\<IChangeToken>, Action\<TState>, TState)](xref:Microsoft.Extensions.Primitives.ChangeToken.OnChange*) overload takes an additional `TState` parameter that's passed into the token consumer `Action`.

`OnChange` returns an <xref:System.IDisposable>. Calling <xref:System.IDisposable.Dispose*> stops the token from listening for further changes and releases the token's resources.

## Example uses of change tokens in ASP.NET Core

Change tokens are used in prominent areas of ASP.NET Core to monitor for changes to objects:

* For monitoring changes to files, <xref:Microsoft.Extensions.FileProviders.IFileProvider>'s <xref:Microsoft.Extensions.FileProviders.IFileProvider.Watch*> method creates an `IChangeToken` for the specified files or folder to watch.
* `IChangeToken` tokens can be added to cache entries to trigger cache evictions on change.
* For `TOptions` changes, the default <xref:Microsoft.Extensions.Options.OptionsMonitor`1> implementation of <xref:Microsoft.Extensions.Options.IOptionsMonitor`1> has an overload that accepts one or more <xref:Microsoft.Extensions.Options.IOptionsChangeTokenSource`1> instances. Each instance returns an `IChangeToken` to register a change notification callback for tracking options changes.

## Monitor for configuration changes

By default, ASP.NET Core templates use [JSON configuration files](xref:fundamentals/configuration/index#json-configuration-provider) (`appsettings.json`, `appsettings.Development.json`, and `appsettings.Production.json`) to load app configuration settings.

These files are configured using the [AddJsonFile(IConfigurationBuilder, String, Boolean, Boolean)](xref:Microsoft.Extensions.Configuration.JsonConfigurationExtensions.AddJsonFile*) extension method on <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder> that accepts a `reloadOnChange` parameter. `reloadOnChange` indicates if configuration should be reloaded on file changes. This setting appears in the <xref:Microsoft.Extensions.Hosting.Host> convenience method <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder*>:

```csharp
config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, 
          reloadOnChange: true);
```

File-based configuration is represented by <xref:Microsoft.Extensions.Configuration.FileConfigurationSource>. `FileConfigurationSource` uses <xref:Microsoft.Extensions.FileProviders.IFileProvider> to monitor files.

By default, the `IFileMonitor` is provided by a <xref:Microsoft.Extensions.FileProviders.PhysicalFileProvider>, which uses <xref:System.IO.FileSystemWatcher> to monitor for configuration file changes.

The sample app demonstrates two implementations for monitoring configuration changes. If any of the `appsettings` files change, both of the file monitoring implementations execute custom code&mdash;the sample app writes a message to the console.

A configuration file's `FileSystemWatcher` can trigger multiple token callbacks for a single configuration file change. To ensure that the custom code is only run once when multiple token callbacks are triggered, the sample's implementation checks file hashes. The sample uses SHA1 file hashing. A retry is implemented with an exponential back-off.

`Utilities/Utilities.cs`:

[!code-csharp[](change-tokens/samples/3.x/SampleApp/Utilities/Utilities.cs?name=snippet1)]

### Simple startup change token

Register a token consumer `Action` callback for change notifications to the configuration reload token.

In `Startup.Configure`:

[!code-csharp[](change-tokens/samples/3.x/SampleApp/Startup.cs?name=snippet2)]

`config.GetReloadToken()` provides the token. The callback is the `InvokeChanged` method:

[!code-csharp[](change-tokens/samples/3.x/SampleApp/Startup.cs?name=snippet3)]

The `state` of the callback is used to pass in the `IWebHostEnvironment`, which is useful for specifying the correct `appsettings` configuration file to monitor (for example, `appsettings.Development.json` when in the Development environment). File hashes are used to prevent the `WriteConsole` statement from running multiple times due to multiple token callbacks when the configuration file has only changed once.

This system runs as long as the app is running and can't be disabled by the user.

### Monitor configuration changes as a service

The sample implements:

* Basic startup token monitoring.
* Monitoring as a service.
* A mechanism to enable and disable monitoring.

The sample establishes an `IConfigurationMonitor` interface.

`Extensions/ConfigurationMonitor.cs`:

[!code-csharp[](change-tokens/samples/3.x/SampleApp/Extensions/ConfigurationMonitor.cs?name=snippet1)]

The constructor of the implemented class, `ConfigurationMonitor`, registers a callback for change notifications:

[!code-csharp[](change-tokens/samples/3.x/SampleApp/Extensions/ConfigurationMonitor.cs?name=snippet2)]

`config.GetReloadToken()` supplies the token. `InvokeChanged` is the callback method. The `state` in this instance is a reference to the `IConfigurationMonitor` instance that's used to access the monitoring state. Two properties are used:

* `MonitoringEnabled`: Indicates if the callback should run its custom code.
* `CurrentState`: Describes the current monitoring state for use in the UI.

The `InvokeChanged` method is similar to the earlier approach, except that it:

* Doesn't run its code unless `MonitoringEnabled` is `true`.
* Outputs the current `state` in its `WriteConsole` output.

[!code-csharp[](change-tokens/samples/3.x/SampleApp/Extensions/ConfigurationMonitor.cs?name=snippet3)]

An instance `ConfigurationMonitor` is registered as a service in `Startup.ConfigureServices`:

[!code-csharp[](change-tokens/samples/3.x/SampleApp/Startup.cs?name=snippet1)]

The Index page offers the user control over configuration monitoring. The instance of `IConfigurationMonitor` is injected into the `IndexModel`.

`Pages/Index.cshtml.cs`:

[!code-csharp[](change-tokens/samples/3.x/SampleApp/Pages/Index.cshtml.cs?name=snippet1)]

The configuration monitor (`_monitor`) is used to enable or disable monitoring and set the current state for UI feedback:

[!code-csharp[](change-tokens/samples/3.x/SampleApp/Pages/Index.cshtml.cs?name=snippet2)]

When `OnPostStartMonitoring` is triggered, monitoring is enabled, and the current state is cleared. When `OnPostStopMonitoring` is triggered, monitoring is disabled, and the state is set to reflect that monitoring isn't occurring.

Buttons in the UI enable and disable monitoring.

`Pages/Index.cshtml`:

[!code-cshtml[](change-tokens/samples/3.x/SampleApp/Pages/Index.cshtml?name=snippet_Buttons)]

## Monitor cached file changes

File content can be cached in-memory using <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache>. In-memory caching is described in the [Cache in-memory](xref:performance/caching/memory) topic. Without taking additional steps, such as the implementation described below, *stale* (outdated) data is returned from a cache if the source data changes.

For example, not taking into account the status of a cached source file when renewing a [sliding expiration](xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions.SlidingExpiration) period leads to stale cached file data. Each request for the data renews the sliding expiration period, but the file is never reloaded into the cache. Any app features that use the file's cached content are subject to possibly receiving stale content.

Using change tokens in a file caching scenario prevents the presence of stale file content in the cache. The sample app demonstrates an implementation of the approach.

The sample uses `GetFileContent` to:

* Return file content.
* Implement a retry algorithm with exponential back-off to cover cases where a file access problem temporarily delays reading the file's content.

`Utilities/Utilities.cs`:

[!code-csharp[](change-tokens/samples/3.x/SampleApp/Utilities/Utilities.cs?name=snippet2)]

A `FileService` is created to handle cached file lookups. The `GetFileContent` method call of the service attempts to obtain file content from the in-memory cache and return it to the caller (`Services/FileService.cs`).

If cached content isn't found using the cache key, the following actions are taken:

1. The file content is obtained using `GetFileContent`.
1. A change token is obtained from the file provider with [IFileProviders.Watch](xref:Microsoft.Extensions.FileProviders.IFileProvider.Watch*). The token's callback is triggered when the file is modified.
1. The file content is cached with a [sliding expiration](xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions.SlidingExpiration) period. The change token is attached with [MemoryCacheEntryExtensions.AddExpirationToken](xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.AddExpirationToken*) to evict the cache entry if the file changes while it's cached.

In the following example, files are stored in the app's [content root](xref:fundamentals/index#content-root). `IWebHostEnvironment.ContentRootFileProvider` is used to obtain an <xref:Microsoft.Extensions.FileProviders.IFileProvider> pointing at the app's `IWebHostEnvironment.ContentRootPath`. The `filePath` is obtained with [IFileInfo.PhysicalPath](xref:Microsoft.Extensions.FileProviders.IFileInfo.PhysicalPath).

[!code-csharp[](change-tokens/samples/3.x/SampleApp/Services/FileService.cs?name=snippet1)]

The `FileService` is registered in the service container along with the memory caching service.

In `Startup.ConfigureServices`:

[!code-csharp[](change-tokens/samples/3.x/SampleApp/Startup.cs?name=snippet4)]

The page model loads the file's content using the service.

In the Index page's `OnGet` method (`Pages/Index.cshtml.cs`):

[!code-csharp[](change-tokens/samples/3.x/SampleApp/Pages/Index.cshtml.cs?name=snippet3)]

## CompositeChangeToken class

For representing one or more `IChangeToken` instances in a single object, use the <xref:Microsoft.Extensions.Primitives.CompositeChangeToken> class.

```csharp
var firstCancellationTokenSource = new CancellationTokenSource();
var secondCancellationTokenSource = new CancellationTokenSource();

var firstCancellationToken = firstCancellationTokenSource.Token;
var secondCancellationToken = secondCancellationTokenSource.Token;

var firstCancellationChangeToken = new CancellationChangeToken(firstCancellationToken);
var secondCancellationChangeToken = new CancellationChangeToken(secondCancellationToken);

var compositeChangeToken = 
    new CompositeChangeToken(
        new List<IChangeToken> 
        {
            firstCancellationChangeToken, 
            secondCancellationChangeToken
        });
```

`HasChanged` on the composite token reports `true` if any represented token `HasChanged` is `true`. `ActiveChangeCallbacks` on the composite token reports `true` if any represented token `ActiveChangeCallbacks` is `true`. If multiple concurrent change events occur, the composite change callback is invoked one time.

:::moniker-end

:::moniker range="< aspnetcore-3.0"

A *change token* is a general-purpose, low-level building block used to track state changes.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/change-tokens/samples/) ([how to download](xref:index#how-to-download-a-sample))

## IChangeToken interface

<xref:Microsoft.Extensions.Primitives.IChangeToken> propagates notifications that a change has occurred. `IChangeToken` resides in the <xref:Microsoft.Extensions.Primitives?displayProperty=fullName> namespace. For apps that don't use the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app), create a package reference for the [Microsoft.Extensions.Primitives](https://www.nuget.org/packages/Microsoft.Extensions.Primitives/) NuGet package.

`IChangeToken` has two properties:

* <xref:Microsoft.Extensions.Primitives.IChangeToken.ActiveChangeCallbacks> indicate if the token proactively raises callbacks. If `ActiveChangedCallbacks` is set to `false`, a callback is never called, and the app must poll `HasChanged` for changes. It's also possible for a token to never be cancelled if no changes occur or the underlying change listener is disposed or disabled.
* <xref:Microsoft.Extensions.Primitives.IChangeToken.HasChanged> receives a value that indicates if a change has occurred.

The `IChangeToken` interface includes the [RegisterChangeCallback(Action\<Object>, Object)](xref:Microsoft.Extensions.Primitives.IChangeToken.RegisterChangeCallback*) method, which registers a callback that's invoked when the token has changed. `HasChanged` must be set before the callback is invoked.

## ChangeToken class

<xref:Microsoft.Extensions.Primitives.ChangeToken> is a static class used to propagate notifications that a change has occurred. `ChangeToken` resides in the <xref:Microsoft.Extensions.Primitives?displayProperty=fullName> namespace. For apps that don't use the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app), create a package reference for the [Microsoft.Extensions.Primitives](https://www.nuget.org/packages/Microsoft.Extensions.Primitives/) NuGet package.

The [ChangeToken.OnChange(Func\<IChangeToken>, Action)](xref:Microsoft.Extensions.Primitives.ChangeToken.OnChange*) method registers an `Action` to call whenever the token changes:

* `Func<IChangeToken>` produces the token.
* `Action` is called when the token changes.

The [ChangeToken.OnChange\<TState>(Func\<IChangeToken>, Action\<TState>, TState)](xref:Microsoft.Extensions.Primitives.ChangeToken.OnChange*) overload takes an additional `TState` parameter that's passed into the token consumer `Action`.

`OnChange` returns an <xref:System.IDisposable>. Calling <xref:System.IDisposable.Dispose*> stops the token from listening for further changes and releases the token's resources.

## Example uses of change tokens in ASP.NET Core

Change tokens are used in prominent areas of ASP.NET Core to monitor for changes to objects:

* For monitoring changes to files, <xref:Microsoft.Extensions.FileProviders.IFileProvider>'s <xref:Microsoft.Extensions.FileProviders.IFileProvider.Watch*> method creates an `IChangeToken` for the specified files or folder to watch.
* `IChangeToken` tokens can be added to cache entries to trigger cache evictions on change.
* For `TOptions` changes, the default <xref:Microsoft.Extensions.Options.OptionsMonitor`1> implementation of <xref:Microsoft.Extensions.Options.IOptionsMonitor`1> has an overload that accepts one or more <xref:Microsoft.Extensions.Options.IOptionsChangeTokenSource`1> instances. Each instance returns an `IChangeToken` to register a change notification callback for tracking options changes.

## Monitor for configuration changes

By default, ASP.NET Core templates use [JSON configuration files](xref:fundamentals/configuration/index#json-configuration-provider) (`appsettings.json`, `appsettings.Development.json`, and `appsettings.Production.json`) to load app configuration settings.

These files are configured using the [AddJsonFile(IConfigurationBuilder, String, Boolean, Boolean)](xref:Microsoft.Extensions.Configuration.JsonConfigurationExtensions.AddJsonFile*) extension method on <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder> that accepts a `reloadOnChange` parameter. `reloadOnChange` indicates if configuration should be reloaded on file changes. This setting appears in the <xref:Microsoft.AspNetCore.WebHost> convenience method <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder*>:

```csharp
config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, 
          reloadOnChange: true);
```

File-based configuration is represented by <xref:Microsoft.Extensions.Configuration.FileConfigurationSource>. `FileConfigurationSource` uses <xref:Microsoft.Extensions.FileProviders.IFileProvider> to monitor files.

By default, the `IFileMonitor` is provided by a <xref:Microsoft.Extensions.FileProviders.PhysicalFileProvider>, which uses <xref:System.IO.FileSystemWatcher> to monitor for configuration file changes.

The sample app demonstrates two implementations for monitoring configuration changes. If any of the `appsettings` files change, both of the file monitoring implementations execute custom code&mdash;the sample app writes a message to the console.

A configuration file's `FileSystemWatcher` can trigger multiple token callbacks for a single configuration file change. To ensure that the custom code is only run once when multiple token callbacks are triggered, the sample's implementation checks file hashes. The sample uses SHA1 file hashing. A retry is implemented with an exponential back-off.

`Utilities/Utilities.cs`:

[!code-csharp[](change-tokens/samples/2.x/SampleApp/Utilities/Utilities.cs?name=snippet1)]

### Simple startup change token

Register a token consumer `Action` callback for change notifications to the configuration reload token.

In `Startup.Configure`:

[!code-csharp[](change-tokens/samples/2.x/SampleApp/Startup.cs?name=snippet2)]

`config.GetReloadToken()` provides the token. The callback is the `InvokeChanged` method:

[!code-csharp[](change-tokens/samples/2.x/SampleApp/Startup.cs?name=snippet3)]

The `state` of the callback is used to pass in the `IHostingEnvironment`, which is useful for specifying the correct `appsettings` configuration file to monitor (for example, `appsettings.Development.json` when in the Development environment). File hashes are used to prevent the `WriteConsole` statement from running multiple times due to multiple token callbacks when the configuration file has only changed once.

This system runs as long as the app is running and can't be disabled by the user.

### Monitor configuration changes as a service

The sample implements:

* Basic startup token monitoring.
* Monitoring as a service.
* A mechanism to enable and disable monitoring.

The sample establishes an `IConfigurationMonitor` interface.

`Extensions/ConfigurationMonitor.cs`:

[!code-csharp[](change-tokens/samples/2.x/SampleApp/Extensions/ConfigurationMonitor.cs?name=snippet1)]

The constructor of the implemented class, `ConfigurationMonitor`, registers a callback for change notifications:

[!code-csharp[](change-tokens/samples/2.x/SampleApp/Extensions/ConfigurationMonitor.cs?name=snippet2)]

`config.GetReloadToken()` supplies the token. `InvokeChanged` is the callback method. The `state` in this instance is a reference to the `IConfigurationMonitor` instance that's used to access the monitoring state. Two properties are used:

* `MonitoringEnabled`: Indicates if the callback should run its custom code.
* `CurrentState`: Describes the current monitoring state for use in the UI.

The `InvokeChanged` method is similar to the earlier approach, except that it:

* Doesn't run its code unless `MonitoringEnabled` is `true`.
* Outputs the current `state` in its `WriteConsole` output.

[!code-csharp[](change-tokens/samples/2.x/SampleApp/Extensions/ConfigurationMonitor.cs?name=snippet3)]

An instance `ConfigurationMonitor` is registered as a service in `Startup.ConfigureServices`:

[!code-csharp[](change-tokens/samples/2.x/SampleApp/Startup.cs?name=snippet1)]

The Index page offers the user control over configuration monitoring. The instance of `IConfigurationMonitor` is injected into the `IndexModel`.

`Pages/Index.cshtml.cs`:

[!code-csharp[](change-tokens/samples/2.x/SampleApp/Pages/Index.cshtml.cs?name=snippet1)]

The configuration monitor (`_monitor`) is used to enable or disable monitoring and set the current state for UI feedback:

[!code-csharp[](change-tokens/samples/2.x/SampleApp/Pages/Index.cshtml.cs?name=snippet2)]

When `OnPostStartMonitoring` is triggered, monitoring is enabled, and the current state is cleared. When `OnPostStopMonitoring` is triggered, monitoring is disabled, and the state is set to reflect that monitoring isn't occurring.

Buttons in the UI enable and disable monitoring.

`Pages/Index.cshtml`:

[!code-cshtml[](change-tokens/samples/2.x/SampleApp/Pages/Index.cshtml?name=snippet_Buttons)]

## Monitor cached file changes

File content can be cached in-memory using <xref:Microsoft.Extensions.Caching.Memory.IMemoryCache>. In-memory caching is described in the [Cache in-memory](xref:performance/caching/memory) topic. Without taking additional steps, such as the implementation described below, *stale* (outdated) data is returned from a cache if the source data changes.

For example, not taking into account the status of a cached source file when renewing a [sliding expiration](xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions.SlidingExpiration) period leads to stale cached file data. Each request for the data renews the sliding expiration period, but the file is never reloaded into the cache. Any app features that use the file's cached content are subject to possibly receiving stale content.

Using change tokens in a file caching scenario prevents the presence of stale file content in the cache. The sample app demonstrates an implementation of the approach.

The sample uses `GetFileContent` to:

* Return file content.
* Implement a retry algorithm with exponential back-off to cover cases where a file access problem temporarily delays reading the file's content.

`Utilities/Utilities.cs`:

[!code-csharp[](change-tokens/samples/2.x/SampleApp/Utilities/Utilities.cs?name=snippet2)]

A `FileService` is created to handle cached file lookups. The `GetFileContent` method call of the service attempts to obtain file content from the in-memory cache and return it to the caller (`Services/FileService.cs`).

If cached content isn't found using the cache key, the following actions are taken:

1. The file content is obtained using `GetFileContent`.
1. A change token is obtained from the file provider with [IFileProviders.Watch](xref:Microsoft.Extensions.FileProviders.IFileProvider.Watch*). The token's callback is triggered when the file is modified.
1. The file content is cached with a [sliding expiration](xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryOptions.SlidingExpiration) period. The change token is attached with [MemoryCacheEntryExtensions.AddExpirationToken](xref:Microsoft.Extensions.Caching.Memory.MemoryCacheEntryExtensions.AddExpirationToken*) to evict the cache entry if the file changes while it's cached.

In the following example, files are stored in the app's [content root](xref:fundamentals/index#content-root). [IHostingEnvironment.ContentRootFileProvider](xref:Microsoft.AspNetCore.Hosting.IHostingEnvironment.ContentRootFileProvider) is used to obtain an <xref:Microsoft.Extensions.FileProviders.IFileProvider> pointing at the app's <xref:Microsoft.AspNetCore.Hosting.IHostingEnvironment.ContentRootPath>. The `filePath` is obtained with [IFileInfo.PhysicalPath](xref:Microsoft.Extensions.FileProviders.IFileInfo.PhysicalPath).

[!code-csharp[](change-tokens/samples/2.x/SampleApp/Services/FileService.cs?name=snippet1)]

The `FileService` is registered in the service container along with the memory caching service.

In `Startup.ConfigureServices`:

[!code-csharp[](change-tokens/samples/2.x/SampleApp/Startup.cs?name=snippet4)]

The page model loads the file's content using the service.

In the Index page's `OnGet` method (`Pages/Index.cshtml.cs`):

[!code-csharp[](change-tokens/samples/2.x/SampleApp/Pages/Index.cshtml.cs?name=snippet3)]

## CompositeChangeToken class

For representing one or more `IChangeToken` instances in a single object, use the <xref:Microsoft.Extensions.Primitives.CompositeChangeToken> class.

```csharp
var firstCancellationTokenSource = new CancellationTokenSource();
var secondCancellationTokenSource = new CancellationTokenSource();

var firstCancellationToken = firstCancellationTokenSource.Token;
var secondCancellationToken = secondCancellationTokenSource.Token;

var firstCancellationChangeToken = new CancellationChangeToken(firstCancellationToken);
var secondCancellationChangeToken = new CancellationChangeToken(secondCancellationToken);

var compositeChangeToken = 
    new CompositeChangeToken(
        new List<IChangeToken> 
        {
            firstCancellationChangeToken, 
            secondCancellationChangeToken
        });
```

`HasChanged` on the composite token reports `true` if any represented token `HasChanged` is `true`. `ActiveChangeCallbacks` on the composite token reports `true` if any represented token `ActiveChangeCallbacks` is `true`. If multiple concurrent change events occur, the composite change callback is invoked one time.

:::moniker-end

## Additional resources

* <xref:performance/caching/memory>
* <xref:performance/caching/distributed>
* <xref:performance/caching/response>
* <xref:performance/caching/middleware>
* <xref:mvc/views/tag-helpers/builtin-th/cache-tag-helper>
* <xref:mvc/views/tag-helpers/builtin-th/distributed-cache-tag-helper>
