---
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---

## SQL Logging of Entity Framework Core

Logging configuration is commonly provided by the `Logging` section of `appsettings.{Environment}.json` files. To log SQL statements, add `"Microsoft.EntityFrameworkCore.Database.Command": "Information"` to the `appsettings.Development.json` file:

[!code-json[](~/includes/sql-log/appsettings.json?highlight=10)]

With the preceding JSON, SQL statements are displayed on the command line and in the Visual Studio output window.

For more information, see <xref:fundamentals/logging/index#configure-logging> and this [GitHub issue](https://github.com/dotnet/aspnetcore/issues/32977).
