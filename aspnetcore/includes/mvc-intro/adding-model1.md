# Adding a model

By [Rick Anderson](https://twitter.com/RickAndMSFT)

In this section you'll add some classes for managing movies in a database. These classes will be the "**M**odel" part of the **M**VC app.

You’ll use a .NET Framework data-access technology known as the [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core) to define and work with these data model classes. Entity Framework Core (often referred to as **EF** Core) features a development paradigm called *Code First*. You write the code first, and the database tables are created from this code. Code First allows you to create data model objects by writing simple classes. (These are also known as POCO classes, from "plain-old CLR objects.") The database is created from your classes. If you are required to create the database first, you can still follow this tutorial to learn about MVC and EF app development.

## Add a data model class