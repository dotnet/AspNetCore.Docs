The generated Identity database code requires [Entity Framework Core Migrations](/ef/core/managing-schemas/migrations/). If a migration to generate the Identity schema isn't already created and applied to the database, use the following procedures to create a migration and update the database.

# [Visual Studio](#tab/visual-studio)

[Visual Studio Connected Services](/visualstudio/azure/overview-connected-services) are used to add an EF Core migration and update the database.

1. In **Solution Explorer**, double-click **Connected Services**.

1. In the **SQL Server Express LocalDB** area of **Service Dependencies**, select **More actions** (**...**) > **Add migration**.

1. Give the migration a **Migration name**, such as `CreateIdentitySchema`, which is a name that describes the migration.

   Wait for the database context to load in the **DbContext class names** field. The action can take a few seconds.
   
1. Select **Finish** to complete the update. After the operation finishes, select **Close**.

1. Select **More actions** (**...**) > **Update database**.

   The **Update database with the latest migration** dialog opens.
   
   Wait for the **DbContext class names** field to update and for prior migrations to load. The action can take a few seconds.

1. Select **Finish** to complete the update. After the operation finishes, select **Close**.

The update database command runs the `Up` method migrations that aren't applied in a migration code file created by the scaffolder. In this case, the command runs the `Up` method in the _Migrations/{TIME STAMP}\_{MIGRATION NAME}.cs_ file, which creates the Identity tables, constraints, and indexes. The `{TIME STAMP}` placeholder is a time stamp, and the `{MIGRATION NAME}` placeholder is the migration name.

# [.NET CLI](#tab/net-cli)

In a command shell, run the following commands:

```dotnetcli
dotnet ef migrations add CreateIdentitySchema
dotnet ef database update
```

---

If the Identity schema is created but not applied to the database, you only need to run the command to update the database:

# [Visual Studio](#tab/visual-studio)

1. In **Solution Explorer**, double-click **Connected Services**.

1. In the **SQL Server Express LocalDB** area of **Service Dependencies**, select **More actions** (**...**) > **Update database**.

   The **Update database with the latest migration** dialog opens.
   
   Wait for the **DbContext class names** field to update and for prior migrations to load. The action can take a few seconds.

1. Select **Finish** to complete the update. After the operation finishes, select **Close**.
   
# [.NET CLI](#tab/net-cli)

In a command shell, run the [dotnet ef database update](/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli#command-line-tools) command:

```dotnetcli
dotnet ef database update
```

---

You can confirm the application of an Identity schema with the following command. The output of the command includes an "`applied`" column to show which migrations are applied to the database.

# [Visual Studio](#tab/visual-studio)

In the Visual Studio **Package Manager Console**, run the [Get-Migration](/ef/core/managing-schemas/migrations/managing?tabs=vs#listing-migrations) command:

```powershell
Get-Migration
```

If more than one database context exists, specify the context with the `-Context` parameter.

# [.NET CLI](#tab/net-cli)

In a command shell, run the [dotnet ef migrations list](/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli#listing-migrations) command:

```dotnetcli
dotnet ef migrations list
```

If more than one database context exists, specify the context with the `--context` parameter.

---
