The page produced by the `Authentication` component (`Pages/Authentication.razor`) defines the routes required for handling different authentication stages.

The <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.RemoteAuthenticatorView> component:

* Is provided by the [`Microsoft.AspNetCore.Components.WebAssembly.Authentication`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebAssembly.Authentication/) package.
* Manages performing the appropriate actions at each stage of authentication.

```razor
@page "/authentication/{action}"
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication

<RemoteAuthenticatorView Action="@Action" />

@code {
    [Parameter]
    public string? Action { get; set; }
}
```

> [!NOTE]
> [Nullable reference types (NRTs) and .NET compiler null-state static analysis](xref:migration/50-to-60#nullable-reference-types-nrts-and-net-compiler-null-state-static-analysis) is supported in ASP.NET Core 6.0 or later. Prior to the release of ASP.NET Core 6.0, the `string` type appears without the null type designation (`?`).
