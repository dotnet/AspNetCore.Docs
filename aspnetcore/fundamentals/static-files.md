---
title: Static files in ASP.NET Core
author: wadepickett
description: Learn how to serve and secure static files and configure Map Static Assets endpoint conventions and Static File Middleware in ASP.NET Core web apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 09/02/2025
uid: fundamentals/static-files
---
# Static files in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

Static files, also called static assets, are files an ASP.NET Core app that aren't dynamically generated and served directly to clients on request, such as HTML, CSS, image, and JavaScript files.

For Blazor static files guidance, which adds to or supersedes the guidance in this article, see <xref:blazor/fundamentals/static-files>.

:::moniker range=">= aspnetcore-9.0"

To enable static file handling in ASP.NET Core, call <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A>. 

By default, static files are stored within the project's [web root](xref:fundamentals/index#web-root) directory. The default directory is `{CONTENT ROOT}/wwwroot`, where the `{CONTENT ROOT}` placeholder is the app's [content root](xref:fundamentals/index#content-root). Only files in the wwwroot folder will be addressable, so you don't need to worry about the rest of your code.

Only files with specific file extensions mapped to supported media types are treated as static web assets.

Static web assets are discovered at build time and optimized using content-based [fingerprinting](https://wikipedia.org/wiki/Fingerprint_(computing)) to prevent the reuse of old file and [compressed](/aspnet/core/performance/response-compression) to reduce asset delivery time. [The optimizations don't include minification.]

At runtime, the discovered static web assets are exposed as endpoints with HTTP headers applied, such as [caching headers](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control) and content type headers. An asset is served once until the file changes or the browser clears its cache. The [`ETag`](https://developer.mozilla.org/docs/Web/HTTP/Headers/ETag), [`Last-Modified`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Last-Modified), and [`Content-Type`](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Content-Type) headers are set. The browser is prevented from using stale assets after an app is updated.

Delivery of static assets is based on [endpoint routing](xref:fundamentals/routing), so it works with other endpoint-aware features, such as authorization. It's designed to work with all UI frameworks, including Blazor, Razor Pages, and MVC.

Map Static Assets provides the following benefits:

* Build-time compression for all the assets in the app, including JavaScript (JS) and stylesheets but excluding image and font assets that are already compressed. [Gzip](https://tools.ietf.org/html/rfc1952) (`Content-Encoding: gz`) compression is used during development. Gzip with [Brotli](https://tools.ietf.org/html/rfc7932) (`Content-Encoding: br`) compression is used during publish.
* [Fingerprinting](https://developer.mozilla.org/docs/Glossary/Fingerprinting) for all assets at build time with a [Base64](https://developer.mozilla.org/docs/Glossary/Base64)-encoded string of the [SHA-256](xref:System.Security.Cryptography.SHA256) hash of each file's content. This prevents reusing an old version of a file, even if the old file is cached. Fingerprinted assets are cached using the [`immutable` directive](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control#directives), which results in the browser never requesting the asset again until it changes. For browsers that don't support the `immutable` directive, a [`max-age` directive](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control#directives) is added.
  * Even if an asset isn't fingerprinted, content based `ETags` are generated for each static asset using the fingerprint hash of the file as the `ETag` value. This ensures that the browser only downloads a file if its content changes (or the file is being downloaded for the first time).
  * Internally, the framework maps physical assets to their fingerprints, which allows the app to:
    * Find automatically-generated assets, such as Razor component scoped CSS for Blazor's [CSS isolation feature](xref:blazor/components/css-isolation) and JS assets described by [JS import maps](https://developer.mozilla.org/docs/Web/HTML/Element/script/type/importmap).
    * Generate link tags in the `<head>` content of the page to preload assets.

Map Static Assets doesn't provide features for minification or other file transformations. Minification is usually handled by custom code or [third-party tooling](xref:blazor/fundamentals/index#community-links-to-blazor-resources).

:::moniker-end

:::moniker range="< aspnetcore-9.0"

To enable static file handling in ASP.NET Core, call <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>. 

By default, static files are stored within the project's [web root](xref:fundamentals/index#web-root) directory. The default directory is `{CONTENT ROOT}/wwwroot`, where the `{CONTENT ROOT}` placeholder is the app's [content root](xref:fundamentals/index#content-root). Only files in the wwwroot folder will be addressable, so you don't need to worry about the rest of your code.

At runtime, static web assets are returned by Static File Middleware when requested with asset modification and content type headers applied. The [`ETag`](https://developer.mozilla.org/docs/Web/HTTP/Headers/ETag), [`Last-Modified`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Last-Modified), and [`Content-Type`](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Content-Type) headers are set.

Static File Middleware enables static file serving and is used by an app when <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> is called in the app's request processing pipeline. Files are served from the path specified in <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootPath%2A?displayProperty=nameWithType> or <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootFileProvider>, which defaults to the web root folder, typically `wwwroot`.

:::moniker-end

You can also serve static web assets from [referenced projects and packages](xref:razor-pages/ui-class#consume-content-from-a-referenced-rcl). 

## Change the web root directory

Use the <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseWebRoot%2A> method if you want to change the web root. For more information, see <xref:fundamentals/index#web-root>.

Prevent publishing files in `wwwroot` with the [`<Content>` project item](/visualstudio/msbuild/common-msbuild-project-items#content) in the project file. The following example prevents publishing content in `wwwroot/local` and its sub-directories:

```xml
<ItemGroup>
  <Content Update="wwwroot\local\**\*.*" CopyToPublishDirectory="Never" />
</ItemGroup>
```

:::moniker range=">= aspnetcore-6.0"

The <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A> method sets the content root to the current directory:

```csharp
var builder = WebApplication.CreateBuilder(args);
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

The <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A> method sets the content root to the current directory:

```csharp
Host.CreateDefaultBuilder(args)
```

:::moniker-end

:::moniker range=">= aspnetcore-9.0"

In the request processing pipeline after the call to <xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A>, call <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> in the app's request processing pipeline to enable serving static files from the app's [web root](xref:fundamentals/index#web-root):

```csharp
app.MapStaticAssets();
```

:::moniker-end

:::moniker range="< aspnetcore-9.0"

In the request processing pipeline after the call to <xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A>, call <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> in the app's request processing pipeline to enable serving static files from the app's [web root](xref:fundamentals/index#web-root):

```csharp
app.UseStaticFiles();
```

:::moniker-end

Static files are accessible via a path relative to the [web root](xref:fundamentals/index#web-root). 

To access an image at `wwwroot/images/favicon.png`:

* URL format: `https://{HOST}/images/{FILE NAME}`
  * The `{HOST}` placeholder is the host.
  * The `{FILE NAME}` placeholder is the file name.
* Examples
  * Absolute URL: `https://localhost:5001/images/favicon.png`
  * Root relative URL: `images/favicon.png`

In a Blazor app, `images/favicon.png` loads the icon image (`favicon.png`) from the app's `wwwroot/images` folder:

```razor
<link rel="icon" type="image/png" href="images/favicon.png" />
```

In Razor Pages and MVC apps, the tilde character `~` points to the web root. In the following example, `~/images/favicon.png` loads the icon image (`favicon.png`) from the app's `wwwroot/images` folder:

```cshtml
<link rel="icon" type="image/png" href="~/images/favicon.png" />
```

:::moniker range=">= aspnetcore-9.0"

## Short-circuit the middleware pipeline

To avoid running the entire middleware pipeline after a static asset is served, which matches the behavior of <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>, call <xref:Microsoft.AspNetCore.Builder.RouteShortCircuitEndpointConventionBuilderExtensions.ShortCircuit%2A> on <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A>. Calling <xref:Microsoft.AspNetCore.Builder.RouteShortCircuitEndpointConventionBuilderExtensions.ShortCircuit%2A> immediately executes the endpoint and returns the response, preventing other middleware from executing for static asset requests:

```csharp
app.MapStaticAssets().ShortCircuit();
```

## Control static file caching during development

When running in the Development environment, for example during [Visual Studio Hot Reload](/visualstudio/debugger/hot-reload) development testing, the framework overrides cache headers to prevent browsers from caching static files. This helps ensure that the latest version of files are used when files change, avoiding issues with stale content. In production, the correct cache headers are set, allowing browsers to cache static assets as expected.

To disable this behavior, set `EnableStaticAssetsDevelopmentCaching` to `true` in the Development environment's app setting file (`appsettings.Development.json`).

:::moniker-end

## Static files in non-`Development` environments

When running an app locally, static web assets are only enabled in the Development environment. To enable static files for environments other than Development during local development and testing (for example, in the Staging environment), call <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStaticWebAssets%2A> on the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder>.

> [!WARNING]
> Call <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStaticWebAssets%2A> for the ***exact environment*** to prevent activating the feature in production, as it serves files from separate locations on disk *other than from the project*. The example in this section checks for the Staging environment with <xref:Microsoft.Extensions.Hosting.HostEnvironmentEnvExtensions.IsStaging%2A>.

```csharp
if (builder.Environment.IsStaging())
{
    builder.WebHost.UseStaticWebAssets();
}
```

:::moniker range=">= aspnetcore-6.0"

## Serve files outside of the web root directory via `IWebHostEnvironment.WebRootPath`

When <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootPath%2A?displayProperty=nameWithType> is set to a folder other than `wwwroot`, the following default behaviors are exhibited:

* In the development environment, static assets are served from `wwwroot` if assets with the same name are in both `wwwroot` and a different folder assigned to <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootPath%2A>.
* In any environment other than development, duplicate static assets are served from the <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootPath%2A> folder.

Consider a web app created from the empty web template:

* Containing an `Index.html` file in `wwwroot` and `wwwroot-custom`.
* The `Program` file is updated to set `WebRootPath = "wwwroot-custom"`.

```csharp
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "wwwroot-custom"
});
```

By default, for requests to `/`:

* In the development environment, `wwwroot/Index.html` is returned.
* In any environment other than development, `wwwroot-custom/Index.html` is returned.

To ensure assets from `wwwroot-custom` are always returned, use ***one*** of the following approaches:

* Delete duplicate-named assets in `wwwroot`.

* Set `ASPNETCORE_ENVIRONMENT` in `Properties/launchSettings.json` to any value other than `Development`.

* Disable static web assets by setting `<StaticWebAssetsEnabled>` to `false` in the app's project file. ***WARNING:*** Disabling static web assets disables [Razor class libraries](xref:razor-pages/ui-class).

* Add the following XML to the project file:

  ```xml
  <ItemGroup>
    <Content Remove="wwwroot\**" />
  </ItemGroup>
  ```

The following code updates <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootPath%2A> to a non-Development value (`Staging`), guaranteeing duplicate content is returned from `wwwroot-custom` rather than `wwwroot`:

```csharp
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    EnvironmentName = Environments.Staging,
    WebRootPath = "wwwroot-custom"
});
```

:::moniker-end

:::moniker range=">= aspnetcore-9.0"

## Static File Middleware

Static File Middleware, which is used in specific static files scenarios, enables static file serving and is used by an app when <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> is called in the app's request processing pipeline. Files are served from the path specified in <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootPath%2A?displayProperty=nameWithType> or <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootFileProvider>, which defaults to the web root folder, typically `wwwroot`. <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> is available in ASP.NET Core in .NET 9 or later. <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> must be used in versions prior to .NET 9.

<xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> serves static files, but it doesn't provide the same level of optimization as <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A>. <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> is optimized for serving assets that the app has knowledge of at runtime. If the app serves assets from other locations, such as disk or embedded resources, <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> should be used.

The build-time compression and fingerprinting features of Map Static Assets endpoint routing conventions aren't available when only relying on Static File Middleware (<xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>).

The following features covered in this article are supported with <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> but not with <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A>:

* [Serve files outside of the web root directory](#serve-files-outside-of-the-web-root-directory-via-usestaticfiles)
* [Set HTTP response headers](#set-http-response-headers)
* [Serving files from disk or embedded resources, or other locations](#serve-files-from-multiple-locations)
* [Directory browsing](#directory-browsing)
* [Serve default documents](#serve-default-documents)
* [Combine static files, default documents, and directory browsing](#combine-static-files-default-documents-and-directory-browsing)
* [Map file extensions to MIME types](#map-file-extensions-to-mime-types)
* [Serving non-standard content types](#non-standard-content-types)

:::moniker-end

## Serve files outside of the web root directory via `UseStaticFiles`

Consider the following directory hierarchy with static files residing outside of the app's [web root](xref:fundamentals/index#web-root) in a folder named `ExtraStaticFiles`:

* `wwwroot`
  * `css`
  * `images`
  * `js`
* `ExtraStaticFiles`
  * `images`
    * `red-rose.jpg`

A request can access `red-rose.jpg` by configuring a new instance of Static File Middleware:

Namespaces for the following API:

```csharp
using Microsoft.Extensions.FileProviders;
```

In the request processing pipeline after the existing call to either <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> (.NET 9 or later) or <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> (.NET 8 or earlier):

```csharp
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "ExtraStaticFiles")),
    RequestPath = "/static-files"
});
```

In the preceding code, the `ExtraStaticFiles` directory hierarchy is exposed publicly via the `static-files` URL segment. A request to `https://{HOST}/StaticFiles/images/red-rose.jpg`, where the `{HOST}` placeholder is the host, serves the `red-rose.jpg` file.

The following markup references `ExtraStaticFiles/images/red-rose.jpg`:

```html
<img src="static-files/images/red-rose.jpg" alt="A red rose" />
```

For the preceding example, tilde-slash notation is supported in Razor Pages and MVC views (`src="~/StaticFiles/images/red-rose.jpg"`), not for Razor components in Blazor apps.

## Serve files from multiple locations

:::moniker range=">= aspnetcore-6.0"

*The guidance in this section applies to Razor Pages and MVC apps. For guidance that applies to Blazor Web Apps, see <xref:blazor/fundamentals/static-files#serve-files-from-multiple-locations>.*

Consider the following markup that displays a company logo:

```html
<img src="~/logo.png" asp-append-version="true" alt="Company logo">
```

The developer intends to use the [Image Tag Helper](xref:mvc/views/tag-helpers/builtin-th/image-tag-helper) to append a version and serve the file from a custom location, a folder named `ExtraStaticFiles`.

:::moniker-end

:::moniker range=">= aspnetcore-9.0"

The following example calls <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> to serve files from `wwwroot` and <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> to serve files from `ExtraStaticFiles`:

In the request processing pipeline after the existing call to either <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> (.NET 9 or later) or <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> (.NET 8 or earlier):

```csharp
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "ExtraStaticFiles"))
});
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-9.0"

The following example calls <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> twice to serve files from both `wwwroot` and `ExtraStaticFiles`.

In the request processing pipeline after the existing call to <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>:

```csharp
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "ExtraStaticFiles"))
});
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

Using the preceding code, the `ExtraStaticFiles/logo.png` file is displayed. However, the [Image Tag Helper](xref:mvc/views/tag-helpers/builtin-th/image-tag-helper) (<xref:Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper.AppendVersion>) isn't applied because the Tag Helper depends on <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootFileProvider>, which hasn't been updated to include the `ExtraStaticFiles` folder.

The following code updates the <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootFileProvider> to include the `ExtraStaticFiles` folder by using a <xref:Microsoft.Extensions.FileProviders.CompositeFileProvider>. This enables the Image Tag Helper to apply a version to images in the `ExtraStaticFiles` folder.

Namespace for the following API:

```csharp
using Microsoft.Extensions.FileProviders;
```

In the request processing pipeline before the existing call to <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> (.NET 9 or later) or <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> (.NET 8 or earlier):

```csharp
var webRootProvider = new PhysicalFileProvider(builder.Environment.WebRootPath);
var newPathProvider = new PhysicalFileProvider(
    Path.Combine(builder.Environment.ContentRootPath, "ExtraStaticFiles"));

var compositeProvider = new CompositeFileProvider(webRootProvider, newPathProvider);

app.Environment.WebRootFileProvider = compositeProvider;
```

:::moniker-end

<xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> and <xref:Microsoft.AspNetCore.Builder.FileServerExtensions.UseFileServer%2A> default to the file provider pointing at `wwwroot`. Additional instances of <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> and <xref:Microsoft.AspNetCore.Builder.FileServerExtensions.UseFileServer%2A> can be provided with other file providers to serve files from other locations. For more information, see [UseStaticFiles still needed with UseFileServer for wwwroot (`dotnet/AspNetCore.Docs` #15578)](https://github.com/dotnet/AspNetCore.Docs/issues/15578).

## Set HTTP response headers

Use <xref:Microsoft.AspNetCore.Builder.StaticFileOptions> to set HTTP response headers. In addition to configuring Static File Middleware to serve static files, the following code sets the [`Cache-Control` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control) to 604,800 seconds (one week).

Namespaces for the following API:

```csharp
using Microsoft.AspNetCore.Http;
```

In the request processing pipeline after the existing call to either <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> (.NET 9 or later) or <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> (.NET 8 or earlier):

```csharp
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append(
            "Cache-Control", "public, max-age=604800");
    }
});
```

## Large collection of assets

When dealing with large collections of assets, which is considered to be around 1,000 or more assets, we recommend using a bundler to reduce the final number of assets served by the app or to combine <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> with <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>.

<xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> eagerly loads the precomputed metadata captured during the build process for the resources in order to support compression, caching, and fingerprinting. These features come at the cost of greater memory usage by the app. For assets that are frequently accessed, it's usually worth the costs. For assets that aren't frequently accessed, the trade-off might not be worth the costs.

If you don't use bundling, we recommend that you combine <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> with <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>. The following example demonstrates the approach.

In the project file (`.csproj`), the `StaticWebAssetEndpointExclusionPattern` MSBuild property is used to filter endpoints from the final manifest for <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A>. Excluded files are served by <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> and don't benefit from compression, caching, and fingerprinting.

When setting the value of `StaticWebAssetEndpointExclusionPattern`, retain `$(StaticWebAssetEndpointExclusionPattern)` to keep the framework's default exclusion pattern. Add additional patterns in a semicolon-separated list.

In the following example, the exclusion patten adds the static files in the `lib/icons` folder, which represents a hypothetical batch of icons:

```xml
<StaticWebAssetEndpointExclusionPattern>
  $(StaticWebAssetEndpointExclusionPattern);lib/icons/**
</StaticWebAssetEndpointExclusionPattern>
```

After HTTPS Redirection Middleware (`app.UseHttpsRedirection();`) processing in the `Program` file:

* Call <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> to handle the excluded files (`lib/icons/**`) and any other files not covered by <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A>.
* Call <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> after <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> to handle critical application files (CSS, JS, images).

```csharp
app.UseStaticFiles();

app.UseAuthorization();

app.MapStaticAssets();
```

## Static file authorization

:::moniker range=">= aspnetcore-9.0"

When an app adopts a [fallback authorization policy](xref:security/authorization/secure-data#require-authenticated-users), authorization is required for all requests that don't explicitly specify an authorization policy, including requests for static files after Authorization Middleware processes requests. Allow anonymous access to static files by applying <xref:Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute> to the endpoint builder for static files:

```csharp
app.MapStaticAssets().Add(endpointBuilder => 
    endpointBuilder.Metadata.Add(new AllowAnonymousAttribute()));
```

:::moniker-end

:::moniker range="< aspnetcore-9.0"

When an app adopts a [fallback authorization policy](xref:security/authorization/secure-data#require-authenticated-users), authorization is required for all requests that don't explicitly specify an authorization policy, including requests for static files after Authorization Middleware processes requests. The ASP.NET Core templates allow anonymous access to static files by calling <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> before calling <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>. Most apps follow this pattern. When the Static File Middleware is called before the authorization middleware:

* No authorization checks are performed on the static files.
* Static files served by the Static File Middleware, such as those web root (typically, `wwwroot`), are publicly accessible.

:::moniker-end

To serve static files based on authorization:

* Confirm that the app sets the [fallback authorization policy](xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.FallbackPolicy) to require authenticated users.
* Store the static file outside of the app's web root.
* After calling <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>, call <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>, specifying the path to the static files folder outside of the web root.

:::moniker range=">= aspnetcore-6.0"

Namespaces for the following API:

```csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.FileProviders;
```

Service registration:

```csharp
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
```

In the request processing pipeline after the call to <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>:

```csharp
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "SecureStaticFiles")),
    RequestPath = "/static-files"
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Namespaces for the following API:

```csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.FileProviders;
```

In `Startup.ConfigureServices`:

```csharp
services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
```

In `Startup.Configure` after the call to <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>:

```csharp
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(env.ContentRootPath, "SecureStaticFiles")),
    RequestPath = "/static-files"
});
```

:::moniker-end

In the preceding code, the fallback authorization policy requires authenticated users. Endpoints, such as controllers and Razor Pages, that specify their own authorization requirements don't use the fallback authorization policy. For example, Razor Pages, controllers, or action methods with `[AllowAnonymous]` or `[Authorize(PolicyName="MyPolicy")]` use the applied authorization attribute rather than the fallback authorization policy.

<xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAuthenticatedUser%2A> adds <xref:Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement> to the current instance, which enforces that the current user is authenticated.

Static assets stored in the app's web root are publicly accessible because the default Static File Middleware (<xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>) is called before <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>. Static assets in the `SecureStaticFiles` folder require authentication.

An alternative approach to serve files based on authorization is to:

* Store the files outside of the web root and any directory accessible to Static File Middleware.
* Serve the files via an action method to which authorization is applied and return a <xref:Microsoft.AspNetCore.Mvc.FileResult> object.

From a Razor page (`Pages/BannerImage.cshtml.cs`):

```csharp
public class BannerImageModel : PageModel
{
    private readonly IWebHostEnvironment _env;

    public BannerImageModel(IWebHostEnvironment env) => _env = env;

    public PhysicalFileResult OnGet()
    {
        var filePath = Path.Combine(
            _env.ContentRootPath, "SecureStaticFiles", "images", "red-rose.jpg");

        return PhysicalFile(filePath, "image/jpeg");
    }
}
```

From a controller (`Controllers/HomeController.cs`):

```csharp
[Authorize]
public IActionResult BannerImage()
{
    var filePath = Path.Combine(
        _env.ContentRootPath, "SecureStaticFiles", "images", "red-rose.jpg");

    return PhysicalFile(filePath, "image/jpeg");
}
```

The preceding approach requires a page or endpoint per file.

The following route endpoint example returns files for authenticated users.

:::moniker range=">= aspnetcore-6.0"

In the `Program` file:

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AuthenticatedUsers", b => b.RequireAuthenticatedUser());
});

...

app.MapGet("/files/{fileName}", IResult (string fileName) => 
{
    var filePath = GetOrCreateFilePath(fileName);

    if (File.Exists(filePath))
    {
        return TypedResults.PhysicalFile(filePath, fileName);
    }

    return TypedResults.NotFound("No file found with the supplied file name");
})
.WithName("GetFileByName")
.RequireAuthorization("AuthenticatedUsers");
```

The following route endpoint example uploads files for authenticated users in the administrator role ("`admin`").

In the `Program` file:

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminsOnly", b => b.RequireRole("admin"));
});

...

// IFormFile uses memory buffer for uploading. For handling large 
// files, use streaming instead. See the *File uploads* article
// in the ASP.NET Core documentation:
// https://learn.microsoft.com/aspnet/core/mvc/models/file-uploads
app.MapPost("/files", async (IFormFile file, LinkGenerator linker, 
    HttpContext context) =>
{
    // Don't rely on the value in 'file.FileName', as it's only metadata that can 
    // be manipulated by the end-user. Consider the 'Utilities.IsFileValid' method 
    // that takes an 'IFormFile' and validates its signature within the 
    // 'AllowedFileSignatures'.
    
    var fileSaveName = Guid.NewGuid().ToString("N") + 
        Path.GetExtension(file.FileName);
    await SaveFileWithCustomFileName(file, fileSaveName);
    
    context.Response.Headers.Append("Location", linker.GetPathByName(context, 
        "GetFileByName", new { fileName = fileSaveName}));

    return TypedResults.Ok("File Uploaded Successfully!");
})
.RequireAuthorization("AdminsOnly");
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.ConfigureServices`:

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("AuthenticatedUsers", b => b.RequireAuthenticatedUser());
});
```

In `Startup.Configure`:

```csharp
app.MapGet("/files/{fileName}", IResult (string fileName) => 
{
    var filePath = GetOrCreateFilePath(fileName);

    if (File.Exists(filePath))
    {
        return TypedResults.PhysicalFile(filePath, fileName);
    }

    return TypedResults.NotFound("No file found with the supplied file name");
})
.WithName("GetFileByName")
.RequireAuthorization("AuthenticatedUsers");
```

The following code uploads files for authenticated users in the administrator role ("`admin`").

In `Startup.ConfigureServices`:

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("AdminsOnly", b => b.RequireRole("admin"));
});
```

In `Startup.Configure`:

```csharp
// IFormFile uses memory buffer for uploading. For handling large 
// files, use streaming instead. See the *File uploads* article
// in the ASP.NET Core documentation:
// https://learn.microsoft.com/aspnet/core/mvc/models/file-uploads
app.MapPost("/files", async (IFormFile file, LinkGenerator linker, 
    HttpContext context) =>
{
    // Don't rely on the value in 'file.FileName', as it's only metadata that can 
    // be manipulated by the end-user. Consider the 'Utilities.IsFileValid' method 
    // that takes an 'IFormFile' and validates its signature within the 
    // 'AllowedFileSignatures'.
    
    var fileSaveName = Guid.NewGuid().ToString("N") + 
        Path.GetExtension(file.FileName);
    await SaveFileWithCustomFileName(file, fileSaveName);
    
    context.Response.Headers.Append("Location", linker.GetPathByName(context, 
        "GetFileByName", new { fileName = fileSaveName}));

    return TypedResults.Ok("File Uploaded Successfully!");
})
.RequireAuthorization("AdminsOnly");
```

:::moniker-end

## Directory browsing

Directory browsing allows directory listing within specified directories.

Directory browsing is disabled by default for security reasons. For more information, see [Security considerations for static files](#security-considerations-for-static-files).

Enable directory browsing with the following API:

* <xref:Microsoft.Extensions.DependencyInjection.DirectoryBrowserServiceExtensions.AddDirectoryBrowser%2A>
* <xref:Microsoft.AspNetCore.Builder.DirectoryBrowserExtensions.UseDirectoryBrowser%2A>

In the following example:

* An `images` folder at the root of the app holds images for directory browsing.
* The request path to browse the images is `/DirectoryImages`.
* Calling <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> and setting the <xref:Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptionsBase.FileProvider%2A> of <xref:Microsoft.AspNetCore.Builder.StaticFileOptions> enables displaying browser links to the individual files.

:::moniker range=">= aspnetcore-6.0"

Namespaces for the following API:

```csharp
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
```

Service registration:

```csharp
builder.Services.AddDirectoryBrowser();
```

In the request processing pipeline after the existing call to either <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> (.NET 9 or later) or <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> (.NET 8 or earlier):

```csharp
var fileProvider = new PhysicalFileProvider(
    Path.Combine(builder.Environment.WebRootPath, "images"));
var requestPath = "/DirectoryImages";

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = fileProvider,
    RequestPath = requestPath
});

app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = fileProvider,
    RequestPath = requestPath
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Namespaces for the following API:

```csharp
using Microsoft.Extensions.FileProviders;
using System.IO;
```

In `Startup.ConfigureServices`:

```csharp
services.AddDirectoryBrowser();
```

In `Startup.Configure` after the existing call to <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>:

```csharp
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(env.WebRootPath, "images")),
    RequestPath = "/DirectoryImages"
});

app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(env.WebRootPath, "images")),
    RequestPath = "/DirectoryImages"
});
```

:::moniker-end

The preceding code allows directory browsing of the `wwwroot/images` folder using the URL `https://{HOST}/DirectoryImages` with links to each file and folder, where the `{HOST}` placeholder is the host.

:::moniker range=">= aspnetcore-6.0"

<xref:Microsoft.Extensions.DependencyInjection.DirectoryBrowserServiceExtensions.AddDirectoryBrowser%2A> adds services required by the Directory Browsing Middleware, including <xref:System.Text.Encodings.Web.HtmlEncoder>. These services may be added by other calls, such as <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddRazorPages%2A>, but we recommend calling <xref:Microsoft.Extensions.DependencyInjection.DirectoryBrowserServiceExtensions.AddDirectoryBrowser%2A> to ensure the services are added.

:::moniker-end

## Serve default documents

Setting a default page provides visitors a starting point on a site. To serve a default file from `wwwroot` without requiring the request URL to include the file's name, call the <xref:Microsoft.AspNetCore.Builder.DefaultFilesExtensions.UseDefaultFiles%2A> method.

<xref:Microsoft.AspNetCore.Builder.DefaultFilesExtensions.UseDefaultFiles%2A> is a URL rewriter that doesn't serve the file. In the request processing pipeline before the existing call to either <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> (.NET 9 or later) or <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> (.NET 8 or earlier):

```csharp
app.UseDefaultFiles();
```

With <xref:Microsoft.AspNetCore.Builder.DefaultFilesExtensions.UseDefaultFiles%2A>, requests to a folder in `wwwroot` search for:

* `default.htm`
* `default.html`
* `index.htm`
* `index.html`

The first file found from the list is served as though the request included the file's name. The browser URL continues to reflect the URI requested.

The following code changes the default file name to `default-document.html`:

```csharp
var options = new DefaultFilesOptions();
options.DefaultFileNames.Clear();
options.DefaultFileNames.Add("default-document.html");
app.UseDefaultFiles(options);
```

## Combine static files, default documents, and directory browsing

<xref:Microsoft.AspNetCore.Builder.FileServerExtensions.UseFileServer%2A> combines the functionality of <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>, <xref:Microsoft.AspNetCore.Builder.DefaultFilesExtensions.UseDefaultFiles%2A>, and optionally <xref:Microsoft.AspNetCore.Builder.DirectoryBrowserExtensions.UseDirectoryBrowser%2A>.

In the request processing pipeline after the existing call to either <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> (.NET 9 or later) or <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> (.NET 8 or earlier), call <xref:Microsoft.AspNetCore.Builder.FileServerExtensions.UseFileServer%2A> to enable the serving of static files and the default file:

```csharp
app.UseFileServer();
```

Directory browsing isn't enabled for the preceding example.

The following code enables the serving of static files, the default file, and directory browsing.

:::moniker range=">= aspnetcore-6.0"

Service registration:

```csharp
builder.Services.AddDirectoryBrowser();
```

In the request processing pipeline after the existing call to <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>:

```csharp
app.UseFileServer(enableDirectoryBrowsing: true);
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.ConfigureServices`:

```csharp
services.AddDirectoryBrowser();
```

In `Startup.Configure` after the existing call to <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>:

```csharp
app.UseFileServer(enableDirectoryBrowsing: true);
```

:::moniker-end

For the host address (`/`), <xref:Microsoft.AspNetCore.Builder.FileServerExtensions.UseFileServer%2A> returns the default HTML document before the default Razor Page (`Pages/Index.cshtml`) or default MVC view (`Home/Index.cshtml`).

Consider the following directory hierarchy:

* `wwwroot`
  * `css`
  * `images`
  * `js`
* `ExtraStaticFiles`
  * `images`
    * `logo.png`
  * `default.html`

The following code enables the serving of static files, the default file, and directory browsing of `ExtraStaticFiles`.

:::moniker range=">= aspnetcore-6.0"

Namespaces for the following API:

```csharp
using Microsoft.Extensions.FileProviders;
```

Service registration:

```csharp
builder.Services.AddDirectoryBrowser();
```

In the request processing pipeline after the existing call to <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>:

```csharp
app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "ExtraStaticFiles")),
    RequestPath = "/static-files",
    EnableDirectoryBrowsing = true
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Namespaces for the following API:

```csharp
using Microsoft.Extensions.FileProviders;
using System.IO;
```

In `Startup.ConfigureServices`:

```csharp
services.AddDirectoryBrowser();
```

In `Startup.Configure` after the existing call to <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>:

```csharp
app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(env.ContentRootPath, "ExtraStaticFiles")),
    RequestPath = "/static-files",
    EnableDirectoryBrowsing = true
});
```

:::moniker-end

<xref:Microsoft.Extensions.DependencyInjection.DirectoryBrowserServiceExtensions.AddDirectoryBrowser%2A> must be called when the `EnableDirectoryBrowsing` property value is `true`.

Using the preceding file hierarchy and code, URLs resolve as shown in the following table (the `{HOST}` placeholder is the host).

| URI | Response file |
| --- | --- |
| `https://{HOST}/static-files/images/logo.png` | `ExtraStaticFiles/images/logo.png` |
| `https://{HOST}/static-files` | `ExtraStaticFiles/default.html` |

If no default-named file exists in the `ExtraStaticFiles` directory, `https://{HOST}/static-files` returns the directory listing with clickable links, where the `{HOST}` placeholder is the host.

<xref:Microsoft.AspNetCore.Builder.DefaultFilesExtensions.UseDefaultFiles%2A> and <xref:Microsoft.AspNetCore.Builder.DirectoryBrowserExtensions.UseDirectoryBrowser%2A> perform a client-side redirect from the target URI without a trailing `/` to the target URI with a trailing `/`. For example, from `https://{HOST}/static-files` (no trailing `/`) to `https://{HOST}/static-files/` (includes a trailing `/`). Relative URLs within the `ExtraStaticFiles` directory are invalid without a trailing slash (`/`) unless the <xref:Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions.RedirectToAppendTrailingSlash> option of <xref:Microsoft.AspNetCore.Builder.DefaultFilesOptions> is used.

## Map file extensions to MIME types

:::moniker range="< aspnetcore-8.0"

> [!NOTE]
> For guidance that applies to Blazor apps, see <xref:blazor/fundamentals/static-files#file-mappings-and-static-file-options>.

:::moniker-end

Use <xref:Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider.Mappings%2A?displayProperty=nameWithType> to add or modify file extension to MIME content type mappings. In the following example, several file extensions are mapped to known MIME types. The `.rtf` extension is replaced, and `.mp4` is removed:

:::moniker range=">= aspnetcore-6.0"

```csharp
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

...

// Set up custom content types - associating file extension to MIME type
var provider = new FileExtensionContentTypeProvider();
// Add new mappings
provider.Mappings[".myapp"] = "application/x-msdownload";
provider.Mappings[".htm3"] = "text/html";
provider.Mappings[".image"] = "image/png";
// Replace an existing mapping
provider.Mappings[".rtf"] = "application/x-msdownload";
// Remove MP4 videos
provider.Mappings.Remove(".mp4");

app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});
```

When you have several static file options to configure, you can alternatively set the provider using <xref:Microsoft.AspNetCore.Builder.StaticFileOptions>:

```csharp
var provider = new FileExtensionContentTypeProvider();

...

builder.Services.Configure<StaticFileOptions>(options =>
{
    options.ContentTypeProvider = provider;
});

app.UseStaticFiles();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.Configure`:

```csharp
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using System.IO;

...

// Set up custom content types - associating file extension to MIME type
var provider = new FileExtensionContentTypeProvider();
// Add new mappings
provider.Mappings[".myapp"] = "application/x-msdownload";
provider.Mappings[".htm3"] = "text/html";
provider.Mappings[".image"] = "image/png";
// Replace an existing mapping
provider.Mappings[".rtf"] = "application/x-msdownload";
// Remove MP4 videos
provider.Mappings.Remove(".mp4");

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(env.WebRootPath, "images")),
    RequestPath = "/images",
    ContentTypeProvider = provider
});

app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(env.WebRootPath, "images")),
    RequestPath = "/images"
});
```

:::moniker-end

For more information, see [MIME content types](https://www.iana.org/assignments/media-types/media-types.xhtml).

## Non-standard content types

The Static File Middleware understands almost 400 known file content types. If the user requests a file with an unknown file type, the Static File Middleware passes the request to the next middleware in the pipeline. If no middleware handles the request, a *404 Not Found* response is returned. If directory browsing is enabled, a link to the file is displayed in a directory listing.

The following code enables serving unknown content types and renders the unknown file as an image:

```csharp
app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true,
    DefaultContentType = "image/png"
});
```

With the preceding code, a request for a file with an unknown content type is returned as an image.

> [!WARNING]
> Enabling <xref:Microsoft.AspNetCore.Builder.StaticFileOptions.ServeUnknownFileTypes> is a security risk. It's disabled by default, and its use is discouraged. [Map file extensions to MIME types](#map-file-extensions-to-mime-types) provides a safer alternative to serving files with non-standard extensions.

:::moniker range=">= aspnetcore-9.0"

## Provide a custom static files manifest

If [`staticAssetsManifestPath`](xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A) is `null`, the <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ApplicationName%2A?displayProperty=nameWithType> is used to locate the manifest. Alternatively, specify a full path to the manifest file. If a relative path is used, the framework searches for the file in the <xref:System.AppContext.BaseDirectory%2A?displayProperty=nameWithType>.

:::moniker-end

## Security considerations for static files

> [!WARNING]
> <xref:Microsoft.AspNetCore.Builder.DirectoryBrowserExtensions.UseDirectoryBrowser%2A> and <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> can leak secrets. Disabling directory browsing in production is highly recommended. Carefully review which directories are enabled via <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> or <xref:Microsoft.AspNetCore.Builder.DirectoryBrowserExtensions.UseDirectoryBrowser%2A>. The entire directory and its sub-directories become publicly accessible. Store files suitable for serving to the public in a dedicated directory, such as `<content_root>/wwwroot`. Separate these files from MVC views, Razor Pages, configuration files, etc.

* The URLs for content exposed with <xref:Microsoft.AspNetCore.Builder.DirectoryBrowserExtensions.UseDirectoryBrowser%2A> and <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> are subject to the case sensitivity and character restrictions of the underlying file system. For example, Windows is case insensitive, but macOS and Linux aren't.

* ASP.NET Core apps hosted in IIS use the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module) to forward all requests to the app, including static file requests. The IIS static file handler isn't used and has no chance to handle requests.

* Complete the following steps in IIS Manager to remove the IIS static file handler at the server or website level:

  1. Navigate to the **Modules** feature.
  1. Select **StaticFileModule** in the list.
  1. Click **Remove** in the **Actions** sidebar.

> [!WARNING]
> If the IIS static file handler is enabled **and** the ASP.NET Core Module is configured incorrectly, static files are served. This happens, for example, if the `web.config` file isn't deployed.

* Place code files, including `.cs` and `.cshtml`, outside of the app project's [web root](xref:fundamentals/index#web-root). A logical separation is therefore created between the app's client-side content and server-based code. This prevents server-side code from being leaked.

## MSBuild properties

The following tables show the static files MSBuild properties and metadata descriptions.

Property | Description
--- | ---
`EnableDefaultCompressedItems` | Enables default compression include/exclude patterns.
`CompressionIncludePatterns` | Semicolon-separated list of file patterns to include for compression.
`CompressionExcludePatterns` | Semicolon-separated list of file patterns to exclude from compression.
`EnableDefaultCompressionFormats` | Enables default compression formats (Gzip and Brotli).
`BuildCompressionFormats` | Compression formats to use during build.
`PublishCompressionFormats` | Compression formats to use during publish.
`DisableBuildCompression` | Disables compression during build.
`CompressDiscoveredAssetsDuringBuild` | Compresses discovered assets during build.
`BrotliCompressionLevel` | Compression level for the Brotli algorithm.
`LinkAlternativeRepresentationsToOriginalResource` | How to link compressed assets to original resources.
`StaticWebAssetBuildCompressAllAssets` | Compresses all assets during build, not just assets discovered or computed during a build.
`StaticWebAssetPublishCompressAllAssets` | Compresses all assets during publish, not just assets discovered or computed during a build.

Property | Description
--- | ---
`StaticWebAssetBasePath` | Base URL path for all the assets in a library.
`StaticWebAssetsFingerprintContent` | Enables content fingerprinting for cache busting.
`StaticWebAssetFingerprintingEnabled` | Enables fingerprinting feature for static web assets.
`StaticWebAssetsCacheDefineStaticWebAssetsEnabled` | Enables caching for static web asset definitions.
`StaticWebAssetBuildManifestPath` | Path to the build manifest JSON file.
`StaticWebAssetsBuildManifestCacheFilePath` | Path to the build manifest cache file.
`StaticWebAssetEndpointExclusionPattern` | Pattern for excluding endpoints.

Item group | Description | Metadata
--- | ---
`StaticWebAssetContentTypeMapping` | Maps file patterns to content types and cache headers for endpoints. | Pattern, Cache
`StaticWebAssetFingerprintPattern` | Defines patterns for applying fingerprints to static web assets for cache busting. | Pattern, Expression

Metadata Descriptions:

* **Pattern**: A glob pattern used to match files. For `StaticWebAssetContentTypeMapping`, it matches files to determine their content type (for example, `*.js` for JavaScript files). For `StaticWebAssetFingerprintPattern`, it identifies multi-extension files that require special fingerprinting treatment (for example, `*.lib.module.js`).

* **Cache**: Specifies the `Cache-Control` header value for the matched content type. This controls browser caching behavior (for example, `max-age=3600, must-revalidate` for media files).

* **Expression**: Defines how the fingerprint is inserted into the filename. The default is `#[.{fingerprint}]`, which inserts the fingerprint before the extension.

The following table describes the runtime configuration options.

Configuration key | Description
--- | ---
`ReloadStaticAssetsAtRuntime` | Enables dev-time hot reloading of static assets: serves modified web root (`wwwroot`) files (recomputes `ETag`, recompresses if required) instead of build-time manifest versions. Defaults to enabled only when serving a build manifest unless explicitly set.
`DisableStaticAssetNotFoundRuntimeFallback` | When `true`, suppresses the fallback endpoint that serves newly added files not present in the build manifest. When `false` or absent, a file-exists-checked `{**path}` fallback (GET/HEAD) logs a warning and serves the file with a computed `ETag`.
`EnableStaticAssetsDevelopmentCaching` | When `true`, preserves the original `Cache-Control` headers on asset descriptors. When `false` or absent, rewrites `Cache-Control` headers to `no-cache` to avoid aggressive client caching during development.
`EnableStaticAssetsDevelopmentIntegrity` | When `true`, keeps integrity properties on asset descriptors. When `false` or absent, removes any integrity property to prevent mismatches when files change during development.

## Additional resources

* <xref:blazor/fundamentals/static-files>
* <xref:fundamentals/middleware/index>
