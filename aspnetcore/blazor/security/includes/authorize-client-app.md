---
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
> [!IMPORTANT]
> If you don't have the authority to grant admin consent to the tenant in the last step of **API permissions** configuration because consent to use the app is delegated to users, then you must take the following additional steps:
>
> * The app must use a [trusted publisher domain](/azure/active-directory/develop/howto-configure-publisher-domain).
> * In the **`Server`** app's configuration in the Azure portal, select **Expose an API**. Under **Authorized client applications**, select the button to **Add a client application**. Add the **`Client`** app's Application (client) ID (for example, `4369008b-21fa-427c-abaa-9b53bf58e538`).
