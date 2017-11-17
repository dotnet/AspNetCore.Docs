---
title: Detect changes with Change Tokens in ASP.NET Core
author: guardrex
description: Learn how to use Change Tokens to track changes.
ms.author: riande
manager: wpickett
ms.date: 11/10/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/primitives/change-tokens
---
# Detect changes with Change Tokens in ASP.NET Core

By [Luke Latham](https://github.com/guardrex)

A Change Token is a general-purpose, low-level building block used to track changes.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/primitives/change-tokens/sample/) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## IChangeToken interface

The public interface [IChangeToken](/dotnet/api/microsoft.extensions.primitives.ichangetoken) propagates notifications that a change has occurred. `IChangeToken` resides in the [Microsoft.Extensions.Primitives](/dotnet/api/microsoft.extensions.primitives) namespace. For apps that don't use the [Microsoft.AspNetCore.All](https://www.nuget.org/packages/Microsoft.AspNetCore.All/) metapackage, reference the [Microsoft.Extensions.Primitives](https://www.nuget.org/packages/Microsoft.Extensions.Primitives/) NuGet package in the project file.

The interface has two properties:

* [ActiveChangedCallbacks](/dotnet/api/microsoft.extensions.primitives.ichangetoken.activechangecallbacks) indicate if the token proactively raises callbacks. If `ActiveChangedCallbacks` is set to `false`, a callback is never called, and the app must poll `HasChanged` for changes. It's also possible a token will never be cancelled when `ActiveChangedCallbacks` is set to `false`.
* [HasChanged](/dotnet/api/microsoft.extensions.primitives.ichangetoken.haschanged) gets a value that indicates if a change has occurred.

The interface has one method, [RegisterChangeCallback(Action\<Object>, Object)](/dotnet/api/microsoft.extensions.primitives.ichangetoken.registerchangecallback), which registers a callback that's invoked when the token has changed. `HasChanged` must be set before the callback is invoked.

## ChangeToken class

`ChangeToken` is a static class used to propagate notifications that a change has occurred. `ChangeToken` resides in the [Microsoft.Extensions.Primitives](/dotnet/api/microsoft.extensions.primitives) namespace. For apps that don't use the [Microsoft.AspNetCore.All](https://www.nuget.org/packages/Microsoft.AspNetCore.All/) metapackage, reference the [Microsoft.Extensions.Primitives](https://www.nuget.org/packages/Microsoft.Extensions.Primitives/) NuGet package in the project file.

`ChangeToken`'s [OnChange(Func\<IChangeToken>, Action)](/dotnet/api/microsoft.extensions.primitives.changetoken.onchange?view=aspnetcore-2.0#Microsoft_Extensions_Primitives_ChangeToken_OnChange_System_Func_Microsoft_Extensions_Primitives_IChangeToken__System_Action_) method registers an `Action` to call whenever the token changes:
* `Func<IChangeToken>` produces the token.
* `Action` is called when the token changes.

