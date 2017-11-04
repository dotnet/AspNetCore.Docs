---
title: Detect changes with Change Tokens in ASP.NET Core
author: guardrex
description: Learn how to use Change Tokens to track changes to configuration, arbitrary files, and objects in apps.
ms.author: riande
manager: wpickett
ms.date: 11/06/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/primitives/change-tokens
---
# Detect changes with Change Tokens in ASP.NET Core

By [Luke Latham](https://github.com/guardrex)

[ChangeToken](/dotnet/api/microsoft.extensions.primitives.changetoken) is a general-purpose, low-level building block used to track changes.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/primitives/change-tokens/sample/) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## ChangeToken class

`ChangeToken` is a static class used to propagate notifications that a change has occurred. `ChangeToken` resides in the [Microsoft.Extensions.Primitives](/dotnet/api/microsoft.extensions.primitives) namespace. For apps that don't use the [Microsoft.AspNetCore.All](https://www.nuget.org/packages/Microsoft.AspNetCore.All/) metapackage, reference the [Microsoft.Extensions.Primitives](https://www.nuget.org/packages/Microsoft.Extensions.Primitives/) NuGet package in the project file.

`ChangeToken`'s [OnChange(Func\<IChangeToken>, Action)](/dotnet/api/microsoft.extensions.primitives.changetoken.onchange?view=aspnetcore-2.0#Microsoft_Extensions_Primitives_ChangeToken_OnChange_System_Func_Microsoft_Extensions_Primitives_IChangeToken__System_Action_) method registers an `Action` to call whenever the token changes:
* `Func<IChangeToken>` produces the token.
* `Action` is called when the token changes.

`ChangeToken`'s [OnChange\<TState>(Func\<IChangeToken>, Action\<TState>, TState)](/dotnet/api/microsoft.extensions.primitives.changetoken.onchange?view=aspnetcore-2.0#Microsoft_Extensions_Primitives_ChangeToken_OnChange__1_System_Func_Microsoft_Extensions_Primitives_IChangeToken__System_Action___0____0_) method registers an `Action` to call whenever the token changes with state tracking:
* `TState` is state for the token consumer `Action`.
* `Func<IChangeToken>` produces the token.
* `Action` is called when the token changes.

## IChangeToken interface

The public interface [IChangeToken](/dotnet/api/microsoft.extensions.primitives.ichangetoken) propagates notifications that a change has occurred. The interface has two properties:

* [ActiveChangedCallbacks](/dotnet/api/microsoft.extensions.primitives.ichangetoken.activechangecallbacks) indicate if the token proactively raises callbacks. Callbacks are still guaranteed to fire, eventually. 
* [HasChanged](/dotnet/api/microsoft.extensions.primitives.ichangetoken.haschanged) gets a value that indicates if a change has occurred.

The interface has one method, [RegisterChangeCallback(Action\<Object>, Object)](/dotnet/api/microsoft.extensions.primitives.ichangetoken.registerchangecallback), which registers a callback that's invoked when the token has changed. `HasChanged` must be set before the callback is invoked.

## Monitoring for configuration changes

By default, ASP.NET Core templates use [JSON configuration files](xref:fundamentals/configuration?tabs=basicconfiguration#simple-configuration) (*appsettings.json*, *appsettings.Development.json*, and *appsettings.Production.json*) to load app configuration settings. These files are configured on a [ConfigurationBuilder](/dotnet/api/microsoft.extensions.configuration.configurationbuilder) instance with the [JsonConfigurationExtensions](/dotnet/api/Microsoft.Extensions.Configuration.JsonConfigurationExtensions) class that accepts a `reloadOnChange` parameter (ASP.NET Core 1.1 and later). `reloadOnChange` indicates if configuration should be reloaded on file changes. See this setting in the [WebHost](/dotnet/api/microsoft.aspnetcore.webhost) convenience method [CreateDefaultBuilder](/dotnet/api/microsoft.aspnetcore.webhost.createdefaultbuilder) ([reference source](https://github.com/aspnet/MetaPackages/blob/rel/2.0.3/src/Microsoft.AspNetCore/WebHost.cs#L152-L193)):

```csharp
config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
```

A [FileSystemWatcher](/dotnet/api/system.io.filesystemwatcher) for each of these files triggers a configuration reload token's callback method to reload configuration when a watched file changes. Tap into this system to monitor for changes in configuration and run custom code when configuration files change.

The sample app demonstrates an implementation for monitoring configuration changes. If either the *appsettings.json* file changes or the Environment version of the file changes, custom code runs inside the callback `Action`. The sample app merely writes a message to the console, but implement any behavior desired. For example, write code to determine if specific options created with [IOptionsSnapshot](/dotnet/api/microsoft.extensions.options.ioptionssnapshot-1) have been updated as a result of config changing.

There are two important factors to note when monitoring configuration changes. The sample app takes both into account:

1. The `FileSystemWatcher` on a configuration file can trigger token callbacks multiple times for a single configuration file change. The sample's implementation guards against this problem by checking file hashes on the configuration files. Checking file hashes ensures that at least one of the configuration files has changed before running the custom code. The sample uses SHA1 file hashing (*Utilities/Utilities.cs*):

   [!code-csharp[Main](change-tokens/sample/Utilities/Utilities.cs?name=snippet1)]

   Note that a re-try is implemented with an exponential back-off. The re-try is present because file locking may occur that temporarily prevents computing a new hash on one of the files.

1. Tokens are single-use and don't renew automatically. The sample deals with this issue by creating a new token each time the current token triggers the callback `Action`.

In the `ChangeTokens` class, a [ConfigurationReloadToken](/dotnet/api/microsoft.extensions.configuration.configurationreloadtoken) and a hash field for each of the configuration settings files are created (*Startup.cs*):

[!code-csharp[Main](change-tokens/sample/Startup.cs?name=snippet1)]

The `OnChange` method obtains the token from configuration with `config.GetReloadToken()` and provides the `Action` to execute when the token's callback is triggered. Checking the files' hashes ensures that `WriteConsole` only runs if one of the files has changed. The last two statements trigger the configuration change token and create a new token:

[!code-csharp[Main](change-tokens/sample/Startup.cs?name=snippet2)]

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

`HasChanged` on the composite change token reports `true` if any represented token `HasChanged` is `true`. `ActiveChangeCallbacks` on the composite change token reports `true` if any represented token `ActiveChangeCallbacks` is `true`. If multiple concurrent change events occur, the composite change callback is invoked exactly one time.
