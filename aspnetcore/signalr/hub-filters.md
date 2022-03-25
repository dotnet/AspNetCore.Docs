---
title: Use hub filters in ASP.NET Core SignalR
author: brecon
description: Learn how to use hub filters in ASP.NET Core SignalR.
monikerRange: '>= aspnetcore-5.0'
ms.author: brecon
ms.custom: mvc
ms.date: 05/22/2020
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: signalr/hub-filters
---

# Use hub filters in ASP.NET Core SignalR

Hub filters:

* Are available in ASP.NET Core 5.0 or later.
* Allow logic to run before and after hub methods are invoked by clients.

This article provides guidance for writing and using hub filters.

## Configure hub filters

Hub filters can be applied globally or per hub type. The order in which filters are added is the order in which the filters run. Global hub filters run before local hub filters.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSignalR(options =>
    {
        // Global filters will run first
        options.AddFilter<CustomFilter>();
    }).AddHubOptions<ChatHub>(options =>
    {
        // Local filters will run second
        options.AddFilter<CustomFilter2>();
    });
}
```

A hub filter can be added in one of the following ways:

* Add a filter by concrete type:

    ```csharp
    hubOptions.AddFilter<TFilter>();
    ```

    This will be resolved from dependency injection (DI) or type activated.

* Add a filter by runtime type:

    ```csharp
    hubOptions.AddFilter(typeof(TFilter));
    ```

    This will be resolved from DI or type activated.

* Add a filter by instance:

    ```csharp
    hubOptions.AddFilter(new MyFilter());
    ```

    This instance will be used like a singleton. All hub method invocations will use the same instance.

Hub filters are created and disposed per hub invocation. If you want to store global state in the filter, or no state, add the hub filter type to DI as a singleton for better performance. Alternatively, add the filter as an instance if you can.

## Create hub filters

Create a filter by declaring a class that inherits from `IHubFilter`, and add the `InvokeMethodAsync` method. There is also `OnConnectedAsync` and `OnDisconnectedAsync` that can optionally be implemented to wrap the `OnConnectedAsync` and `OnDisconnectedAsync` hub methods respectively.

```csharp
public class CustomFilter : IHubFilter
{
    public async ValueTask<object> InvokeMethodAsync(
        HubInvocationContext invocationContext, Func<HubInvocationContext, ValueTask<object>> next)
    {
        Console.WriteLine($"Calling hub method '{invocationContext.HubMethodName}'");
        try
        {
            return await next(invocationContext);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception calling '{invocationContext.HubMethodName}': {ex}");
            throw;
        }
    }

    // Optional method
    public Task OnConnectedAsync(HubLifetimeContext context, Func<HubLifetimeContext, Task> next)
    {
        return next(context);
    }

    // Optional method
    public Task OnDisconnectedAsync(
        HubLifetimeContext context, Exception exception, Func<HubLifetimeContext, Exception, Task> next)
    {
        return next(context, exception);
    }
}
```

Filters are very similar to middleware. The `next` method invokes the next filter. The final filter will invoke the hub method. Filters can also store the result from awaiting `next` and run logic after the hub method has been called before returning the result from `next`.

To skip a hub method invocation in a filter, throw an exception of type `HubException` instead of calling `next`. The client will receive an error if it was expecting a result.

## Use hub filters

When writing the filter logic, try to make it generic by using attributes on hub methods instead of checking for hub method names.

Consider a filter that will check a hub method argument for banned phrases and replace any phrases it finds with `***`.
For this example, assume a `LanguageFilterAttribute` class is defined. The class has a property named `FilterArgument` that can be set when using the attribute.

1. Place the attribute on the hub method that has a string argument to be cleaned:

    ```csharp
    public class ChatHub
    {
        [LanguageFilter(filterArgument = 0)]
        public async Task SendMessage(string message, string username)
        {
            await Clients.All.SendAsync("SendMessage", $"{username} says: {message}");
        }
    }
    ```

1. Define a hub filter to check for the attribute and replace banned phrases in a hub method argument with `***`:

    ```csharp
    public class LanguageFilter : IHubFilter
    {
        // populated from a file or inline
        private List<string> bannedPhrases = new List<string> { "async void", ".Result" };

        public async ValueTask<object> InvokeMethodAsync(HubInvocationContext invocationContext, 
            Func<HubInvocationContext, ValueTask<object>> next)
        {
            var languageFilter = (LanguageFilterAttribute)Attribute.GetCustomAttribute(
                invocationContext.HubMethod, typeof(LanguageFilterAttribute));
            if (languageFilter != null &&
                invocationContext.HubMethodArguments.Count > languageFilter.FilterArgument &&
                invocationContext.HubMethodArguments[languageFilter.FilterArgument] is string str)
            {
                foreach (var bannedPhrase in bannedPhrases)
                {
                    str = str.Replace(bannedPhrase, "***");
                }

                arguments = invocationContext.HubMethodArguments.ToArray();
                arguments[languageFilter.FilterArgument] = str;
                invocationContext = new HubInvocationContext(invocationContext.Context,
                    invocationContext.ServiceProvider,
                    invocationContext.Hub,
                    invocationContext.HubMethod,
                    arguments);
            }

            return await next(invocationContext);
        }
    }
    ```

1. Register the hub filter in the `Startup.ConfigureServices` method. To avoid reinitializing the banned phrases list for every invocation, the hub filter is registered as a singleton:

    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSignalR(hubOptions =>
        {
            hubOptions.AddFilter<LanguageFilter>();
        });
    
        services.AddSingleton<LanguageFilter>();
    }
    ```

## The HubInvocationContext object

The `HubInvocationContext` contains information for the current hub method invocation.

| Property | Description | Type |
| ------ | ------ | ----------- |
| `Context ` | The `HubCallerContext` contains information about the connection. | `HubCallerContext` |
| `Hub` | The instance of the Hub being used for this hub method invocation. | `Hub` |
| `HubMethodName` | The name of the hub method being invoked. | `string` |
| `HubMethodArguments` | The list of arguments being passed to the hub method. | `IReadOnlyList<string>` |
| `ServiceProvider` | The scoped service provider for this hub method invocation. | `IServiceProvider` |
| `HubMethod` | The hub method information. | `MethodInfo` |

## The HubLifetimeContext object

The `HubLifetimeContext` contains information for the `OnConnectedAsync` and `OnDisconnectedAsync` hub methods.

| Property | Description | Type |
| ------ | ------ | ----------- |
| `Context ` | The `HubCallerContext` contains information about the connection. | `HubCallerContext` |
| `Hub` | The instance of the Hub being used for this hub method invocation. | `Hub` |
| `ServiceProvider` | The scoped service provider for this hub method invocation. | `IServiceProvider` |

## Authorization and filters

[Authorize attributes on hub methods](xref:signalr/authn-and-authz#use-authorization-handlers-to-customize-hub-method-authorization) run before hub filters.
