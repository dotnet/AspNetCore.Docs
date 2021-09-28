---
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
Run the following .NET CLI commands:

```dotnetcli
dotnet tool uninstall -g dotnet-aspnet-codegenerator
dotnet tool install -g dotnet-aspnet-codegenerator --version 6.0.0-rc.1.21464.1
dotnet tool uninstall -g dotnet-ef
dotnet tool install --global dotnet-ef --version 6.0.0-rc.1.21452.10
dotnet add package Microsoft.EntityFrameworkCore.Design --prerelease
dotnet add package Microsoft.EntityFrameworkCore.SQLite --prerelease
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --prerelease
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --prerelease
```

The preceding commands add:
* The [command-line interface (CLI) tools for EF Core](/ef/core/miscellaneous/cli/dotnet)
* The [aspnet-codegenerator scaffolding tool](xref:fundamentals/tools/dotnet-aspnet-codegenerator).
* Design time tools for EF Core
* The EF Core SQLite provider, which installs the EF Core package as a dependency.
* Packages needed for scaffolding: `Microsoft.VisualStudio.Web.CodeGeneration.Design` and `Microsoft.EntityFrameworkCore.SqlServer`.

For guidance on multiple environment configuration that permits an app to configure its database contexts by environment, see <xref:fundamentals/environments#environment-based-startup-class-and-methods>.
