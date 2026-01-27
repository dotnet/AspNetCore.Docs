---
title: "Breaking change: HostBuilder enables ValidateOnBuild/ValidateScopes in development environment"
description: Learn about the breaking change in .NET 9 where HostBuilder now enables ValidateOnBuild and ValidateScopes in the development environment.
ms.date: 08/05/2024
---
# HostBuilder enables ValidateOnBuild/ValidateScopes in development environment

Previously, no validation was enabled by default. Now, in the [development environment](/aspnet/core/fundamentals/environments), <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateOnBuild> and <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateScopes> are enabled.

## Version introduced

.NET 9 Preview 7

## Previous behavior

<xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateOnBuild> and <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateScopes> defaulted to `false` and were only enabled when they were explicitly set by calling <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseDefaultServiceProvider%2A>.

## New behavior

In the [development environment](/aspnet/core/fundamentals/environments) when options haven't been set with <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseDefaultServiceProvider%2A>, <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateOnBuild> and <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateScopes> are set to `true`.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Validation helps to catch problems early in application startup rather than later (or not at all) when the application interacts with its service provider.

## Recommended action

No action necessary if your application validates successfully. If you do see a validation error when testing in development, first try to fix it. If you can't fix it, you can disable validation by calling <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseDefaultServiceProvider%2A>.

## Affected APIs

- <xref:Microsoft.Extensions.Hosting.HostBuilder>
- <xref:Microsoft.Extensions.Hosting.HostBuilder.Build>
