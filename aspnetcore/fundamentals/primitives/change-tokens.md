---
title: Detect changes with Change Tokens in ASP.NET Core
author: guardrex
description: Learn how to use Change Tokens to track changes to configuration, arbitrary files, and objects in your apps.
ms.author: riande
manager: wpickett
ms.date: 10/28/2017
ms.topic: article
ms.assetid: 86f4f9c5-d40f-4d21-8b1f-b11cec86f29e
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/primitives/change-tokens
---
# Detect changes with Change Tokens in ASP.NET Core

By [Luke Latham](https://github.com/guardrex)

[ChangeToken](/dotnet/api/microsoft.extensions.primitives.changetoken) is a general-purpose, low-level building block that you can use to track changes to configuration, arbitrary files, and objects in your apps.

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

By default, ASP.NET Core templates use [JSON configuration files](xref:fundamentals/configuration?tabs=basicconfiguration#simple-configuration) (*appsettings.json*, *appsettings.Development.json*, and *appsettings.Production.json*) to load app configuration settings. These files are configured on a [ConfigurationBuilder](/dotnet/api/microsoft.extensions.configuration.configurationbuilder) instance with the [JsonConfigurationExtensions](/dotnet/api/Microsoft.Extensions.Configuration.JsonConfigurationExtensions) class that accepts a `reloadOnChange` parameter (ASP.NET Core 1.1 and later). `reloadOnChange` indicates if configuration should be reloaded on file changes. You can see this setting in the [WebHost](/dotnet/api/microsoft.aspnetcore.webhost) convenience method [CreateDefaultBuilder](/dotnet/api/microsoft.aspnetcore.webhost.createdefaultbuilder) ([reference source](https://github.com/aspnet/MetaPackages/blob/rel/2.0.3/src/Microsoft.AspNetCore/WebHost.cs#L152-L193)):

```csharp
config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
      .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
```

A [FileSystemWatcher](/dotnet/api/system.io.filesystemwatcher) for each of these files triggers a configuration reload token's callback method to reload configuration when a watched file changes. You can tap into this system to monitor for changes in configuration and run custom code when configuration files change.

The sample app demonstrates an implementation for monitoring configuration changes. If either the *appsettings.json* file changes or the Environment version of the file changes, custom code runs inside the callback `Action`. The sample app merely writes a message to the console, but you can implement any behavior you desire.

There are two important factors to note when monitoring configuration changes. The sample app takes both into account:

1. The `FileSystemWatcher` on a configuration file can trigger token callbacks multiple times for a single configuration file change. The sample's implementation guards against this problem by checking file hashes on the configuration files. Checking file hashes ensures that at least one of the configuration files has changed before running the custom code. The sample uses SHA1 file hashing (*Utilities/Utilities.cs*):

   [!code-csharp[Main](change-tokens/sample/Utilities/Utilities.cs?name=snippet1)]

1. Tokens are single-use and don't renew automatically. The sample deals with this issue by creating a new token each time the current token triggers the callback `Action`.

In the `ChangeTokens` class, a [ConfigurationReloadToken](/dotnet/api/microsoft.extensions.configuration.configurationreloadtoken) and a hash field for each of the configuration settings files are created (*ChangeTokens.cs*):

[!code-csharp[Main](change-tokens/sample/ChangeTokens.cs?name=snippet1)]

The `OnChange` method obtains the token from configuration with `config.GetReloadToken()` and provides the `Action` to execute when the token's callback is triggered. Checking the files' hashes ensures that `PrintConsole` only runs if one of the files has changed. The last two statements trigger the configuration change token and create a new token:

[!code-csharp[Main](change-tokens/sample/ChangeTokens.cs?name=snippet5)]

## Monitoring for changes to arbitrary files

You can monitor changes to arbitrary files using a similar approach to the one used by the configuration system.

The sample app keeps track of the modification state of a test file, *poem.txt*, which contains a few lines from Edgar Allan Poe's *Spirits of the Dead*. The possible states of the file are kept in an `enum` (*Enums/Enums.cs*):

[!code-csharp[Main](change-tokens/sample/Enums/Enums.cs?name=snippet1)]

A static `MonitorFile` class holds the name, path, and current file state (*Data/MonitorFile.cs*):

[!code-csharp[Main](change-tokens/sample/Data/MonitorFile.cs?name=snippet1)]

`FileChangeToken` implements the [IChangeToken](/dotnet/api/microsoft.extensions.primitives.ichangetoken) interface and provides the same logic that [ConfigurationReloadToken](/dotnet/api/microsoft.extensions.configuration.configurationreloadtoken) uses to implement `IChangeToken` for configuration change tracking (*Extensions/FileChangeToken.cs*):

[!code-csharp[Main](change-tokens/sample/Extensions/FileChangeToken.cs?name=snippet1)]

The token doesn't automatically renew when the callback is triggered. The sample deals with this issue by creating a new token each time the current token triggers the callback `Action`.

The sample creates a token, `_fileChangeToken`, for monitoring the next file change after each callback. A hash field is created for use in the callback `Action` to ensure that the custom code is only executed once (*ChangeTokens.cs*):

[!code-csharp[Main](change-tokens/sample/ChangeTokens.cs?name=snippet2)]

The `OnChange` method creates the token using the [ContentRootFileProvider](/dotnet/api/microsoft.aspnetcore.hosting.ihostingenvironment.contentrootfileprovider). The `Action` is executed on callback, and the final two statements trigger the file change token and create a new token (*ChangeTokens.cs*):

[!code-csharp[Main](change-tokens/sample/ChangeTokens.cs?name=snippet6)]

## Monitoring for changes in objects

You can use `ChangeToken` to execute custom code when you trigger the callback `Action` on a `ChangeToken` manually. `ChangeTokens` can also maintain state, which you can use within your callbacks.

The sample app includes a simple message tracking system with the following characteristics:

* Accepts user text from the UI and stores it in an in-memory database (a message "Add" operation).
* Allows each message to be deleted (a message "Delete" operation).
* Allows all of the messages to be deleted (a "DeleteAll" operation).

When a message change occurs, the sample app updates a static property to keep track of the type of change that occurred. It also passes in the type of change that occurred as the state for the callback. The state is merely written out to the console when the callback `Action` is triggered, but you can implement any use of the callback state you desire.

An `enum` describes the types of changes that occur in the message system of the sample app (*Enums/Enums.cs*):

[!code-csharp[Main](change-tokens/sample/Enums/Enums.cs?name=snippet2)]

The implementation of `IChangeToken` for `MessageChangeToken` is different than that used for the configuration and file monitoring examples shown earlier. This version of the token has a callback that's triggered by a call to a `Changed` method. The `Changed` method:

* Accepts a `MessageChangeType`.
* Sets a global static property on the `ChangeTokens` class (`LastMessageChangeType = messageChangeType`).
* Sets `HasChanged` to `true` before triggering the callback with the state representing the `MessageChangeType`.

*Extensions/MessageChangeToken.cs*:

[!code-csharp[Main](change-tokens/sample/Extensions/MessageChangeToken.cs?name=snippet1&highlight=14-19)]

The `OnChange` method creates the token and executes the custom code (`PrintConsole`) on callback. Note how the state (`MessageChangeType`) is passed into the token consumer `Action` and used in the call to `PrintConsole` (*ChangeTokens.cs*):

[!code-csharp[Main](change-tokens/sample/ChangeTokens.cs?name=snippet7)]

Unlike monitoring configuration and arbitrary files described earlier, new tokens aren't generated each callback in the token consumer `Action` of the `OnChange` method. The `Action` of the callback is to trigger another callback. Using this approach, only one token is required by the app.

In the code-behind file of the Object Watching page (*Pages/ObjectWatching.csthml.cs*), the `OnPostAddMessageAsync` method, which handles adding messages, calls the `Changed` method with the type of change that occurred:

[!code-csharp[Main](change-tokens/sample//Pages/ObjectWatching.cshtml.cs?name=snippet1&highlight=3)]

Similarly, the `OnPostDeleteAllMessagesAsync` and `OnPostDeleteMessageAsync` methods call `Changed` with their respective change types:

[!code-csharp[Main](change-tokens/sample//Pages/ObjectWatching.cshtml.cs?name=snippet2)]

[!code-csharp[Main](change-tokens/sample//Pages/ObjectWatching.cshtml.cs?name=snippet3)]

## Monitoring objects without state

The sample uses the overload of `OnChange` that accepts a state parameter, [OnChange\<TState>(Func\<IChangeToken>, Action\<TState>, TState)](/dotnet/api/microsoft.extensions.primitives.changetoken.onchange?view=aspnetcore-2.0#Microsoft_Extensions_Primitives_ChangeToken_OnChange__1_System_Func_Microsoft_Extensions_Primitives_IChangeToken__System_Action___0____0_). You can also use `OnChange` without passing state to the callback with [OnChange(Func\<IChangeToken>, Action)](/dotnet/api/microsoft.extensions.primitives.changetoken.onchange?view=aspnetcore-2.0#Microsoft_Extensions_Primitives_ChangeToken_OnChange_System_Func_Microsoft_Extensions_Primitives_IChangeToken__System_Action_) (*Extensions/MessageChangeTokenNoState.cs*):

[!code-csharp[Main](change-tokens/sample/Extensions/MessageChangeTokenNoState.cs?name=snippet1)]

*ChangeTokens.cs*:

[!code-csharp[Main](change-tokens/sample/ChangeTokens.cs?name=snippet4)]

[!code-csharp[Main](change-tokens/sample/ChangeTokens.cs?name=snippet8)]

Although the sample contains the code that enables the use of the `MessageChangeTokenNoState` token, the token itself isn't implemented by the app's messaging system in the Object Watch page. If you wish to enable the use of the `MessageChangeTokenNoState` token, perform the following steps:

1. Open the *Pages/ObjectWatching.cshtml.cs* code-behind file.
1. In the `OnPostAddMessageAsync`, `OnPostAddMessageAsync`, and `OnPostDeleteMessageAsync` methods, find the line in each method that contains the call to `MessageChangeToken.Changed`.
1. Change `MessageChangeToken` to `MessageChangeTokenNoState`.
1. Run the app. When you trigger a message change in the UI, the console logs "Messages changed" in the `MessageChangeTokenNoState` callback.

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
