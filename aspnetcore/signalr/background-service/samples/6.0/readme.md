# ASP.NET Core SignalR background service sample

This sample consists of 4 projects:

* A web application hosting a SignalR hub that produces output every 1 second.
* A library containing shared interfaces and constants.
* 2 console applications to consume the output from the web application via SignalR.

## Running this sample
Start the `Server`, `Clients.ConsoleOne`, and `Clients.ConsoleTwo` projects with your favourite IDE, or run the following commands from this folder in separate terminals:

* `dotnet run --project Server`
* `dotnet run --project Clients.ConsoleOne`
* `dotnet run --project Clients.ConsoleTwo`

The `ConsoleOne` and `ConsoleTwo` applications produce log output when they receive a message via SignalR.
