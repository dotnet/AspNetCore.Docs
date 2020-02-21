By [Rick Anderson](https://twitter.com/RickAndMSFT)

In this section, you add classes for managing movies in a database. You use these classes with [Entity Framework Core](/ef/core) (EF Core) to work with a database. EF Core is an object-relational mapping (ORM) framework that simplifies the data access code that you have to write.

The model classes you create are known as POCO classes (from "plain-old CLR objects") because they don't have any dependency on EF Core. They define the properties of the data that are stored in the database.

In this tutorial, you write the model classes first, and EF Core creates the database. An alternate approach not covered here is to [generate model classes from an existing database](/ef/core/get-started/aspnetcore/existing-db).

[View or download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/tutorials/razor-pages/razor-pages-start/sample/RazorPagesMovie) sample.
