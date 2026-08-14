---
title: ASP.NET Core Blazor CacheView component
ai-usage: ai-assisted
author: guardrex
description: Learn how to use the CacheView component to cache the rendered output of a Razor component subtree during static server-side rendering (static SSR).
monikerRange: '>= aspnetcore-11.0'
ms.author: wpickett
ms.date: 08/14/2026
uid: blazor/state-management/cacheview-component
---
# ASP.NET Core Blazor `CacheView` component

<!-- UPDATE 11.0 - Edit this new article -->

The `CacheView` component caches the rendered output of a Razor component subtree during static server-side rendering (static SSR). On a cache hit, cached markup is replayed without instantiating or running the lifecycle of the child components that were included in the cached output.

`CacheView` is useful for expensive, mostly static sections of a page that don't require the entire response to be cached.

```razor
<CacheView VaryByQuery="category" ExpiresAfter="TimeSpan.FromMinutes(5)">
    <ProductList Category="@Category" />
</CacheView>
```

Caching is enabled by default. Set `Enabled="false"` to render the content normally without reading or writing a cache entry.

## Cache keys and vary-by values

Each `CacheView` has a key based on its position in the component tree. Set `CacheKey` when the same component containing a `CacheView` is rendered multiple times, such as in a loop, so that each instance has a distinct entry.

For example, every `CacheView` produced by this loop has the same position in the render tree:

```razor
@for (var i = 0; i < 3; i++)
{
    <CacheView ExpiresAfter="TimeSpan.FromHours(1)"
               VaryByQuery="testId">
        <p>@Guid.NewGuid()</p>
    </CacheView>
}
```

The instances therefore resolve to the same key during the request, and `CacheView` throws an `InvalidOperationException`. Assign a unique `CacheKey` to each iteration, as demonstrated by the CacheView E2E tests:

```razor
@for (var i = 0; i < 3; i++)
{
    <CacheView CacheKey="@($"loop-{i}")"
               ExpiresAfter="TimeSpan.FromHours(1)"
               VaryByQuery="testId">
        <p class="cached-value">@Guid.NewGuid()</p>
    </CacheView>
}
```

Each iteration now creates and reuses an independent cache entry.

The following parameters add request-specific values to the cache key:

| Parameter | Cache varies by |
|---|---|
| `VaryByQuery` | A comma-separated list of query parameter names. Use `"*"` for all query parameters. |
| `VaryByRoute` | A comma-separated list of route parameter names. |
| `VaryByHeader` | A comma-separated list of HTTP header names. |
| `VaryByCookie` | A comma-separated list of cookie names. |
| `VaryByUser` | The authenticated user identity. |
| `VaryByCulture` | The current culture and UI culture. |
| `VaryBy` | An application-defined string value. |

Without a matching vary-by parameter, requests with different values share the same cached output.

## Expiration and cache storage

`CacheView` supports three expiration parameters:

* `ExpiresAfter` sets an absolute lifetime relative to entry creation.
* `ExpiresOn` sets an absolute expiration date and time.
* `ExpiresSliding` expires an entry after a period without access.

When no expiration is specified, entries expire after 30 seconds.

The default store is an in-memory cache with a 100 MB size limit. Configure the limit with `RazorComponentsServiceOptions.CacheViewSizeLimit`. A value of `0` prevents new entries from being cached.

```csharp
builder.Services.AddRazorComponents(options =>
{
    options.CacheViewSizeLimit = 50 * 1024 * 1024;
});
```

If a `HybridCache` service is registered, `CacheView` uses it automatically. `RazorComponentsServiceOptions.CacheViewHybridCache` can select a specific `HybridCache` instance instead. Sliding expiration isn't supported with `HybridCache`; use `ExpiresAfter` or `ExpiresOn`.

Concurrent requests for the same key are coalesced so that only one request creates the cache entry.

## Components that render on every request

Some components contain per-request content that must not be baked into shared cached markup. Component authors can apply `CacheBehaviorAttribute` and `CacheConditionAttribute` to control how their component behaves inside a `CacheView`.

These attributes allow component authors to declare that a component:

* Must never be included in cached output but can render live by using `CacheBehavior.Rerender`.
* Must not be used inside a `CacheView` by using `CacheBehavior.Throw` without a cache condition.
* Can only be included in cached output when the enclosing `CacheView` varies by specific request dimensions by combining `CacheBehavior.Throw` with `CacheConditionAttribute`.

```csharp
[CacheBehavior(CacheBehavior.Rerender)]
public sealed class CurrentRequestTime : ComponentBase
{
}
```

`CacheBehavior.Rerender` keeps the component live: its lifecycle runs on every request while the surrounding markup is served from the cache. The component's parameters are captured when the cache entry is created and replayed unchanged on cache hits.

