---
title: "Breaking change: Blazor: Target framework of NuGet packages changed"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled Blazor: Target framework of NuGet packages changed"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/425
---
# Blazor: Target framework of NuGet packages changed

Blazor 3.2 WebAssembly projects were compiled to target .NET Standard 2.1 (`<TargetFramework>netstandard2.1</TargetFramework>`). In ASP.NET Core 5.0, both Blazor Server and Blazor WebAssembly projects target .NET 5 (`<TargetFramework>net5.0</TargetFramework>`). To better align with the target framework change, the following Blazor packages no longer target .NET Standard 2.1:

* [Microsoft.AspNetCore.Components](https://www.nuget.org/packages/Microsoft.AspNetCore.Components)
* [Microsoft.AspNetCore.Components.Authorization](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Authorization)
* [Microsoft.AspNetCore.Components.Forms](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Forms)
* [Microsoft.AspNetCore.Components.Web](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Web)
* [Microsoft.AspNetCore.Components.WebAssembly](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly)
* [Microsoft.AspNetCore.Components.WebAssembly.Authentication](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication)
* [Microsoft.JSInterop](https://www.nuget.org/packages/Microsoft.JSInterop)
* [Microsoft.JSInterop.WebAssembly](https://www.nuget.org/packages/Microsoft.JSInterop.WebAssembly)
* [Microsoft.Authentication.WebAssembly.Msal](https://www.nuget.org/packages/Microsoft.Authentication.WebAssembly.Msal)

For discussion, see GitHub issue [dotnet/aspnetcore#23424](https://github.com/dotnet/aspnetcore/issues/23424).

## Version introduced

5.0 Preview 7

## Old behavior

In Blazor 3.1 and 3.2, packages target .NET Standard 2.1 and .NET Core 3.1.

## New behavior

In ASP.NET Core 5.0, packages target .NET 5.0.

## Reason for change

The change was made to better align with .NET target framework requirements.

## Recommended action

Blazor 3.2 WebAssembly projects should target .NET 5 as part of updating their package references to 5.x.x. Libraries that reference one of these packages can either target .NET 5 or multi-target depending on their requirements.

## Affected APIs

None

<!--

### Category

ASP.NET Core

### Affected APIs

Not detectable via API analysis

-->
