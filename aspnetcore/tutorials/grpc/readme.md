---
page_type: sample
description: "This tutorial shows how to create a gRPC Service and gRPC client on ASP.NET Core."
languages:
- csharp
products:
- dotnet-core
- aspnet-core
- vs
urlFragment: create-grpc-client
---

# Create a gRPC client and server in ASP.NET Core 3.0 using Visual Studio

This tutorial shows how to create a .NET Core [gRPC](https://grpc.io/docs/guides/) client and an ASP.NET Core gRPC Server.

At the end, you'll have a gRPC client that communicates with the gRPC Greeter service.

In this tutorial, you;

* Create a gRPC Server.
* Create a gRPC client.
* Test the gRPC client service with the gRPC Greeter service.

## Create a gRPC service

* From the Visual Studio **File** menu, select **New** > **Project**.
* In the **Create a new project** dialog, select **ASP.NET Core Web Application**.
* Select **Next**
* Name the project **GrpcGreeter**. It's important to name the project *GrpcGreeter* so the namespaces will match when you copy and paste code.
* Select **Create**
* In the **Create a new ASP.NET Core Web Application** dialog:
  * Select **.NET Core** and **ASP.NET Core 3.0** in the dropdown menus. 
  * Select the **gRPC Service** template.
  * Select **Create**

### Run the service

* Press `Ctrl+F5` to run the gRPC service without the debugger.

  Visual Studio runs the service in a command prompt.

The logs show the service listening on `https://localhost:5001`.

```console
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
```

> [!NOTE]
> The gRPC template is configured to use [Transport Layer Security (TLS)](https://tools.ietf.org/html/rfc5246). gRPC clients need to use HTTPS to call the server.
>
> macOS doesn't support ASP.NET Core gRPC with TLS. Additional configuration is required to successfully run gRPC services on macOS. For more information, see [gRPC and ASP.NET Core on macOS](xref:grpc/aspnetcore#grpc-and-aspnet-core-on-macos).

### Examine the project files

*GrpcGreeter* project files:

* *greet.proto*: The *Protos/greet.proto* file defines the `Greeter` gRPC and is used to generate the gRPC server assets. For more information, see [Introduction to gRPC](xref:grpc/index).
* *Services* folder: Contains the implementation of the `Greeter` service.
* *appSettings.json*: Contains configuration data, such as protocol used by Kestrel. For more information, see <xref:fundamentals/configuration/index>.
* *Program.cs*: Contains the entry point for the gRPC service. For more information, see <xref:fundamentals/host/generic-host>.
* *Startup.cs*: Contains code that configures app behavior. For more information, see [App startup](xref:fundamentals/startup).

## Create the gRPC client in a .NET console app

* Open a second instance of Visual Studio.
* Select **File** > **New** > **Project** from the menu bar.
* In the **Create a new project** dialog, select **Console App (.NET Core)**.
* Select **Next**
* In the **Name** text box, enter "GrpcGreeterClient".
* Select **Create**.

### Add required packages

The gRPC client project requires the following packages:

* [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client), which contains the .NET Core client.
* [Google.Protobuf](https://www.nuget.org/packages/Google.Protobuf/), which contains protobuf message APIs for C#.
* [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools/), which contains C# tooling support for protobuf files. The tooling package isn't required at runtime, so the dependency is marked with `PrivateAssets="All"`.

Install the packages using either the Package Manager Console (PMC) or Manage NuGet Packages.

#### PMC option to install packages

* From Visual Studio, select **Tools** > **NuGet Package Manager** > **Package Manager Console**
* From the **Package Manager Console** window, navigate to the directory in which the *GrpcGreeterClient.csproj* file exists.
* Run the following commands:

 ```powershell
Install-Package Grpc.Net.Client
Install-Package Google.Protobuf
Install-Package Grpc.Tools
```

#### Manage NuGet Packages option to install packages

* Right-click the project in **Solution Explorer** > **Manage NuGet Packages**
* Select the **Browse** tab.
* Enter **Grpc.Net.Client** in the search box.
* Select the **Grpc.Net.Client** package from the **Browse** tab and select **Install**.
* Repeat for `Google.Protobuf` and `Grpc.Tools`.

### Add greet.proto

* Create a **Protos** folder in the gRPC client project.
* Copy the **Protos\greet.proto** file from the gRPC Greeter service to the gRPC client project.
* Edit the *GrpcGreeterClient.csproj* project file:

  Right-click the project and select **Edit Project File**.

* Add an item group with a `<Protobuf>` element that refers to the **greet.proto** file:

  ```xml
  <ItemGroup>
    <Protobuf Include="Protos\greet.proto" GrpcServices="Client" />
  </ItemGroup>
  ```

### Create the Greeter client

Build the project to create the types in the `GrpcGreeter` namespace. The `GrpcGreeter` types are generated automatically by the build process.

Update the gRPC client *Program.cs* file with the following code:

```csharp
using System;
using System.Net.Http;
using System.Threading.Tasks;
using GrpcGreeter;
using Grpc.Net.Client;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
```

*Program.cs* contains the entry point and logic for the gRPC client.

The Greeter client is created by:

* Instantiating a `GrpcChannel` containing the information for creating the connection to the gRPC service.
* Using the `GrpcChannel` to construct the Greeter client.

## Test the gRPC client with the gRPC Greeter service

* In the Greeter service, press `Ctrl+F5` to start the server without the debugger.
* In the `GrpcGreeterClient` project, press `Ctrl+F5` to start the client without the debugger.

The client sends a greeting to the service with a message containing its name "GreeterClient". The service sends the message "Hello GreeterClient" as a response. The "Hello GreeterClient" response is displayed in the command prompt:

```console
Greeting: Hello GreeterClient
Press any key to exit...
```

The gRPC service records the details of the successful call in the logs written to the command prompt.

```console
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\GH\aspnet\docs\4\Docs\aspnetcore\tutorials\grpc\grpc-start\sample\GrpcGreeter
info: Microsoft.AspNetCore.Hosting.Diagnostics[1]
      Request starting HTTP/2 POST https://localhost:5001/Greet.Greeter/SayHello application/grpc
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[0]
      Executing endpoint 'gRPC - /Greet.Greeter/SayHello'
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[1]
      Executed endpoint 'gRPC - /Greet.Greeter/SayHello'
info: Microsoft.AspNetCore.Hosting.Diagnostics[2]
      Request finished in 78.32260000000001ms 200 application/grpc
```

### Docs help & next steps for gRPC

* [Introduction to gRPC on ASP.NET Core](https://docs.microsoft.com/aspnet/core/grpc/index?view=aspnetcore-3.0)
* [gRPC services with C#](https://docs.microsoft.com/aspnet/core/grpc/basics?view=aspnetcore-3.0)
* [Migrating gRPC services from C-core to ASP.NET Core](https://docs.microsoft.com/aspnet/core/grpc/migration?view=aspnetcore-3.0)
