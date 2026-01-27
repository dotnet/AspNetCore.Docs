---
title: "Breaking change: Default authentication scheme"
description: Learn about the breaking change in ASP.NET Core 7.0 where a singly registered authentication scheme will cause it to be used as the default.
ms.date: 07/20/2022
ms.custom: https://github.com/aspnet/Announcements/issues/490
---
# Default authentication scheme

Starting in .NET 7, we introduced new behavior in the authentication area in ASP.NET Core.

Previously, users were required to set the default authentication scheme, which is used by authentication and authorization handlers, in the `AddAuthentication` call:

```csharp
builder.Services.AddAuthentication("MyDefaultScheme");
```

Moving forward, when a *single* authentication scheme is registered, that scheme is treated as the default scheme. For example, "MyDefaultScheme" is treated as the default scheme in the following code.

```csharp
builder.Services.AddAuthentication().AddOAuth("MyDefaultScheme");
```

This change might expose unintended behavior changes in applications, such as authentication options being validated earlier than expected.

## Version introduced

ASP.NET Core 7.0

## Previous behavior

Previously, when users did not provide a default scheme in the `AddAuthentication` call, no default scheme was set.

```csharp
builder.Services.AddAuthentication().AddCookie();
```

This impacted the behavior of authentication handlers in the application layer.

## New behavior

Starting in ASP.NET Core 7.0, if (and only if) a single scheme is registered in an application, that scheme is treated as the default. In the following code, the `CookieDefaults.AuthenticationScheme` is treated as the default scheme.

```csharp
builder.Services.AddAuthentication().AddCookie();
```

However, in the next code snippet, no default is set because multiple schemes are registered.

```csharp
builder.Services.AddAuthentication().AddCookie().AddJwtBearer();
```

## Type of breaking change

This change affects [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

This change was made to reduce boilerplate when configuring authentication and to set up sensible defaults.

## Recommended action

The change only impacts applications that have a single scheme registered. For those scenarios, it's recommended to ensure that your application is prepared to handle the assumption that a single scheme is the default. For example, ensure that the options associated with that scheme are configured correctly.

Alternatively, you can disable the new behavior by setting the `Microsoft.AspNetCore.Authentication.SuppressAutoDefaultScheme` app context flag.

## Affected APIs

Authentication APIs.
