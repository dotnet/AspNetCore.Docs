---
title: ASP.NET Core Blazor Progressive Web Application (PWA)
author: guardrex
description: Learn how to build a Blazor Progressive Web Application (PWA) that use modern browser features to behave like a desktop app.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/progressive-web-app
---
# ASP.NET Core Blazor Progressive Web Application (PWA)

[!INCLUDE[](~/includes/not-latest-version.md)]

A Blazor Progressive Web Application (PWA) is a single-page application (SPA) that uses modern browser APIs and capabilities to behave like a desktop app.

Blazor WebAssembly is a standards-based client-side web app platform, so it can use any browser API, including PWA APIs required for the following capabilities:

* Working offline and loading instantly, independent of network speed.
* Running in its own app window, not just a browser window.
* Being launched from the host's operating system start menu, dock, or home screen.
* Receiving push notifications from a backend server, even while the user isn't using the app.
* Automatically updating in the background.

The word *progressive* is used to describe these apps because:

* A user might first discover and use the app within their web browser like any other SPA.
* Later, the user progresses to installing it in their OS and enabling push notifications.

## Create a project from the PWA template

# [Visual Studio](#tab/visual-studio)

When creating a new **Blazor WebAssembly App**, select the **Progressive Web Application** checkbox.

# [Visual Studio Code / .NET Core CLI](#tab/visual-studio-code+netcore-cli)

Use the following command to create a PWA project in a command shell with the `--pwa` switch:

```dotnetcli
dotnet new blazorwasm -o MyBlazorPwa --pwa
```

In the preceding command, the `-o|--output` option creates a new folder for the app named `MyBlazorPwa`.

---

:::moniker range="< aspnetcore-8.0"

Optionally, PWA can be configured for an app created from the **ASP.NET Core Hosted** Blazor WebAssembly project template. The PWA scenario is independent of the hosting model.

:::moniker-end

## Convert an existing Blazor WebAssembly app into a PWA

Convert an existing Blazor WebAssembly app into a PWA following the guidance in this section.

In the app's project file:

* Add the following `ServiceWorkerAssetsManifest` property to a `PropertyGroup`:

  ```xml
    ...
    <ServiceWorkerAssetsManifest>service-worker-assets.js</ServiceWorkerAssetsManifest>
  </PropertyGroup>
   ```

* Add the following `ServiceWorker` item to an `ItemGroup`:

  ```xml
  <ItemGroup>
    <ServiceWorker Include="wwwroot\service-worker.js" 
      PublishedContent="wwwroot\service-worker.published.js" />
  </ItemGroup>
  ```

To obtain static assets, use **one** of the following approaches:

* Create a separate, new PWA project with the [`dotnet new`](/dotnet/core/tools/dotnet-new) command in a command shell:

  ```dotnetcli
  dotnet new blazorwasm -o MyBlazorPwa --pwa
  ```
  
  In the preceding command, the `-o|--output` option creates a new folder for the app named `MyBlazorPwa`.
  
  **If you aren't converting an app for the latest release**, pass the `-f|--framework` option. The following example creates the app for ASP.NET Core version 5.0:
  
  ```dotnetcli
  dotnet new blazorwasm -o MyBlazorPwa --pwa -f net5.0
  ```

:::moniker range=">= aspnetcore-8.0"

