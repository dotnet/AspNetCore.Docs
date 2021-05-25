---
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---

## System.IO.IOException: The configured user limit (128) on the number of inotify instances has been reached.

Disabling `reloadOnChange` can significantly reduce the number of opened files:

[!code-csharp[](~/includes/docker-128/Program.cs?hightlight=14)]