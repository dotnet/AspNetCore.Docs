The generated Identity database code requires [Entity Framework Core Migrations](/ef/core/managing-schemas/migrations/). If a migration to create the Identity schema hasn't been created and applied to the database, create a migration and update the database. For example, run the following commands:

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

If the Identity schema has already been created but not applied to the database, only the command to update the database must be executed:

# [Visual Studio](#tab/visual-studio)

In the Visual Studio **Package Manager Console**, execute [`Update-Database`](/ef/core/managing-schemas/migrations/applying?tabs=vs#command-line-tools):

```powershell
Update-Database
```

# [.NET Core CLI](#tab/netcore-cli)

In a command shell, execute [`dotnet ef database update`](/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli#command-line-tools):

```dotnetcli
dotnet ef database update
```

---

You can confirm the application of an Identity schema with the following command. The output of the command includes an "`applied`" column to show which migrations are applied to the database.

# [Visual Studio](#tab/visual-studio)

In the Visual Studio **Package Manager Console**, execute [`Get-Migration`](/ef/core/managing-schemas/migrations/managing?tabs=vs#listing-migrations):

```powershell
Get-Migration
```

If more than one database context exists, specify the context with the `-Context` parameter.

# [.NET Core CLI](#tab/netcore-cli)

In a command shell, execute [`dotnet ef migrations list`](/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli#listing-migrations):

```dotnetcli
dotnet ef migrations list
```

If more than one database context exists, specify the context with the `--context` parameter.

---
