---
title: A/B Testing Migrated Endpoints
description: A/B Testing Migrated Endpoints
author: twsouthwick
ms.author: tasou
monikerRange: '>= aspnetcore-6.0'
ms.date: 3/1/2023
ms.topic: article
ms.prod: aspnet-core
uid: migration/inc/ab-testing
---

# A/B Testing endpoints during migration

During incremental migration, new endpoints are brought over to a [YARP](https://microsoft.github.io/reverse-proxy/) enabled ASP.NET Core app. With the default setup, these endpoints are automatically served for all requests once deployed. In order to test these endpoints, or be able to turn them off if needed, additional setup is needed.

This document describes how to setup a conditional endpoint selection system to enable A/B testing during incremental migration. It assumes a setup as described in [incremental migration overview](xref:migration/inc/overview) as a starting point.

## Conditional endpoint selection

To enable conditional endpoint selection, a few services need to be defined:

1. Metadata that can be added to an endpoint to turn on any conditional related logic. Endpoints include controllers, minimal APIs, Razor Page, etc. If this metadata isn't added to an endpoint, no conditional checks are performed for it.

    ```CSharp
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ConditionalRouteAttribute : Attribute
    {
        public bool IsConditional { get; set; } = true;
    }
    ```

    The property `IsConditional` is useful to set it `true` at a global level, and then allow lower levels, such as controllers or routes, to turn off the conditional checks.

2. The API we want to implement to make a decision per request and endpoint selection:

    ```CSharp
    public interface IConditionalEndpointSelector
    {
        ValueTask<bool> IsEnabledAsync(HttpContext context, Endpoint candidate);
    }
    ```

3. A `MatcherPolicy` that is used to hook into routing and call the custom selector:

    ```CSharp
    public static class ConditionalEndpointExtensions
    {
        /// <summary>
        /// Registers a <see cref="IConditionalEndpointSelector"/> that is called when selecting
        /// an endpoint that has been marked as conditional by <see cref="WithConditionalRoute{TBuilder}(TBuilder)"/>.
        /// </summary>
        /// <typeparam name="T">Type of selector</typeparam>
        /// <param name="services">Service collection to add to.</param>
        public static void AddConditionalEndpoints<T>(this IServiceCollection services)
            where T : class, IConditionalEndpointSelector
        {
            services.AddTransient<IConditionalEndpointSelector, T>();
            services.TryAddEnumerable(ServiceDescriptor.Singleton<MatcherPolicy, ConditionalEndpointMatcherPolicy>());
        }
    
        /// <summary>
        /// Enable conditional behavior for supplied endpoints. An implementation of <see cref="IConditionalEndpointSelector"/> must be registered as a service for this to be enabled at runtime.
        /// </summary>
        /// <param name="builder">The endpoint convention builder</param>
        /// <returns>The original convention builder.</returns>
        public static TBuilder WithConditionalRoute<TBuilder>(this TBuilder builder)
            where TBuilder : IEndpointConventionBuilder
        {
            ArgumentNullException.ThrowIfNull(builder);
    
            return builder.WithMetadata(new ConditionalRouteAttribute());
        }
    
        private sealed class ConditionalEndpointMatcherPolicy : MatcherPolicy, IEndpointSelectorPolicy
        {
            private readonly IConditionalEndpointSelector _selector;
    
            public ConditionalEndpointMatcherPolicy(IConditionalEndpointSelector selector)
            {
                _selector = selector;
            }
    
            public override int Order => 0;
    
            public bool AppliesToEndpoints(IReadOnlyList<Endpoint> endpoints)
                => endpoints.Any(e => e.Metadata.GetMetadata<ConditionalRouteAttribute>() is { IsConditional: true });
    
            public async Task ApplyAsync(HttpContext httpContext, CandidateSet candidates)
            {
                for (int i = 0; i < candidates.Count; i++)
                {
                    var endpoint = candidates[i].Endpoint;
    
                    if (endpoint.Metadata.GetMetadata<ConditionalRouteAttribute>() is { IsConditional: true })
                    {
                        if (await _selector.IsEnabledAsync(httpContext, endpoint) == false)
                        {
                            candidates.SetValidity(i, false);
                        }
                    }
                }
            }
        }
    }
    ```

4. Implement a custom selector. As an example, this defines a check for the presence of a query parameter (`IgnoreLocal`) that turns off the local endpoint and uses the YARP endpoint instead.

    ```CSharp
    public class QueryConditionalSelector : IConditionalEndpointSelector
    {
        public ValueTask<bool> IsEnabledAsync(HttpContext context, Endpoint candidate)
        {
            var result = context.Request.Query.TryGetValue("IgnoreLocal", out var values) &&
                values is { Count: 1 } &&
                bool.TryParse(values[0], out var skip)
                && skip;
    
            return ValueTask.FromResult(result);
        }
    ```

5. Register the services in the program startup and mark the controllers for conditional selection. This marking can also be done using attribute marking on controllers or routes if needed.

    ```diff
    using Microsoft.AspNetCore.SystemWebAdapters;
    
    var builder = WebApplication.CreateBuilder();
    builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
    
    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddSystemWebAdapters();
    + builder.Services.AddConditionalEndpoint<QueryConditionalSelector>();
    
    var app = builder.Build();
    
    app.UseSystemWebAdapters();
    
    - app.MapDefaultControllerRoute();
    + app.MapDefaultControllerRoute().WithConditionalRoute();
    app.MapReverseProxy();
    
    app.Run();
    ```
