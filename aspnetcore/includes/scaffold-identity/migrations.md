The generated Identity database code requires [Entity Framework (EF) Core Migrations](/ef/core/managing-schemas/migrations/). If a migration to generate the Identity schema hasn't been created and applied to the database, create a migration and update the database.

# [Visual Studio](#tab/visual-studio)

[Visual Studio Connected Services](/visualstudio/azure/overview-connected-services) are used to add an EF Core migration and update the database.

In **Solution Explorer**, double-click **Connected Services**. In the **SQL Server Express LocalDB** area of **Service Dependencies**, select the ellipsis (**`...`**) followed by **Add migration**.

Give the migration a **Migration name**, such as `CreateIdentitySchema`, which is a name that describes the migration. Wait for the database context to load in the **DbContext class names** field, which may take a few seconds. Select **Finish** to create the migration.

Select the **Close** button after the operation finishes.

Select the ellipsis (**`...`**) again followed by the **Update database** command.

The **Update database with the latest migration** dialog opens. Wait for the **DbContext class names** field to update and for prior migrations to load, which may take a few seconds. Select the **Finish** button.

Select the **Close** button after the operation finishes.

The update database command executes the `Up` method migrations that haven't been applied in a migration code file created by the scaffolder. In this case, the command executes the `Up` method in the `Migrations/{TIME STAMP}_{MIGRATION NAME}.cs` file, which creates the Identity tables, constraints, and indexes. The `{TIME STAMP}` placeholder is a time stamp, and the `{MIGRATION NAME}` placeholder is the migration name.

# [.NET CLI](#tab/net-cli)

```dotnetcli
dotnet ef migrations add CreateIdentitySchema
dotnet ef database update
```

---

If the Identity schema has already been created but not applied to the database, only the command to update the database must be executed:

# [Visual Studio](#tab/visual-studio)

In **Solution Explorer**, double-click **Connected Services**. In the **SQL Server Express LocalDB** area of **Service Dependencies**, select the ellipsis (`...`) followed by the **Update database** command.

The **Update database with the latest migration** dialog opens. Wait for the **DbContext class names** field to update and for prior migrations to load, which may take a few seconds. Select the **Finish** button.

Select the **Close** button after the operation finishes.

# [.NET CLI](#tab/net-cli)

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

# [.NET CLI](#tab/net-cli)

In a command shell, execute [`dotnet ef migrations list`](/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli#listing-migrations):

```dotnetcli
dotnet ef migrations list
```

If more than one database context exists, specify the context with the `--context` parameter.

---
