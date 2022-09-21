# ASP.NET Core Distributed Cache Sample

This sample illustrates the use of a distributed cache. This sample demonstrates the scenario described in the [Work with a distributed cache in ASP.NET Core](https://learn.microsoft.com/aspnet/core/performance/caching/distributed) topic.

In the Production environment, the sample app is configured to use a distributed SQL Server cache. To reconfigure the app to use a distributed Redis cache, change the preprocessor directive at the top of the `Startup.cs` file to use Redis (`#define Redis // SQLServer`). For more information, see [Preprocessor directives in sample code](https://learn.microsoft.com/aspnet/core/introduction-to-aspnet-core#preprocessor-directives-in-sample-code).
