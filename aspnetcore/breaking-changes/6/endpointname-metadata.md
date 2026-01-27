---
title: "Breaking change: EndpointName metadata no longer automatically set"
description: "Learn about the breaking change in ASP.NET Core 6.0 where EndpointName metadata is no longer automatically set for minimal endpoints."
ms.date: 10/18/2021
ms.custom: https://github.com/aspnet/Announcements/issues/473
---
# EndpointName metadata not set automatically

Behavior that was introduced in .NET 6 RC 1 to automatically set `IEndpointNameMetadata` for endpoints has been reverted. `IEndpointNameMetadata` is no longer set automatically to avoid issues with duplicate endpoint names.

## Version introduced

ASP.NET Core 6 RC 2

## Previous behavior

In ASP.NET Core 6 RC 1, `IEndpointNameMetadata` was automatically set for endpoints that referenced a method group. For example, the following code produced an endpoint for `/foo` with `EndpointName` set to `GetFoo`.

```csharp
app.MapGet("/foo", GetFoo);
```

## New behavior

Starting in ASP.NET Core 6 RC 2, `IEndpointNameMetadata` is not automatically set. The following code does not generate any `IEndpointNameMetadata`.

```csharp
app.MapGet("/foo", GetFoo);
```

## Type of breaking change

This change can affect [source compatibility](/dotnet/core/compatibility/categories#source-compatibility).

## Reason for change

The behavior of automatically setting endpoint name metadata was not robust and resulted in issues where the same name was set for different endpoints. For more information, see [dotnet/aspnetcore#36487](https://github.com/dotnet/aspnetcore/issues/36487).

## Recommended action

We recommend that you manually set `IEndpointNameMetadata` using the `WithName` extension method to set the metadata.

```csharp
app.MapGet("/foo", GetFoo).WithName("GetFoo");
```

## Affected APIs

N/A
