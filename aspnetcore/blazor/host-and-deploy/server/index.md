---
title: Host and deploy ASP.NET Core server-side Blazor apps
author: guardrex
description: Learn how to host and deploy server-side Blazor apps (Blazor Web Apps and Blazor Server apps) using ASP.NET Core.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc, linux-related-content
ms.date: 11/11/2025
uid: blazor/host-and-deploy/server/index
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

* <xref:blazor/security/static-server-side-rendering>
* <xref:blazor/security/interactive-server-side-rendering>

Each circuit uses approximately 250 KB of memory for a minimal *Hello World*-style app. The size of a circuit depends on the app's code and the state maintenance requirements associated with each component. We recommend that you measure resource demands during development for your app and infrastructure, but the following baseline can be a starting point in planning your deployment target: If you expect your app to support 5,000 concurrent users, consider budgeting at least 1.3 GB of server memory to the app (or ~273 KB per user).

:::moniker range=">= aspnetcore-10.0"

## Blazor WebAssembly static asset preloading

The `ResourcePreloader` component in the `App` component's head content (`App.razor`) is used to reference Blazor static assets. The component is placed after the base URL tag (`<base>`):

```razor
<ResourcePreloader />
```

A Razor component is used instead of `<link>` elements because:

* The component permits the base URL (`<base>` tag's `href` attribute value) to correctly identify the root of the Blazor app within an ASP.NET Core app.
* The feature can be removed by removing the `ResourcePreloader` component tag from the `App` component. This is helpful in cases where the app is using a [`loadBootResource` callback](xref:blazor/fundamentals/startup#load-client-side-boot-resources) to modify URLs.

:::moniker-end

## SignalR configuration

[SignalR's hosting and scaling conditions](xref:signalr/publish-to-azure-web-app) apply to Blazor apps that use SignalR.

For more information on SignalR in Blazor apps, including configuration guidance, see <xref:blazor/fundamentals/signalr>.

:::moniker range=">= aspnetcore-6.0"

### Transports

Blazor works best when using [WebSockets](xref:fundamentals/websockets) as the SignalR transport due to lower latency, better reliability, and improved [security](xref:signalr/security). [Long Polling](https://github.com/dotnet/aspnetcore/blob/main/src/SignalR/docs/specs/TransportProtocols.md#long-polling-server-to-client-only) is used by SignalR when WebSockets isn't available or when the app is explicitly configured to use Long Polling.

A console warning appears if Long Polling is utilized:

> :::no-loc text="Failed to connect via WebSockets, using the Long Polling fallback transport. This may be due to a VPN or proxy blocking the connection.":::

### Global deployment and connection failures

Recommendations for global deployments to geographical data centers:

* Deploy the app to the regions where most of the users reside.
* Take into consideration the increased latency for traffic across continents. To control the appearance of the reconnection UI, see <xref:blazor/fundamentals/signalr#control-when-the-reconnection-ui-appears>.
* Consider using the [Azure SignalR Service](#azure-signalr-service).

:::moniker-end

## Azure App Service

Hosting on Azure App Service requires configuration for WebSockets and session affinity, also called Application Request Routing (ARR) affinity.

> [!NOTE]
> A Blazor app on Azure App Service doesn't require [Azure SignalR Service](#azure-signalr-service).

Enable the following for the app's registration in Azure App Service:

* [WebSockets](xref:fundamentals/websockets) to allow the WebSockets transport to function. The default setting is **Off**.
* Session affinity to route requests from a user back to the same App Service instance. The default setting is **On**.

1. In the Azure portal, navigate to the web app in **App Services**.
1. Open **Settings** > **Configuration**.
1. Set **Web sockets** to **On**.
1. Verify that **Session affinity** is set to **On**.

## Azure SignalR Service

The optional [Azure SignalR Service](xref:signalr/scale#azure-signalr-service) works in conjunction with the app's SignalR hub for scaling up a server-side app to a large number of concurrent connections. In addition, the service's global reach and high-performance data centers significantly aid in reducing latency due to geography.

The service isn't required for Blazor apps hosted in Azure App Service or Azure Container Apps but can be helpful in other hosting environments:

* To facilitate connection scale out.
* Handle global distribution.

:::moniker range=">= aspnetcore-8.0"

The Azure SignalR Service with SDK [v1.26.1](https://github.com/Azure/azure-signalr/releases/tag/v1.26.1) or later supports [SignalR stateful reconnect](xref:signalr/configuration#configure-stateful-reconnect) (<xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilderHttpExtensions.WithStatefulReconnect%2A>).

:::moniker-end

In the event that the app uses Long Polling or falls back to Long Polling instead of [WebSockets](xref:fundamentals/websockets), you may need to configure the maximum poll interval (`MaxPollIntervalInSeconds`, default: 5 seconds, limit: 1-300 seconds), which defines the maximum poll interval allowed for Long Polling connections in the Azure SignalR Service. If the next poll request doesn't arrive within the maximum poll interval, the service closes the client connection.

For guidance on how to add the service as a dependency to a production deployment, see <xref:signalr/publish-to-azure-web-app>.

For more information, see:

* [Azure SignalR Service](https://azure.microsoft.com/products/signalr-service/)
* [What is Azure SignalR Service?](/azure/azure-signalr/signalr-overview)
* <xref:signalr/scale#azure-signalr-service>
* <xref:signalr/publish-to-azure-web-app>

:::moniker range=">= aspnetcore-6.0"

## Azure Container Apps

For a deeper exploration of scaling server-side Blazor apps on the Azure Container Apps service, see <xref:host-and-deploy/scaling-aspnet-apps/scaling-aspnet-apps>. The tutorial explains how to create and integrate the services required to host apps on Azure Container Apps. Basic steps are also provided in this section.

1. Configure Azure Container Apps service for session affinity by following the guidance in [Session Affinity in Azure Container Apps (Azure documentation)](/azure/container-apps/sticky-sessions).

1. The ASP.NET Core Data Protection (DP) service must be configured to persist keys in a centralized location that all container instances can access. The keys can be stored in Azure Blob Storage and protected with Azure Key Vault. The DP service uses the keys to deserialize Razor components. To configure the DP service to use Azure Blob Storage and Azure Key Vault, reference the following NuGet packages:

   * [`Azure.Identity`](https://www.nuget.org/packages/Azure.Identity): Provides classes to work with the Azure identity and access management services.
   * [`Microsoft.Extensions.Azure`](https://www.nuget.org/packages/Microsoft.Extensions.Azure): Provides helpful extension methods to perform core Azure configurations.
   * [`Azure.Extensions.AspNetCore.DataProtection.Blobs`](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Blobs): Allows storing ASP.NET Core Data Protection keys in Azure Blob Storage so that keys can be shared across several instances of a web app.
   * [`Azure.Extensions.AspNetCore.DataProtection.Keys`](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.DataProtection.Keys): Enables protecting keys at rest using the Azure Key Vault Key Encryption/Wrapping feature.

   [!INCLUDE[](~/includes/package-reference.md)]

1. Update `Program.cs` with the following highlighted code:

   :::code language="csharp" source="~/../AspNetCore.Docs.Samples/tutorials/scalable-razor-apps/end/Program.cs" id="snippet_ProgramConfigurations" highlight="1-4,6-7,13-19":::    

   The preceding changes allow the app to manage the DP service using a centralized, scalable architecture. <xref:Azure.Identity.DefaultAzureCredential> discovers the container app managed identity after the code is deployed to Azure and uses it to connect to blob storage and the app's key vault.

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

> [!NOTE]
> The preceding example uses <xref:Azure.Identity.DefaultAzureCredential> to simplify authentication while developing apps that deploy to Azure by combining credentials used in Azure hosting environments with credentials used in local development. When moving to production, an alternative is a better choice, such as <xref:Azure.Identity.ManagedIdentityCredential>. For more information, see [Authenticate Azure-hosted .NET apps to Azure resources using a system-assigned managed identity](/dotnet/azure/sdk/authentication/system-assigned-managed-identity).

## IIS

When using IIS, enable:

* [WebSockets on IIS](xref:fundamentals/websockets#enabling-websockets-on-iis).
* [Session affinity with Application Request Routing](/iis/extensions/configuring-application-request-routing-arr/http-load-balancing-using-application-request-routing).

For more information, see the guidance and external IIS resource cross-links in <xref:tutorials/publish-to-iis>.

## Kubernetes

Create an ingress definition with the following [Kubernetes annotations for session affinity](https://kubernetes.github.io/ingress-nginx/examples/affinity/cookie/):

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

:::moniker range=">= aspnetcore-9.0"

:::code language="razor" source="~/../blazor-samples/9.0/BlazorSample_BlazorWebApp/Components/MeasureLatency.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-9.0"

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
