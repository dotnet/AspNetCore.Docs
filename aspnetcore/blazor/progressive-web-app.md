---
title: Build Progressive Web Applications with ASP.NET Core Blazor WebAssembly
author: guardrex
description: Learn how to build Blazor-based Progressive Web Applications (PWAs), web apps that use modern browser features to behave like desktop apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/09/2020
no-loc: [Blazor, SignalR]
uid: blazor/progressive-web-app
---
# Build Progressive Web Applications with ASP.NET Core Blazor WebAssembly

By [Steve Sanderson](https://github.com/SteveSandersonMS)

[!INCLUDE[](~/includes/blazorwasm-preview-notice.md)]

[!INCLUDE[](~/includes/blazorwasm-3.2-template-article-notice.md)]

A Progressive Web Application (PWA) is a web-based application that uses modern browser APIs and capabilities to behave like a desktop application. These capabilities can include:

* Working offline and always loading instantly, independently of network speed
* Being able to run in its own application window, not just a browser window
* Being launched from the host operating system (OS) start menu, dock, or home screen
* Receiving push notifications from a backend server, even while the user is not using the application
* Automatically updating in the background

A user might first discover and use the application within their web browser like any other single-page application (SPA), then later progress to installing it in their OS and enabling push notifications. That's why we use the term *progressive*.

Blazor WebAssembly is a true standards-based client-side web application platform, so it can use any browser API, including PWA APIs needed for the capabilities listed above. It can work offline just like any other client-side web technology.

## PWA template

When creating a new Blazor WebAssembly application, you are offered the option to add PWA features. In Visual Studio, the option is given as a checkbox in the project creation dialog:

![image](https://user-images.githubusercontent.com/1101362/76207411-a6b54200-61f5-11ea-9dfc-6acd87a91428.png)

If you're creating the project on the command line, you can use the `--pwa` flag. For example,

```dotnetcli
dotnet new blazorwasm --pwa -o MyNewProject
```

In both cases, you're free to combine this with the "ASP.NET Core hosted" option if you wish, but don't have to do so. PWA features are independent of the hosting model.

## Installation and app manifest

When visiting an application created using the PWA template option, users have the option to install the application into their OS's start menu, dock, or home screen.

The way this option is presented depends on the user's browser. For example, when using desktop Chromium-based browsers such as Edge or Chrome, an *Add* button appears within the URL bar:

![image](https://user-images.githubusercontent.com/1101362/76208127-f7796a80-61f6-11ea-8aea-7fba704be787.png)

On iOS, visitors can install the PWA using Safari's *Share* button and its *Add to Homescreen* option. On Chrome for Android, users should tap the *Menu* button in the upper-right corner, then choose *Add to Home screen*.

Once installed, the application appears in its own window, without any address bar.

![image](https://user-images.githubusercontent.com/1101362/76208588-e2e9a200-61f7-11ea-85e1-8c3fc849b252.png)

To customize the window's title, color scheme, icon, or other details, see the file `manifest.json` in your project's *wwwroot* directory. The schema of this file is defined by web standards. For detailed documentation, see https://developer.mozilla.org/docs/Web/Manifest.

## Offline support

By default, applications created using the PWA template option have support for running offline. A user must first visit the application while they are online, then the browser will automatically download and cache all the resources needed to operate offline.

> [!IMPORTANT]
> Offline support is only enabled for *published* applications. It is not enabled during development. This is because it would interfere with the usual development cycle of making changes and testing them.

> [!WARNING]
> If you intend to ship an offline-enabled PWA, there are [several important warnings and caveats](#caveats-for-offline-pwas) you need to understand. These are inherent to offline PWAs, and not specific to Blazor. Be sure to read and understand these caveats before making assumptions about how your offline-enabled application will work.

To see how offline support works, first [publish your application](https://docs.microsoft.com/aspnet/core/host-and-deploy/blazor/?view=aspnetcore-3.1&tabs=visual-studio#publish-the-app), and host it on a server supporting HTTPS. When you visit the application, you should be able to open the browser's dev tools and verify that a *Service Worker* is registered for your host:

![image](https://user-images.githubusercontent.com/1101362/76210294-bd5e9780-61fb-11ea-9869-65c55c62803d.png)

Additionally, if you reload the page, then on the *Network* tab you should see that all resources needed to load your page are being retrieved from the *Service Worker* or *Memory Cache*:

![image](https://user-images.githubusercontent.com/1101362/76210472-1d553e00-61fc-11ea-84c6-291644df709e.png)

This shows that the browser is not dependent on network access to load your application. To verify this, you can either shut down your web server, or instruct the browser to simulate offline mode:

![image](https://user-images.githubusercontent.com/1101362/76210556-47a6fb80-61fc-11ea-9d12-20a8f6528744.png)

Now, even without access to your web server, you should be able to reload the page and see that your application still loads and runs. Likewise, even if you simulate a very slow network connection, your page will still load immediately since it is loaded independently of the network.

### Service worker

Offline support is achieved using a service worker. This is a web standard, not specific to Blazor. For documentation about service workers, see https://developer.mozilla.org/docs/Web/API/Service_Worker_API. To learn more about common usage patterns for service workers, see the excellent article [The Service Worker Lifecycle](https://developers.google.com/web/fundamentals/primers/service-workers/lifecycle).

Blazor's PWA template produces two service worker files:

* *wwwroot/service-worker.js*, which is used during development
* *wwwroot/service-worker.published.js*, which is used once your application is published

If you want to share logic between these two files, consider adding a third JavaScript file to hold the common logic, and use [`self.importScripts`](https://developer.mozilla.org/docs/Web/API/WorkerGlobalScope/importScripts) to load that logic into both files.

#### Cache-first fetch strategy

The built-in *service-worker.published.js* service worker resolves requests using a *cache-first* strategy. This means it always prefers to return cached content if available, regardless of whether the user has network access or whether newer content is available on the server.

There are two reasons why this is valuable:

* **It ensures reliability.** Network access is not a boolean state. A user is not simply "online" or "offline". In reality, the user's device may believe it is online, but the network may be so slow as to be impractical to wait for. Or the network might be returning invalid results for certain URLs, such as when there is a captive WIFI portal that is currently blocking or redirecting certain requests. This is why the browser's `navigator.onLine` API is not reliable and should not be depended upon.
* **It ensures correctness.** When building a cache of offline resources, the service worker uses content hashing to guarantee it has fetched a complete and self-consistent snapshot of resources at a single instant in time. This cache is then used as an atomic unit. Given this, there is no point asking the network for newer resources, since the only versions you want are the ones you've already cached. Anything else risks inconsistency and incompatibility (for example, trying to use versions of .NET assemblies that were not compiled together).

#### Background updates

As a mental model, you can think of an offline-first PWA as behaving like an mobile app that can be installed. It always starts up immediately regardless of network connectivity, but the installed application logic comes from a point-in-time snapshot that might not be the latest version.

The Blazor PWA template produces applications that automatically try to update themselves in the background whenever the user visits and has a working network connection. The way this works is as follows:

* During compilation, your project generates a *service worker assets manifest*. By default this is called *service-worker-assets.js*. This lists all the static resources your application needs to function offline, such as .NET assemblies, JavaScript files, CSS, etc., including their content hashes. This list is loaded by your service worker so that it knows which resources to cache.
* Each time the user visits your application, the browser re-requests *service-worker.js* and *service-worker-assets.js* in the background. If the server returns changed content for either of these files (compared byte-for-byte with the existing installed service worker), the service worker tries to install a new version of itself.
* When installing a new version of itself, the service worker creates a new, separate cache for offline resources, and starts populating it with resources listed in *service-worker-assets.js*. This logic is implemented in the `onInstall` function inside *service-worker.published.js*.
* If the process completes successfully (i.e., all the resources are loaded without error, and all content hashes match), then the new service worker enters a "waiting for activation" state. As soon as the user closes your application (i.e., there are no remaining tabs or windows displaying your application), the new service worker becomes "active" and will be used for subsequent visits to your application. The old service worker and its cache are deleted.
* If the process does not complete successfully, the new service worker instance is discarded. The update process will be attempted again on the user's next visit, when hopefully they have a better network connection that can complete the requests.

You can customize any aspect of this process by editing the service worker logic. None of the above is specific to Blazor, but is merely a suggestion provided by the PWA template option. See [service worker documentation](https://developer.mozilla.org/docs/Web/API/Service_Worker_API.) for more information.

#### How requests are resolved

As described above, the default service worker uses a *cache-first* strategy, meaning that it tries to serve cached content when available. If there is no content cached for a certain URL, for example when requesting data from a backend API, the service worker falls back on a regular network request which can only succeed if the server is reachable. This logic is implemented inside `onFetch` within *service-worker.published.js*.

If your Blazor components rely on requesting data from backend APIs, and you want to provide a friendly user experience in the case where such requests fail due to network unavailability, then you need to implement logic within your components. For example, use `try/catch` around `HttpClient` requests.

#### Support server-rendered pages

Consider what happens when the user first navigates to a URL such as `/counter` or any other deep link into your application. In these cases, you don't want to return content cached as `/counter`, but instead need the browser to load the content cached as `/index.html` to start up your Blazor WebAssembly application. These initial requests are known as *navigation* requests (as opposed to *subresource* requests for images/CSS/etc, or *fetch/XHR* requests for API data).

The default service worker contains special-case logic for navigation requests. It resolves them by returning the cached content for `/index.html`, regardless of the requested URL. This logic is implemented in the `onFetch` function inside *service-worker.published.js*.

If your application has certain URLs that must return server-rendered HTML (and not serve `/index.html` from the cache), then you need to edit the logic in your service worker. For example, if all URLs containing `/Identity/` need to be handled as regular online-only requests to the server, then modify *service-worker.published.js* `onFetch` logic. Locate the following code:

```javascript
const shouldServeIndexHtml = event.request.mode === 'navigate';
```

Change the code to the following:

```javascript
const shouldServeIndexHtml = event.request.mode === 'navigate'
    && !event.request.url.includes('/Identity/');
```

If you don't do this, then regardless of network connectivity, the service worker will intercept requests for such URLs and will resolve them using `/index.html`.

#### Control asset caching

If your project defines an MSBuild property called `ServiceWorkerAssetsManifest`, then Blazor's build tooling will generate a service worker assets manifest with the specified name. The default PWA template produces a project file containing the following:

```xml
<ServiceWorkerAssetsManifest>service-worker-assets.js</ServiceWorkerAssetsManifest>
```

The file is placed in the *wwwroot* output directory, so the browser can retrieve this file by requesting `/service-worker-assets.js`. To see the contents, open *YourProject\bin\Debug\netstandard2.1\wwwroot\service-worker-assets.js* in a text editor. However, don't edit the file, as it will be regenerated on each build.

By default, this manifest lists:

* Any Blazor-managed resources such as .NET assemblies and the .NET WebAssembly runtime files needed to function offline
* All resources that will be published in your *wwwroot* directory, such as images, CSS files, and JavaScript files. This includes static web assets supplied by external projects and NuGet packages.

You can control which of these resources will be fetched and cached by the service worker by editing the logic in `onInstall` in *service-worker.published.js*. By default, it will fetch and cache files matching typical web filename extensions such as *.html*, *.css*, *.js*, *.wasm*, and others, plus file types specific to Blazor WebAssembly (*.dll*, *.pdb*).

If you want to include additional resources that aren't present in your *wwwroot* directory, you can do so by defining extra MSBuild itemgroup entries. For example, in your project file, add:

```xml
<ItemGroup>
    <ServiceWorkerAssetsManifestItem
        Include="MyDirectory\AnotherFile.json"
        RelativePath="MyDirectory\AnotherFile.json"
        AssetUrl="files/AnotherFile.json" />
</ItemGroup>
```

The `AssetUrl` metadata specifies the base-relative URL that the browser should use when fetching the resource to cache. This can be independent of its original source file name on disk.

> [!IMPORTANT]
> Adding a `ServiceWorkerAssetsManifestItem` does not cause the file to be published in your *wwwroot* directory. It up to you to control your publish output separately. The `ServiceWorkerAssetsManifestItem` only causes an additional entry to appear in the service worker assets manifest.

## Push notifications

Like any other PWA, a Blazor WebAssembly PWA can receive push notifications from a backend server. Your server can send these at any time, even when the user is not actively using your application (for example, when a different user performs an action that may be relevant).

The mechanism for sending a push notification is entirely independent of Blazor WebAssembly, since it's implemented by the backend server which can use any technology. If you want to send push notifications from an ASP.NET Core server, consider [using a technique similar to that in the Blazing Pizza workshop](https://github.com/dotnet-presentations/blazor-workshop/blob/master/docs/09-progressive-web-app.md#sending-push-notifications).

The mechanism for receiving and displaying a push notification on the client is also independent of Blazor WebAssembly, since it's implemented in the service worker, which is a JavaScript file. As an example, you can again see [the approach used in the Blazing Pizza workshop](https://github.com/dotnet-presentations/blazor-workshop/blob/master/docs/09-progressive-web-app.md#displaying-notifications).

## Caveats for offline PWAs

Not all applications should attempt to support offline use. It adds significant complexity, while not always being relevant.

Offline support is usually relevant only:

* If your primary data store is local to the browser. For example, when building a UI for an [IoT](https://en.wikipedia.org/wiki/Internet_of_things) device that stores data in `localStorage` or [IndexedDB](https://developer.mozilla.org/docs/Web/API/IndexedDB_API).

* If you do significant work to fetch and cache the backend API data relevant to each user, so they can navigate through it offline. If you support editing, you will also need to build a system for tracking changes and synchronizing them with the backend.

* If your goal is to guarantee the application loads immediately regardless of network conditions. You will then need to implement a suitable user experience around backend API requests to show the progress of requests and behave gracefully when they fail due to network unavailability.

Additionally, offline-capable PWAs need to deal with a range of extra complications. Developers should carefully familiarize themselves with the following caveats.

### Offline support only when published

Blazor's PWA template enables offline support only when published. This is because, during development, you typically want to see each change reflected immediately in the browser, without going through a background update process.

Therefore when building an offline-capable application, it's not enough to test your application in development mode. You must test your application in its published state to understand how it will respond to differing network conditions.

### Update completion after user navigation away from app

Updates don't complete until the user has navigated away from your application in all tabs. As explained in [Background updates](#background-updates), after you deploy an update to your application, the browser will fetch the updated service worker files and begin an update process.

What surprises many developers is that, even when this update completes, it does **not** take effect until the user has navigated away in all tabs. It is **not** sufficient to refresh the tab displaying your application, even if it's the only tab displaying your application. Until your application is completely closed, the new service worker will remain in a "waiting to activate" status. **This is not specific to Blazor, but rather is a standard web platform behavior.**

This commonly troubles developers who are trying to test updates to their service worker or offline cached resources. If you check in the browser's dev tools, you may see something like the following:

![image](https://user-images.githubusercontent.com/1101362/76226394-b93f7380-6215-11ea-8572-7d52afee2dd8.png)

For as long as the list of "clients" (i.e., tabs or windows displaying your application) is nonempty, the worker will continue waiting. The reason service workers do this is to guarantee consistency, i.e., that all resources are fetched from the same atomic cache.

When testing changes, you may find it convenient to click the "skipWaiting" link as shown in the screenshot above, then reload the page. If you want, you can automate this for all users by coding your service worker to [skip the "waiting" phase and immediately activate on update](https://developers.google.com/web/fundamentals/primers/service-workers/lifecycle#skip_the_waiting_phase). However if you do this, you are giving up the guarantee that resources are always fetched consistently from the same cache instance.

### Users may run any historical version of the app

Web developers habitually expect that users will only run the latest deployed version of their web application, since that's normal within the traditional web distribution model. However, an offline-first PWA is more akin to a native mobile app, where users are not necessarily running the latest version.

As explained in [Background updates](#background-updates), after you deploy an update to your application, **each existing user will continue to use a previous version for at least one further visit** (because the update occurs in the background and isn't activated until the user then navigates away). Plus, the previous version being used isn't necessarily the previous one you deployed - it can be *any* historical version, depending on when the user last completed an update.

This can be an issue if the frontend and backend parts of your application require agreement about the schema for API requests. You must not deploy backward-incompatible API schema changes until you can be sure that all users have upgraded, or at least block users from using incompatible older versions of the app. This is just like a native mobile app. If you deploy a breaking change in server APIs, the client app will be broken for people who haven't yet updated.

If possible, don't deploy breaking changes to your backend APIs. But if you must do so, consider using [standard Service Worker APIs such as `ServiceWorkerRegistration`](https://developer.mozilla.org/docs/Web/API/ServiceWorkerRegistration) to determine whether the application is up-to-date, and if not, to prevent usage.

### Interference with server-rendered pages

[As described above](#support-server-rendered-pages), if you want to bypass the service worker's behavior of returning `/index.html` contents for all navigation requests, you need to edit the logic in your service worker.

### All service worker asset manifest contents are cached by default

[As described above](#control-asset-caching), the file *service-worker-assets.js* is generated during build and lists all assets the service worker should fetch and cache.

Since this list by default includes everything emitted to *wwwroot* (including content supplied by external packages and projects), you must be careful not to put too much content there. If for example your *wwwroot* directory contains millions of images, the service worker would try to fetch and cache them all, consuming excessive bandwidth and most likely not completing successfully.

You can implement arbitrary logic to control which subset of the manifest's contents should be fetched and cached by editing the `onInstall` function in *service-worker.published.js*.

### Interaction with authentication

It's possible to use the PWA template option in conjunction with the authentication options. An offline-capable PWA can also support authentication when the user has network connectivity.

However, when a user does not have network connectivity, they will not be able to authenticate or obtain access tokens. Attempting to visit the "login" page will by default display a message saying "network error".

As such it's your job to design a UI flow that lets the user do useful things while offline without attempting to authenticate or obtain access tokens, or at least failing in a graceful way in those cases. If this isn't possible in your application, you might not want to enable offline support.
