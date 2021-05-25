---
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---

<a name="d128"></a>

## System.IO.IOException: The configured user limit (128) on the number of inotify instances has been reached.

Disabling `reloadOnChange` can significantly reduce the number of opened files:

[!code-csharp[](~/includes/docker-128/Program.cs?highlight=14&name=snippet)]

The preceding code can help prevent the user limit (128) when the app doesn't depend on reloading the *appsettings.json* file.

When adding multiple docker containers using the same host, consider specifying a randomized user ID in each Dockerfile. For more information, see [this GitHub issue](https://github.com/dotnet/AspNetCore.Docs/issues/19814).
