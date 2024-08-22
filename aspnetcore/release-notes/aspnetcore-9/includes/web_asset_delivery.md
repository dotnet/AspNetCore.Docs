### Optimizing static web asset delivery

Following production best practices for serving static assets requires a significant amount of work and technical expertise. Without optimizations like compression, caching, and [fingerprints](https://en.wikipedia.org/wiki/Fingerprint_(computing)):

* The browser has to make additional requests on every page load.
* More bytes than necessary are transferred through the network.
* Sometimes stale versions of files are served to clients.

Creating performant web apps requires optimizing asset delivery to the browser. Possible optimizations include:

* Serve a given asset once until the file changes or the browser clears its cache. Set the [ETag](https://developer.mozilla.org/docs/Web/HTTP/Headers/ETag) header.
* Prevent the browser from using old or stale assets after an app is updated. Set the [Last-Modified](https://developer.mozilla.org/docs/Web/HTTP/Headers/Last-Modified) header.
* Set up proper [caching headers](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control).
* Use [caching middleware](xref:performance/caching/middleware).
* Serve [compressed](/aspnet/core/performance/response-compression) versions of the assets when possible.
* Use a [CDN](/microsoft-365/enterprise/content-delivery-networks?view=o365-worldwide&preserve-view=true) to serve the assets closer to the user.
* Minimize the size of assets served to the browser. This optimization doesn't include minification.

[`MapStaticAssets`](/dotnet/api/microsoft.aspnetcore.builder.staticassetsendpointroutebuilderextensions.mapstaticassets) is a new middleware that helps optimize the delivery of static assets in an app. It's designed to work with all UI frameworks, including Blazor, Razor Pages, and MVC. It's typically a drop-in replacement for [UseStaticFiles](/dotnet/api/microsoft.aspnetcore.builder.staticfileextensions.usestaticfiles):

```diff
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

+app.MapStaticAssets();
-app.UseStaticFiles();
app.MapRazorPages();

app.Run();
```

`MapStaticAssets` operates by combining build and publish-time processes to collect information about all the static resources in an app. This information is then utilized by the runtime library to efficiently serve these files to the browser.

`MapStaticAssets` can replace [`UseStaticFiles`](/dotnet/api/microsoft.aspnetcore.builder.staticfileextensions.usestaticfiles) in most situations, however, it's optimized for serving the assets that the app has knowledge of at build and publish time. If the app serves assets from other locations, such as disk or embedded resources, `UseStaticFiles` should be used.

`MapStaticAssets` provides the following benefits not found with `UseStaticFiles`:

* Build time compression for all the assets in the app:
  * `gzip` during development and `gzip + brotli` during publish.
  * All assets are compressed with the goal of reducing the size of the assets to the minimum.
* Content based `ETags`: The `Etags` for each resource are the [Base64](https://developer.mozilla.org/docs/Glossary/Base64) encoded string of the [SHA-256](/dotnet/api/system.security.cryptography.sha256?view=net-8.0&preserve-view=true) hash of the content. This ensures that the browser only redownloads a file if its contents have changed.

The following table shows the original and compressed sizes of the CSS and JS files in the default Razor Pages template:

File | Original | Compressed | % Reduction
-- | -- | --
bootstrap.min.css | 163 | 17.5 | 89.26%
jquery.js | 89.6 | 28 | 68.75%
bootstrap.min.js | 78.5 | 20 | 74.52%
**Total** | 331.1 | 65.5 | 80.20%

The following table shows the original and compressed sizes using the [Fluent UI Blazor components library](https://www.fluentui-blazor.net/):

File | Original | Compressed | % Reduction
-- | -- | -- | --
fluent.js | 384 | 73 | 80.99%
fluent.css | 94 | 11 | 88.30%
**Total** | 478 | 84 | 82.43%

For a total of 478 KB uncompressed to 84 KB compressed.

The following table shows the original and compressed sizes using the [MudBlazor](https://mudblazor.com) Blazor components library:

File | Original | Compressed | Reduction
-- | -- | -- | --
MudBlazor.min.css | 541 | 37.5 | 93.07%
MudBlazor.min.js | 47.4 | 9.2 | 80.59%
**Total** | 588.4 | 46.7 | 92.07%

Optimization happens automatically when using `MapStaticAssets`. When a library is added or updated, for example with new JavaScript or CSS, the assets are optimized as part of the build. Optimization is especially beneficial to mobile environments that can have a lower bandwidth or an unreliable connections.

For more information on the new file delivery features, see the following resources:

* <xref:fundamentals/static-files?view=aspnetcore-9.0>
* <xref:blazor/fundamentals/static-files?view=aspnetcore-9.0>

### Enabling dynamic compression on the server vs using `MapStaticAssets`

`MapStaticAssets` has the following advantages over dynamic compression on the server:

<!-- 
I'm confused about the following:
If we take MudBlazor as an example, IIS will compress the CSS bundle at around 90Kb, while brotli with max settings will result in 37Kb. That is still a whopping 59% size reduction or 41% of its dynamically compressed size -->

* Is simpler because there is no server specific configuration.
* Is more performant because the assets are compressed at build time. <!-- IIS can do static compression -->
* Allows the developer to spend extra time during the build process to ensure that the assets are the minimum size.

Consider the following table comparing MudBlazor compression with IIS dynamic compression and `MapStaticAssets`:
<!-- MapStaticAssets uses brotli max so it's the same as IIS brotli max is the same as -->

IIS gzip | MapStaticAssets | MapStaticAssets Reduction
-- | -- | --
 &#8773; 90 | 37.5 | 59%

<!--  “always flush” does not work with IIS Brotli AND might degrade Zlib compression ratio. See https://microsoft.sharepoint.com/:p:/r/teams/GlobalDAS/WebApps/_layouts/15/Doc.aspx?sourcedoc=%7BDC4A0B9B-6A27-498F-BC7D-6B6647AAC39F%7D&file=IIS_Compression_new_API.pptx -->
