---
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
Blazor server apps live in server memory. That means that there are multiple apps hosted within the same process. For each app session, Blazor starts a circuit with its own DI container scope. That means that scoped services are unique per Blazor session.

> [!WARNING]
> We don't recommend apps on the same server share state using singleton services unless extreme care is taken, as this can introduce security vulnerabilities, such as leaking user state across circuits.

You can use stateful singleton services in Blazor apps if they are specifically designed for it. For example, it's ok to use a memory cache as a singleton because it requires a key to access a given entry, assuming users don't have control of what cache keys are used.

**Additionally, again for security reasons, you must not use <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> within Blazor apps.** Blazor apps run outside of the context of the ASP.NET Core pipeline. The <xref:Microsoft.AspNetCore.Http.HttpContext> isn't guaranteed to be available within the <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor>, nor is it guaranteed to be holding the context that started the Blazor app.

The recommended way to pass request state to the Blazor app is through parameters to the root component in the initial rendering of the app:

* Define a class with all the data you want to pass to the Blazor app.
* Populate that data from the Razor page using the <xref:Microsoft.AspNetCore.Http.HttpContext> available at that time.
* Pass the data to the Blazor app as a parameter to the root component (App).
* Define a parameter in the root component to hold the data being passed to the app.
* Use the user-specific data within the app; or alternatively, copy that data into a scoped service within <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> so that it can be used across the app.

For more information and example code, see <xref:blazor/security/server/additional-scenarios#pass-tokens-to-a-blazor-server-app>.
