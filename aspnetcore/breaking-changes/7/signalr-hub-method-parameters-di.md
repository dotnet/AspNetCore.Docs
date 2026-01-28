---
title: "Breaking change: SignalR Hub methods try to resolve parameters from DI"
description: Learn about the breaking change in ASP.NET Core 7.0 where SignalR Hub methods try to resolve parameters from DI.
ms.date: 03/03/2022
ms.custom: https://github.com/aspnet/Announcements/issues/479
---

# SignalR Hub methods try to resolve parameters from DI

SignalR Hub methods now support injecting services from your Dependency Injection (DI) container. In rare cases, this can break apps that have a type in DI that is also accepted in Hub methods from SignalR client messages.

## Version introduced

ASP.NET Core 7.0

## Previous behavior

If you accepted a type in your Hub method that was also in your Dependency Injection container, the type would always be resolved from a message sent by the client.

```csharp
Services.AddScoped<SomeCustomType>();

class MyHub : Hub
{
    // type always comes from the client, never comes from DI
    public Task Method(string text, SomeCustomType type) => Task.CompletedTask;
}
```

## New behavior

Types in DI are checked at app startup using <xref:Microsoft.Extensions.DependencyInjection.IServiceProviderIsService> to determine if an argument in a Hub method comes from DI or from the client.

In the following example, which assumes you're using the default DI container, `SomeCustomType` comes from the DI container instead of from the client. If the client tries to send `SomeCustomType`, it gets an error:

```csharp
Services.AddScoped<SomeCustomType>();

class MyHub : Hub
{
    // comes from DI by default
    public Task Method(string text, SomeCustomType type) => Task.CompletedTask;
}
```

## Type of breaking change

This change affects [source compatibility](/dotnet/core/compatibility/categories#source-compatibility).

## Reason for change

This change improves the user experience when using different services in different Hub methods. It also improves performance by not requiring the user to inject all dependencies in the Hub's constructor.

The likelihood of breaking apps is low as it isn't common to have a type in DI and as an argument in your Hub method at the same time.

## Recommended action

If you're broken by this change, you can disable the feature by setting `DisableImplicitFromServicesParameters` to true:

```csharp
Services.AddSignalR(options =>
{
    options.DisableImplicitFromServicesParameters = true;
});
```

If you're broken by the change, but you want to use the feature without breaking clients, you can disable the feature as shown above and use an attribute that implements <xref:Microsoft.AspNetCore.Http.Metadata.IFromServiceMetadata> on *new* arguments/Hub methods:

```csharp
Services.AddScoped<SomeCustomType>();
Services.AddScoped<SomeCustomType2>();

class MyHub : Hub
{
    // old method with new feature (non-breaking), only SomeCustomType2 is resolved from DI
    public Task MethodA(string arguments, SomeCustomType type, [FromServices] SomeCustomType2 type2);

    // new method
    public Task MethodB(string arguments, [FromServices] SomeCustomType type);
}
```

## Affected APIs

Hub methods
