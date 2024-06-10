## Optimizing static web asset delivery

/en-US
?view=aspnetcore-8.0

Creating performant web apps includes optimizing asset delivery to the browser. This involves many aspects such as:

* Setting the [ETag](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/ETag) and [Last-Modified](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Last-Modified) headers.
* Setting up proper [caching headers](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Cache-Control).
* Using [caching middleware](xref:performance/caching/middleware).
* Serving [compressed](/aspnet/core/performance/response-compression?view=aspnetcore-8.0) versions of the assets when possible.
* Using a [CDN](/microsoft-365/enterprise/content-delivery-networks?view=o365-worldwide) to serve the assets closer to the user.
* Minifying the assets.

[`MapStaticAssets`](https://source.dot.net/#Microsoft.AspNetCore.StaticAssets/StaticAssetsEndpointRouteBuilderExtensions.cs,18) is a new middleware that helps optimize the delivery of static assets in an app. It's designed to work with all UI frameworks, including Blazor, Razor Pages, and MVC. It's typically a drop-in replacement for `UseStaticFiles`.

`MapStaticAssets` operates by combining build and publish-time processes to collect information about all the static resources in an app. This information is then utilized by the runtime library to efficiently serve these files to the browser.

`MapStaticAssets` can replace `UseStaticFiles` in most situations, however, its optimized for serving the assets that the app has knowledge of at build and publish time. If the app serves assets from other locations, such as disk or embedded resources, `UseStaticFiles` should be used.

`MapStaticAssets` provides the following benefits not found with `UseStaticFiles`:

* Build time compression for all the assets in the app:
  * `gzip` during development and `gzip + brotli` during publish.
  * All assets are compressed with the goal of reducing the size of the assets to the minimum.
* Content based `ETags`: The `Etags` for each resource are the [Base64](https://developer.mozilla.org/en-US/docs/Glossary/Base64) encoded string of the [SHA-256](/dotnet/api/system.security.cryptography.sha256?view=net-8.0) hash of the content. This ensures ensure that the browser only re-downloads a file if its contents have changed.

What are some of the gains that we can expect:

This is the default Razor Pages template (did we mention that this works for all UI flavors, Blazor, MVC, Razor Pages or your own custom framework?)

File | Original | Compressed | % Reduction
-- | -- | -- | --
bootstrap.min.css | 163 | 17.5 | 89.26%
jquery.js | 89.6 | 28 | 68.75%
bootstrap.min.js | 78.5 | 20 | 74.52%

For a total of 331.1 KB uncompressed vs 65.5 KB compressed.

This is the reduction that you get if you use the [Fluent UI Blazor components library](https://www.fluentui-blazor.net/):

File | Original | Compressed | % Reduction
-- | -- | -- | --
fluent.js | 384 | 73 | 80.99%
fluent.css | 94 | 11 | 88.30%

For a total of 478 KB uncompressed to 84 KB compressed.

Or, if you use other popular Blazor component libraries like [MudBlazor](https://mudblazor.com):

File | Original | Compressed | Reduction
-- | -- | -- | --
MudBlazor.min.css | 541 | 37.5 | 93.07%
MudBlazor.min.js | 47.4 | 9.2 | 80.59%

For a total of 588.4 KB to 46.7 KB

The best part is that all of this happens automatically for the app after using `MapStaticAssets`. When you decide to bring in a new library or copy some new JS/CSS library to your project, you don't have to do anything. It'll get optimized as part of the build and served to the browser faster, which is especially important for mobile environments with lower bandwidth or spotty connections.

You might be wondering, if I have turn on dynamic compression on the server, how do I benefit from this? To begin, this approach is simpler, because there is no server specific configuration for you to figure out.

Then, even in this situation, you still benefit from leveraging MapStaticAssets instead of letting your IIS or other server do the compression for you. This is for two reasons:
* You are able to spend extra time during the build process to ensure that the assets are as small as they can be. How much smaller? If we take MudBlazor as an example, IIS will compress the CSS bundle at around 90Kb, while brotli with max settings will result in 37Kb. That is still a whopping 59% size reduction or 41% of its dynamically compressed size.