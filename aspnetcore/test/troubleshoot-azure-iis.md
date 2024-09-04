---
title: Troubleshoot ASP.NET Core on Azure App Service
author: rick-anderson
description: Learn how to diagnose problems with Azure App Service of ASP.NET Core apps.
monikerRange: '>= aspnetcore-2.2'
ms.author: riande
ms.custom: mvc
ms.date: 6/11/2024
uid: test/troubleshoot-azure-iis
---
# Troubleshoot ASP.NET Core on Azure App Service

By [Justin Kotalik](https://github.com/jkotalik)

:::moniker range=">= aspnetcore-8.0"

This article provides information on common app startup errors and instructions on how to diagnose errors when an app is deployed to Azure App Service:

[App startup errors](#app-startup-errors)  
Explains common startup HTTP status code scenarios.

[Troubleshoot on Azure App Service](#troubleshoot-on-azure-app-service)  
Provides troubleshooting advice for apps deployed to Azure App Service.

[Clear package caches](#clear-package-caches)  
Explains what to do when incoherent packages break an app when performing major upgrades or changing package versions.

### Connection reset

If an error occurs after the headers are sent, it's too late for the server to send a **500 Internal Server Error** when an error occurs. This often happens when an error occurs during the serialization of complex objects for a response. This type of error appears as a *connection reset* error on the client. [Application logging](xref:fundamentals/logging/index) can help troubleshoot these types of errors.

### Default startup limits

The [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module) is configured with a default *startupTimeLimit* of 120 seconds. When left at the default value, an app may take up to two minutes to start before the module logs a process failure. For information on configuring the module, see [Attributes of the aspNetCore element](xref:host-and-deploy/aspnet-core-module#attributes-of-the-aspnetcore-element).

## Troubleshoot on Azure App Service

[!INCLUDE [Azure App Service Preview Notice](~/includes/azure-apps-preview-notice.md)]

### Azure App Services Log stream

The Azure App Services Log streams logging information as it occurs. For more information, see:

* [Azure App Service diagnostics overview](/azure/app-service/app-service-diagnostics)
* [Enable diagnostics logging for web apps in Azure App Service](/azure/app-service/web-sites-enable-diagnostic-log)
* [Monitor Azure App Service](/azure/app-service/web-sites-monitor)
* [Azure App Service troubleshooting and diagnostics](/azure/app-service/troubleshoot-diagnostic-logs)
* [Azure App Service Logging: How to Monitor Your Web Apps in Real-Time](https://techcommunity.microsoft.com/t5/apps-on-azure-blog/azure-app-service-logging-how-to-monitor-your-web-apps-in-real/ba-p/3800390)
* [Log streams in Azure Container Apps](/azure/container-apps/how-to-view-logs)
* [View log streams in Azure Container Apps](/azure/container-apps/log-streaming)

### Azure App Services Log

* [Enable diagnostics logging for apps in Azure App Service](/azure/app-service/web-sites-enable-diagnostic-log)

### Application Event Log (Azure App Service)

* [How to access Azure webapp of Application event log into Azure Log Analytic Workspace instead of Diagnostic tool](/answers/questions/1337181/how-to-access-azure-webapp-of-application-event-lo)
* Enable diagnostics logging for apps in Azure App Service[https://learn.microsoft.com/en-us/azure/app-service/troubleshoot-diagnostic-logs](/azure/app-service/troubleshoot-diagnostic-logs)

<a name="kudu"></a>

### Run the app in the Kudu console

Many startup errors don't produce useful information in the Application Event Log. You can run the app in the [Kudu](https://github.com/projectkudu/kudu/wiki) Remote Execution Console to discover the error:

* [Kudu service overview)](/azure/app-service/resources-kudu)
* [Video:Azure App Service Advanced Tools a.k.a. Kudu](https://www.youtube.com/watch?v=fREVSQDbdAU)

#### Test a 32-bit (x86) app

**Current release**

1. `cd d:\home\site\wwwroot`
1. Run the app:
   * If the app is a [framework-dependent deployment](/dotnet/core/deploying/#framework-dependent-deployments-fdd):

     ```dotnetcli
     dotnet .\{ASSEMBLY NAME}.dll
     ```

   * If the app is a [self-contained deployment](/dotnet/core/deploying/#self-contained-deployments-scd):

     ```console
     {ASSEMBLY NAME}.exe
     ```

The console output from the app, showing any errors, is piped to the [Kudu console](https://github.com/projectkudu/kudu/wiki/Kudu-console).

**Framework-dependent deployment running on a preview release**

*Requires installing the ASP.NET Core {VERSION} (x86) Runtime site extension.*

1. `cd D:\home\SiteExtensions\AspNetCoreRuntime.{X.Y}.x32` (`{X.Y}` is the runtime version)
1. Run the app: `dotnet \home\site\wwwroot\{ASSEMBLY NAME}.dll`

The console output from the app, showing any errors, is piped to the [Kudu console](https://github.com/projectkudu/kudu/wiki/Kudu-console).

#### Test a 64-bit (x64) app

**Current release**

* If the app is a 64-bit (x64) [framework-dependent deployment](/dotnet/core/deploying/#framework-dependent-deployments-fdd):
  1. `cd D:\Program Files\dotnet`
  1. Run the app: `dotnet \home\site\wwwroot\{ASSEMBLY NAME}.dll`
* If the app is a [self-contained deployment](/dotnet/core/deploying/#self-contained-deployments-scd):
  1. `cd D:\home\site\wwwroot`
  1. Run the app: `{ASSEMBLY NAME}.exe`

The console output from the app, showing any errors, is piped to the [Kudu console](https://github.com/projectkudu/kudu/wiki/Kudu-console).

**Framework-dependent deployment running on a preview release**

*Requires installing the ASP.NET Core {VERSION} (x64) Runtime site extension.*

1. `cd D:\home\SiteExtensions\AspNetCoreRuntime.{X.Y}.x64` (`{X.Y}` is the runtime version)
1. Run the app: `dotnet \home\site\wwwroot\{ASSEMBLY NAME}.dll`

The console output from the app, showing any errors, is piped to the [Kudu console](https://github.com/projectkudu/kudu/wiki/Kudu-console).

<!-- IIS Only -->

### ASP.NET Core Module stdout log (Azure App Service)

> [!WARNING]
> Failure to disable the stdout log can lead to app or server failure. There's no limit on log file size or the number of log files created. Only use stdout logging to troubleshoot app startup problems.
>
> For general logging in an ASP.NET Core app after startup, use a logging library that limits log file size and rotates logs. For more information, see [third-party logging providers](xref:fundamentals/logging/index#third-party-logging-providers).

The ASP.NET Core Module stdout log often records useful error messages not found in the Application Event Log. To enable and view stdout logs:

1. In the Azure Portal, navigate to the web app.
1. In the **App Service** blade, enter **kudu** in the search box.
1. Select **Advanced Tools** > **Go**.
1. Select  **Debug console > CMD**.
1. Navigate to *site/wwwroot*
1. Select the pencil icon to edit the *web.config* file.
1. In the `<aspNetCore />` element, set `stdoutLogEnabled="true"` and select **Save**.

Disable stdout logging when troubleshooting is complete by setting `stdoutLogEnabled="false"`.

For more information, see <xref:host-and-deploy/aspnet-core-module#log-creation-and-redirection>.

<a name="enhanced-diagnostic-logs"></a>

### ASP.NET Core Module debug log (Azure App Service)

The ASP.NET Core Module debug log provides additional, deeper logging from the ASP.NET Core Module. To enable and view stdout logs:

1. To enable the enhanced diagnostic log, perform either of the following:
   * Follow the instructions in [Enhanced diagnostic logs](xref:host-and-deploy/iis/logging-and-diagnostics#enhanced-diagnostic-logs) to configure the app for an enhanced diagnostic logging. Redeploy the app.
   * Add the `<handlerSettings>` shown in [Enhanced diagnostic logs](xref:host-and-deploy/iis/logging-and-diagnostics#enhanced-diagnostic-logs) to the live app's *web.config* file using the [Kudu console](https://github.com/projectkudu/kudu/wiki/Kudu-console):
     1. Open **Advanced Tools** in the **Development Tools** area. Select the **Go&rarr;** button. The [Kudu console](https://github.com/projectkudu/kudu/wiki/Kudu-console) opens in a new browser tab or window.
     1. Using the navigation bar at the top of the page, open **Debug console** and select **CMD**.
     1. Open the folders to the path **site** > **wwwroot**. Edit the *web.config* file by selecting the pencil button. Add the `<handlerSettings>` section as shown in [Enhanced diagnostic logs](xref:host-and-deploy/iis/logging-and-diagnostics#enhanced-diagnostic-logs). Select the **Save** button.
1. Open **Advanced Tools** in the **Development Tools** area. Select the **Go&rarr;** button. The [Kudu console](https://github.com/projectkudu/kudu/wiki/Kudu-console) opens in a new browser tab or window.
1. Using the navigation bar at the top of the page, open **Debug console** and select **CMD**.
1. Open the folders to the path **site** > **wwwroot**. If you didn't supply a path for the *aspnetcore-debug.log* file, the file appears in the list. If you supplied a path, navigate to the location of the log file.
1. Open the log file with the pencil button next to the file name.

Disable debug logging when troubleshooting is complete:

To disable the enhanced debug log, perform either of the following:

* Remove the `<handlerSettings>` from the *web.config* file locally and redeploy the app.
* Use the [Kudu console](https://github.com/projectkudu/kudu/wiki/Kudu-console) to edit the *web.config* file and remove the `<handlerSettings>` section. Save the file.

For more information, see <xref:host-and-deploy/iis/logging-and-diagnostics#enhanced-diagnostic-logs>.

> [!WARNING]
> Failure to disable the debug log can lead to app or server failure. There's no limit on log file size. Only use debug logging to troubleshoot app startup problems.
>
> For general logging in an ASP.NET Core app after startup, use a logging library that limits log file size and rotates logs. For more information, see [third-party logging providers](xref:fundamentals/logging/index#third-party-logging-providers).

### Slow or hanging app (Azure App Service)

<!-- END IIS Only -->

When an app responds slowly or hangs on a request, see [Troubleshoot slow web app performance issues in Azure App Service](/azure/app-service/app-service-web-troubleshoot-performance-degradation).

### Monitoring blades

Monitoring blades provide an alternative troubleshooting experience to the methods described earlier in the topic. These blades can be used to diagnose 500-series errors.

Confirm that the ASP.NET Core Extensions are installed. If the extensions aren't installed, install them manually:

1. In the **DEVELOPMENT TOOLS** blade section, select the **Extensions** blade.
1. The **ASP.NET Core Extensions** should appear in the list.
1. If the extensions aren't installed, select the **Add** button.
1. Choose the **ASP.NET Core Extensions** from the list.
1. Select **OK** to accept the legal terms.
1. Select **OK** on the **Add extension** blade.
1. An informational pop-up message indicates when the extensions are successfully installed.

If stdout logging isn't enabled, follow these steps:

1. In the Azure portal, select the **Advanced Tools** blade in the **DEVELOPMENT TOOLS** area. Select the **Go&rarr;** button. The [Kudu console](https://github.com/projectkudu/kudu/wiki/Kudu-console) opens in a new browser tab or window.
1. Using the navigation bar at the top of the page, open **Debug console** and select **CMD**.
1. Open the folders to the path **site** > **wwwroot** and scroll down to reveal the *web.config* file at the bottom of the list.
1. Click the pencil icon next to the *web.config* file.
1. Set **stdoutLogEnabled** to `true` and change the **stdoutLogFile** path to: `\\?\%home%\LogFiles\stdout`.
1. Select **Save** to save the updated *web.config* file.

Proceed to activate diagnostic logging:

1. In the Azure portal, select the **Diagnostics logs** blade.
1. Select the **On** switch for **Application Logging (Filesystem)** and **Detailed error messages**. Select the **Save** button at the top of the blade.
1. To include failed request tracing, also known as Failed Request Event Buffering (FREB) logging, select the **On** switch for **Failed request tracing**.
1. Select the **Log stream** blade, which is listed immediately under the **Diagnostics logs** blade in the portal.
1. Make a request to the app.
1. Within the log stream data, the cause of the error is indicated.

Be sure to disable stdout logging when troubleshooting is complete.

To view the failed request tracing logs (FREB logs):

1. Navigate to the **Diagnose and solve problems** blade in the Azure portal.
1. Select **Failed Request Tracing Logs** from the **SUPPORT TOOLS** area of the sidebar.

See [Failed request traces section of the Enable diagnostics logging for web apps in Azure App Service topic](/azure/app-service/web-sites-enable-diagnostic-log#failed-request-traces) and the [Application performance FAQs for Web Apps in Azure: How do I turn on failed request tracing?](/azure/app-service/app-service-web-availability-performance-application-issues-faq#how-do-i-turn-on-failed-request-tracing) for more information.

For more information, see [Enable diagnostics logging for web apps in Azure App Service](/azure/app-service/web-sites-enable-diagnostic-log).

> [!WARNING]
> Failure to disable the stdout log can lead to app or server failure. There's no limit on log file size or the number of log files created.
>
> For routine logging in an ASP.NET Core app, use a logging library that limits log file size and rotates logs. For more information, see [third-party logging providers](xref:fundamentals/logging/index#third-party-logging-providers).

## Additional resources

* <xref:test/debug-aspnetcore-source>
* <xref:test/troubleshoot>
* <xref:fundamentals/error-handling>
* <xref:host-and-deploy/aspnet-core-module>

### Azure documentation

* [Application Insights for ASP.NET Core](/azure/application-insights/app-insights-asp-net-core)
* [Remote debugging web apps section of Troubleshoot a web app in Azure App Service using Visual Studio](/azure/app-service/web-sites-dotnet-troubleshoot-visual-studio#remotedebug)
* [Azure App Service diagnostics overview](/azure/app-service/app-service-diagnostics)
* [How to: Monitor Apps in Azure App Service](/azure/app-service/web-sites-monitor)
* [Troubleshoot a web app in Azure App Service using Visual Studio](/azure/app-service/web-sites-dotnet-troubleshoot-visual-studio)
* [Troubleshoot HTTP errors of "502 bad gateway" and "503 service unavailable" in your Azure web apps](/azure/app-service/app-service-web-troubleshoot-http-502-http-503)
* [Troubleshoot slow web app performance issues in Azure App Service](/azure/app-service/app-service-web-troubleshoot-performance-degradation)
* [Application performance FAQs for Web Apps in Azure](/azure/app-service/app-service-web-availability-performance-application-issues-faq)
* [Azure Web App sandbox (App Service runtime execution limitations)](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox)

### Visual Studio documentation

* [Remote Debug ASP.NET Core on IIS in Azure in Visual Studio 2017](/visualstudio/debugger/remote-debugging-azure)
* [Remote Debug ASP.NET Core on a Remote IIS Computer in Visual Studio 2017](/visualstudio/debugger/remote-debugging-aspnet-on-a-remote-iis-computer)
* [Learn to debug using Visual Studio](/visualstudio/debugger/getting-started-with-the-debugger)

### Visual Studio Code documentation

* [Debugging with Visual Studio Code](https://code.visualstudio.com/docs/editor/debugging)

:::moniker-end

[!INCLUDE[](~/test/troubleshoot-azure-iis/includes/troubleshoot-azure-iis2.md)]
[!INCLUDE[](~/test/troubleshoot-azure-iis/includes/troubleshoot-azure-iis7.md)]
