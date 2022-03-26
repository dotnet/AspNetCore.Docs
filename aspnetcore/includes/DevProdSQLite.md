---
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
<h3 id="sqlite-ss-6">Use SQLite for development, SQL Server for production</h3>

When SQLite is selected, the template generated code is ready for development. The following code shows how to select the SQLite connection string in develpment and SQL Server in production.

[!code-csharp[](~/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie60/ProgramProd.cs?name=snippet&highlight=7-16)]

The preceding code doesn't call `UseDeveloperExceptionPage` in development because `WebApplication` calls `UseDeveloperExceptionPage` in development mode.