`ChangeToken` has an [OnChange\<TState>(Func\<IChangeToken>, Action\<TState>, TState)](/dotnet/api/microsoft.extensions.primitives.changetoken.onchange?view=aspnetcore-2.0#Microsoft_Extensions_Primitives_ChangeToken_OnChange__1_System_Func_Microsoft_Extensions_Primitives_IChangeToken__System_Action___0____0_) overload that takes an additional `TState` parameter that's passed into the token consumer `Action`.

`OnChange` returns an [IDisposable](/dotnet/api/system.idisposable). Calling [Dispose](/dotnet/api/system.idisposable.dispose) stops the token from listening for further changes and releases the token's resources.

## Example uses of Change Tokens in ASP.NET Core

Change Tokens are seen at work in prominent areas of ASP.NET Core monitoring changes to objects:

* For monitoring changes to files, [IFileProvider](/dotnet/api/microsoft.extensions.fileproviders.ifileprovider)'s [Watch](/dotnet/api/microsoft.extensions.fileproviders.ifileprovider.watch) method creates an `IChangeToken` for the specified files or folder to watch.
* `IChangeToken` tokens can be added to cache entries to trigger cache evictions on change.
* For `TOptions` changes, the default [OptionsMonitor](/dotnet/api/microsoft.extensions.options.optionsmonitor-1) implementation of [IOptionsMonitor](/dotnet/api/microsoft.extensions.options.ioptionsmonitor-1) has an overload that accepts one or more [IOptionsChangeTokenSource](/dotnet/api/microsoft.extensions.options.ioptionschangetokensource-1) instances. Each instance returns an `IChangeToken` to register a change notification callback for tracking options changes.

## Monitoring for configuration changes

By default, ASP.NET Core templates use [JSON configuration files](xref:fundamentals/configuration?tabs=basicconfiguration#simple-configuration) (*appsettings.json*, *appsettings.Development.json*, and *appsettings.Production.json*) to load app configuration settings.

These files are configured using the [AddJsonFile(IConfigurationBuilder, String, Boolean, Boolean)](/dotnet/api/microsoft.extensions.configuration.jsonconfigurationextensions.addjsonfile?view=aspnetcore-2.0#Microsoft_Extensions_Configuration_JsonConfigurationExtensions_AddJsonFile_Microsoft_Extensions_Configuration_IConfigurationBuilder_System_String_System_Boolean_System_Boolean_) extension method on [ConfigurationBuilder](/dotnet/api/microsoft.extensions.configuration.configurationbuilder) that accepts a `reloadOnChange` parameter (ASP.NET Core 1.1 and later). `reloadOnChange` indicates if configuration should be reloaded on file changes. See this setting in the [WebHost](/dotnet/api/microsoft.aspnetcore.webhost) convenience method [CreateDefaultBuilder](/dotnet/api/microsoft.aspnetcore.webhost.createdefaultbuilder) ([reference source](https://github.com/aspnet/MetaPackages/blob/rel/2.0.3/src/Microsoft.AspNetCore/WebHost.cs#L152-L193)):

```csharp
config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
```

File-based configuration is represented by [FileConfigurationSource](/dotnet/api/microsoft.extensions.configuration.fileconfigurationsource). `FileConfigurationSource` uses the [IFileProvider](/dotnet/api/microsoft.extensions.fileproviders.ifileprovider) abstraction ([reference source](https://github.com/aspnet/FileSystem/blob/patch/2.0.1/src/Microsoft.Extensions.FileProviders.Abstractions/IFileProvider.cs)) to monitor files.

By default, the `IFileMonitor` is provided by a [PhysicalFileProvider](/dotnet/api/microsoft.extensions.fileproviders.physicalfileprovider) ([reference source](https://github.com/aspnet/Configuration/blob/patch/2.0.1/src/Microsoft.Extensions.Configuration.FileExtensions/FileConfigurationSource.cs#L82)), which uses [FileSystemWatcher](/dotnet/api/system.io.filesystemwatcher) to monitor for configuration file changes.

The sample app demonstrates two implementations for monitoring configuration changes. If either the *appsettings.json* file changes or the Environment version of the file changes, each implementation executes custom code. The sample app merely writes a message to the console, but implement any behavior desired.

A configuration file's `FileSystemWatcher` can trigger multiple token callbacks for a single configuration file change. The sample's implementation guards against this problem by checking file hashes on the configuration files. Checking file hashes ensures that at least one of the configuration files has changed before running the custom code. The sample uses SHA1 file hashing (*Utilities/Utilities.cs*):

   [!code-csharp[Main](change-tokens/sample/Utilities/Utilities.cs?name=snippet1)]

   A retry is implemented with an exponential back-off. The re-try is present because file locking may occur that temporarily prevents computing a new hash on one of the files.

### Simple startup Change Token

Register a token consumer `Action` callback for change notifications to the configuration reload token (*Startup.cs*):

[!code-csharp[Main](change-tokens/sample/Startup.cs?name=snippet2)]

`config.GetReloadToken()` provides the token. The callback is the `InvokeChanged` method:

[!code-csharp[Main](change-tokens/sample/Startup.cs?name=snippet3)]

The `state` of the callback is used to pass in the `IHostingEnvironment`. This is useful to determine the correct *appsettings* configuration JSON file to monitor, *appsettings.\<Environment>.json*. File hashes are used to prevent the `WriteConsole` statement from running multiple times due to multiple token callbacks when the configuration file has only actually changed once.

This system runs as long as the app is running and can't be disabled by the user.

### Monitoring configuration changes as a service

In addition to the simple startup token monitoring, the sample also implements monitoring as a service and offers a mechanism to enable and disable the monitoring. First, the sample establishes an `IConfigurationMonitor` interface (*Extensions/ConfigurationMonitor.cs*):

[!code-csharp[Main](change-tokens/sample/Extensions/ConfigurationMonitor.cs?name=snippet1)]

The constructor of the implemented class, `ConfigurationMonitor`, registers a callback for change notifications:

[!code-csharp[Main](change-tokens/sample/Extensions/ConfigurationMonitor.cs?name=snippet2)]

As before, `config.GetReloadToken()` supplies the token. `InvokeChanged` is the callback method. The `state` in this instance is a string that describes the monitoring state. Two properties are used:

* `MonitoringEnabled` indicates if the callback should run its custom code.
* `CurrentState` describes the current monitoring state for use in the UI.

The `InvokeChanged` method is similar to the earlier approach, except that it:

* Doesn't run its code unless `MonitoringEnabled` is `true`.
* Sets the `CurrentState` property string to a descriptive message that records the time that the code ran.
* Notes the current `state` in its `WriteConsole` output.

[!code-csharp[Main](change-tokens/sample/Extensions/ConfigurationMonitor.cs?name=snippet3)]

An instance `ConfigurationMonitor` is registered as a service in `ConfigureServices` of *Startup.cs*:

[!code-csharp[Main](change-tokens/sample/Startup.cs?name=snippet1)]

The Index page offers the user control over configuration monitoring. The instance of `IConfigurationMonitor` is injected into the `IndexModel`:

[!code-csharp[Main](change-tokens/sample/Pages/Index.cshtml.cs?name=snippet1)]

The app responds on form submits when the user selects buttons in the interface to enable and disable monitoring:

[!code-cshtml[Main](change-tokens/sample/Pages/Index.cshtml?range=35)]

[!code-csharp[Main](change-tokens/sample/Pages/Index.cshtml.cs?name=snippet2)]

When the user triggers the `OnPostStartMonitoring` method, monitoring is enabled and the current state is cleared. When the user triggers the `OnPostStopMonitoring` method, monitoring is disabled and the state is set to reflect that monitoring is not occurring.

## Monitoring cached file changes

File content is cached in-memory using [IMemoryCache](/dotnet/api/microsoft.extensions.caching.memory.imemorycache). In-memory caching is described in the [Introduction to in-memory caching](xref:performance/caching/memory) topic. When an app finds cached content to return, it returns that content without regard to whether or not the source content has changed. In these cases, the content in the cache has become *stale* (outdated).

Stale cached content is a common problem in apps that use caching. For example, cached file content returned on a [sliding expiration](/dotnet/api/microsoft.extensions.caching.memory.memorycacheentryoptions.slidingexpiration) period isn't updated if the file is changed but requests for the cached file content continually arrive within the sliding expiration window. Each request renews the sliding expiration period, and the file is never reloaded into the cache. Any app features that use the file's cached content are subject to possibly using stale content.

Using change tokens in a file caching scenario avoids the possibility of recovering stale file content from the cache. The sample app demonstrates an implementation of the approach.

The sample establishes a static method to return file content. The method uses a retry algorithm with exponential back-off to cover cases where a file lock is temporarily preventing a file from being read (*Utilities/Utilities.cs*):

[!code-csharp[Main](change-tokens/sample/Utilities/Utilities.cs?name=snippet2)]

A `FileService` is created to handle cached file lookups. The `GetFileContents` method of the service attempts to obtain file content from the in-memory cache and return it to the caller (*Services/FileService.cs*).

If cached content isn't found using the cache key, which is the file path in this example, the following actions are taken:

1. The file content is obtained using `GetFileContent`.
1. The file content is cached with a sliding expiration period.
1. If no change token has been established for the file, a change token is created using the [IFileProviders.Watch](/dotnet/api/microsoft.extensions.fileproviders.ifileprovider.watch) method with a callback that loads the file's content and caches it using the file path as the key.

[!code-csharp[Main](change-tokens/sample/Services/FileService.cs?name=snippet1)]

The `FileService` is registered in the service container (*Startup.cs*):

[!code-csharp[Main](change-tokens/sample/Startup.cs?name=snippet4)]

The page model loads the file's content using the service (*Pages/Index.cshtml.cs*):

[!code-csharp[Main](change-tokens/sample/Pages/Index.cshtml.cs?name=snippet3)]

## CompositeChangeToken class

For representing one or more `IChangeToken` instances in a single object, use the [CompositeChangeToken](/dotnet/api/microsoft.extensions.primitives.compositechangetoken) class ([reference source](https://github.com/aspnet/Common/blob/patch/2.0.1/src/Microsoft.Extensions.Primitives/CompositeChangeToken.cs)).

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

`HasChanged` on the composite token reports `true` if any represented token `HasChanged` is `true`. `ActiveChangeCallbacks` on the composite token reports `true` if any represented token `ActiveChangeCallbacks` is `true`. If multiple concurrent change events occur, the composite change callback is invoked exactly one time.
