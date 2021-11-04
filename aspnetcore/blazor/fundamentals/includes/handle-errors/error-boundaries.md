---
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
Error boundaries provide a convenient approach for handling exceptions. The `ErrorBoundary` component:

* Renders its child content when an error hasn't occurred.
* Renders error UI when an unhandled exception is thrown.

To define an error boundary, use the `ErrorBoundary` component to wrap existing content. For example, an error boundary can be added around the body content of the app's main layout.

`Shared/MainLayout.razor`:

```razor
<div class="main">
    <div class="content px-4">
        <ErrorBoundary>
            @Body
        </ErrorBoundary>
    </div>
</div>
```

The app continues to function normally, but the error boundary handles unhandled exceptions.

Consider the following example, where the `Counter` component throws an exception if the count increments past five.

In `Pages/Counter.razor`:

```csharp
private void IncrementCount()
{
    currentCount++;

    if (currentCount > 5)
    {
        throw new InvalidOperationException("Current count is too big!");
    }
}
```

If the unhandled exception is thrown for a `currentCount` over five:

* The exception is handled by the error boundary.
* Error UI is rendered (`An error has occurred!`).

By default, the `ErrorBoundary` component renders an empty `<div>` element with the `blazor-error-boundary` CSS class for its error content. The colors, text, and icon for the default UI are defined using CSS in the app's stylesheet in the `wwwroot` folder, so you're free to customize the error UI.

You can also change the default error content by setting the `ErrorContent` property:

```razor
<ErrorBoundary>
    <ChildContent>
        @Body
    </ChildContent>
    <ErrorContent>
        <p class="errorUI">Nothing to see here right now. Sorry!</p>
    </ErrorContent>
</ErrorBoundary>
```

Because the error boundary is defined in the layout in the preceding examples, the error UI is seen regardless of which page the user navigated to. We recommend narrowly scoping error boundaries in most scenarios. If you do broadly scope an error boundary, you can reset it to a non-error state on subsequent page navigation events by calling the error boundary's `Recover` method:

```razor
...

<ErrorBoundary @ref="errorBoundary">
    @Body
</ErrorBoundary>

...

@code {
    private ErrorBoundary errorBoundary;

    protected override void OnParametersSet()
    {
        errorBoundary?.Recover();
    }
}
```
