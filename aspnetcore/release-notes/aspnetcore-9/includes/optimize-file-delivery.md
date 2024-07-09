### Optimize file delivery for web apps

Following production best practices for serving static assets requires a significant amount of work and technical expertise. Files are usually delivered to browsers without optimizations, such as compression, caching, and fingerprinting. As a result, the browser is forced to perform additional requests on every page load, more bytes are transferred through the network, and even stale versions of files are sometimes served to clients.

.NET 9 includes optimizations that accomplish the following goals:

* Serve a given asset once until the file changes or the browser clears its cache.
* Preclude the browser from using old or stale assets after an app is updated.
* Preclude the browser from using old asset versions during development.
* Decrease page load times by delivering assets faster using modern browser features.
* Minimize the size of assets served to the browser. (This optimization doesn't include minification.)

For more information on the new file delivery features, see the following resources:

* <xref:fundamentals/static-files?view=aspnetcore-9.0>
* <xref:blazor/fundamentals/static-files?view=aspnetcore-9.0>
