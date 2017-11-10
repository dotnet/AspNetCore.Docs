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

* [ActiveChangedCallbacks](/dotnet/api/microsoft.extensions.primitives.ichangetoken.activechangecallbacks) indicate if the token proactively raises callbacks. Callbacks are still guaranteed to fire, eventually. 
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

Change Tokens are seen at work in promonent areas of ASP.NET Core monitoring changes to objects:

* For monitoring changes to files, [IFileProvider](/dotnet/api/microsoft.extensions.fileproviders.ifileprovider)'s [Watch](/dotnet/api/microsoft.extensions.fileproviders.ifileprovider.watch) method creates an `IChangeToken` for the specified files or folder to watch.
* For cache item expiration, the default [MemoryCache](/dotnet/api/microsoft.extensions.caching.memory.memorycache) implementation of [IMemoryCache](/dotnet/api/microsoft.extensions.caching.memory.imemorycache) offers a [Set](/dotnet/api/microsoft.extensions.caching.memory.cacheextensions.set?view=aspnetcore-2.0#Microsoft_Extensions_Caching_Memory_CacheExtensions_Set__1_Microsoft_Extensions_Caching_Memory_IMemoryCache_System_Object___0_Microsoft_Extensions_Primitives_IChangeToken_) overload that uses an `IChangeToken` as an `expirationToken` for the cached item.
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

The `state` of the callback is used to pass in the `IHostingEnvironment`. This is useful to determine the correct *appsettings* configuration JSON file to monitor, *appsettings.\<Environment>.json*. File hashes are used to prevent the `WriteConsole` statement from running muliple times due to multiple token callbacks when the configruation file has only actually changed once.

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

[!code-cshtml[Main](change-tokens/sample/Pages/Index.cshtml?range=35-36)]

[!code-csharp[Main](change-tokens/sample/Pages/Index.cshtml.cs?name=snippet2)]

When the user triggers the `OnPostStartMonitoring` method, monitoring is enabled and the current state is cleared. When the user triggers the `OnPostStopMonitoring` method, monitoring is disabled and the state is set to reflect that monitoring is not occurring.

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
