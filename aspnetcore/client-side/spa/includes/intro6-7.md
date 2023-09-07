::: moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"
<!-- Content from https://github.com/dotnet/AspNetCore.Docs/issues/26373 -->

## Architecture of Single Page Application templates

The Single Page Application (SPA) templates for [Angular](https://angular.io/) and [React](https://reactjs.org/) offer the ability to develop Angular and React apps that are hosted inside a .NET backend server.

At publish time, the files of the Angular and React app are copied to the `wwwroot` folder and are served via the [static files middleware](xref:fundamentals/static-files).

Rather than returning HTTP 404 (Not Found), a fallback route handles unknown requests to the backend and serves the `index.html` for the SPA.

During development, the app is configured to use the frontend proxy. React and Angular use the same frontend proxy.

When the app launches, the `index.html` page is opened in the browser. A special middleware that is only enabled in development:

* Intercepts the incoming requests.
* Checks whether the proxy is running.
* Redirects to the URL for the proxy if it's running or launches a new instance of the proxy.
* Returns a page to the browser that auto refreshes every few seconds until the proxy is up and the browser is redirected.

![Browser Proxy Server diagram](~/client-side/spa/intro/static/1_BPS.png)

The primary benefit the ASP.NET Core SPA templates provide:

* Launches a proxy if it's not already running.
* Setting up HTTPS.
* Configuring some requests to be proxied to the backend ASP.NET Core server.

When the browser sends a request for a backend endpoint, for example `/weatherforecast` in the templates. The SPA proxy receives the request and sends it back to the server transparently. The server responds and the SPA proxy sends the request back to the browser:

![Proxy Server diagram](~/client-side/spa/intro/static/2BP.png)

## Published Single Page Apps

When the app is published, the SPA becomes a collection of files in the `wwwroot` folder.

There is no runtime component required to serve the app:

:::code language="csharp" source="~/client-side/spa/intro/samples/Program.cs" highlight="13,21":::

In the preceding template generated `Program.cs` file:
* `app.`<xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> allows the files to be served.
* `app.`<xref:Microsoft.AspNetCore.Builder.StaticFilesEndpointRouteBuilderExtensions.MapFallbackToFile%2A>`("index.html")` enables serving the default document for any unknown request the server receives.

When the app is published with [dotnet publish](/dotnet/core/tools/dotnet-publish), the following tasks in the `csproj` file ensures that [`npm restore`](https://www.npmjs.com/package/restore) runs and that the appropriate npm script runs to generate the production artifacts:

:::code language="xml" source="~/client-side/spa/intro/samples/MyReact.csproj" range="27-99":::

## Developing Single Page Apps

The project file defines a few properties that control the behavior of the app during development:

:::code language="xml" source="~/client-side/spa/intro/samples/MyReact.csproj" highlight="11-12,17":::

* `SpaProxyServerUrl`: Controls the URL where the server expects the SPA proxy to be running. This is the URL:
  * The server pings after launching the proxy to know if it's ready.
  * Where it redirects the browser after a successful response.
* `SpaProxyLaunchCommand`:  The command the server uses to launch the SPA proxy when it detects the proxy is not running.

The package `Microsoft.AspNetCore.SpaProxy` is responsible for the preceding logic to detect the proxy and redirect the browser.

The [hosting startup assembly](xref:fundamentals/configuration/platform-specific-configuration) defined in `Properties/launchSettings.json` is used to automatically add the required components during development necessary to detect if the proxy is running and launch it otherwise:

:::code language="json" source="~/client-side/spa/intro/samples/launchSettings.json" highlight="17,25":::

### Setup for the client app

This setup is specific to the frontend framework the app is using, however many aspects of the configuration are similar.

#### Angular setup

The template generated `ClientApp/package.json` file:

  :::code language="json" source="~/client-side/spa/intro/samples/Ang_package.json" highlight="6-9":::

* Contains scripts that launching the angular development server:
* The `prestart` script invokes `ClientApp/aspnetcore-https.js`, which is responsible for ensuring the development server HTTPS certificate is available to the SPA proxy server.
* The `start:windows` and `start:default`:

  * Launch the Angular development server via [`ng serve`](https://angular.io/cli/serve).
  * Provide the port, the options to use HTTPS, and the path to the certificate and the associated key. The provide port number matches the port number specified in the `.csproj` file.

The template generated `ClientApp/angular.json` file contains:

* The `serve` command.
* A `proxyconfig` element in the `development` configuration to indicate that `proxy.conf.js` should be used to configure the frontend proxy, as shown in the following highlighted JSON:

  :::code language="json" source="~/client-side/spa/intro/samples/angular.json" highlight="71-80":::

`ClientApp/proxy.conf.js` defines the routes that need to be proxied back to the server backend. The general set of options is defined at [http-proxy-middleware](https://github.com/chimurai/http-proxy-middleware) for react and angular since they both use the same proxy.

The following highlighted code from `ClientApp/proxy.conf.js` uses logic based on the environment variables set during development to determine the port the backend is running on:

  :::code language="javascript" source="~/client-side/spa/intro/samples/Ang_proxy.conf.js" highlight="3-4":::

#### React setup

* The `package.json` scripts section contains the following scripts that launches the react app during development, as shown in the following highlighted code:

  :::code language="json" source="~/client-side/spa/intro/samples/React_package.json" highlight="51-53":::

* The `prestart` script invokes:

  * `aspnetcore-https.js`, which is responsible for ensuring the development server HTTPS certificate is available to the SPA proxy server.
  * Invokes `aspnetcore-react.js` to setup the appropriate `.env.development.local` file to use the HTTPS local development certificate. `aspnetcore-react.js` configures the HTTPS local development certificate by adding `SSL_CRT_FILE=<certificate-path>` and `SSL_KEY_FILE=<key-path>` to the file.

* The `.env.development` file defines the port for the development server and specifies HTTPS.

The `src/setupProxy.js` configures the SPA proxy to forward the requests to the backend. The general set of options is defined in [http-proxy-middleware](https://github.com/chimurai/http-proxy-middleware).

The following highlighted code in `ClientApp/src/setupProxy.js` uses logic based on the environment variables set during development to determine the port the backend is running on:

  :::code language="javascript" source="~/client-side/spa/intro/samples/setupProxy.js" highlight="4-5":::

## Supported SPA framework version in ASP.NET Core SPA templates

The SPA project templates that ship with each ASP.NET Core release reference the latest version of the appropriate SPA framework.

SPA frameworks typically have a shorter release cycle than .NET. Because of the two different release cycles, the supported version of the SPA framework and .NET can get out of sync: the major SPA framework version, that a .NET major release depends on, can go out of support, while the .NET version the SPA framework shipped with is still supported.

The ASP.NET Core SPA templates can be updated in a patch release to a new SPA framework version to keep the templates in a supported and safe state.

## Additional resources

* <xref:security/authentication/identity/spa>
* <xref:spa/angular>
* <xref:spa/react>
* [Hosting Startup Assemblies](xref:fundamentals/host/web-host#hosting-startup-assemblies)

::: moniker-end
