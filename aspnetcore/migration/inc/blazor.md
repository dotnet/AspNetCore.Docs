---
title: Enable ASP.NET Core Blazor support with Yarp in incremental migration
author: twsouthwick
description: Blazor Support in Incremental Migration
monikerRange: '>= aspnetcore-6.0'
ms.author: tasou
ms.custom: "mvc"
ms.date: 03/01/2023
uid: migration/inc/blazor
---
# Enable ASP.NET Core Blazor support with Yarp in incremental migration

When adding Yarp to a Blazor app, both attempt to act as fallback routes for the app's request routing. Either Blazor or Yarp handles routing arbitrarily, which means that scenarios such as deep linking in Blazor may fail. This will be fixed in the .NET 8 release later this year. For migration to ASP.NET Core 6.0 and 7.0, map Blazor's endpoints to achieve correct request routing by following the guidance in this article.

Add the following route builder extensions class to the project.

`BlazorEndpointRouteBuilderExtensions.cs`:

```csharp
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Routing;

public static class BlazorEndpointRouteBuilderExtensions {
    public static IEndpointConventionBuilder MapBlazorPages(
        this IEndpointRouteBuilder endpoints, string page)
    {
        var assembly = Assembly.GetEntryAssembly();

        if (assembly is null)
        {
            throw new InvalidOperationException("No entry assembly available.");
        }

        return endpoints.MapBlazorPages(page, assembly);
    }

    public static IEndpointConventionBuilder MapBlazorPages(
        this IEndpointRouteBuilder endpoints, string page, 
        params Assembly[] assemblies)
    {
        ArgumentNullException.ThrowIfNull(assemblies);

        var builder = new BlazorEndpointConventionBuilder();

        foreach (var route in GetRoutes(assemblies))
        {
            var conventionBuilder = endpoints.MapFallbackToPage(route, page);

            conventionBuilder.Add(b =>
            {
                b.DisplayName = $"Blazor {route}";
                ((RouteEndpointBuilder)b).Order = -1;
            });

            builder.Add(conventionBuilder);
        }

        return builder;
    }

    private static IEnumerable<string> GetRoutes(Assembly[] assemblies)
    {
        foreach (var assembly in assemblies)
        {
            foreach (var type in assembly.GetTypes())
            {
                if (typeof(IComponent).IsAssignableFrom(type))
                {
                    foreach (var attribute in 
                        type.GetCustomAttributes(typeof(RouteAttribute)))
                    {
                        if (attribute is RouteAttribute { Template: { } route })
                        {
                            yield return route;
                        }
                    }
                }
            }
        }
    }

    private sealed class BlazorEndpointConventionBuilder : IEndpointConventionBuilder {
        private readonly List<IEndpointConventionBuilder> builders = new();

        public void Add(IEndpointConventionBuilder builder)
        {
            builders.Add(builder);
        }

        void IEndpointConventionBuilder.Add(Action<EndpointBuilder> convention)
        {
            foreach (var builder in builders)
            {
                builder.Add(convention);
            }
        }

#if NET7_0_OR_GREATER
        void IEndpointConventionBuilder.Finally(
            Action<EndpointBuilder> finalConvention)
        {
            foreach (var builder in builders)
            {
                builder.Finally(finalConvention);
            }
        }
#endif
    }
}
```

In the preceding code:

* <xref:Microsoft.AspNetCore.Builder.EndpointBuilder.DisplayName?displayProperty=nameWithType> defaults to `Fallback {route}`. The line that changes it to `Blazor {route}` (`b.DisplayName = $"Blazor {route}";`) identifies the Blazor route as explicitly registered.
* For the line that sets the route order (`((RouteEndpointBuilder)b).Order = -1;`), `{page}` has a route order of `0` by default. Setting the Blazor route order to `-1` ensures the order is changed to give the Blazor route precedence.

Update the app registration for using Blazor in `Program.cs`:

```diff
- app.MapFallbackToPage("/_Host");
+ app.MapBlazorPages("/_Host");
```

At this point, the app should route requests correctly for Blazor and Yarp, including deep linking to pages.
