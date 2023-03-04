---
title: Blazor Support in Incremental Migration
description: Blazor Support in Incremental Migration
author: twsouthwick
ms.author: tasou
monikerRange: '>= aspnetcore-6.0'
ms.date: 3/1/2023
ms.topic: article
ms.prod: aspnet-core
uid: migration/inc/blazor
---

# Enabling Blazor support with Yarp

When adding both Blazor and Yarp to an application, they both are used as fallback routes. This causes problems so that one will win over the other and scenarios like deep-linking in Blazor applications may fail. This will be addressed in ASP.NET Core 8, but for migration to ASP.NET Core 6 and 7, it can still be achieved by explicitly mapping Blazor endpoints.

In order to do this, the following must be added to a project:

```CSharp
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Routing;

namespace BlazorHelper;

public static class BlazorEndpointRouteBuilderExtensions
{
    public static IEndpointConventionBuilder MapBlazorPages(this IEndpointRouteBuilder endpoints, string page)
    {
        var assembly = Assembly.GetEntryAssembly();

        if (assembly is null)
        {
            throw new InvalidOperationException("No entry assembly available.");
        }

        return endpoints.MapBlazorPages(page, assembly);
    }

    public static IEndpointConventionBuilder MapBlazorPages(this IEndpointRouteBuilder endpoints, string page, params Assembly[] assemblies)
    {
        ArgumentNullException.ThrowIfNull(assemblies);

        var builder = new BlazorEndpointConventionBuilder();

        foreach (var route in GetRoutes(assemblies))
        {

            var conventionBuilder = endpoints.MapFallbackToPage(route, page);

            conventionBuilder.Add(b =>
            {
                // By default this will be 'Fallback {route}', but this will help identify it is explicitly registered
                b.DisplayName = $"Blazor {route}";

                // {page} will, by default, have Order = 0; this will ensure the order is not the same
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
                    foreach (var attribute in type.GetCustomAttributes(typeof(RouteAttribute)))
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

    private sealed class BlazorEndpointConventionBuilder : IEndpointConventionBuilder
    {
        private readonly List<IEndpointConventionBuilder> _builders = new();

        public void Add(IEndpointConventionBuilder builder)
        {
            _builders.Add(builder);
        }

        void IEndpointConventionBuilder.Add(Action<EndpointBuilder> convention)
        {
            foreach (var builder in _builders)
            {
                builder.Add(convention);
            }
        }

#if NET7_0_OR_GREATER
        void IEndpointConventionBuilder.Finally(Action<EndpointBuilder> finalConvention)
        {
            foreach (var builder in _builders)
            {
                builder.Finally(finalConvention);
            }
        }
#endif
    }
}

```

With this, the application registration needs to be updated for using Blazor:

```diff
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

app.MapBlazorHub();

- app.MapFallbackToPage("/_Host");
+ app.MapBlazorPages("/_Host");

app.MapReverseProxy();

app.Run();
```

At this point, the application should now both work with Yarp as well as Blazor, including deep-linking to pages.