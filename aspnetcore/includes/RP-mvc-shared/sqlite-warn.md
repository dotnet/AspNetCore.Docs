
> [!NOTE]
> Many schema change operations are not supported by the EF Core SQLite provider. For example, adding a column is supported, but removing or changing a column is not supported. If a migration is created to remove or change a column, the `ef migrations add` command succeeds but the `ef database update` command fails. Due to these limitations, this tutorial doesn't use migrations for SQLite schema changes. Instead, when the schema changes, you drop and re-create the database.

You can work around the SQLite limitations by manually writing migrations code to perform a table rebuild. A table rebuild involves:

>* Renaming the existing table.
>* Creating a new table.
>* Copying data from the old table to the new table.
>* Dropping the old table.

This tutorial doesn't show how to do a table rebuild. For more information, see the following resources:
> * [SQLite EF Core Database Provider Limitations](/ef/core/providers/sqlite/limitations)
> * [Customize migration code](/ef/core/managing-schemas/migrations/#customize-migration-code)
> * [Data seeding](/ef/core/modeling/data-seeding)