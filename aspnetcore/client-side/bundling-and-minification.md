---
title: Bundle and minify static assets in ASP.NET Core
author: scottaddie
description: Learn how to optimize static resources in an ASP.NET Core web application by applying bundling and minification techniques.
ms.author: scaddie
ms.custom: mvc
ms.date: 09/02/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: client-side/bundling-and-minification
---
# Bundle and minify static assets in ASP.NET Core

By [Scott Addie](https://twitter.com/Scott_Addie) and [David Pine](https://twitter.com/davidpine7)

This article explains the benefits of applying bundling and minification, including how these features can be used with ASP.NET Core web apps.

## What is bundling and minification

Bundling and minification are two distinct performance optimizations you can apply in a web app. Used together, bundling and minification improve performance by reducing the number of server requests and reducing the size of the requested static assets.

Bundling and minification primarily improve the first page request load time. Once a web page has been requested, the browser caches the static assets (JavaScript, CSS, and images). Consequently, bundling and minification don't improve performance when requesting the same page, or pages, on the same site requesting the same assets. If the expires header isn't set correctly on the assets and if bundling and minification isn't used, the browser's freshness heuristics mark the assets stale after a few days. Additionally, the browser requires a validation request for each asset. In this case, bundling and minification provide a performance improvement even after the first page request.

### Bundling

Bundling combines multiple files into a single file. Bundling reduces the number of server requests that are necessary to render a web asset, such as a web page. You can create any number of individual bundles specifically for CSS, JavaScript, etc. Fewer files means fewer HTTP requests from the browser to the server or from the service providing your application. This results in improved first page load performance.

### Minification

Minification removes unnecessary characters from code without altering functionality. The result is a significant size reduction in requested assets (such as CSS, images, and JavaScript files). Common side effects of minification include shortening variable names to one character and removing comments and unnecessary whitespace.

Consider the following JavaScript function:

[!code-javascript[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/wwwroot/js/site.js)]

Minification reduces the function to the following:

[!code-javascript[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/wwwroot/js/site.min.js)]

In addition to removing the comments and unnecessary whitespace, the following parameter and variable names were renamed as follows:

Original | Renamed
--- | :---:
`imageTagAndImageID` | `t`
`imageContext` | `a`
`imageElement` | `r`

## Impact of bundling and minification

The following table outlines differences between individually loading assets and using bundling and minification:

Action | With B/M | Without B/M | Change
--- | :---: | :---: | :---:
File Requests  | 7   | 18     | 157%
KB Transferred | 156 | 264.68 | 70%
Load Time (ms) | 885 | 2360   | 167%

Browsers are fairly verbose with regard to HTTP request headers. The total bytes sent metric saw a significant reduction when bundling. The load time shows a significant improvement, however this example ran locally. Greater performance gains are realized when using bundling and minification with assets transferred over a network.

## Choose a bundling and minification strategy

The MVC and Razor Pages project templates provide a solution for bundling and minification consisting of a JSON configuration file. Third-party tools, such as the [Grunt](xref:client-side/using-grunt) task runner, accomplish the same tasks with a bit more complexity. A third-party tool is a great fit when your development workflow requires processing beyond bundling and minification&mdash;such as linting and image optimization. By using design-time bundling and minification, the minified files are created prior to the app's deployment. Bundling and minifying before deployment provides the advantage of reduced server load. However, it's important to recognize that design-time bundling and minification increases build complexity and only works with static files.

## Configure bundling and minification

> [!NOTE]
> The [BuildBundlerMinifier](https://www.nuget.org/packages/BuildBundlerMinifier) NuGet package needs to be added to your project for this to work.

::: moniker range="<= aspnetcore-2.0"

In ASP.NET Core 2.0 or earlier, the MVC and Razor Pages project templates provide a *bundleconfig.json* configuration file that defines the options for each bundle:

::: moniker-end

::: moniker range=">= aspnetcore-2.1"

In ASP.NET Core 2.1 or later, add a new JSON file, named *bundleconfig.json*, to the MVC or Razor Pages project root. Include the following JSON in that file as a starting point:

::: moniker-end

[!code-json[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/bundleconfig.json)]

The *bundleconfig.json* file defines the options for each bundle. In the preceding example, a single bundle configuration is defined for the custom JavaScript (*wwwroot/js/site.js*) and stylesheet (*wwwroot/css/site.css*) files.

Configuration options include:

* `outputFileName`: The name of the bundle file to output. Can contain a relative path from the *bundleconfig.json* file. **required**
* `inputFiles`: An array of files to bundle together. These are relative paths to the configuration file. **optional**, *an empty value results in an empty output file. [globbing](https://www.tldp.org/LDP/abs/html/globbingref.html) patterns are supported.
* `minify`: The minification options for the output type. **optional**, *default - `minify: { enabled: true }`*
  * Configuration options are available per output file type.
    * [CSS Minifier](https://github.com/madskristensen/BundlerMinifier/wiki/cssminifier)
    * [JavaScript Minifier](https://github.com/madskristensen/BundlerMinifier/wiki/JavaScript-Minifier-settings)
    * [HTML Minifier](https://github.com/madskristensen/BundlerMinifier/wiki)
* `includeInProject`: Flag indicating whether to add generated files to project file. **optional**, *default - false*
* `sourceMap`: Flag indicating whether to generate a source map for the bundled file. **optional**, *default - false*
* `sourceMapRootPath`: The root path for storing the generated source map file.

## Add files to workflow

Consider an example in which an additional *custom.css* file is added resembling the following:

[!code-css[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/wwwroot/css/custom.css)]

To minify *custom.css* and bundle it with *site.css* into a *site.min.css* file, add the relative path to *bundleconfig.json*:

[!code-json[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/bundleconfig2.json?highlight=6)]

> [!NOTE]
> Alternatively, the following globbing pattern could be used:
>
> ```json
> "inputFiles": ["wwwroot/**/!(*.min).css" ]
> ```
>
> This globbing pattern matches all CSS files and excludes the minified file pattern.

Build the application. Open *site.min.css* and notice the content of *custom.css* is appended to the end of the file.

## Environment-based bundling and minification

As a best practice, the bundled and minified files of your app should be used in a production environment. During development, the original files make for easier debugging of the app.

Specify which files to include in your pages by using the [Environment Tag Helper](xref:mvc/views/tag-helpers/builtin-th/environment-tag-helper) in your views. The Environment Tag Helper only renders its contents when running in specific [environments](xref:fundamentals/environments).

The following `environment` tag renders the unprocessed CSS files when running in the `Development` environment:

::: moniker range=">= aspnetcore-2.0"

[!code-cshtml[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/Pages/_Layout.cshtml?highlight=3&range=21-24)]

::: moniker-end

::: moniker range="<= aspnetcore-1.1"

[!code-cshtml[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/Pages/_Layout.cshtml?highlight=3&range=9-12)]

::: moniker-end

The following `environment` tag renders the bundled and minified CSS files when running in an environment other than `Development`. For example, running in `Production` or `Staging` triggers the rendering of these stylesheets:

::: moniker range=">= aspnetcore-2.0"

[!code-cshtml[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/Pages/_Layout.cshtml?highlight=5&range=25-30)]

::: moniker-end

::: moniker range="<= aspnetcore-1.1"

[!code-cshtml[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/Pages/_Layout.cshtml?highlight=3&range=13-18)]

::: moniker-end

## Consume bundleconfig.json from Gulp

There are cases in which an app's bundling and minification workflow requires additional processing. Examples include image optimization, cache busting, and CDN asset processing. To satisfy these requirements, you can convert the bundling and minification workflow to use Gulp.

### Manually convert the bundling and minification workflow to use Gulp

Add a *package.json* file, with the following `devDependencies`, to the project root:

> [!WARNING]
> The `gulp-uglify` module doesn't support ECMAScript (ES) 2015 / ES6 and later. Install [gulp-terser](https://www.npmjs.com/package/gulp-terser) instead of `gulp-uglify` to use ES2015 / ES6 or later.

[!code-json[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/package.json?range=5-13)]

Install the dependencies by running the following command at the same level as *package.json*:

```bash
npm i
```

Install the Gulp CLI as a global dependency:

```bash
npm i -g gulp-cli
```

Copy the *gulpfile.js* file below to the project root:

[!code-javascript[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/gulpfile.js?range=1-11,14-)]

### Run Gulp tasks

To trigger the Gulp minification task before the project builds in Visual Studio:

1. Install the [BuildBundlerMinifier](https://www.nuget.org/packages/BuildBundlerMinifier) NuGet package.
1. Add the following [MSBuild Target](/visualstudio/msbuild/msbuild-targets) to the project file:

    [!code-xml[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/BuildBundlerMinifierApp.csproj?range=14-16)]

In this example, any tasks defined within the `MyPreCompileTarget` target run before the predefined `Build` target. Output similar to the following appears in Visual Studio's Output window:

```console
1>------ Build started: Project: BuildBundlerMinifierApp, Configuration: Debug Any CPU ------
1>BuildBundlerMinifierApp -> C:\BuildBundlerMinifierApp\bin\Debug\netcoreapp2.0\BuildBundlerMinifierApp.dll
1>[14:17:49] Using gulpfile C:\BuildBundlerMinifierApp\gulpfile.js
1>[14:17:49] Starting 'min:js'...
1>[14:17:49] Starting 'min:css'...
1>[14:17:49] Starting 'min:html'...
1>[14:17:49] Finished 'min:js' after 83 ms
1>[14:17:49] Finished 'min:css' after 88 ms
========== Build: 1 succeeded, 0 failed, 0 up-to-date, 0 skipped ==========
```

## Additional resources

* [Use Grunt](xref:client-side/using-grunt)
* [Use multiple environments](xref:fundamentals/environments)
* [Tag Helpers](xref:mvc/views/tag-helpers/intro)
