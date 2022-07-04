---
title: Create a .NET Core gRPC client and server in ASP.NET Core
author: jamesnk
description: This tutorial shows how to create a gRPC Service and gRPC client on ASP.NET Core. Learn how to create a gRPC Service project, edit a proto file, and add a duplex streaming call.
ms.author: jamesnk
ms.date: 04/15/2022
uid: tutorials/grpc/grpc-start
---
# Tutorial: Create a gRPC client and server in ASP.NET Core

:::moniker range=">= aspnetcore-6.0"
This tutorial shows how to create a .NET Core [gRPC](xref:grpc/index) client and an ASP.NET Core gRPC Server. At the end, you'll have a gRPC client that communicates with the gRPC Greeter service.

In this tutorial, you:

> [!div class="checklist"]
> * Create a gRPC Server.
> * Create a gRPC client.
> * Test the gRPC client with the gRPC Greeter service.

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-prereqs-vs-6.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-6.0.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

[!INCLUDE[](~/includes/net-prereqs-mac-6.0.md)]

---

## Create a gRPC service

# [Visual Studio](#tab/visual-studio)

* Start Visual Studio 2022 and select **Create a new project**.
* In the **Create a new project** dialog, search for `gRPC`. Select **ASP.NET Core gRPC Service** and select **Next**.
* In the **Configure your new project** dialog, enter `GrpcGreeter` for **Project name**. It's important to name the project *GrpcGreeter* so the namespaces match when you copy and paste code.
* Select **Next**.
* In the **Additional information** dialog, select **.NET 6.0 (Long-term support)** and then select **Create**.

# [Visual Studio Code](#tab/visual-studio-code)

