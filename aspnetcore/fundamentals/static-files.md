---
title: Static files in ASP.NET Core
author: wadepickett
description: Learn how to serve and secure static files and configure Static Files Middleware behaviors in an ASP.NET Core web app.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 08/06/2025
uid: fundamentals/static-files
---
# Static files in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

Static files, also called static assets, are files an ASP.NET Core app that aren't dynamically generated and served directly to clients on request, such as HTML, CSS, image, and JavaScript files.

For Blazor static files guidance, which adds to or supersedes the guidance in this article, see <xref:blazor/fundamentals/static-files>.

:::moniker range=">= aspnetcore-9.0"

### Map Static Assets routing endpoint conventions (`MapStaticAssets`)

Creating performant web apps requires optimizing asset delivery to the browser. Possible optimizations with <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> include:

* Serve a given asset once until the file changes or the browser clears its cache. Set the [`ETag`](https://developer.mozilla.org/docs/Web/HTTP/Headers/ETag) and [Last-Modified](https://developer.mozilla.org/docs/Web/HTTP/Headers/Last-Modified) headers.
* Prevent the browser from using old or stale assets after an app is updated. Set the [`Last-Modified`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Last-Modified) header.
* Set appropriate [caching headers](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control) on the response.
* Use [Caching Middleware](xref:performance/caching/middleware).
* Serve [compressed](/aspnet/core/performance/response-compression) versions of the assets when possible. This optimization doesn't include minification.
* Use a [CDN](/microsoft-365/enterprise/content-delivery-networks?view=o365-worldwide&preserve-view=true) to serve the assets closer to the user.
* [Fingerprinting assets](https://wikipedia.org/wiki/Fingerprint_(computing)) to prevent reusing old versions of files.

`MapStaticAssets`:

* Integrates the information gathered about static web assets during the build and publish process with a runtime library that processes this information to optimize file serving to the browser.
* Are routing endpoint conventions that optimize the delivery of static assets in an app. It's designed to work with all UI frameworks, including Blazor, Razor Pages, and MVC.

### `MapStaticAssets` versus `UseStaticFiles`

<xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> is available in ASP.NET Core in .NET 9 or later. <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> must be used in versions prior to .NET 9.

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

* [Serve files outside of the web root directory](#serve-files-outside-of-the-web-root-directory)
* [Set HTTP response headers](#set-http-response-headers)



* [Serving files from disk or embedded resources, or other locations](#serve-files-from-multiple-locations) <!-- -->

* [Directory browsing](#directory-browsing) <!-- -->
* [Serve default documents](#serve-default-documents) <!-- -->
* [`FileExtensionContentTypeProvider`](#fileextensioncontenttypeprovider) <!-- -->
* [Serve files from multiple locations](#serve-files-from-multiple-locations) <!-- HERE! -->

:::moniker-end

### Serve files in the web root directory

By default, static files are stored within the project's [web root](xref:fundamentals/index#web-root) directory. The default directory is `{CONTENT ROOT}/wwwroot`, where the `{CONTENT ROOT}` placeholder is the app's [content root](xref:fundamentals/index#content-root). Use the <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseWebRoot%2A> method if you want to change the web root. For more information, see <xref:fundamentals/index#web-root>.

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

Call <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> in the app's request processing pipeline to enable serving static files from the app's [web root](xref:fundamentals/index#web-root):

```csharp
app.MapStaticAssets();
```

:::moniker-end

:::moniker range="< aspnetcore-9.0"

Call <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> in the app's request processing pipeline to enable serving static files from the app's [web root](xref:fundamentals/index#web-root):

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

### Serve files outside of the web root directory

Consider the following directory hierarchy with static files residing outside of the app's [web root](xref:fundamentals/index#web-root) in a folder named `ExtraStaticFiles`:

* `wwwroot`
  * `css`
  * `images`
  * `js`
* `ExtraStaticFiles`
  * `images`
    * `red-rose.jpg`

A request can access `red-rose.jpg` by configuring a new instance of Static File Middleware:

```csharp
using Microsoft.Extensions.FileProviders;

...

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "ExtraStaticFiles")),
    RequestPath = "/static-files"
});
```

In the preceding code, the `ExtraStaticFiles` directory hierarchy is exposed publicly via the `StaticFiles` URL segment. A request to `https://{HOST}/StaticFiles/images/red-rose.jpg`, where the `{HOST}` placeholder is the host, serves the `red-rose.jpg` file.

The following markup references `ExtraStaticFiles/images/red-rose.jpg`:

```html
<img src="static-files/images/red-rose.jpg" alt="A red rose" />
```

For the preceding example, tilde-slash notation is supported in Razor Pages and MVC views (`src="~/StaticFiles/images/red-rose.jpg"`), not for Razor components in Blazor apps.

### Set HTTP response headers

Use <xref:Microsoft.AspNetCore.Builder.StaticFileOptions> to set HTTP response headers. In addition to configuring Static File Middleware to serve static files, the following code sets the [`Cache-Control` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control) to 604,800 seconds (one week):

```csharp
using Microsoft.AspNetCore.Http;

...

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append(
            "Cache-Control", "public, max-age=604800");
    }
});
```

## Static file authorization

:::moniker range=">= aspnetcore-9.0"

The ASP.NET Core templates call <xref:Microsoft.AspNetCore.Builder.StaticAssetsEndpointRouteBuilderExtensions.MapStaticAssets%2A> before calling <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>. Most apps follow this pattern. When `MapStaticAssets` is called before the authorization middleware:

:::moniker-end

:::moniker range="< aspnetcore-9.0"

The ASP.NET Core templates call <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> before calling <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>. Most apps follow this pattern. When the Static File Middleware is called before the authorization middleware:

:::moniker-end

* No authorization checks are performed on the static files.
* Static files served by the Static File Middleware, such as those under `wwwroot`, are publicly accessible.

The ASP.NET Core templates call <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> before calling <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>. Most apps follow this pattern. When the Static File Middleware is called before the authorization middleware:

* No authorization checks are performed on the static files.
* Static files served by the Static File Middleware, such as those under `wwwroot`, are publicly accessible.
  
To serve static files based on authorization:

* Store them outside of `wwwroot`.
* Call `UseStaticFiles`, specifying a path, after calling `UseAuthorization`.
* Set the [fallback authorization policy](xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.FallbackPolicy).

:::moniker range=">= aspnetcore-6.0"

```csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.FileProviders;
...

var builder = WebApplication.CreateBuilder(args);

...

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

...

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "MyStaticFiles")),
    RequestPath = "/StaticFiles"
});

...
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.ConfigureServices`:

```csharp
services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
```

In `Startup.Configure`:

```csharp
app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "ExtraStaticFiles")),
    RequestPath = "/static-files"
});
```

:::moniker-end

In the preceding code, the fallback authorization policy requires ***all*** users to be authenticated. Endpoints such as controllers, Razor Pages, etc that specify their own authorization requirements don't use the fallback authorization policy. For example, Razor Pages, controllers, or action methods with `[AllowAnonymous]` or `[Authorize(PolicyName="MyPolicy")]` use the applied authorization attribute rather than the fallback authorization policy.

<xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAuthenticatedUser%2A> adds <xref:Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement> to the current instance, which enforces that the current user is authenticated.

Static assets under `wwwroot` are publicly accessible because the default Static File Middleware (`app.UseStaticFiles();`) is called before `UseAuthentication`. Static assets in the *ExtraStaticFiles* folder require authentication.

An alternative approach to serve files based on authorization is to:

* Store them outside of `wwwroot` and any directory accessible to the Static File Middleware.
* Serve them via an action method to which authorization is applied and return a <xref:Microsoft.AspNetCore.Mvc.FileResult> object:

From a Razor page (`Pages/BannerImage.cshtml.cs`):

```csharp
public class BannerImageModel : PageModel
{
    private readonly IWebHostEnvironment _env;

    public BannerImageModel(IWebHostEnvironment env) => _env = env;

    public PhysicalFileResult OnGet()
    {
        var filePath = Path.Combine(
            _env.ContentRootPath, "ExtraStaticFiles", "images", "red-rose.jpg");

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
        _env.ContentRootPath, "ExtraStaticFiles", "images", "red-rose.jpg");

    return PhysicalFile(filePath, "image/jpeg");
}
```

The preceding approach requires a page or endpoint per file.

:::moniker range=">= aspnetcore-8.0"

The following code returns files for authenticated users:

```csharp
builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("AuthenticatedUsers", b => b.RequireAuthenticatedUser());
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

The following code uploads files for authenticated users:

```csharp
builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("AdminsOnly", b => b.RequireRole("admin"));
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

:::moniker range=">= aspnetcore-6.0"

## Serve files outside wwwroot by updating `IWebHostEnvironment.WebRootPath`

When <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootPath%2A?displayProperty=nameWithType> is set to a folder other than `wwwroot`, the following default behaviors are exhibited:

* In the development environment, static assets are served from `wwwroot` if assets with the same name are in both `wwwroot` and a different folder assigned to `IWebHostEnvironment.WebRootPath`.
* In any environment other than development, duplicate static assets are served from the `IWebHostEnvironment.WebRootPath` folder.

Consider a web app created from the empty web template:

* Containing an `Index.html` file in `wwwroot` and `wwwroot-custom`.
* With the following updated `Program.cs` file that sets `WebRootPath = "wwwroot-custom"`:

```csharp
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    // Look for static files in "wwwroot-custom"
    WebRootPath = "wwwroot-custom"
});

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

app.Run();
```

By default, requests to `/`:

* In the development environment, `wwwroot/Index.html` is returned.
* In any environment other than development, `wwwroot-custom/Index.html` is returned.

To ensure assets from `wwwroot-custom` are always returned, use ***one*** of the following approaches:

* Delete duplicate-named assets in `wwwroot`.

* Set `"ASPNETCORE_ENVIRONMENT"` in `Properties/launchSettings.json` to any value other than `Development`.

* Disable static web assets by setting `<StaticWebAssetsEnabled>` to `false` in the app's project file. ***WARNING:*** Disabling static web assets disables [Razor class libraries](xref:razor-pages/ui-class).

* Add the following XML to the project file:

  ```xml
  <ItemGroup>
      <Content Remove="wwwroot\**" />
  </ItemGroup>
  ```

The following code updates `IWebHostEnvironment.WebRootPath` to a non-Development value (`Staging`), guaranteeing duplicate content is returned from `wwwroot-custom` rather than `wwwroot`:

```csharp
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    EnvironmentName = Environments.Staging,
    WebRootPath = "wwwroot-custom"
});
```

When developing a server-side Blazor app and testing locally, see <xref:blazor/fundamentals/static-files#static-files-in-non-development-environments>.

:::moniker-end

## Serve files from multiple locations

:::moniker range=">= aspnetcore-6.0"

*The guidance in this section applies to Razor Pages and MVC apps. For guidance that applies to Blazor Web Apps, see <xref:blazor/fundamentals/static-files#serve-files-from-multiple-locations>.*

Consider the following Razor page which displays the `/ExtraStaticFiles/image3.png` file:

```html
<img src="~/image3.png" class="img" asp-append-version="true" alt="Test">
```

`UseStaticFiles` and `UseFileServer` default to the file provider pointing at `wwwroot`. Additional instances of `UseStaticFiles` and `UseFileServer` can be provided with other file providers to serve files from other locations. The following example calls `UseStaticFiles` twice to serve files from both `wwwroot` and `ExtraStaticFiles`:

```csharp
app.UseStaticFiles(); // Serve files from wwwroot
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "ExtraStaticFiles"))
});
```

Using the preceding code:

* The `/ExtraStaticFiles/image3.png` file is displayed.
* [Image Tag Helpers](xref:mvc/views/tag-helpers/builtin-th/image-tag-helper) (<xref:Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper.AppendVersion>) aren't applied because Tag Helpers depend on <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootFileProvider>. `WebRootFileProvider` hasn't been updated to include the `ExtraStaticFiles` folder.

The following code updates the `WebRootFileProvider`, which enables the Image Tag Helper to provide a version:

```csharp
using Microsoft.Extensions.FileProviders;

...

var webRootProvider = new PhysicalFileProvider(builder.Environment.WebRootPath);
var newPathProvider = new PhysicalFileProvider(
    Path.Combine(builder.Environment.ContentRootPath, "ExtraStaticFiles"));

var compositeProvider = new CompositeFileProvider(webRootProvider, newPathProvider);

// Update the default provider.
app.Environment.WebRootFileProvider = compositeProvider;

app.MapStaticAssets();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

`UseStaticFiles` and `UseFileServer` default to the file provider pointing at `wwwroot`. Additional instances of `UseStaticFiles` and `UseFileServer` can be provided with other file providers to serve files from other locations. For more information, see [this GitHub issue](https://github.com/dotnet/AspNetCore.Docs/issues/15578).

:::moniker-end




















## Additional resources

* <xref:fundamentals/middleware/index>
