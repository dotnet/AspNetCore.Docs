:::moniker range=">= aspnetcore-3.0 < aspnetcore-5.0"

> [!WARNING]
> A **catch-all** parameter may match routes incorrectly due to a [bug](https://github.com/dotnet/aspnetcore/issues/18677) in routing. Apps impacted by this bug have the following characteristics:
>
> * A catch-all route, for example, `{**slug}"`
> * The catch-all route fails to match requests it should match.
> * Removing other routes makes catch-all route start working.
>
> See GitHub bugs [18677](https://github.com/dotnet/aspnetcore/issues/18677) and [16579](https://github.com/dotnet/aspnetcore/issues/16579) for example cases that hit this bug.
>
> An opt-in fix for this bug is contained in [.NET Core 3.1.301 SDK and later](https://dotnet.microsoft.com/download/dotnet-core/3.1). The following code sets an internal switch that fixes this bug:
>
>```csharp
>public static void Main(string[] args)
>{
>    AppContext.SetSwitch("Microsoft.AspNetCore.Routing.UseCorrectCatchAllBehavior", 
>                          true);
>    CreateHostBuilder(args).Build().Run();
>}
>// Remaining code removed for brevity.
>```

:::moniker-end