`CacheBehavior.Throw` rejects use inside a `CacheView` unless a matching `CacheConditionAttribute` is satisfied.

Component authors can use `CacheBehavior.Throw` for components that are never safe to cache, or combine it with `CacheConditionAttribute` for components that are cacheable only in specific cases.

```csharp
[CacheBehavior(CacheBehavior.Throw)]
[CacheCondition(CacheVaryBy.User)]
public sealed class UserSpecificComponent : ComponentBase
{
}
```

In this example, the component can be included in cached output only when the enclosing `CacheView` sets `VaryByUser="true"`. Otherwise, rendering throws an `InvalidOperationException`.

Built-in components use these policies:

| Component | Behavior inside `CacheView` |
|---|---|
| `AuthorizeView` | Requires `VaryByUser="true"` or throws. |
| `QuickGrid` | Requires `VaryByQuery` or throws. |
| `Virtualize` | Always throws. |
| Antiforgery tokens, `HeadOutlet`, interactive render mode boundaries, and streaming children | Render fresh on every request while surrounding content remains cached. |

## Limitations

### Request and streaming rendering restrictions

`CacheView` only caches static SSR output for `GET` requests. Caching is skipped for other HTTP methods.

A `CacheView` rendered inside a streaming rendering subtree also isn't cached. However, a streaming child inside a `CacheView` is supported: the streaming child renders fresh on each request while the surrounding content is cached.

### Nested cache views

A `CacheView` can't be nested inside another `CacheView`. The inner output would become part of the outer cache entry, which could freeze per-request content such as antiforgery tokens, authentication-dependent output, or interactive component markers.

Move the inner `CacheView` outside the outer cached subtree.

### Live component parameters are captured once

Components marked with `CacheBehavior.Rerender` run their lifecycle on every request, but their parameter values are captured when the cache entry is created and replayed unchanged on cache hits.

For example, this live component receives the current user's name as a parameter:

```razor
@attribute [CacheBehavior(CacheBehavior.Rerender)]

<p>Welcome, @UserName!</p>

@code {
    [Parameter]
    public string? UserName { get; set; }
}
```

The following usage is unsafe:

```razor
<CacheView>
    <UserGreeting UserName="@CurrentUserName" />
</CacheView>

@code {
    [CascadingParameter]
    private HttpContext? HttpContext { get; set; }

    private string? CurrentUserName => HttpContext?.User.Identity?.Name;
}
```

If Alice creates the cache entry, `"Alice"` is captured as the `UserName` parameter. When Bob requests the page, `UserGreeting` runs its lifecycle again, but it receives the captured `"Alice"` value. Vary the cache by user so that each identity has a separate entry:

```razor
<CacheView VaryByUser="true">
    <UserGreeting UserName="@CurrentUserName" />
</CacheView>
```

Alternatively, move `UserGreeting` outside the `CacheView`.

### Live components can't have render fragment parameters

A live component can't have a `RenderFragment` or `RenderFragment<T>` parameter, including `ChildContent`. The parameter would capture content and references from the request that created the cache entry and couldn't be safely replayed on later requests.

For example, the following live component exposes a `ChildContent` parameter:

```razor
@attribute [CacheBehavior(CacheBehavior.Rerender)]

<div class="current-request-panel">
    @ChildContent
</div>

@code {
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
```

Using the component inside a `CacheView` isn't supported:

```razor
<CacheView>
    <CurrentRequestPanel>
        <p>Content for @DateTimeOffset.Now</p>
    </CurrentRequestPanel>
</CacheView>
```

`CacheView` throws an `InvalidOperationException` instead of creating the cache entry. Remove the `ChildContent` parameter, move `CurrentRequestPanel` outside the `CacheView`, or introduce a live wrapper without render fragment parameters.

For example, the wrapper can render `CurrentRequestPanel` and its child content internally:

```razor
@attribute [CacheBehavior(CacheBehavior.Rerender)]

<CurrentRequestPanel>
    <p>Content for @DateTimeOffset.Now</p>
</CurrentRequestPanel>
```

The wrapper itself has no `ChildContent` or other `RenderFragment` parameter, so it can be used as the live component inside the cache:

```razor
<CacheView>
    <CurrentRequestPanelWrapper />
</CacheView>
```

On a cache hit, `CurrentRequestPanelWrapper` and its subtree render fresh. The wrapper provides a component boundary between the cached content and the component that receives `ChildContent`.

### Sliding expiration with HybridCache

`ExpiresSliding` isn't supported when the backing store uses `HybridCache`. Use `ExpiresAfter` or `ExpiresOn` for absolute expiration.
