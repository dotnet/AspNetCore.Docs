# Adding a model to an ASP.NET Core MVC app

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Tom Dykstra](https://github.com/tdykstra)

In this section, you'll add some classes for managing movies in a database. These classes will be the "**M**odel" part of the **M**VC app.

You use these classes with [Entity Framework Core](https://docs.microsoft.com/ef/core) (EF Core) to work with a database. EF Core is an object-relational mapping (ORM) framework that simplifies the data access code that you have to write. [EF Core supports many database engines](https://docs.microsoft.com/ef/core/providers/).

The model classes you'll create are known as POCO classes (from "plain-old CLR objects") because they don't have any dependency on EF Core. They just define the properties of the data that will be stored in the database.

In this tutorial you'll write the model classes first, and EF Core will create the database. An alternate approach not covered here is to generate model classes from an already-existing database. For information about that approach, see [ASP.NET Core - Existing Database](https://docs.microsoft.com/ef/core/get-started/aspnetcore/existing-db).

## Add a data model class
