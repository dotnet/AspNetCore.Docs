---
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
There are also certain sets of keywords that ASP.NET Core MVC uses internally, which should ***not*** be used in ASP.NET Core apps as it can result in unexpected outcomes in certain scenarios.

* `controller`, `action`, `area`, and `page` are reserved keywords used by MVC's routing system. Using these as part of link generations, model bound parameters, or top level properties can bind the reserved route value.

Consider
```C#
// /ListProducts/Index.cshtml
@page "{page:int?}"

@functions {
   public async Task OnGetAsync(int page)
   {
        ...
    }
```

The parameter `page` on the page handler is not bound correctly since `page` is a reserved keyword.

* The following keywords are reserved in the context of a Razor view or a Razor Page:
   * `page`
   * `using`
   * `namespace`
   * `inject`
   * `section`
   * `inherits`
   * `model`
   * `addTagHelper`
   * `removeTagHelper`

These keywords should not be used for link generations, model bound parameters, or top level properties.
