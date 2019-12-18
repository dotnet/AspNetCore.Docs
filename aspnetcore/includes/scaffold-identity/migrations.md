The generated Identity database code requires [Entity Framework Core Migrations](/ef/core/managing-schemas/migrations/). Create a migration and update the database. For example, run the following commands:

# [Visual Studio](#tab/visual-studio)

In the Visual Studio **Package Manager Console**:

```powershell
Install-Package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
Add-Migration CreateIdentitySchema
Update-Database
```

# [.NET Core CLI](#tab/netcore-cli)

```dotnetcli
dotnet ef migrations add CreateIdentitySchema
dotnet ef database update
```

---

The "CreateIdentitySchema" name parameter for the `Add-Migration` command is arbitrary. `"CreateIdentitySchema"` describes the migration.
