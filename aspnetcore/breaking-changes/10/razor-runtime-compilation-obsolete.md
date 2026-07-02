---
title: "Breaking change: Razor runtime compilation is obsolete"
description: Learn about the breaking change in ASP.NET Core 10.0 where Razor runtime compilation APIs have been marked obsolete.
ms.date: 08/08/2025
ms.custom: https://github.com/aspnet/Announcements/issues/522
---

# Razor runtime compilation is obsolete

Razor runtime compilation is obsolete and is not recommended for production scenarios. For production scenarios, use the default build-time compilation. For development scenarios, use [Hot Reload](/aspnet/core/test/hot-reload) instead.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Previously, you could use [Razor runtime compilation](/aspnet/core/mvc/views/view-compilation) to recompile `.cshtml` files while the application was running. This meant you didn't need to restart the application for changes to take effect.

## New behavior

Starting in .NET 10, use of the [affected APIs](#affected-apis) produces a compiler warning with diagnostic ID `ASPDEPR003`:

> warning ASPDEPR003: Razor runtime compilation is obsolete and is not recommended for production scenarios. For production scenarios, use the default build time compilation. For development scenarios, use Hot Reload instead. For more information, visit <https://aka.ms/aspnet/deprecate/003>.

## Type of breaking change

This change can affect [source compatibility](/dotnet/core/compatibility/categories#source-compatibility).

## Reason for change

Razor runtime compilation has been replaced by [Hot Reload](/aspnet/core/test/hot-reload), which has been the recommended approach for a few years now. This change makes it clearer that Razor runtime compilation doesn't get support for new features and should no longer be used.

## Recommended action

Remove calls to <xref:Microsoft.Extensions.DependencyInjection.RazorRuntimeCompilationMvcBuilderExtensions.AddRazorRuntimeCompilation%2A> and use [Hot Reload](/aspnet/core/test/hot-reload) instead.

## Affected APIs

- <xref:Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPartExtensions?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.RazorRuntimeCompilationMvcBuilderExtensions.AddRazorRuntimeCompilation%2A?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.RazorRuntimeCompilationMvcCoreBuilderExtensions.AddRazorRuntimeCompilation%2A?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation.FileProviderRazorProjectItem?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation.MvcRazorRuntimeCompilationOptions?displayProperty=fullName>

## See also

- [.NET Hot Reload support for ASP.NET Core](/aspnet/core/test/hot-reload)
