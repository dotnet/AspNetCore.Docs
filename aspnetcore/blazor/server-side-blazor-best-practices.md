---
title: Server Blazor app best practices
author: prkrishn
description: Learn some best practices authoring Blazor apps
monikerRange: '>= aspnetcore-3.0'
ms.author: prkrishn
ms.custom: mvc
ms.date: 08/21/2019
uid: blazor/server-best-practices
---

### Harden JSInterop

JSInterop is a Blazor feature that allows two-way RPC between .NET Code and JavaScript code. By default, any calls to JSInterop call may fail due to networking errors and is to be treated as unreliable. By default, Blazor Server app will time out JSInterop calls on the server after 1 minute. If your applications can tolerate a more aggresive timeout, consider setting it either globally or on a per-invocation basis:

```C#
// Globally
services.AddServerSideBlazor(options => options.JSInteropDefaultCallTimeout = TimeSpan.FromSeconds(10));

// Per invocation
var result = await JSRuntime.InvokeAsync<string>("MyJSOperation", TimeSpan.FromSeconds(8), new[] { "Arg1" });
```

### Long-running operations

#### Guard against multiple dispatches
If an event callback invokes a long running operation, such as fetching from an external service or the databse, consider using a guard. The guard can prevent the user from queueing up multiple operations while the operation is in progress also providing a visual feedback.

```C#

<button disabled=@isLoading @onclick=@UpdateForecasts>Update</button>

@code {
    bool isLoading;
    WeatherForecast[] forecasts;

    private async Task UpdateForecasts()
    {
        if (!isLoading)
        {
            isLoading = true;
            // Long-running Task
            forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
            isLoading = false;
        }
    }
}
```

#### Cancel early and avoid use-after-dispose.
In addition to using a guard, consider using a `CancellationToken` to cancel long-running operations when the component is disposed. This has the added benefit of avoiding use-after-dispose in your components:

```C#
@implements IDisposable

@code {
    private readonly CancellationTokenSource TokenSource = new CancellationTokenSource();

    private async Task UpdateForecasts()
    {
        ...
        forecasts = await ForecastService.GetForecastAsync(DateTime.Now, TokenSource.Token);
        if (TokenSource.Token.IsCancellationRequested)
        {
           return;
        }
        ...
    }

    public void Dispose()
    {
        CancellationTokenSource.Cancel();
    }
}
```

### Apply upper bounds to collections

Use reasonable bounds for collection types that read user inputted values. Allowing users to perform operations that can add an unbounded number of items can trivially result in a denial-of-service attacks:

```C#
<input @bind="newTodo" />
<button @onclick="AddTodo" />

@code
{
    string newTodo;
    List<string> todos = new List<string>();

    void AddTodo()
    {
        if (todos.Count < 1000)
        {
            todos.Add(newTodo);
            newTodo = "";
        }
    }
}
```

### Avoid chatty events

DOM events such as `oninput` or `onscroll` can produce a lot of data. Avoid using these events in your Blazor server app.

### Measure network latency

A fairly trivial way to measure network latency would be to use JSInterop

```C#
@inject IJSRuntime JS

@if (latency is null)
{
    <span>Calculating...</span>
}
else
{
    <span>@(latency.Value.TotalMilliseconds)ms</span>
}

@code
{
    DateTime startTime;
    TimeSpan? latency;

    protected override async Task OnInitializedAsync()
    {
        startTime = DateTime.UtcNow;
        var _ = await JS.InvokeAsync<string>("toString");
        latency = DateTime.UtcNow - startTime;
    }
}

For a reasonable UI experience, we recommend a sustained UI latency of 250ms or lower.
