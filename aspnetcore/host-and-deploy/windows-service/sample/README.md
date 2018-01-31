# Custom WebHost Service Sample

This sample shows the recommended way to host an ASP.NET Core app on Windows without using IIS as a Windows Service. This sample demonstrates the features described in [Host an ASP.NET Core app in a Windows Service](https://docs.microsoft.com/aspnet/core/host-and-deploy/windows-service).

## Instructions

The sample app is a simple MVC web app modified according to the instructions in [Host an ASP.NET Core app in a Windows Service](https://docs.microsoft.com/aspnet/core/host-and-deploy/windows-service).

To run the app in a service, perform the following steps:

1. Create a folder at *c:\svc*.

1. Publish the app to the folder with `dotnet publish --configuration Release --output c:\\svc`. The command will move the app's assets to the folder, including the required `appsettings.json` file and the `wwwroot` folder with its contents.

1. Open an **administrator** command shell.

1. Execute the following commands:

   ```console
   sc create MyService binPath="c:\svc\aspnetcoreservice.exe"
   sc start MyService
   ```

1. In a browser, go to `http://localhost:5000` to verify that the service is running.

1. To stop the service, use the command:

   ```console
   sc stop MyService
   ```

If the app doesn't start up as expected when running in a service, a quick way to make error messages accessible is to add a logging provider, such as the [Windows EventLog provider](https://docs.microsoft.com/aspnet/core/fundamentals/logging/index#eventlog). Another option is to check the Application Event Log using the Event Viewer on the system. For example, here's an unhandled exception for a FileNotFound error in the Application Event Log:

```console
Application: AspNetCoreService.exe
Framework Version: v4.0.30319
Description: The process was terminated due to an unhandled exception.
Exception Info: System.IO.FileNotFoundException
   at Microsoft.Extensions.Configuration.FileConfigurationProvider.Load(Boolean)
   at Microsoft.Extensions.Configuration.ConfigurationRoot..ctor(System.Collections.Generic.IList`1<Microsoft.Extensions.Configuration.IConfigurationProvider>)
   at Microsoft.Extensions.Configuration.ConfigurationBuilder.Build()
   ...
```
