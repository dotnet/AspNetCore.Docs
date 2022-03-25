---
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
> [!NOTE]
> 
> **SQLite limitations**
>
> This tutorial uses the Entity Framework Core [migrations](/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli) feature where possible. Migrations updates the database schema to match changes in the data model. However, migrations only does the kinds of changes that the database engine supports, and SQLite's schema change capabilities are limited. For example, adding a column is supported, but removing a column is not supported. If a migration is created to remove a column, the `ef migrations add` command succeeds but the `ef database update` command fails. 
>
> The workaround for the SQLite limitations is to manually write migrations code to perform a table rebuild when something in the table changes. The code goes in the `Up` and `Down` methods for a migration and involves:
>
> * Creating a new table.
> * Copying data from the old table to the new table.
> * Dropping the old table.
> * Renaming the new table.
>
> Writing database-specific code of this type is outside the scope of this tutorial. Instead, this tutorial drops and re-creates the database whenever an attempt to apply a migration would fail. For more information, see the following resources:
>
> * [SQLite EF Core Database Provider Limitations](/ef/core/providers/sqlite/limitations)
> * [Customize migration code](/ef/core/managing-schemas/migrations/#customize-migration-code)
> * [Data seeding](/ef/core/modeling/data-seeding)
> * [SQLite ALTER TABLE statement](https://sqlite.org/lang_altertable.html)