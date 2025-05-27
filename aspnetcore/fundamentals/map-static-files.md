---
title: Map static files in ASP.NET Core
author: rick-anderson
description: Learn how to serve and secure mapped static files and configure static file hosting middleware behaviors in an ASP.NET Core web app.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 3/18/2025
uid: fundamentals/map-static-files
---
# Map static files in ASP.NET Core

:::moniker range=">= aspnetcore-9.0"

By [Rick Anderson](https://twitter.com/RickAndMSFT)

Static files, such as HTML, CSS, images, and JavaScript, are assets an ASP.NET Core app serves directly to clients by default.

For Blazor static files guidance, which adds to or supersedes the guidance in this article, see <xref:blazor/fundamentals/static-files>.

## Serve static files

Static files are stored within the project's [web root](xref:fundamentals/index#web-root) directory. The default directory is `{content root}/wwwroot`, but it can be changed with the <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseWebRoot%2A> method. For more information, see [Content root](xref:fundamentals/index#content-root) and [Web root](xref:fundamentals/index#web-root).

The <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A> method sets the content root to the current directory:

[!code-csharp[](~/fundamentals/static-files/samples/9.x/StaticFilesSample/Program.cs?name=snippet&highlight=1,15)]

Static files are accessible via a path relative to the [web root](xref:fundamentals/index#web-root). For example, the **Web Application** project templates contain several folders within the `wwwroot` folder:

* `wwwroot`
  * `css`
  * `js`
  * `lib`

Consider an app with the `wwwroot/images/MyImage.jpg` file. The URI format to access a file in the `images` folder is `https://<hostname>/images/<image_file_name>`. For example, `https://localhost:5001/images/MyImage.jpg`

### Map Static Assets routing endpoint conventions (`MapStaticAssets`)

Creating performant web apps requires optimizing asset delivery to the browser. Possible optimizations with <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> include:

* Serve a given asset once until the file changes or the browser clears its cache. Set the [ETag](https://developer.mozilla.org/docs/Web/HTTP/Headers/ETag) and [Last-Modified](https://developer.mozilla.org/docs/Web/HTTP/Headers/Last-Modified) headers.
* Prevent the browser from using old or stale assets after an app is updated. Set the [Last-Modified](https://developer.mozilla.org/docs/Web/HTTP/Headers/Last-Modified) header.
* Set up proper [caching headers](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control).
* Use [Caching Middleware](xref:performance/caching/middleware).
* Serve [compressed](/aspnet/core/performance/response-compression) versions of the assets when possible. This optimization doesn't include minification.
* Use a [CDN](/microsoft-365/enterprise/content-delivery-networks?view=o365-worldwide&preserve-view=true) to serve the assets closer to the user.
* [Fingerprinting assets](https://en.wikipedia.org/wiki/Fingerprint_(computing)) to prevent reusing old versions of files.

`MapStaticAssets`:

* Integrates the information gathered about static web assets during the build and publish process with a runtime library that processes this information to optimize file serving to the browser.
* Are routing endpoint conventions that optimize the delivery of static assets in an app. It's designed to work with all UI frameworks, including Blazor, Razor Pages, and MVC.

### `MapStaticAssets` versus `UseStaticFiles`

<xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> is available in ASP.NET Core in .NET 9 and later. <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> must be used in versions prior to .NET 9.

`UseStaticFiles` serves static files, but it doesn't provide the same level of optimization as `MapStaticAssets`. `MapStaticAssets` is optimized for serving assets that the app has knowledge of at runtime. If the app serves assets from other locations, such as disk or embedded resources, `UseStaticFiles` should be used.

Map Static Assets provides the following benefits that aren't available when calling `UseStaticFiles`:

* Build-time compression for all the assets in the app, including JavaScript (JS) and stylesheets but excluding image and font assets that are already compressed. [Gzip](https://tools.ietf.org/html/rfc1952) (`Content-Encoding: gz`) compression is used during development. Gzip with [Brotli](https://tools.ietf.org/html/rfc7932) (`Content-Encoding: br`) compression is used during publish.
* [Fingerprinting](https://developer.mozilla.org/docs/Glossary/Fingerprinting) for all assets at build time with a [Base64](https://developer.mozilla.org/docs/Glossary/Base64)-encoded string of the [SHA-256](xref:System.Security.Cryptography.SHA256) hash of each file's content. This prevents reusing an old version of a file, even if the old file is cached. Fingerprinted assets are cached using the [`immutable` directive](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control#directives), which results in the browser never requesting the asset again until it changes. For browsers that don't support the `immutable` directive, a [`max-age` directive](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control#directives) is added.
  * Even if an asset isn't fingerprinted, content based `ETags` are generated for each static asset using the fingerprint hash of the file as the `ETag` value. This ensures that the browser only downloads a file if its content changes (or the file is being downloaded for the first time).
  * Internally, the framework maps physical assets to their fingerprints, which allows the app to:
    * Find automatically-generated assets, such as Razor component scoped CSS for Blazor's [CSS isolation feature](xref:blazor/components/css-isolation) and JS assets described by [JS import maps](https://developer.mozilla.org/docs/Web/HTML/Element/script/type/importmap).
    * Generate link tags in the `<head>` content of the page to preload assets.
* During [Visual Studio Hot Reload](/visualstudio/debugger/hot-reload) development testing:
  * Integrity information is removed from the assets to avoid issues when a file is changed while the app is running.
  * Static assets aren't cached to ensure that the browser always retrieves current content.

Map Static Assets doesn't provide features for minification or other file transformations. Minification is usually handled by custom code or [third-party tooling](xref:blazor/fundamentals/index#community-links-to-blazor-resources).

The following features are supported with `UseStaticFiles` but not with `MapStaticAssets`:

* [Serving files from disk or embedded resources, or other locations](xref:fundamentals/static-files#serve-files-from-multiple-locations)
* [Serve files outside of web root](xref:fundamentals/static-files#serve-files-outside-of-web-root)
* [Set HTTP response headers](xref:fundamentals/static-files#set-http-response-headers)
* [Directory browsing](xref:fundamentals/static-files#directory-browsing)
* [Serve default documents](xref:fundamentals/static-files#serve-default-documents)
* [`FileExtensionContentTypeProvider`](xref:fundamentals/static-files#fileextensioncontenttypeprovider)
* [Serve files from multiple locations](xref:fundamentals/static-files#serve-files-from-multiple-locations)
* [Serving files from disk or embedded resources, or other locations](xref:fundamentals/static-files#serve-files-from-multiple-locations)
* [Serve files outside of web root](xref:fundamentals/static-files#serve-files-outside-of-web-root)
* [Set HTTP response headers](xref:fundamentals/static-files#set-http-response-headers)
* [Directory browsing](xref:fundamentals/static-files#directory-browsing)
* [Serve default documents](xref:fundamentals/static-files#serve-default-documents)
* [`FileExtensionContentTypeProvider`](xref:fundamentals/static-files#fileextensioncontenttypeprovider)
* [Serve files from multiple locations](xref:fundamentals/static-files#serve-files-from-multiple-locations)

### Serve files in web root

The default web app templates call the <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> method in `Program.cs`, which enables static files to be served:

[!code-csharp[](~/fundamentals/static-files/samples/9.x/StaticFilesSample/Program.cs?name=snippet&highlight=15)]

The parameterless `MapStaticAssets` method overload marks the files in [web root](xref:fundamentals/index#web-root) as servable. The following markup references `wwwroot/images/MyImage.jpg`:

```html
<img src="~/images/MyImage.jpg" class="img" alt="My image" />
```

In the preceding markup, the tilde character `~` points to the [web root](xref:fundamentals/index#web-root).

### Serve files outside of web root

Consider a directory hierarchy in which the static files to be served reside outside of the [web root](xref:fundamentals/index#web-root):

* `wwwroot`
  * `css`
  * `images`
  * `js`
* `MyStaticFiles`
  * `images`
    * `red-rose.jpg`

A request can access the `red-rose.jpg` file by configuring the Static File Middleware as follows:

[!code-csharp[](~/fundamentals/static-files/samples/9.x/StaticFilesSample/Program.cs?name=snippet_rr&highlight=1,18-23)]

In the preceding code, the *MyStaticFiles* directory hierarchy is exposed publicly via the *StaticFiles* URI segment. A request to `https://<hostname>/StaticFiles/images/red-rose.jpg` serves the `red-rose.jpg` file.

The following markup references `MyStaticFiles/images/red-rose.jpg`:
<!-- zz test via /Home2/MyStaticFilesRR -->
[!code-html[](~/fundamentals/static-files/samples/9.x/StaticFilesSample/Views/Home2/MyStaticFilesRR.cshtml?range=1)]

To serve files from multiple locations, see [Serve files from multiple locations](xref:fundamentals/static-files#serve-files-from-multiple-locations).

### Set HTTP response headers

A <xref:Microsoft.AspNetCore.Builder.StaticFileOptions> object can be used to set HTTP response headers. In addition to configuring static file serving from the [web root](xref:fundamentals/index#web-root), the following code sets the [Cache-Control](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control) header:

[!code-csharp[](~/fundamentals/static-files/samples/9.x/StaticFilesSample/Program.cs?name=snippet_rh&highlight=16-24)]

The preceding code makes static files publicly available in the local cache for one week.

## Static file authorization

The ASP.NET Core templates call <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> before calling <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>. Most apps follow this pattern. When `MapStaticAssets` is called before the authorization middleware:

  * No authorization checks are performed on the static files.
  * Static files served by the Static File Middleware, such as those under `wwwroot`, are publicly accessible.
  
To serve static files based on authorization, see [Static file authorization](xref:fundamentals/static-files#static-file-authorization).

## Serve files from multiple locations

Consider the following Razor page which displays the `/MyStaticFiles/image3.png` file:

[!code-cshtml[](~/fundamentals/static-files/samples/9.x/StaticFilesSample/Pages/Test.cshtml?highlight=5)]

`UseStaticFiles` and `UseFileServer` default to the file provider pointing at `wwwroot`. Additional instances of `UseStaticFiles` and `UseFileServer` can be provided with other file providers to serve files from other locations. The following example calls `UseStaticFiles` twice to serve files from both `wwwroot` and `MyStaticFiles`:

[!code-csharp[](~/fundamentals/static-files/samples/9.x/StaticFilesSample/Program.cs?name=snippet_mul)]

Using the preceding code:

* The `/MyStaticFiles/image3.png` file is displayed.
* The [Image Tag Helpers](xref:mvc/views/tag-helpers/builtin-th/image-tag-helper) <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper.AppendVersion> is not applied because the Tag Helpers depend on <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootFileProvider>. `WebRootFileProvider` has not been updated to include the `MyStaticFiles` folder.

The following code updates the `WebRootFileProvider`, which enables the Image Tag Helper to provide a version:

[!code-csharp[](~/fundamentals/static-files/samples/9.x/StaticFilesSample/Program.cs?name=snippet_mult2)]

> [!NOTE]
> The preceding approach applies to Razor Pages and MVC apps. For guidance that applies to Blazor Web Apps, see <xref:blazor/fundamentals/static-files#serve-files-from-multiple-locations>.

## Serve files outside wwwroot by updating IWebHostEnvironment.WebRootPath

When <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootPath%2A?displayProperty=nameWithType> is set to a folder other than `wwwroot`:

* In the development environment, static assets found in both `wwwroot` and the updated `IWebHostEnvironment.WebRootPath` are served from `wwwroot`.
* In any environment other than development, duplicate static assets are served from the updated `IWebHostEnvironment.WebRootPath` folder.

Consider a web app created with the empty web template:

* Containing an `Index.html` file in `wwwroot` and `wwwroot-custom`.
* With the following updated `Program.cs` file that sets `WebRootPath = "wwwroot-custom"`:

  [!code-csharp[](~/fundamentals/static-files/samples/9.x/WebRoot/Program.cs?name=snippet1)]

In the preceding code, requests to `/`:

* In the development environment return `wwwroot/Index.html`
* In any environment other than development return `wwwroot-custom/Index.html`

To ensure assets from `wwwroot-custom` are returned, use one of the following approaches:

* Delete duplicate named assets in `wwwroot`.
* Set `"ASPNETCORE_ENVIRONMENT"` in `Properties/launchSettings.json` to any value other than `"Development"`.
* Completely disable static web assets by setting `<StaticWebAssetsEnabled>false</StaticWebAssetsEnabled>` in the project file. ***WARNING, disabling static web assets disables [Razor Class Libraries](xref:razor-pages/ui-class)***.
* Add the following XML to the project file:

  ```xml
  <ItemGroup>
	  <Content Remove="wwwroot\**" />
  </ItemGroup>
  ```

The following code updates `IWebHostEnvironment.WebRootPath` to a non development value, guaranteeing duplicate content is returned from `wwwroot-custom` rather than `wwwroot`:

[!code-csharp[](~/fundamentals/static-files/samples/9.x/WebRoot/Program.cs?name=snippet2&highlight=5)]

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/static-files/samples) ([how to download](xref:index#how-to-download-a-sample))
* [Middleware](xref:fundamentals/middleware/index)
* [Introduction to ASP.NET Core](xref:index)
* <xref:blazor/file-uploads>
* <xref:blazor/file-downloads>

:::moniker-end
