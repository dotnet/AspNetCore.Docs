---
title: Host and deploy ASP.NET Core server-side Blazor apps
author: guardrex
description: Learn how to host and deploy server-side Blazor apps using ASP.NET Core.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc, linux-related-content
ms.date: 02/09/2024
uid: blazor/host-and-deploy/server
---
# Host and deploy server-side Blazor apps

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to host and deploy server-side Blazor apps (Blazor Web Apps and Blazor Server apps) using ASP.NET Core.

## Host configuration values

Server-side Blazor apps can accept [Generic Host configuration values](xref:fundamentals/host/generic-host#host-configuration).

## Deployment

Using a server-side hosting model, Blazor is executed on the server from within an ASP.NET Core app. UI updates, event handling, and JavaScript calls are handled over a [SignalR](xref:signalr/introduction) connection.

A web server capable of hosting an ASP.NET Core app is required. Visual Studio includes a server-side app project template. For more information on Blazor project templates, see <xref:blazor/project-structure>.

Publish an app in Release configuration and deploy the contents of the `bin/Release/{TARGET FRAMEWORK}/publish` folder, where the `{TARGET FRAMEWORK}` placeholder is the target framework.

## Scalability

When considering the scalability of a single server (scale up), the memory available to an app is likely the first resource that the app exhausts as user demands increase. The available memory on the server affects the:

* Number of active circuits that a server can support.
* UI latency on the client.

For guidance on building secure and scalable server-side Blazor apps, see the following resources:

* <xref:blazor/security/server/static-server-side-rendering>
* <xref:blazor/security/server/interactive-server-side-rendering>

Each circuit uses approximately 250 KB of memory for a minimal *Hello World*-style app. The size of a circuit depends on the app's code and the state maintenance requirements associated with each component. We recommend that you measure resource demands during development for your app and infrastructure, but the following baseline can be a starting point in planning your deployment target: If you expect your app to support 5,000 concurrent users, consider budgeting at least 1.3 GB of server memory to the app (or ~273 KB per user).

## SignalR configuration

[SignalR's hosting and scaling conditions](xref:signalr/publish-to-azure-web-app) apply to Blazor apps that use SignalR.

For more information on SignalR in Blazor apps, including configuration guidance, see <xref:blazor/fundamentals/signalr>.

:::moniker range=">= aspnetcore-6.0"

### Transports

Blazor works best when using [WebSockets](xref:fundamentals/websockets) as the SignalR transport due to lower latency, better reliability, and improved [security](xref:signalr/security). [Long Polling](https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/docs/specs/TransportProtocols.md#long-polling-server-to-client-only) is used by SignalR when WebSockets isn't available or when the app is explicitly configured to use Long Polling. When deploying to Azure App Service, configure the app to use WebSockets in the Azure portal settings for the service. For details on configuring the app for Azure App Service, see the [SignalR publishing guidelines](xref:signalr/publish-to-azure-web-app).

A console warning appears if Long Polling is utilized:

> :::no-loc text="Failed to connect via WebSockets, using the Long Polling fallback transport. This may be due to a VPN or proxy blocking the connection.":::

### Global deployment and connection failures

Recommendations for global deployments to geographical data centers:

* Deploy the app to the regions where most of the users reside.
* Take into consideration the increased latency for traffic across continents. To control the appearance of the reconnection UI, see <xref:blazor/fundamentals/signalr#control-when-the-reconnection-ui-appears>.
* For Azure hosting, use the [Azure SignalR Service](#azure-signalr-service).

:::moniker-end

## Azure SignalR Service

:::moniker range=">= aspnetcore-8.0"

For Blazor Web Apps that adopt interactive server-side rendering, consider using the [Azure SignalR Service](xref:signalr/scale#azure-signalr-service). The service works in conjunction with the app's Blazor Hub for scaling up to a large number of concurrent SignalR connections. In addition, the service's global reach and high-performance data centers significantly aid in reducing latency due to geography. If your hosting environment already handles these concerns, using the Azure SignalR Service isn't necessary.

<!-- UPDATE 9.0 Remove when support is present -->

> [!NOTE]
> [Stateful reconnect](xref:signalr/configuration#configure-stateful-reconnect) (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilderHttpExtensions.WithStatefulReconnect%2A>) was released with .NET 8 but isn't currently supported for the Azure SignalR Service. For more information, see [Stateful Reconnect Support? (`Azure/azure-signalr` #1878)](https://github.com/Azure/azure-signalr/issues/1878).

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Consider using the [Azure SignalR Service](xref:signalr/scale#azure-signalr-service), which works in conjunction with the app's Blazor Hub for scaling up to a large number of concurrent SignalR connections. In addition, the service's global reach and high-performance data centers significantly aid in reducing latency due to geography. If your hosting environment already handles these concerns, using the Azure SignalR Service isn't necessary.

:::moniker-end

> [!IMPORTANT]
> When [WebSockets](https://wikipedia.org/wiki/WebSocket) are disabled, Azure App Service simulates a real-time connection using HTTP Long Polling. HTTP Long Polling is noticeably slower than running with WebSockets enabled, which doesn't use polling to simulate a client-server connection. In the event that Long Polling must be used, you may need to configure the maximum poll interval (`MaxPollIntervalInSeconds`), which defines the maximum poll interval allowed for Long Polling connections in [Azure SignalR Service](#azure-signalr-service) if the service ever falls back from WebSockets to Long Polling. If the next poll request does not come in within `MaxPollIntervalInSeconds`, Azure SignalR Service cleans up the client connection. Note that Azure SignalR Service also cleans up connections when cached waiting to write buffer size is greater than 1 MB to ensure service performance. Default value for `MaxPollIntervalInSeconds` is 5 seconds. The setting is limited to 1-300 seconds.
>
> **We recommend using WebSockets for server-side Blazor apps deployed to Azure App Service.** The [Azure SignalR Service](xref:signalr/scale#azure-signalr-service) uses WebSockets by default. If the app doesn't use the Azure SignalR Service, see <xref:signalr/publish-to-azure-web-app#configure-the-app-in-azure-app-service>.
>
> For more information, see:
>
> * [What is Azure SignalR Service?](/azure/azure-signalr/signalr-overview)
> * [Performance guide for Azure SignalR Service](/azure/azure-signalr/signalr-concept-performance#performance-factors)
> * <xref:signalr/publish-to-azure-web-app>

The app must support *session affinity*, also called *sticky sessions*, where clients are redirected back to the same server. To support session affinity, an application setting in the Azure portal is automatically configured (**Configuration** > **Application settings**: **Name**: `Azure__SignalR__ServerStickyMode`, **Value**: `Required`). Therefore, you don't need to manually configure the app for session affinity.

If you prefer not to use the app setting in Azure (and delete it in the Azure portal), two other approaches for configuring session affinity are (**use either approach, not both**):

* Set the option in `Program.cs`:

  ```csharp
  builder.Services.AddSignalR().AddAzureSignalR(options =>
  {
      options.ServerStickyMode = 
          Microsoft.Azure.SignalR.ServerStickyMode.Required;
  });
  ```

* Configure the option in `appsettings.json`:

  ```json
  "Azure:SignalR:ServerStickyMode": "Required"
  ```

> [!NOTE]
> The following error is thrown by an app that hasn't enabled session affinity:
>
> > :::no-loc text="blazor.server.js:1 Uncaught (in promise) Error: Invocation canceled due to the underlying connection being closed.":::

To provision the Azure SignalR Service for an app in Visual Studio:

1. Create an Azure Apps publish profile in Visual Studio for the app.
1. Add the **Azure SignalR Service** dependency to the profile. If the Azure subscription doesn't have a pre-existing Azure SignalR Service instance to assign to the app, select **Create a new Azure SignalR Service instance** to provision a new service instance.
1. Publish the app to Azure.

Provisioning the Azure SignalR Service in Visual Studio automatically adds the SignalR connection string to the app service's configuration.

## Azure App Service

:::moniker range=">= aspnetcore-8.0"

Hosting a Blazor Web App that uses interactive server-side rendering on Azure App Service requires configuration for Application Request Routing (ARR) affinity and WebSockets. The App Service should also be appropriately globally distributed to reduce UI latency. Using the Azure SignalR Service when hosting on Azure App Service isn't required.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Hosting a Blazor Server app on Azure App Service requires configuration for Application Request Routing (ARR) affinity and WebSockets. The App Service should also be appropriately globally distributed to reduce UI latency. Using the Azure SignalR Service when hosting on Azure App Service isn't required.

:::moniker-end

1. Use the following guidance to configure the service:

  * [Configure the app in Azure App Service](xref:signalr/publish-to-azure-web-app#configure-the-app-in-azure-app-service).
  * [App Service Plan Limits](xref:signalr/publish-to-azure-web-app#app-service-plan-limits).

:::moniker range=">= aspnetcore-6.0"

## Azure Container Apps

For a deeper exploration of scaling server-side Blazor apps on the Azure Container Apps service, see <xref:host-and-deploy/scaling-aspnet-apps/scaling-aspnet-apps>. The tutorial explains how to create and integrate the services required to host apps on Azure Container Apps. Basic steps are also provided in this section.

1. Configure Azure Container Apps service for session affinity by following the guidance in [Session Affinity in Azure Container Apps (Azure documentation)](/azure/container-apps/sticky-sessions).

1. The ASP.NET Core Data Protection service must be configured to persist keys in a centralized location that all container instances can access. The keys can be stored in Azure Blob Storage and protected with Azure Key Vault. The data protection service uses the keys to deserialize Razor components. To configure the data protection service to use Azure Blob Storage and Azure Key Vault, reference the following NuGet packages:

   * [`Azure.Identity`](https://www.nuget.org/packages/Azure.Identity): Provides classes to work with the Azure identity and access management services.
   * [`Microsoft.Extensions.Azure`](https://www.nuget.org/packages/Microsoft.Extensions.Azure): Provides helpful extension methods to perform core Azure configurations.
   * [`Azure.Extensions.AspNetCore.DataProtection.Blobs`](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Blobs): Allows storing ASP.NET Core Data Protection keys in Azure Blob Storage so that keys can be shared across several instances of a web app.
   * [`Azure.Extensions.AspNetCore.DataProtection.Keys`](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Keys): Enables protecting keys at rest using the Azure Key Vault Key Encryption/Wrapping feature.

   [!INCLUDE[](~/includes/package-reference.md)]

1. Update `Program.cs` with the following highlighted code:

   :::code language="csharp" source="~/../AspNetCore.Docs.Samples/tutorials/scalable-razor-apps/end/Program.cs" id="snippet_ProgramConfigurations" highlight="1-4,6-7,13-19":::    

   The preceding changes allow the app to manage data protection using a centralized, scalable architecture. <xref:Azure.Identity.DefaultAzureCredential> discovers the container app managed identity after the code is deployed to Azure and uses it to connect to blob storage and the app's key vault.

1. To create the container app managed identity and grant it access to blob storage and a key vault, complete the following steps:

   1. In the Azure Portal, navigate to the overview page of the container app.
   1. Select **Service Connector** from the left navigation.
   1. Select **+ Create** from the top navigation.
   1. In the **Create connection** flyout menu, enter the following values:
      * **Container**: Select the container app you created to host your app.
      * **Service type**: Select **Blob Storage**.
      * **Subscription**: Select the subscription that owns the container app.
      * **Connection name**: Enter a name of `scalablerazorstorage`.
      * **Client type**: Select **.NET** and then select **Next**.
   1. Select **System assigned managed identity** and select **Next**.
   1. Use the default network settings and select **Next**.
   1. After Azure validates the settings, select **Create**.

   Repeat the preceding settings for the key vault. Select the appropriate key vault service and key in the **Basics** tab.

:::moniker-end

## IIS

When using IIS, enable:

* [WebSockets on IIS](xref:fundamentals/websockets#enabling-websockets-on-iis).
* [Sticky sessions with Application Request Routing](/iis/extensions/configuring-application-request-routing-arr/http-load-balancing-using-application-request-routing).

For more information, see the guidance and external IIS resource cross-links in <xref:tutorials/publish-to-iis>.

## Kubernetes

Create an ingress definition with the following [Kubernetes annotations for sticky sessions](https://kubernetes.github.io/ingress-nginx/examples/affinity/cookie/):

```yaml
apiVersion: extensions/v1beta1
kind: Ingress
metadata:
  name: <ingress-name>
  annotations:
    nginx.ingress.kubernetes.io/affinity: "cookie"
    nginx.ingress.kubernetes.io/session-cookie-name: "affinity"
    nginx.ingress.kubernetes.io/session-cookie-expires: "14400"
    nginx.ingress.kubernetes.io/session-cookie-max-age: "14400"
```

## Linux with Nginx

Follow the guidance for an [ASP.NET Core SignalR app](xref:signalr/scale#linux-with-nginx) with the following changes:

* Change the `location` path from `/hubroute` (`location /hubroute { ... }`) to the root path `/` (`location / { ... }`).
* Remove the configuration for proxy buffering (`proxy_buffering off;`) because the setting only applies to [Server-Sent Events (SSE)](https://developer.mozilla.org/docs/Web/API/Server-sent_events), which aren't relevant to Blazor app client-server interactions.

For more information and configuration guidance, consult the following resources:

* <xref:signalr/scale>
* <xref:host-and-deploy/linux-nginx>
* <xref:host-and-deploy/proxy-load-balancer>
* [NGINX as a WebSocket Proxy](https://www.nginx.com/blog/websocket-nginx/)
* [WebSocket proxying](http://nginx.org/docs/http/websocket.html)
* Consult developers on non-Microsoft support forums:
  * [Stack Overflow (tag: `blazor`)](https://stackoverflow.com/questions/tagged/blazor)
  * [ASP.NET Core Slack Team](https://join.slack.com/t/aspnetcore/shared_invite/zt-1mv5487zb-EOZxJ1iqb0A0ajowEbxByQ)
  * [Blazor Gitter](https://gitter.im/aspnet/Blazor)

## Linux with Apache

To host a Blazor app behind Apache on Linux, configure `ProxyPass` for HTTP and WebSockets traffic.

In the following example:

* Kestrel server is running on the host machine.
* The app listens for traffic on port 5000.

```
ProxyPreserveHost   On
ProxyPassMatch      ^/_blazor/(.*) http://localhost:5000/_blazor/$1
ProxyPass           /_blazor ws://localhost:5000/_blazor
ProxyPass           / http://localhost:5000/
ProxyPassReverse    / http://localhost:5000/
```

Enable the following modules:

```
a2enmod   proxy
a2enmod   proxy_wstunnel
```

Check the browser console for WebSockets errors. Example errors:

* Firefox can't establish a connection to the server at :::no-loc text="ws://the-domain-name.tld/_blazor?id=XXX":::
* Error: Failed to start the transport 'WebSockets': Error: There was an error with the transport.
* Error: Failed to start the transport 'LongPolling': TypeError: this.transport is undefined
* Error: Unable to connect to the server with any of the available transports. WebSockets failed
* Error: Cannot send data if the connection is not in the 'Connected' State.

For more information and configuration guidance, consult the following resources:

* <xref:host-and-deploy/proxy-load-balancer>
* [Apache documentation](https://httpd.apache.org/docs/current/mod/mod_proxy.html)
* Consult developers on non-Microsoft support forums:
  * [Stack Overflow (tag: `blazor`)](https://stackoverflow.com/questions/tagged/blazor)
  * [ASP.NET Core Slack Team](https://join.slack.com/t/aspnetcore/shared_invite/zt-1mv5487zb-EOZxJ1iqb0A0ajowEbxByQ)
  * [Blazor Gitter](https://gitter.im/aspnet/Blazor)

## Measure network latency

[JS interop](xref:blazor/js-interop/call-javascript-from-dotnet) can be used to measure network latency, as the following example demonstrates.

`MeasureLatency.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/MeasureLatency.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/host-and-deploy/MeasureLatency.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/host-and-deploy/MeasureLatency.razor":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```razor
@inject IJSRuntime JS

@if (latency is null)
{
    <span>Calculating...</span>
}
else
{
    <span>@(latency.Value.TotalMilliseconds)ms</span>
}

@code {
    private DateTime startTime;
    private TimeSpan? latency;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            startTime = DateTime.UtcNow;
            var _ = await JS.InvokeAsync<string>("toString");
            latency = DateTime.UtcNow - startTime;
            StateHasChanged();
        }
    }
}
```

:::moniker-end

For a reasonable UI experience, we recommend a sustained UI latency of 250 ms or less.

## Memory management

On the server, a new circuit is created for each user session. Each user session corresponds to rendering a single document in the browser. For example, multiple tabs create multiple sessions.

Blazor maintains a constant connection to the browser, called a *circuit*, that initiated the session. Connections can be lost at any time for any of several reasons, such as when the user loses network connectivity or abruptly closes the browser. When a connection is lost, Blazor has a recovery mechanism that places a limited number of circuits in a "disconnected" pool, giving clients a limited amount of time to reconnect and re-establish the session (default: 3 minutes).

After that time, Blazor releases the circuit and discards the session. From that point on, the circuit is eligible for garbage collection (GC) and is claimed when a collection for the circuit's GC generation is triggered. One important aspect to understand is that circuits have a long lifetime, which means that most of the objects rooted by the circuit eventually reach Gen 2. As a result, you might not see those objects released until a Gen 2 collection happens.

### Measure memory usage in general

Prerequisites:

* The app must be published in **Release** configuration. **Debug** configuration measurements aren't relevant, as the generated code isn't representative of the code used for a production deployment.
* The app must run without a debugger attached, as this might also affect the behavior of the app and spoil the results. In Visual Studio, start the app without debugging by selecting **Debug** > **Start Without Debugging** from the menu bar or <kbd>Ctrl</kbd>+<kbd>F5</kbd> using the keyboard.
* Consider the different types of memory to understand how much memory is actually used by .NET. Generally, developers inspect app memory usage in Task Manager on Windows OS, which typically offers an upper bound of the actual memory in use. For more information, consult the following articles:
  * [.NET Memory Performance Analysis](https://github.com/Maoni0/mem-doc/blob/master/doc/.NETMemoryPerformanceAnalysis.md): In particular, see the section on [Memory Fundamentals](https://github.com/Maoni0/mem-doc/blob/master/doc/.NETMemoryPerformanceAnalysis.md#Memory-Fundamentals).
  * [Work flow of diagnosing memory performance issues (three-part series)](https://devblogs.microsoft.com/dotnet/work-flow-of-diagnosing-memory-performance-issues-part-0/): Links to the three articles of the series are at the top of each article in the series.

### Memory usage applied to Blazor

We compute the memory used by blazor as follows:

(**Active Circuits** × **Per-circuit Memory**) + (**Disconnected Circuits** × **Per-circuit Memory**)

The amount of memory a circuit uses and the maximum potential active circuits that an app can maintain is largely dependent on how the app is written. The maximum number of possible active circuits is roughly described by:

**Maximum Available Memory** / **Per-circuit Memory** = **Maximum Potential Active Circuits**

For a memory leak to occur in Blazor, the following must be true:

* The memory must be allocated by the framework, not the app. If you allocate a 1 GB array in the app, the app must manage the disposal of the array.
* The memory must not be actively used, which means the circuit isn't active and has been evicted from the disconnected circuits cache. If you have the maximum active circuits running, running out of memory is a scale issue, not a memory leak.
* A garbage collection (GC) for the circuit's GC generation has run, but the garbage collector hasn't been able to claim the circuit because another object in the framework is holding a strong reference to the circuit.

In other cases, there's no memory leak. If the circuit is active (connected or disconnected), the circuit is still in use.

If a collection for the circuit's GC generation doesn't run, the memory isn't released because the garbage collector doesn't need to free the memory at that time.

If a collection for a GC generation runs and frees the circuit, you must validate the memory against the GC stats, not the process, as .NET might decide to keep the virtual memory active.

If the memory isn't freed, you must find a circuit that isn't either active or disconnected and that's rooted by another object in the framework. In any other case, the inability to free memory is an app issue in developer code.

### Reduce memory usage

Adopt any of the following strategies to reduce an app's memory usage:

* Limit the total amount of memory used by the .NET process. For more information, see [Runtime configuration options for garbage collection](/dotnet/core/runtime-config/garbage-collector).
* Reduce the number of disconnected circuits.
* Reduce the time a circuit is allowed to be in the disconnected state.
* Trigger a garbage collection manually to perform a collection during downtime periods.
* Configure the garbage collection in Workstation mode, which aggressively triggers garbage collection, instead of Server mode.

### Heap size for some mobile device browsers

When building a Blazor app that runs on the client and targets mobile device browsers, especially Safari on iOS, decreasing the maximum memory for the app with the MSBuild property `EmccMaximumHeapSize` may be required. For more information, see <xref:blazor/host-and-deploy/webassembly#decrease-maximum-heap-size-for-some-mobile-device-browsers>.

###  Additional actions and considerations

* Capture a memory dump of the process when memory demands are high and identify the objects are taking the most memory and where are those objects are rooted (what holds a reference to them).
* You can examine the statistics on how memory in your app is behaving using `dotnet-counters`. For more information see [Investigate performance counters (dotnet-counters)](/dotnet/core/diagnostics/dotnet-counters).
* Even when a GC is triggered, .NET holds on to the memory instead of returning it to the OS immediately, as it's likely that it will reuse the memory the near future. This avoids committing and decommitting memory constantly, which is expensive. You'll see this reflected if you use `dotnet-counters` because you'll see the GCs happen and the amount of used memory go down to 0 (zero), but you won't see the working set counter decrease, which is the sign that .NET is holding on to the memory to reuse it. For more information on project file (`.csproj`) settings to control this behavior, see [Runtime configuration options for garbage collection](/dotnet/core/runtime-config/garbage-collector).
* Server GC doesn't trigger garbage collections until it determines it's absolutely necessary to do so to avoid freezing your app and considers that your app is the only thing running on the machine, so it can use all the memory in the system. If the system has 50 GB, the garbage collector seeks to use the full 50 GB of available memory before it triggers a Gen 2 collection.
* For information on disconnected circuit retention configuration, see <xref:blazor/fundamentals/signalr#server-side-circuit-handler-options>.

### Measuring memory

* Publish the app in Release configuration.
* Run a published version of the app.
* Don't attach a debugger to the running app.
* Does triggering a Gen 2 forced, compacting collection (`GC.Collect(2, GCCollectionMode.Aggressive | GCCollectionMode.Forced, blocking: true, compacting: true))` free the memory?
* Consider if your app is allocating objects on the large object heap.
* Are you testing the memory growth after the app is warmed up with requests and processing? Typically, there are caches that are populated when code executes for the first time that add a constant amount of memory to the footprint of the app.