* Navigate to the ASP.NET Core GitHub repository at the following URL, which links to `main` branch reference source and assets. Select the release that you're working with from the **Switch branches or tags** dropdown list that applies to your app.

  [Blazor WebAssembly project template `wwwroot` folder (dotnet/aspnetcore GitHub repository `main` branch)](https://github.com/dotnet/aspnetcore/tree/main/src/ProjectTemplates/Web.ProjectTemplates/content/ComponentsWebAssembly-CSharp/wwwroot)

  [!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

  From the source `wwwroot` folder either in the app that you created or from the reference assets in the `dotnet/aspnetcore` GitHub repository, copy the following files into the app's `wwwroot` folder:

  * `icon-192.png`
  * `icon-512.png`
  * `manifest.webmanifest`
  * `service-worker.js`
  * `service-worker.published.js`

In the app's `wwwroot/index.html` file:

* Add `<link>` elements for the manifest and app icon:

  ```html
  <link href="manifest.webmanifest" rel="manifest" />
  <link rel="apple-touch-icon" sizes="512x512" href="icon-512.png" />
  <link rel="apple-touch-icon" sizes="192x192" href="icon-192.png" />
  ```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* Navigate to the ASP.NET Core GitHub repository at the following URL, which links to the `release/7.0` branch reference source and assets. If you're using a version of ASP.NET Core later than 7.0, change the document version selector to see the updated guidance for this section. Select the release that you're working with from the **Switch branches or tags** dropdown list that applies to your app.

  [Blazor WebAssembly project template `wwwroot` folder (dotnet/aspnetcore GitHub repository `release/7.0` branch)](https://github.com/dotnet/aspnetcore/tree/release/7.0/src/ProjectTemplates/Web.ProjectTemplates/content/ComponentsWebAssembly-CSharp/Client/wwwroot)

  [!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

  From the source `wwwroot` folder either in the app that you created or from the reference assets in the `dotnet/aspnetcore` GitHub repository, copy the following files into the app's `wwwroot` folder:

  * `favicon.png`
  * `icon-512.png`
  * `manifest.json`
  * `service-worker.js`
  * `service-worker.published.js`

In the app's `wwwroot/index.html` file:

* Add `<link>` elements for the manifest and app icon:

  ```html
  <link href="manifest.json" rel="manifest" />
  <link rel="apple-touch-icon" sizes="512x512" href="icon-512.png" />
  ```

:::moniker-end

* Add the following `<script>` tag inside the closing `</body>` tag immediately after the `blazor.webassembly.js` script tag:

  ```html
      ...
      <script>navigator.serviceWorker.register('service-worker.js');</script>
  </body>
  ```

## Installation and app manifest

When visiting an app created using the PWA template, users have the option of installing the app into their OS's start menu, dock, or home screen. The way this option is presented depends on the user's browser. When using desktop Chromium-based browsers, such as Edge or Chrome, an **Add** button appears within the URL bar. After the user selects the **Add** button, they receive a confirmation dialog:

![The confirmation dialog in Google Chrome presents an Install button to the user for the 'MyBlazorPwa' app.](~/blazor/progressive-web-app/_static/image2.png)

On iOS, visitors can install the PWA using Safari's **Share** button and its **Add to Homescreen** option. On Chrome for Android, users should select the **Menu** button in the upper-right corner, followed by **Add to Home screen**.

Once installed, the app appears in its own window without an address bar:

![The 'MyBlazorPwa' app runs in Google Chrome without an address bar.](~/blazor/progressive-web-app/_static/image3.png)

To customize the window's title, color scheme, icon, or other details, see the `manifest.json` file in the project's `wwwroot` directory. The schema of this file is defined by web standards. For more information, see [MDN web docs: Web App Manifest](https://developer.mozilla.org/docs/Web/Manifest).

## Offline support

By default, apps created using the PWA template option have support for running offline. A user must first visit the app while they're online. The browser automatically downloads and caches all of the resources required to operate offline.

> [!IMPORTANT]
> Development support would interfere with the usual development cycle of making changes and testing them. Therefore, offline support is only enabled for *published* apps. 

> [!WARNING]
> If you intend to distribute an offline-enabled PWA, there are [several important warnings and caveats](#caveats-for-offline-pwas). These scenarios are inherent to offline PWAs and not specific to Blazor. Be sure to read and understand these caveats before making assumptions about how your offline-enabled app works.

To see how offline support works:

1. Publish the app. For more information, see <xref:blazor/host-and-deploy/index#publish-the-app>.
1. Deploy the app to a server that supports HTTPS, and access the app in a browser at its secure HTTPS address.
1. Open the browser's dev tools and verify that a *Service Worker* is registered for the host on the **Application** tab:

   ![Google Chrome developer tools 'Application' tab shows a Service Worker activated and running.](~/blazor/progressive-web-app/_static/image4.png)

1. Reload the page and examine the **Network** tab. **Service Worker** or **memory cache** are listed as the sources for all of the page's assets:

   ![Google Chrome developer tools 'Network' tab showing sources for all of the page's assets.](~/blazor/progressive-web-app/_static/image5.png)

1. To verify that the browser isn't dependent on network access to load the app, either:

   * Shut down the web server and see how the app continues to function normally, which includes page reloads. Likewise, the app continues to function normally when there's a slow network connection.
   * Instruct the browser to simulate offline mode in the **Network** tab:

   ![Google Chrome developer tools 'Network' tab with the browser mode dropdown list changed from 'Online' to 'Offline'.](~/blazor/progressive-web-app/_static/image6.png)

Offline support using a service worker is a web standard, not specific to Blazor. For more information on service workers, see [MDN web docs: Service Worker API](https://developer.mozilla.org/docs/Web/API/Service_Worker_API). To learn more about common usage patterns for service workers, see [Google Web: The Service Worker Lifecycle](https://web.dev/service-worker-lifecycle/).

Blazor's PWA template produces two service worker files:

* `wwwroot/service-worker.js`, which is used during development.
* `wwwroot/service-worker.published.js`, which is used after the app is published.

To share logic between the two service worker files, consider the following approach:

* Add a third JavaScript file to hold the common logic.
* Use [`self.importScripts`](https://developer.mozilla.org/docs/Web/API/WorkerGlobalScope/importScripts) to load the common logic into both service worker files.

### Cache-first fetch strategy

The built-in `service-worker.published.js` service worker resolves requests using a *cache-first* strategy. This means that the service worker prefers to return cached content, regardless of whether the user has network access or newer content is available on the server.

The cache-first strategy is valuable because:

* **It ensures reliability.** Network access isn't a boolean state. A user isn't simply online or offline:

  * The user's device may assume it's online, but the network might be so slow as to be impractical to wait for.
  * The network might return invalid results for certain URLs, such as when there's a captive WIFI portal that's currently blocking or redirecting certain requests.
  
  This is why the browser's `navigator.onLine` API isn't reliable and shouldn't be depended upon.

* **It ensures correctness.** When building a cache of offline resources, the service worker uses content hashing to guarantee it has fetched a complete and self-consistent snapshot of resources at a single instant in time. This cache is then used as an atomic unit. There's no point asking the network for newer resources, since the only versions required are the ones already cached. Anything else risks inconsistency and incompatibility (for example, trying to use versions of .NET assemblies that weren't compiled together).

If you must prevent the browser from fetching `service-worker-assets.js` from its HTTP cache, for example to resolve temporary integrity check failures when deploying a new version of the service worker, update the service worker registration in `wwwroot/index.html` with [`updateViaCache`](https://developer.mozilla.org/docs/Web/API/ServiceWorkerRegistration/updateViaCache) set to 'none':

```html
<script>
  navigator.serviceWorker.register('/service-worker.js', {updateViaCache: 'none'});
</script>
```

### Background updates

As a mental model, you can think of an offline-first PWA as behaving like a mobile app that can be installed. The app starts up immediately regardless of network connectivity, but the installed app logic comes from a point-in-time snapshot that might not be the latest version.

The Blazor PWA template produces apps that automatically try to update themselves in the background whenever the user visits and has a working network connection. The way this works is as follows:

* During compilation, the project generates a *service worker assets manifest*. By default, this is called `service-worker-assets.js`. The manifest lists all the static resources that the app requires to function offline, such as .NET assemblies, JavaScript files, and CSS, including their content hashes. The resource list is loaded by the service worker so that it knows which resources to cache.
* Each time the user visits the app, the browser re-requests `service-worker.js` and `service-worker-assets.js` in the background. The files are compared byte-for-byte with the existing installed service worker. If the server returns changed content for either of these files, the service worker attempts to install a new version of itself.
* When installing a new version of itself, the service worker creates a new, separate cache for offline resources and starts populating the cache with resources listed in `service-worker-assets.js`. This logic is implemented in the `onInstall` function inside `service-worker.published.js`.
* The process completes successfully when all of the resources are loaded without error and all content hashes match. If successful, the new service worker enters a *waiting for activation* state. As soon as the user closes the app (no remaining app tabs or windows), the new service worker becomes *active* and is used for subsequent app visits. The old service worker and its cache are deleted.
* If the process doesn't complete successfully, the new service worker instance is discarded. The update process is attempted again on the user's next visit, when hopefully the client has a better network connection that can complete the requests.

Customize this process by editing the service worker logic. None of the preceding behavior is specific to Blazor but is merely the default experience provided by the PWA template option. For more information, see [MDN web docs: Service Worker API](https://developer.mozilla.org/docs/Web/API/Service_Worker_API).

### How requests are resolved

As described in the [Cache-first fetch strategy](#cache-first-fetch-strategy) section, the default service worker uses a *cache-first* strategy, meaning that it tries to serve cached content when available. If there is no content cached for a certain URL, for example when requesting data from a backend API, the service worker falls back on a regular network request. The network request succeeds if the server is reachable. This logic is implemented inside `onFetch` function within `service-worker.published.js`.

If the app's Razor components rely on requesting data from backend APIs and you want to provide a friendly user experience for failed requests due to network unavailability, implement logic within the app's components. For example, use [`try/catch`](/dotnet/csharp/language-reference/keywords/try-catch) around <xref:System.Net.Http.HttpClient> requests.

### Support server-rendered pages

Consider what happens when the user first navigates to a URL such as `/counter` or any other deep link in the app. In these cases, you don't want to return content cached as `/counter`, but instead need the browser to load the content cached as `/index.html` to start up your Blazor WebAssembly app. These initial requests are known as *navigation* requests, as opposed to:

* `subresource` requests for images, stylesheets, or other files.
* `fetch/XHR` requests for API data.

The default service worker contains special-case logic for navigation requests. The service worker resolves the requests by returning the cached content for `/index.html`, regardless of the requested URL. This logic is implemented in the `onFetch` function inside `service-worker.published.js`.

If your app has certain URLs that must return server-rendered HTML, and not serve `/index.html` from the cache, then you need to edit the logic in your service worker. If all URLs containing `/Identity/` need to be handled as regular online-only requests to the server, then modify `service-worker.published.js` `onFetch` logic. Locate the following code:

```javascript
const shouldServeIndexHtml = event.request.mode === 'navigate';
```

Change the code to the following:

```javascript
const shouldServeIndexHtml = event.request.mode === 'navigate'
  && !event.request.url.includes('/Identity/');
```

If you don't do this, then regardless of network connectivity, the service worker intercepts requests for such URLs and resolves them using `/index.html`.

Add additional endpoints for external authentication providers to the check. In the following example, `/signin-google` for Google authentication is added to the check:

```javascript
const shouldServeIndexHtml = event.request.mode === 'navigate'
  && !event.request.url.includes('/Identity/')
  && !event.request.url.includes('/signin-google');
```

No action is required for the `Development` environment, where content is always fetched from the network.

### Control asset caching

If your project defines the `ServiceWorkerAssetsManifest` MSBuild property, Blazor's build tooling generates a service worker assets manifest with the specified name. The default PWA template produces a project file containing the following property:

```xml
<ServiceWorkerAssetsManifest>service-worker-assets.js</ServiceWorkerAssetsManifest>
```

The file is placed in the `wwwroot` output directory, so the browser can retrieve this file by requesting `/service-worker-assets.js`. To see the contents of this file, open `/bin/Debug/{TARGET FRAMEWORK}/wwwroot/service-worker-assets.js` in a text editor. However, don't edit the file, as it's regenerated on each build.

By default, this manifest lists:

* Any Blazor-managed resources, such as .NET assemblies and the .NET WebAssembly runtime files required to function offline.
* All resources for publishing to the app's `wwwroot` directory, such as images, stylesheets, and JavaScript files, including static web assets supplied by external projects and NuGet packages.

You can control which of these resources are fetched and cached by the service worker by editing the logic in `onInstall` in `service-worker.published.js`. By default, the service worker fetches and caches files matching typical web file name extensions such as `.html`, `.css`, `.js`, and `.wasm`, plus file types specific to Blazor WebAssembly, such as `.pdb` files (all versions) and `.dll` files (ASP.NET Core 7.0 or earlier).

To include additional resources that aren't present in the app's `wwwroot` directory, define extra MSBuild `ItemGroup` entries, as shown in the following example:

```xml
<ItemGroup>
  <ServiceWorkerAssetsManifestItem Include="MyDirectory\AnotherFile.json"
    RelativePath="MyDirectory\AnotherFile.json" AssetUrl="files/AnotherFile.json" />
</ItemGroup>
```

The `AssetUrl` metadata specifies the base-relative URL that the browser should use when fetching the resource to cache. This can be independent of its original source file name on disk.

> [!IMPORTANT]
> Adding a `ServiceWorkerAssetsManifestItem` doesn't cause the file to be published in the app's `wwwroot` directory. The publish output must be controlled separately. The `ServiceWorkerAssetsManifestItem` only causes an additional entry to appear in the service worker assets manifest.

## Push notifications

Like any other PWA, a Blazor WebAssembly PWA can receive push notifications from a backend server. The server can send push notifications at any time, even when the user isn't actively using the app. For example, push notifications can be sent when a different user performs a relevant action.

The mechanism for sending a push notification is entirely independent of Blazor WebAssembly, since it's implemented by the backend server which can use any technology. If you want to send push notifications from an ASP.NET Core server, consider [using a technique similar to the approach taken in the Blazing Pizza workshop](https://github.com/dotnet-presentations/blazor-workshop/blob/master/docs/09-progressive-web-app.md#sending-push-notifications).

The mechanism for receiving and displaying a push notification on the client is also independent of Blazor WebAssembly, since it's implemented in the service worker JavaScript file. For an example, see [the approach used in the Blazing Pizza workshop](https://github.com/dotnet-presentations/blazor-workshop/blob/master/docs/09-progressive-web-app.md#displaying-notifications).

## Caveats for offline PWAs

Not all apps should attempt to support offline use. Offline support adds significant complexity, while not always being relevant for the use cases required.

Offline support is usually relevant only:

* If the primary data store is local to the browser. For example, the approach is relevant in an app with a UI for an [IoT](https://en.wikipedia.org/wiki/Internet_of_things) device that stores data in `localStorage` or [IndexedDB](https://developer.mozilla.org/docs/Web/API/IndexedDB_API).
* If the app performs a significant amount of work to fetch and cache the backend API data relevant to each user so that they can navigate through the data offline. If the app must support editing, a system for tracking changes and synchronizing data with the backend must be built.
* If the goal is to guarantee that the app loads immediately regardless of network conditions. Implement a suitable user experience around backend API requests to show the progress of requests and behave gracefully when requests fail due to network unavailability.

Additionally, offline-capable PWAs must deal with a range of additional complications. Developers should carefully familiarize themselves with the caveats in the following sections.

### Offline support only when published

During development you typically want to see each change reflected immediately in the browser without going through a background update process. Therefore, Blazor's PWA template enables offline support only when published.

When building an offline-capable app, it's not enough to test the app in the `Development` environment. You must test the app in its published state to understand how it responds to different network conditions.

### Update completion after user navigation away from app

Updates don't complete until the user has navigated away from the app in all tabs. As explained in the [Background updates](#background-updates) section, after you deploy an update to the app, the browser fetches the updated service worker files to begin the update process.

What surprises many developers is that, even when this update completes, it doesn't take effect until the user has navigated away in all tabs. It isn't sufficient to refresh the tab displaying the app, even if it's the only tab displaying the app. Until your app is completely closed, the new service worker remains in the *waiting to activate* status. This isn't specific to Blazor, but rather is a standard web platform behavior.

This commonly troubles developers who are trying to test updates to their service worker or offline cached resources. If you check in the browser's developer tools, you may see something like the following:

![Google Chrome 'Application' tab shows that the Service Worker of the app is 'waiting to activate'.](~/blazor/progressive-web-app/_static/image7.png)

For as long as the list of "clients," which are tabs or windows displaying your app, is nonempty, the worker continues waiting. The reason service workers do this is to guarantee consistency. Consistency means that all resources are fetched from the same atomic cache.

When testing changes, you may find it convenient to select the "skipWaiting" link as shown in the preceding screenshot, then reload the page. You can automate this for all users by coding your service worker to [skip the "waiting" phase and immediately activate on update](https://web.dev/service-worker-lifecycle/#skip-waiting). If you skip the waiting phase, you're giving up the guarantee that resources are always fetched consistently from the same cache instance.

### Users may run any historical version of the app

Web developers habitually expect that users only run the latest deployed version of their web app, since that's normal within the traditional web distribution model. However, an offline-first PWA is more akin to a native mobile app, where users aren't necessarily running the latest version.

As explained in the [Background updates](#background-updates) section, after you deploy an update to your app, each existing user continues to use a previous version for at least one further visit because the update occurs in the background and isn't activated until the user thereafter navigates away. Plus, the previous version being used isn't necessarily the previous one you deployed. The previous version can be *any* historical version, depending on when the user last completed an update.

This can be an issue if the frontend and backend parts of your app require agreement about the schema for API requests. You must not deploy backward-incompatible API schema changes until you can be sure that all users have upgraded. Alternatively, block users from using incompatible older versions of the app. This scenario requirement is the same as for native mobile apps. If you deploy a breaking change in server APIs, the client app is broken for users who haven't yet updated.

If possible, don't deploy breaking changes to your backend APIs. If you must do so, consider using [standard Service Worker APIs such as ServiceWorkerRegistration](https://developer.mozilla.org/docs/Web/API/ServiceWorkerRegistration) to determine whether the app is up-to-date, and if not, to prevent usage.

### Interference with server-rendered pages

As described in the [Support server-rendered pages](#support-server-rendered-pages) section, if you want to bypass the service worker's behavior of returning `/index.html` contents for all navigation requests, edit the logic in your service worker.

### All service worker asset manifest contents are cached by default

As described in the [Control asset caching](#control-asset-caching) section, the file `service-worker-assets.js` is generated during build and lists all assets the service worker should fetch and cache.

Since this list by default includes everything emitted to `wwwroot`, including content supplied by external packages and projects, you must be careful not to put too much content there. If the `wwwroot` directory contains millions of images, the service worker tries to fetch and cache them all, consuming excessive bandwidth and most likely not completing successfully.

Implement arbitrary logic to control which subset of the manifest's contents should be fetched and cached by editing the `onInstall` function in `service-worker.published.js`.

### Interaction with authentication

The PWA template can be used in conjunction with authentication. An offline-capable PWA can also support authentication when the user has initial network connectivity.

When a user doesn't have network connectivity, they can't authenticate or obtain access tokens. By default, attempting to visit the login page without network access results in a "network error" message. You must design a UI flow that allows the user perform useful tasks while offline without attempting to authenticate the user or obtain access tokens. Alternatively, you can design the app to gracefully fail when the network isn't available. If the app can't be designed to handle these scenarios, you might not want to enable offline support.

When an app that's designed for online and offline use is online again:

* The app might need to provision a new access token.
* The app must detect if a different user is signed into the service so that it can apply operations to the user's account that were made while they were offline.

To create an offline PWA app that interacts with authentication:

* Replace the <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication.AccountClaimsPrincipalFactory%601> with a factory that stores the last signed-in user and uses the stored user when the app is offline.
* Queue operations while the app is offline and apply them when the app returns online.
* During sign out, clear the stored user.

The [`CarChecker`](https://github.com/SteveSandersonMS/CarChecker) sample app demonstrates the preceding approaches. See the following parts of the app:

* `OfflineAccountClaimsPrincipalFactory` (`Client/Data/OfflineAccountClaimsPrincipalFactory.cs`)
* `LocalVehiclesStore` (`Client/Data/LocalVehiclesStore.cs`)
* `LoginStatus` component (`Client/Shared/LoginStatus.razor`)

## Additional resources

* [Troubleshoot integrity PowerShell script](xref:blazor/host-and-deploy/webassembly#troubleshoot-integrity-powershell-script)
* [Client-side SignalR cross-origin negotiation for authentication](xref:blazor/fundamentals/signalr#client-side-signalr-cross-origin-negotiation-for-authentication)
