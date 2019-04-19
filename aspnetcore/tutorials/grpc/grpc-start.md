---
title: "Tutorial: Get started with gRPC in ASP.NET Core"
author: juntaoluo
description: This series of tutorials shows how to create a gRPC Service on ASP.NET Core. Learn how to create a gRPC Service project, edit a proto file, and add an duplex streaming call.
monikerRange: '>= aspnetcore-3.0'
ms.author: johluo
ms.date: 2/26/2019
uid: tutorials/grpc/grpc-start
---

# Tutorial: Get started with gRPC service in ASP.NET Core

By [John Luo](https://github.com/juntaoluo)

This tutorial teaches the basics of building a gRPC service on ASP.NET Core.

At the end, you'll have a gRPC service that echoes greetings.

[!INCLUDE[View or download sample code](~/includes/grpc/download.md)]

In this tutorial, you:

> [!div class="checklist"]
> * Create a gRPC service.
> * Run the gRPC service.
> * Examine the project files.

[!INCLUDE[](~/includes/net-core-prereqs-all-3.0.md)]

## Create a gRPC service

# [Visual Studio](#tab/visual-studio)

* From the Visual Studio **File** menu, select **New** > **Project**.
* Create a new ASP.NET Core Web Application.
  ![new ASP.NET Core Web Application](grpc-start/_static/np_3_0.1.png)
* Name the project **GrpcGreeter**. It's important to name the project *GrpcGreeter* so the namespaces will match when you copy and paste code.
  ![new ASP.NET Core Web Application](grpc-start/_static/np_3_0.2.png)
* Select **.NET Core** and **ASP.NET Core 3.0** in the dropdown. Choose the **gRPC Service** template.

  The following starter project is created:

  ![Solution Explorer](grpc-start/_static/se3.0.png)

# [Visual Studio Code](#tab/visual-studio-code)

* Open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
* Change directories (`cd`) to a folder which will contain the project.
* Run the following commands:

  ```console
  dotnet new grpc -o GrpcGreeter
  code -r GrpcGreeter
  ```

  * The `dotnet new` command creates a new gRPC service in the *GrpcGreeter* folder.
  * The `code` command opens the *GrpcGreeter* folder in a new instance of Visual Studio Code.

  A dialog box appears with **Required assets to build and debug are missing from 'GrpcGreeter'. Add them?**
* Select **Yes**

# [Visual Studio for Mac](#tab/visual-studio-mac)

From a terminal, run the following commands:

```console
  dotnet new grpc -o GrpcGreeter
  cd GrpcGreeter
```

The preceding commands use the [.NET Core CLI](/dotnet/core/tools/dotnet) to create a gRPC service.

### Open the project

From Visual Studio, select **File > Open**, and then select the *GrpcGreeter.sln* file.

<!-- End of VS tabs -->

---

### Run the service

# [Visual Studio](#tab/visual-studio)

* Press Ctrl+F5 to run the gRPC service without the debugger.

  Visual Studio runs the service in a command prompt. The logs show that the service started listening on `http://localhost:50051`.

  ![new ASP.NET Core Web Application](grpc-start/_static/server_start.png)

# [Visual Studio Code / Visual Studio for Mac](#tab/visual-studio-code+visual-studio-mac)

* Run the gRPC Greeter project GrpcGreeter from the command line using `dotnet run`. The logs show that the service started listening on `http://localhost:50051`.

```console
dbug: Grpc.AspNetCore.Server.Internal.GrpcServiceBinder[1]
      Added gRPC method 'SayHello' to service 'Greet.Greeter'. Method type: 'Unary', route pattern: '/Greet.Greeter/SayHello'.
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:50051
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\gh\Docs\aspnetcore\tutorials\grpc\grpc-start\samples\GrpcGreeter
```

<!-- End of combined VS/Mac tabs -->

---

The next tutorial will demonstrate how to build a gRPC client, which is required to test the Greeter service.

### Examine the project files of the gRPC project

GrpcGreeter files:

* greet.proto: The *Protos/greet.proto* file defines the `Greeter` gRPC and is used to generate the gRPC server assets. For more information, see <xref:grpc/index>.
* *Services* folder: Contains the implementation of the `Greeter` service.
* *appSettings.json*:Contains configuration data, such as protocol used by Kestrel. For more information, see <xref:fundamentals/configuration/index>.
* *Program.cs*: Contains the entry point for the gRPC service. For more information, see <xref:fundamentals/host/web-host>.
* Startup.cs: Contains code that configures app behavior. For more information, see <xref:fundamentals/startup>.

### Test the service

## Additional resources

In this tutorial, you:

> [!div class="checklist"]
> * Created a gRPC service.
> * Ran the gRPC service.
> * Examined the project files.

> [!div class="step-by-step"]
> [Next: Create a .NET Core gRPC client](xref:tutorials/grpc/grpc-client)