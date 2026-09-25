---
title: ASP.NET Core Blazor CacheView component
ai-usage: ai-assisted
author: guardrex
description: Learn how to use the CacheView component to cache the rendered output of a Razor component subtree during static server-side rendering (static SSR).
monikerRange: '>= aspnetcore-11.0'
ms.author: wiwagn
ms.date: 09/16/2026
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

### Sliding expiration is bounded by an absolute expiration

`ExpiresSliding` doesn't keep an entry alive indefinitely. Every entry also carries an absolute expiration in the following order:

1. `ExpiresOn`, if set.
1. `ExpiresAfter`, if set.
1. The 30-second default.

An entry expires when either the sliding window elapses without access or the absolute expiration is reached, whichever comes first.

For example, consider `ExpiresSliding` set to 10 seconds with `ExpiresAfter` set to two minutes. Requests spaced less than 10 seconds apart reuse the cached output, and each access restarts the sliding window. A gap longer than 10 seconds expires the entry, so the next request creates a new entry. No matter how often the entry is accessed, it's never served more than two minutes after it's created.

Now consider `ExpiresSliding` set to 10 seconds without `ExpiresAfter` or `ExpiresOn`. The 30-second default absolute expiration applies, so repeated access within the 10-second window only keeps the entry alive until it's 30 seconds old. A gap longer than 10 seconds expires the entry earlier.

When you measure this behavior, report the configured expiration options together with the observed expiry because the sliding window alone doesn't determine when an entry is evicted.

The default store is an in-memory cache with a 100 MB size limit. Configure the limit with `RazorComponentsServiceOptions.CacheViewSizeLimit`. A value of `0` prevents new entries from being cached.

```csharp
builder.Services.AddRazorComponents(options =>
{
    options.CacheViewSizeLimit = 50 * 1024 * 1024;
});
```

If a `HybridCache` service is registered, `CacheView` uses it automatically. `RazorComponentsServiceOptions.CacheViewHybridCache` can select a specific `HybridCache` instance instead. Sliding expiration isn't supported with `HybridCache`; use `ExpiresAfter` or `ExpiresOn`.

Concurrent requests for the same key are coalesced so that only one request creates the cache entry.

## Declare component cache compatibility

Some components contain per-request content that must not be baked into shared cached markup. Component authors can apply `CacheBehaviorAttribute` and `CacheConditionAttribute` to control how their component behaves inside a `CacheView`.

The following table describes how the attributes work together.

Attributes | Condition isn't satisfied | Condition is satisfied
--- | --- | ---
No attributes | The component is included in cached output. | Not applicable.
`[CacheBehavior(CacheBehavior.Rerender)]` | The component renders live on every request. | Not applicable.
`[CacheBehavior(CacheBehavior.Throw)]` | The component throws an `InvalidOperationException`. | Not applicable.
`[CacheCondition(...)]` | The component renders live on every request using the default `CacheBehavior.Rerender` behavior. | The component is included in cached output.
`[CacheBehavior(CacheBehavior.Rerender)]` with `[CacheCondition(...)]` | The component renders live on every request. | The component is included in cached output.
`[CacheBehavior(CacheBehavior.Throw)]` with `[CacheCondition(...)]` | The component throws an `InvalidOperationException`. | The component is included in cached output.

```csharp
[CacheBehavior(CacheBehavior.Rerender)]
public sealed class CurrentRequestTime : ComponentBase
{
}
```

`CacheBehavior.Rerender` keeps the component live: its lifecycle runs on every request while the surrounding markup is served from the cache. The component's parameters are captured when the cache entry is created and replayed unchanged on cache hits.

`CacheBehavior.Throw` rejects use inside a `CacheView` unless a matching `CacheConditionAttribute` is satisfied.

Component authors can use `CacheBehavior.Throw` for components that are never safe to cache:

```razor
@attribute [CacheBehavior(CacheBehavior.Throw)]

<span class="user-badge">User: @UserName</span>

@code {
    [Parameter]
    public string? UserName { get; set; }
}
```

Adding vary-by parameters to the enclosing `CacheView` doesn't make this component cacheable because the component doesn't declare a cache condition. Move the component outside the cache boundary.

Combine `CacheBehavior.Throw` with `CacheConditionAttribute` for components that are cacheable only when the enclosing `CacheView` varies by specific request dimensions:

```csharp
[CacheBehavior(CacheBehavior.Throw)]
[CacheCondition(CacheVaryBy.User)]
public sealed class UserSpecificComponent : ComponentBase
{
}
```

In this example, the component can be included in cached output only when the enclosing `CacheView` sets `VaryByUser="true"`. Otherwise, rendering throws an `InvalidOperationException`.

Combine `CacheBehavior.Rerender` with `CacheConditionAttribute` when a component can render live if a required vary-by dimension isn't active and can be included in cached output when the dimension is active:

```razor
@using Microsoft.AspNetCore.Http
@attribute [CacheBehavior(CacheBehavior.Rerender)]
@attribute [CacheCondition(CacheVaryBy.Cookie)]

<p>Price selection: @PriceSelection</p>

@code {
    [CascadingParameter]
    private HttpContext? HttpContext { get; set; }

    private string PriceSelection =>
        HttpContext?.Request.Cookies["price-selection"] ?? "standard";
}
```

Without `VaryByCookie`, this component runs on every request. The following cache boundary satisfies the condition, so the component is included in cached output:

```razor
<CacheView VaryByCookie="price-selection">
    <PricePanel />
</CacheView>
```

`CacheConditionAttribute` checks vary-by dimensions, not individual query parameter, route parameter, header, or cookie names. For example, `[CacheCondition(CacheVaryBy.Cookie)]` is satisfied when `VaryByCookie` contains any value. It doesn't verify that `VaryByCookie` contains the correct cookie names. A component author must document every name that affects the component's output, and the consumer must include those exact names in the corresponding `CacheView` parameter. In the preceding example, specifying a cookie other than `price-selection` satisfies the declared condition but results in an unsafe cache key.

`CacheVaryBy` is a flags enum in which each value represents a request dimension. Combine dimensions with the logical OR operator (`|`):

```csharp
[CacheCondition(CacheVaryBy.User | CacheVaryBy.Query)]
```

In this example, both user variation and query string variation must be active to satisfy the condition.

You can only apply one `CacheConditionAttribute` to a component. Conditions don't have an evaluation order.

Built-in components use these policies:

| Component | Behavior inside `CacheView` |
|---|---|
| `AuthorizeView` | Requires `VaryByUser="true"` or throws. |
| `QuickGrid` | Requires `VaryByQuery` or throws. |
| `Virtualize` | Always throws. |
| Antiforgery tokens, `HeadOutlet`, interactive render mode boundaries, and streaming children | Render fresh on every request while surrounding content remains cached. |

When `CacheBehavior.Throw` rejects a component, the exception identifies the component and either lists the required vary-by dimensions or directs the developer to move the component outside the `CacheView`.

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
