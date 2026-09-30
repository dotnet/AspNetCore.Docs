# ASP.NET Core Background Tasks Web Sample

This sample illustrates the use of [`IHostedService`](https://learn.microsoft.com/dotnet/api/microsoft.extensions.hosting.ihostedservice) in a web app that uses the `Microsoft.NET.Sdk.Web` SDK. This sample demonstrates the features described in the [Background tasks with hosted services in ASP.NET Core](https://learn.microsoft.com/aspnet/core/fundamentals/host/hosted-services) article.

Run the sample from a command shell:

```dotnetcli
dotnet run
```

Send a POST request to the `/queue` endpoint to add a work item to the background queue:

```console
curl -X POST http://localhost:5000/queue
```