The tutorial assumes familiarity with VS Code. For more information, see [Getting started with VS Code](https://code.visualstudio.com/docs)

* Open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
* Change to the directory (`cd`) that will contain the project.
* Run the following commands:

  ```dotnetcli
  dotnet new grpc -o GrpcGreeter
  code -r GrpcGreeter
  ```

  * The `dotnet new` command creates a new gRPC service in the *GrpcGreeter* folder.
  * The `code` command opens the *GrpcGreeter* folder in a new instance of Visual Studio Code.

# [Visual Studio for Mac](#tab/visual-studio-mac)

* Start Visual Studio for Mac and select **File** > **New Project**.
* In the **Choose a template for your new project** dialog, select **Web and Console** > **App** > **gRPC Service** and select **Continue**.
* Select **.NET 6.0** for the target framework and select **Continue**.
* Name the project **GrpcGreeter**. It's important to name the project *GrpcGreeter* so the namespaces match when you copy and paste code.
* Select **Continue**.

---

### Run the service
 
[!INCLUDE[](~/includes/run-the-app6.0.md)]

The logs show the service listening on `https://localhost:<port>`, where `<port>` is the localhost port number randomly assigned when the project is created and set in `Properties/launchSettings.json`.

```console
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:<port>
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
```

> [!NOTE]
> The gRPC template is configured to use [Transport Layer Security (TLS)](https://tools.ietf.org/html/rfc5246). gRPC clients need to use HTTPS to call the server.  The gRPC service localhost port number is randomly assigned when the project is created and set in the *Properties\launchSettings.json* file of the gRPC service project.
>
> macOS doesn't support ASP.NET Core gRPC with TLS. Additional configuration is required to successfully run gRPC services on macOS. For more information, see [Unable to start ASP.NET Core gRPC app on macOS](xref:grpc/troubleshoot#unable-to-start-aspnet-core-grpc-app-on-macos).

### Examine the project files

*GrpcGreeter* project files:

* `Protos/greet.proto`: defines the `Greeter` gRPC and is used to generate the gRPC server assets. For more information, see [Introduction to gRPC](xref:grpc/index).
* `Services` folder: Contains the implementation of the `Greeter` service.
* `appSettings.json`: Contains configuration data such as the protocol used by Kestrel. For more information, see <xref:fundamentals/configuration/index>.
* `Program.cs`, which contains:
  * The entry point for the gRPC service. For more information, see <xref:fundamentals/host/generic-host>.
  * Code that configures app behavior. For more information, see [App startup](xref:fundamentals/startup).

## Create the gRPC client in a .NET console app

# [Visual Studio](#tab/visual-studio)

* Open a second instance of Visual Studio and select **Create a new project**.
* In the **Create a new project** dialog, select **Console Application**, and select **Next**.
* In the **Project name** text box, enter **GrpcGreeterClient** and select **Next**.
* In the **Additional information** dialog, select **.NET 6.0 (Long-term support)** and then select **Create**.

# [Visual Studio Code](#tab/visual-studio-code)

* Open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
* Change directories (`cd`) to a folder for the project.
* Run the following commands:

  ```dotnetcli
  dotnet new console -o GrpcGreeterClient
  code -r GrpcGreeterClient
  ```

# [Visual Studio for Mac](#tab/visual-studio-mac)

Follow the instructions in [Building a complete .NET Core solution on macOS using Visual Studio for Mac](/dotnet/core/tutorials/using-on-mac-vs-full-solution) to create a console app with the name *GrpcGreeterClient*.

---

### Add required NuGet packages

The gRPC client project requires the following NuGet packages:

* [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client), which contains the .NET Core client.
* [Google.Protobuf](https://www.nuget.org/packages/Google.Protobuf/), which contains protobuf message APIs for C#.
* [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools/), which contain C# tooling support for protobuf files. The tooling package isn't required at runtime, so the dependency is marked with `PrivateAssets="All"`.

# [Visual Studio](#tab/visual-studio)

Install the packages using either the Package Manager Console (PMC) or Manage NuGet Packages.

#### PMC option to install packages

* From Visual Studio, select **Tools** > **NuGet Package Manager** > **Package Manager Console**
* From the **Package Manager Console** window, run `cd GrpcGreeterClient` to change directories to the folder containing the `GrpcGreeterClient.csproj` files.
* Run the following commands:

  ```powershell
  Install-Package Grpc.Net.Client
  Install-Package Google.Protobuf
  Install-Package Grpc.Tools
  ```

#### Manage NuGet Packages option to install packages

* Right-click the project in **Solution Explorer** > **Manage NuGet Packages**.
* Select the **Browse** tab.
* Enter **Grpc.Net.Client** in the search box.
* Select the **Grpc.Net.Client** package from the **Browse** tab and select **Install**.
* Repeat for `Google.Protobuf` and `Grpc.Tools`.

# [Visual Studio Code](#tab/visual-studio-code)

Run the following commands from the **Integrated Terminal**:

```dotnetcli
dotnet add GrpcGreeterClient.csproj package Grpc.Net.Client
dotnet add GrpcGreeterClient.csproj package Google.Protobuf
dotnet add GrpcGreeterClient.csproj package Grpc.Tools
```

# [Visual Studio for Mac](#tab/visual-studio-mac)

* Right-click **GrpcGreeterClient** project in the **Solution Pad** and select **Manage NuGet Packages**.
* Enter **Grpc.Net.Client** in the search box.
* Select the **Grpc.Net.Client** package from the results pane and select **Add Package**.
* In **Select Projects** select **OK**.
* If the **License Acceptance** dialog appears, select **Accept** if you agree to the license terms.
* Repeat for `Google.Protobuf` and `Grpc.Tools`.

---

### Add greet.proto

* Create a *Protos* folder in the gRPC client project.
* Copy the *Protos\greet.proto* file from the gRPC Greeter service to the *Protos* folder in the gRPC client project.
* Update the namespace inside the `greet.proto` file to the project's namespace:

  ```
  option csharp_namespace = "GrpcGreeterClient";
  ```

* Edit the `GrpcGreeterClient.csproj` project file:

# [Visual Studio](#tab/visual-studio)

  Right-click the project and select **Edit Project File**.

# [Visual Studio Code](#tab/visual-studio-code)

  Select the `GrpcGreeterClient.csproj` file.

# [Visual Studio for Mac](#tab/visual-studio-mac)

  Right-click the project and select **Edit Project File**.

  ---

* Add an item group with a `<Protobuf>` element that refers to the *greet.proto* file:

  ```xml
  <ItemGroup>
    <Protobuf Include="Protos\greet.proto" GrpcServices="Client" />
  </ItemGroup>
  ```

### Create the Greeter client

* Build the client project to create the types in the `GrpcGreeterClient` namespace.

> [!NOTE]
> The `GrpcGreeterClient` types are generated automatically by the build process. The tooling package [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools/) generates the following files based on the *greet.proto* file:
>
> * `GrpcGreeterClient\obj\Debug\[TARGET_FRAMEWORK]\Protos\Greet.cs`: The protocol buffer code which populates, serializes and retrieves the request and response message types.
> * `GrpcGreeterClient\obj\Debug\[TARGET_FRAMEWORK]\Protos\GreetGrpc.cs`: Contains the the generated client classes.
>
> For more information on the C# assets automatically generated by [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools/), see [gRPC services with C#: Generated C# assets](xref:grpc/basics#generated-c-assets).

* Update the gRPC client `Program.cs` file with the following code.

  [!code-csharp[](~/tutorials/grpc/grpc-start/sample6/GrpcGreeterClient/Program.cs?name=snippet2&highlight=6)]

* In the preceding highlighted code, replace the localhost port number `7042` with the `HTTPS` port number specified in `Properties/launchSettings.json` within the `GrpcGreeter` service project.

`Program.cs` contains the entry point and logic for the gRPC client.

The Greeter client is created by:

* Instantiating a `GrpcChannel` containing the information for creating the connection to the gRPC service.
* Using the `GrpcChannel` to construct the Greeter client:

[!code-csharp[](~/tutorials/grpc/grpc-start/sample6/GrpcGreeterClient/Program.cs?name=snippet&highlight=1-3)]

The Greeter client calls the asynchronous `SayHello` method. The result of the `SayHello` call is displayed:

[!code-csharp[](~/tutorials/grpc/grpc-start/sample6/GrpcGreeterClient/Program.cs?name=snippet&highlight=4-7)]

## Test the gRPC client with the gRPC Greeter service

# [Visual Studio](#tab/visual-studio)

* In the Greeter service, press `Ctrl+F5` to start the server without the debugger.
* In the `GrpcGreeterClient` project, press `Ctrl+F5` to start the client without the debugger.

# [Visual Studio Code](#tab/visual-studio-code)

* Start the Greeter service.
* Start the client.

# [Visual Studio for Mac](#tab/visual-studio-mac)

* Due to the previously mentioned [HTTP/2 TLS issue on macOS workaround](xref:grpc/troubleshoot#unable-to-start-aspnet-core-grpc-app-on-macos), you'll need to update the channel address in the client to match port in launchSetting.json of the GrpcGreeter service "http://localhost:5000". Update line 13 of *`GrpcGreeterClient/Program.cs`* to read:

  ```csharp
  using var channel = GrpcChannel.ForAddress("http://localhost:5000");
  ```

* Start the Greeter service.
* Start the client.

---

The client sends a greeting to the service with a message containing its name, *GreeterClient*. The service sends the message "Hello GreeterClient" as a response. The "Hello GreeterClient" response is displayed in the command prompt:

```console
Greeting: Hello GreeterClient
Press any key to exit...
```

The gRPC service records the details of the successful call in the logs written to the command prompt:

```console
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:<port>
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\GH\aspnet\docs\4\Docs\aspnetcore\tutorials\grpc\grpc-start\sample\GrpcGreeter
info: Microsoft.AspNetCore.Hosting.Diagnostics[1]
      Request starting HTTP/2 POST https://localhost:<port>/Greet.Greeter/SayHello application/grpc
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[0]
      Executing endpoint 'gRPC - /Greet.Greeter/SayHello'
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[1]
      Executed endpoint 'gRPC - /Greet.Greeter/SayHello'
info: Microsoft.AspNetCore.Hosting.Diagnostics[2]
      Request finished in 78.32260000000001ms 200 application/grpc
```

Update the `appsettings.Development.json` file by adding the following lines:

 ```
 "Microsoft.AspNetCore.Hosting": "Information",
 "Microsoft.AspNetCore.Routing.EndpointMiddleware": "Information"
  ```



> [!NOTE]
> The code in this article requires the ASP.NET Core HTTPS development certificate to secure the gRPC service. If the .NET gRPC client fails with the message `The remote certificate is invalid according to the validation procedure.` or `The SSL connection could not be established.`, the development certificate isn't trusted. To fix this issue, see [Call a gRPC service with an untrusted/invalid certificate](xref:grpc/troubleshoot#call-a-grpc-service-with-an-untrustedinvalid-certificate).

[!INCLUDE[](~/includes/gRPCazure.md)]

### Next steps

* View or download [the completed sample code for this tutorial](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/grpc/grpc-start/sample6) ([how to download](xref:index#how-to-download-a-sample)).
* <xref:grpc/index>
* <xref:grpc/basics>
* <xref:grpc/migration>

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"
This tutorial shows how to create a .NET Core [gRPC](xref:grpc/index) client and an ASP.NET Core gRPC Server.

At the end, you'll have a gRPC client that communicates with the gRPC Greeter service.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/grpc/grpc-start/sample) ([how to download](xref:index#how-to-download-a-sample)).

In this tutorial, you:

> [!div class="checklist"]
> * Create a gRPC Server.
> * Create a gRPC client.
> * Test the gRPC client with the gRPC Greeter service.

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-core-prereqs-vs-5.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-core-prereqs-vsc-5.0.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

* [Visual Studio for Mac version 8.7 or later](/visualstudio/releasenotes/vs2019-mac-relnotes)
* [!INCLUDE [.NET Core 3.1 SDK](~/includes/5.0-SDK.md)]
---

## Create a gRPC service

# [Visual Studio](#tab/visual-studio)

* Start Visual Studio and select **Create a new project**.
* In the **Create a new project** dialog, select **gRPC Service** and select **Next**.
* In the **Configure your new project** dialog, enter `GrpcGreeter` for **Project name**. It's important to name the project *GrpcGreeter* so the namespaces match when you copy and paste code.
* Select **Next**.
* In the **Additional information** dialog, select **.NET 5.0** in the **Target Framework** dropdown.
* Select **Create**.

# [Visual Studio Code](#tab/visual-studio-code)

The tutorial assumes familiarity with VS Code. For more information, see [Getting started with VS Code](https://code.visualstudio.com/docs)

* Open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
* Change to the directory (`cd`) that will contain the project.
* Run the following commands:

  ```dotnetcli
  dotnet new grpc -o GrpcGreeter
  code -r GrpcGreeter
  ```

  * The `dotnet new` command creates a new gRPC service in the *GrpcGreeter* folder.
  * The `code` command opens the *GrpcGreeter* folder in a new instance of Visual Studio Code.

# [Visual Studio for Mac](#tab/visual-studio-mac)

* Start Visual Studio for Mac and select **New**. Alternatively, from the Visual Studio **File** menu, select **New Solution**.
* In the **Choose a template for your new project** dialog, select **Web and Console** > **App** > **gRPC Service** and select **Next**.
* Select **.NET 5.0** for the target framework and select **Next**.
* Name the project **GrpcGreeter**. It's important to name the project *GrpcGreeter* so the namespaces match when you copy and paste code.
* Select **Create**.
---

### Run the service

  [!INCLUDE[](~/includes/run-the-app.md)]

The logs show the service listening on `https://localhost:5001`.

```console
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
```

> [!NOTE]
> The gRPC template is configured to use [Transport Layer Security (TLS)](https://tools.ietf.org/html/rfc5246). gRPC clients need to use HTTPS to call the server.
>
> macOS doesn't support ASP.NET Core gRPC with TLS. Additional configuration is required to successfully run gRPC services on macOS. For more information, see [Unable to start ASP.NET Core gRPC app on macOS](xref:grpc/troubleshoot#unable-to-start-aspnet-core-grpc-app-on-macos).

### Examine the project files

*GrpcGreeter* project files:

* *greet.proto*: The *Protos/greet.proto* file defines the `Greeter` gRPC and is used to generate the gRPC server assets. For more information, see [Introduction to gRPC](xref:grpc/index).
* *Services* folder: Contains the implementation of the `Greeter` service.
* `appsettings.json`: Contains configuration data, such as protocol used by Kestrel. For more information, see <xref:fundamentals/configuration/index>.
* `Program.cs`: Contains the entry point for the gRPC service. For more information, see <xref:fundamentals/host/generic-host>.
* `Startup.cs`: Contains code that configures app behavior. For more information, see [App startup](xref:fundamentals/startup).

## Create the gRPC client in a .NET console app

# [Visual Studio](#tab/visual-studio)

* Open a second instance of Visual Studio and select **Create a new project**.
* In the **Create a new project** dialog, select **Console App (.NET Core)** and select **Next**.
* In the **Project name** text box, enter **GrpcGreeterClient** and select **Create**.

# [Visual Studio Code](#tab/visual-studio-code)

* Open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
* Change directories (`cd`) to a folder for the project.
* Run the following commands:

  ```dotnetcli
  dotnet new console -o GrpcGreeterClient
  code -r GrpcGreeterClient
  ```

# [Visual Studio for Mac](#tab/visual-studio-mac)

Follow the instructions in [Building a complete .NET Core solution on macOS using Visual Studio for Mac](/dotnet/core/tutorials/using-on-mac-vs-full-solution) to create a console app with the name *GrpcGreeterClient*.

---

### Add required packages

The gRPC client project requires the following packages:

* [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client), which contains the .NET Core client.
* [Google.Protobuf](https://www.nuget.org/packages/Google.Protobuf/), which contains protobuf message APIs for C#.
* [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools/), which contains C# tooling support for protobuf files. The tooling package isn't required at runtime, so the dependency is marked with `PrivateAssets="All"`.

# [Visual Studio](#tab/visual-studio)

Install the packages using either the Package Manager Console (PMC) or Manage NuGet Packages.

#### PMC option to install packages

* From Visual Studio, select **Tools** > **NuGet Package Manager** > **Package Manager Console**
* From the **Package Manager Console** window, run `cd GrpcGreeterClient` to change directories to the folder containing the `GrpcGreeterClient.csproj` files.
* Run the following commands:

  ```powershell
  Install-Package Grpc.Net.Client
  Install-Package Google.Protobuf
  Install-Package Grpc.Tools
  ```

#### Manage NuGet Packages option to install packages

* Right-click the project in **Solution Explorer** > **Manage NuGet Packages**.
* Select the **Browse** tab.
* Enter **Grpc.Net.Client** in the search box.
* Select the **Grpc.Net.Client** package from the **Browse** tab and select **Install**.
* Repeat for `Google.Protobuf` and `Grpc.Tools`.

# [Visual Studio Code](#tab/visual-studio-code)

Run the following commands from the **Integrated Terminal**:

```dotnetcli
dotnet add GrpcGreeterClient.csproj package Grpc.Net.Client
dotnet add GrpcGreeterClient.csproj package Google.Protobuf
dotnet add GrpcGreeterClient.csproj package Grpc.Tools
```

# [Visual Studio for Mac](#tab/visual-studio-mac)

* Right-click **GrpcGreeterClient** project in the **Solution Pad** and select **Manage NuGet Packages**.
* Enter **Grpc.Net.Client** in the search box.
* Select the **Grpc.Net.Client** package from the results pane and select **Add Package**.
* Select the **Accept** button on the **Accept License** dialog.
* Repeat for `Google.Protobuf` and `Grpc.Tools`.

---

### Add greet.proto

* Create a *Protos* folder in the gRPC client project.
* Copy the *Protos\greet.proto* file from the gRPC Greeter service to the *Protos* folder in the gRPC client project.
* Update the namespace inside the `greet.proto` file to the project's namespace:

  ```
  option csharp_namespace = "GrpcGreeterClient";
  ```

* Edit the `GrpcGreeterClient.csproj` project file:

  # [Visual Studio](#tab/visual-studio)

  Right-click the project and select **Edit Project File**.

  # [Visual Studio Code](#tab/visual-studio-code)

  Select the `GrpcGreeterClient.csproj` file.

  # [Visual Studio for Mac](#tab/visual-studio-mac)

  Right-click the project and select **Edit Project File**.

  ---

* Add an item group with a `<Protobuf>` element that refers to the *greet.proto* file:

  ```xml
  <ItemGroup>
    <Protobuf Include="Protos\greet.proto" GrpcServices="Client" />
  </ItemGroup>
  ```

### Create the Greeter client

* Build the client project to create the types in the `GrpcGreeterClient` namespace.

> [!NOTE]
> The `GrpcGreeterClient` types are generated automatically by the build process. The tooling package [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools/) generates the following files based on the *greet.proto* file:
>
> * `GrpcGreeterClient\obj\Debug\[TARGET_FRAMEWORK]\Protos\Greet.cs`: The protocol buffer code which populates, serializes and retrieves the request and response message types.
> * `GrpcGreeterClient\obj\Debug\[TARGET_FRAMEWORK]\Protos\GreetGrpc.cs`: Contains the the generated client classes.
>
> For more information on the C# assets automatically generated by [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools/), see [gRPC services with C#: Generated C# assets](xref:grpc/basics#generated-c-assets).

* Update the gRPC client `Program.cs` file with the following code:

  [!code-csharp[](~/tutorials/grpc/grpc-start/sample/GrpcGreeterClient/Program.cs?name=snippet2)]

`Program.cs` contains the entry point and logic for the gRPC client.

The Greeter client is created by:

* Instantiating a `GrpcChannel` containing the information for creating the connection to the gRPC service.
* Using the `GrpcChannel` to construct the Greeter client:

[!code-csharp[](~/tutorials/grpc/grpc-start/sample/GrpcGreeterClient/Program.cs?name=snippet&highlight=3-5)]

The Greeter client calls the asynchronous `SayHello` method. The result of the `SayHello` call is displayed:

[!code-csharp[](~/tutorials/grpc/grpc-start/sample/GrpcGreeterClient/Program.cs?name=snippet&highlight=6-8)]

## Test the gRPC client with the gRPC Greeter service

# [Visual Studio](#tab/visual-studio)

* In the Greeter service, press `Ctrl+F5` to start the server without the debugger.
* In the `GrpcGreeterClient` project, press `Ctrl+F5` to start the client without the debugger.

# [Visual Studio Code](#tab/visual-studio-code)

* Start the Greeter service.
* Start the client.


# [Visual Studio for Mac](#tab/visual-studio-mac)

* Due to the previously mentioned [HTTP/2 TLS issue on macOS workaround](xref:grpc/troubleshoot#unable-to-start-aspnet-core-grpc-app-on-macos), you'll need to update the channel address in the client to "http://localhost:5000". Update line 13 of *`GrpcGreeterClient/Program.cs`* to read:
  ```csharp
  using var channel = GrpcChannel.ForAddress("http://localhost:5000");
  ``` 
* Start the Greeter service.
* Start the client.

---

The client sends a greeting to the service with a message containing its name, *GreeterClient*. The service sends the message "Hello GreeterClient" as a response. The "Hello GreeterClient" response is displayed in the command prompt:

```console
Greeting: Hello GreeterClient
Press any key to exit...
```

The gRPC service records the details of the successful call in the logs written to the command prompt:

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

> [!NOTE]
> The code in this article requires the ASP.NET Core HTTPS development certificate to secure the gRPC service. If the .NET gRPC client fails with the message `The remote certificate is invalid according to the validation procedure.` or `The SSL connection could not be established.`, the development certificate isn't trusted. To fix this issue, see [Call a gRPC service with an untrusted/invalid certificate](xref:grpc/troubleshoot#call-a-grpc-service-with-an-untrustedinvalid-certificate).

[!INCLUDE[](~/includes/gRPCazure.md)]

### Next steps

* <xref:grpc/index>
* <xref:grpc/basics>
* <xref:grpc/migration>

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-5.0"

This tutorial shows how to create a .NET Core [gRPC](xref:grpc/index) client and an ASP.NET Core gRPC Server.

At the end, you'll have a gRPC client that communicates with the gRPC Greeter service.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/grpc/grpc-start/sample) ([how to download](xref:index#how-to-download-a-sample)).

In this tutorial, you:

> [!div class="checklist"]
> * Create a gRPC Server.
> * Create a gRPC client.
> * Test the gRPC client with the gRPC Greeter service.

## Prerequisites

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-core-prereqs-vs-3.1.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-core-prereqs-vsc-3.1.md)]

# [Visual Studio for Mac](#tab/visual-studio-mac)

* [Visual Studio for Mac version 8.7 or later](/visualstudio/releasenotes/vs2019-mac-relnotes)
* [!INCLUDE [.NET Core 3.1 SDK](~/includes/3.1-SDK.md)]
---

## Create a gRPC service

# [Visual Studio](#tab/visual-studio)

* Start Visual Studio and select **Create a new project**. Alternatively, from the Visual Studio **File** menu, select **New** > **Project**.
* In the **Create a new project** dialog, select **gRPC Service** and select **Next**:

  ![Create a new project dialog in Visual Studio](~/tutorials/grpc/grpc-start/static/cnp.png)

* Name the project **GrpcGreeter**. It's important to name the project *GrpcGreeter* so the namespaces match when you copy and paste code.
* Select **Create**.
* In the **Create a new gRPC service** dialog:
  * The **gRPC Service** template is selected.
  * Select **Create**.

# [Visual Studio Code](#tab/visual-studio-code)

* Open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
* Change directories (`cd`) to a folder for the project.
* Run the following commands:

  ```dotnetcli
  dotnet new grpc -o GrpcGreeter
  code -r GrpcGreeter
  ```

  * The `dotnet new` command creates a new gRPC service in the *GrpcGreeter* folder.
  * The `code` command opens the *GrpcGreeter* folder in a new instance of Visual Studio Code.

  A dialog box appears with **Required assets to build and debug are missing from 'GrpcGreeter'. Add them?**
* Select **Yes**.

# [Visual Studio for Mac](#tab/visual-studio-mac)

* Start Visual Studio for Mac and select **Create a new project**. Alternatively, from the Visual Studio **File** menu, select **New** > **Project**.
* In the **Create a new project** dialog, select **Web and Console** > **App** > **gRPC Service** and select **Next**:

  ![Create a new project dialog on macOS](~/tutorials/grpc/grpc-start/static/cnp-mac.png)

* Select **.NET Core 3.1** for the target framework and select **Next**.
* Name the project **GrpcGreeter**. It's important to name the project *GrpcGreeter* so the namespaces match when you copy and paste code.
* Select **Create**.
---

### Run the service

  [!INCLUDE[](~/includes/run-the-app.md)]

The logs show the service listening on `https://localhost:5001`.

```console
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
```

> [!NOTE]
> The gRPC template is configured to use [Transport Layer Security (TLS)](https://tools.ietf.org/html/rfc5246). gRPC clients need to use HTTPS to call the server.
>
> macOS doesn't support ASP.NET Core gRPC with TLS. Additional configuration is required to successfully run gRPC services on macOS. For more information, see [Unable to start ASP.NET Core gRPC app on macOS](xref:grpc/troubleshoot#unable-to-start-aspnet-core-grpc-app-on-macos).

### Examine the project files

*GrpcGreeter* project files:

* *greet.proto*: The *Protos/greet.proto* file defines the `Greeter` gRPC and is used to generate the gRPC server assets. For more information, see [Introduction to gRPC](xref:grpc/index).
* *Services* folder: Contains the implementation of the `Greeter` service.
* `appsettings.json`: Contains configuration data, such as protocol used by Kestrel. For more information, see <xref:fundamentals/configuration/index>.
* `Program.cs`: Contains the entry point for the gRPC service. For more information, see <xref:fundamentals/host/generic-host>.
* `Startup.cs`: Contains code that configures app behavior. For more information, see [App startup](xref:fundamentals/startup).

## Create the gRPC client in a .NET console app

# [Visual Studio](#tab/visual-studio)

* Open a second instance of Visual Studio and select **Create a new project**.
* In the **Create a new project** dialog, select **Console App (.NET Core)** and select **Next**.
* In the **Project name** text box, enter **GrpcGreeterClient** and select **Create**.

# [Visual Studio Code](#tab/visual-studio-code)

* Open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).
* Change directories (`cd`) to a folder for the project.
* Run the following commands:

  ```dotnetcli
  dotnet new console -o GrpcGreeterClient
  code -r GrpcGreeterClient
  ```

# [Visual Studio for Mac](#tab/visual-studio-mac)

Follow the instructions in [Building a complete .NET Core solution on macOS using Visual Studio for Mac](/dotnet/core/tutorials/using-on-mac-vs-full-solution) to create a console app with the name *GrpcGreeterClient*.

---

### Add required packages

The gRPC client project requires the following packages:

* [Grpc.Net.Client](https://www.nuget.org/packages/Grpc.Net.Client), which contains the .NET Core client.
* [Google.Protobuf](https://www.nuget.org/packages/Google.Protobuf/), which contains protobuf message APIs for C#.
* [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools/), which contains C# tooling support for protobuf files. The tooling package isn't required at runtime, so the dependency is marked with `PrivateAssets="All"`.

# [Visual Studio](#tab/visual-studio)

Install the packages using either the Package Manager Console (PMC) or Manage NuGet Packages.

#### PMC option to install packages

* From Visual Studio, select **Tools** > **NuGet Package Manager** > **Package Manager Console**
* From the **Package Manager Console** window, run `cd GrpcGreeterClient` to change directories to the folder containing the `GrpcGreeterClient.csproj` files.
* Run the following commands:

  ```powershell
  Install-Package Grpc.Net.Client
  Install-Package Google.Protobuf
  Install-Package Grpc.Tools
  ```

#### Manage NuGet Packages option to install packages

* Right-click the project in **Solution Explorer** > **Manage NuGet Packages**.
* Select the **Browse** tab.
* Enter **Grpc.Net.Client** in the search box.
* Select the **Grpc.Net.Client** package from the **Browse** tab and select **Install**.
* Repeat for `Google.Protobuf` and `Grpc.Tools`.

# [Visual Studio Code](#tab/visual-studio-code)

Run the following commands from the **Integrated Terminal**:

```dotnetcli
dotnet add GrpcGreeterClient.csproj package Grpc.Net.Client
dotnet add GrpcGreeterClient.csproj package Google.Protobuf
dotnet add GrpcGreeterClient.csproj package Grpc.Tools
```

# [Visual Studio for Mac](#tab/visual-studio-mac)

* Right-click **GrpcGreeterClient** project in the **Solution Pad** and select **Manage NuGet Packages**.
* Enter **Grpc.Net.Client** in the search box.
* Select the **Grpc.Net.Client** package from the results pane and select **Add Package**.
* Select the **Accept** button on the **Accept License** dialog.
* Repeat for `Google.Protobuf` and `Grpc.Tools`.

---

### Add greet.proto

* Create a *Protos* folder in the gRPC client project.
* Copy the *Protos\greet.proto* file from the gRPC Greeter service to the *Protos* folder in the gRPC client project.
* Update the namespace inside the `greet.proto` file to the project's namespace:

  ```
  option csharp_namespace = "GrpcGreeterClient";
  ```

* Edit the `GrpcGreeterClient.csproj` project file:

  # [Visual Studio](#tab/visual-studio)

  Right-click the project and select **Edit Project File**.

  # [Visual Studio Code](#tab/visual-studio-code)

  Select the `GrpcGreeterClient.csproj` file.

  # [Visual Studio for Mac](#tab/visual-studio-mac)

  Right-click the project and select **Edit Project File**.

  ---

* Add an item group with a `<Protobuf>` element that refers to the *greet.proto* file:

  ```xml
  <ItemGroup>
    <Protobuf Include="Protos\greet.proto" GrpcServices="Client" />
  </ItemGroup>
  ```

### Create the Greeter client

* Build the client project to create the types in the `GrpcGreeterClient` namespace.

> [!NOTE]
> The `GrpcGreeterClient` types are generated automatically by the build process. The tooling package [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools/) generates the following files based on the *greet.proto* file:
>
> * `GrpcGreeterClient\obj\Debug\[TARGET_FRAMEWORK]\Protos\Greet.cs`: The protocol buffer code which populates, serializes and retrieves the request and response message types.
> * `GrpcGreeterClient\obj\Debug\[TARGET_FRAMEWORK]\Protos\GreetGrpc.cs`: Contains the the generated client classes.
>
> For more information on the C# assets automatically generated by [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools/), see [gRPC services with C#: Generated C# assets](xref:grpc/basics#generated-c-assets).

Update the gRPC client `Program.cs` file with the following code:

[!code-csharp[](~/tutorials/grpc/grpc-start/sample/GrpcGreeterClient/Program.cs?name=snippet2)]

`Program.cs` contains the entry point and logic for the gRPC client.

The Greeter client is created by:

* Instantiating a `GrpcChannel` containing the information for creating the connection to the gRPC service.
* Using the `GrpcChannel` to construct the Greeter client:

[!code-csharp[](~/tutorials/grpc/grpc-start/sample/GrpcGreeterClient/Program.cs?name=snippet&highlight=3-5)]

The Greeter client calls the asynchronous `SayHello` method. The result of the `SayHello` call is displayed:

[!code-csharp[](~/tutorials/grpc/grpc-start/sample/GrpcGreeterClient/Program.cs?name=snippet&highlight=6-8)]

## Test the gRPC client with the gRPC Greeter service

# [Visual Studio](#tab/visual-studio)

* In the Greeter service, press `Ctrl+F5` to start the server without the debugger.
* In the `GrpcGreeterClient` project, press `Ctrl+F5` to start the client without the debugger.

# [Visual Studio Code](#tab/visual-studio-code)

* Start the Greeter service.
* Start the client.

# [Visual Studio for Mac](#tab/visual-studio-mac)

* Due to the previously mentioned [HTTP/2 TLS issue on macOS workaround](xref:grpc/troubleshoot#unable-to-start-aspnet-core-grpc-app-on-macos), you'll need to update the channel address in the client to "http://localhost:5000". Update line 13 of *`GrpcGreeterClient/Program.cs`* to read:
  ```csharp
  using var channel = GrpcChannel.ForAddress("http://localhost:5000");
  ``` 
* Start the Greeter service.
* Start the client.

---

The client sends a greeting to the service with a message containing its name, *GreeterClient*. The service sends the message "Hello GreeterClient" as a response. The "Hello GreeterClient" response is displayed in the command prompt:

```console
Greeting: Hello GreeterClient
Press any key to exit...
```

The gRPC service records the details of the successful call in the logs written to the command prompt:

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

> [!NOTE]
> The code in this article requires the ASP.NET Core HTTPS development certificate to secure the gRPC service. If the .NET gRPC client fails with the message `The remote certificate is invalid according to the validation procedure.` or `The SSL connection could not be established.`, the development certificate isn't trusted. To fix this issue, see [Call a gRPC service with an untrusted/invalid certificate](xref:grpc/troubleshoot#call-a-grpc-service-with-an-untrustedinvalid-certificate).

[!INCLUDE[](~/includes/gRPCazure.md)]

### Next steps

* <xref:grpc/index>
* <xref:grpc/basics>
* <xref:grpc/migration>

:::moniker-end
