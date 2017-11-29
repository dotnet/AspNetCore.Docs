---
title: Bundling and minification in ASP.NET Core
author: scottaddie
description: Learn how to optimize static assets in an ASP.NET Core web application by applying techniques such as bundling and minification.
manager: wpickett
ms.author: riande
ms.custom: mvc
ms.date: 11/29/2017
ms.devlang: csharp
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: client-side/bundling-and-minification
---
# Bundling and minification

By [Scott Addie](https://twitter.com/Scott_Addie)

Bundling and minification are two techniques you can use in an ASP.NET Core web app to reduce page load time. Bundling combines multiple files into a single file. Minification performs a variety of different code optimizations to scripts and CSS, resulting in smaller payloads. Used together, bundling and minification improve performance by reducing the number of requests to the server and reducing the size of the requested static assets.

This article explains the benefits of using bundling and minification, including how these features can be used with ASP.NET Core web apps.

## Overview

ASP.NET Core web apps offer multiple options for bundling and minifying client-side resources. The MVC and Razor Pages project templates provide an out-of-the-box solution using a configuration file and the [BuildBundlerMinifier NuGet package](https://www.nuget.org/packages/BuildBundlerMinifier/). Third-party tools, such as [Gulp](xref:client-side/using-gulp) and [Grunt](xref:client-side/using-grunt) are also available to accomplish the same tasks, should your processes require additional workflow or complexities. By using design-time bundling and minification, the minified files are created prior to the app's deployment. Bundling and minifying before deployment provides the advantage of reduced server load. However, it's important to recognize that design-time bundling and minification increases build complexity and only works with static files.

Bundling and minification primarily improve the first page request load time. Once a web page has been requested, the browser caches the assets (JavaScript, CSS, and images). Consequently, bundling and minification don't improve performance when requesting the same page, or pages, on the same site requesting the same assets. If you don't set the expires header correctly on your assets, and if you don’t use bundling and minification, the browser's freshness heuristics mark the assets stale after a few days. Additionally, the browser requires a validation request for each asset. In this case, bundling and minification provide a performance increase even after the first page request.

### Bundling

Bundling is a feature that makes it easy to combine (or bundle) multiple files into a single file. Bundling reduces the number of server requests which are necessary to render a web asset, such as a web page. You can create bundles specifically for CSS, JavaScript, etc. Fewer files means fewer HTTP requests from your browser to the server or from the service providing your application. This results in improved first page load performance.

### Minification

Minification performs a variety of code optimizations to reduce the size of requested assets (such as CSS, images, and JavaScript files). Common results of minification include shortening variable names to one character and removing comments and unnecessary whitespace.

Consider the following JavaScript function:

```javascript
AddAltToImg = function (imageTagAndImageID, imageContext) {
  ///<signature>
  ///<summary> Adds an alt tab to the image
  // </summary>
  //<param name="imgElement" type="String">The image selector.</param>
  //<param name="ContextForImage" type="String">The image context.</param>
  ///</signature>
  var imageElement = $(imageTagAndImageID, imageContext);
  imageElement.attr('alt', imageElement.attr('id').replace(/ID/, ''));
}
```

Minification reduces the function to the following:

```javascript
AddAltToImg=function(t,a){var r=$(t,a);r.attr("alt",r.attr("id").replace(/ID/,""))};
```

In addition to removing the comments and unnecessary whitespace, the following parameters and variable names were renamed (shortened) as follows:

Original | Renamed
--- | :---:
`imageTagAndImageID` | `t`
`imageContext` | `a`
`imageElement` | `r`

## Impact of bundling and minification

The following table outlines important differences between listing all the assets individually and using bundling and minification on a simple web page:

Action | With B/M | Without B/M | Change
--- | :---: | :---: | :---:
File Requests |7 | 18 | 157%
KB Transferred | 156 | 264.68 | 70%
Load Time (MS) | 885 | 2360 | 167%

Browsers are fairly verbose with regard to HTTP request headers, so the total bytes sent metric saw a significant reduction when bundling. The load time shows a big improvement, however this example ran locally. Greater performance gains are realized when using bundling and minification with assets transferred over a network.

## Use bundling and minification in a project

The MVC and Razor Pages project templates provide a *bundleconfig.json* configuration file which defines the options for each bundle. By default, a single bundle configuration is defined for the custom JavaScript (*wwwroot/js/site.js*) and stylesheet (*wwwroot/css/site.css*) files:

[!code-json[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/bundleconfig.json)]

Bundle options include:

* `outputFileName`: name of the bundle file to output. Can contain a relative path from the *bundleconfig.json* file. **required**
* `inputFiles`: array of files to bundle together. These are relative paths to the configuration file. **optional**, *an empty value results in an empty output file. [globbing](http://www.tldp.org/LDP/abs/html/globbingref.html) patterns are supported.
* `minify`: minification options for the output type. **optional**, *default - `minify: { enabled: true }`*
  * Configuration options are available per output file type.
    * [CSS Minifier](https://github.com/madskristensen/BundlerMinifier/wiki/cssminifier)
    * [JavaScript Minifier](https://github.com/madskristensen/BundlerMinifier/wiki/JavaScript-Minifier-settings)
    * [HTML Minifier](https://github.com/madskristensen/BundlerMinifier/wiki)
* `includeInProject`: add generated files to project file. **optional**, *default - false*
* `sourceMaps`: generate source maps for the bundled file. **optional**, *default - false*

# [Visual Studio](#tab/visual-studio) 

Open *bundleconfig.json* in Visual Studio. If the appropriate extension isn't installed, a prompt suggests there's one that could assist with this file type.

![BuildBundlerMinifier Extension Suggestion](../client-side/bundling-and-minification/_static/bundler-extension-suggestion.png)

Click **View Extensions**, and install the [Bundler & Minifier](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.BundlerMinifier) extension.

![BuildBundlerMinifier Extension Suggestion](../client-side/bundling-and-minification/_static/view-extension.png)

Configure the build to run the client-side asset bundling and minification tasks. Right-click the *bundleconfig.json* file in Solution Explorer and select **Bundler & Minifier** > **Enable bundle on build...**. The [BuildBundlerMinifier NuGet package](https://www.nuget.org/packages/BuildBundlerMinifier/) was added to the project:

[!code-xml[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/BuildBundlerMinifierApp.csproj?range=6)]

Build the project. The *bundleconfig.json* file is considered in the build process to produce the output files based on the defined configuration. The following appears in the Output window:

```console
1>------ Build started: Project: BuildBundlerMinifierApp, Configuration: Debug Any CPU ------
1>
1>Bundler: Begin processing bundleconfig.json
1>Bundler: Done processing bundleconfig.json
1>BuildBundlerMinifierApp -> C:\BuildBundlerMinifierApp\bin\Debug\netcoreapp2.0\BuildBundlerMinifierApp.dll
========== Build: 1 succeeded, 0 failed, 0 up-to-date, 0 skipped ==========
```

# [.NET Core CLI](#tab/netcore-cli) 

Add the [BuildBundlerMinifier NuGet package](https://www.nuget.org/packages/BuildBundlerMinifier/) to your project:

    ```console
    dotnet add package BuildBundlerMinifier
    ```

Restore the dependencies:

    ```console
    dotnet restore
    ```

Build the app:

    ```console
    dotnet build
    ```

The output from the build command shows the results of the minification and/or bundling according to what is configured. For example:

    ```console
    Microsoft (R) Build Engine version 15.4.8.50001 for .NET Core
    Copyright (C) Microsoft Corporation. All rights reserved.
    
    
      Bundler: Begin processing bundleconfig.json
      Bundler: Done processing bundleconfig.json
      BuildBundlerMinifierApp -> C:\BuildBundlerMinifierApp\bin\Debug\netcoreapp2.0\BuildBundlerMinifierApp.dll
    ```

---

## Add files to workflow

Consider an example in which an additional *custom.css* file is added resembling the following:

[!code-css[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/wwwroot/css/custom.css)]

To minify *custom.css* and bundle it with *site.css* into a single *site.min.css* file, add the relative path to *bundleconfig.json*:

[!code-json[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/bundleconfig2.json?highlight=6)]

> [!NOTE]
> Alternatively, the following globbing pattern could be used:
>
> ```json
> "inputFiles": ["wwwroot/**/*(*.css|!(*.min.css)"]
> ```
>
> This globbing pattern matches all CSS files and excludes the minified file pattern.

Build the application. Open *site.min.css* and notice the content of *custom.css* is appended to the end of the file.

## Control bundling and minification

In general, you want to use the bundled and minified files of your app only in a production environment. During development, you want to use your original files so your app is easier to debug.

Specify which scripts and CSS files to include in your pages by using the [Environment Tag Helper](xref:mvc/views/tag-helpers/builtin-th/environment-tag-helper) in your views. The Environment Tag Helper only renders its contents when running in specific environments. See [Working with Multiple Environments](xref:fundamentals/environments) for details on specifying the current environment.

The following *environment* tag renders the unprocessed CSS files when running in the `Development` environment:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-cshtml[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/Pages/_Layout.cshtml?highlight=3&range=21-24)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-cshtml[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/Pages/_Layout.cshtml?highlight=3&range=9-12)]

---

The following *environment* tag renders the bundled and minified CSS files when running in an environment other than `Development`. For example, running in `Production` or `Staging` triggers the rendering of these stylesheets:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-cshtml[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/Pages/_Layout.cshtml?highlight=5&range=25-30)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-cshtml[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/Pages/_Layout.cshtml?highlight=3&range=13-18)]

---

## Consume bundleconfig.json from Gulp

There are cases in which an app's bundling and minification workflow requires additional processing. Examples include image optimization, cache busting, and CDN asset processing. To satisfy these requirements, you can convert the bundling and minification workflow to use Gulp. The Visual Studio [Bundler & Minifier extension](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.BundlerMinifier) is used for this purpose.

### Use the Bundler & Minifier extension

Right-click the *bundleconfig.json* in Solution Explorer and select **Convert to Gulp...**:

![Convert to Gulp](../client-side/bundling-and-minification/_static/convert-togulp.png)

The *gulpfile.js* and *package.json* files are added to the project. The supporting [npm](https://www.npmjs.com/) packages listed in the *package.json* file's `devDependencies` section are installed.

Run the following command in Package Manager Console to install the Gulp CLI as a global dependency:

```console
npm i -g gulp-cli
```

The *gulpfile.js* file reads the *bundleconfig.json* file for the inputs, outputs, and settings.

[!code-javascript[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/gulpfile.js?highlight=10)]

### Run Gulp tasks

To trigger the Gulp minification task before the project builds in Visual Studio, add the following [MSBuild Target](/visualstudio/msbuild/msbuild-targets) to the *.csproj file:

[!code-xml[](../client-side/bundling-and-minification/samples/BuildBundlerMinifierApp/BuildBundlerMinifierApp.csproj?range=12-14)]

In this example, any tasks defined within the `MyPreCompileTarget` target run before the `Build` target.

Alternatively, Visual Studio's Task Runner Explorer may be used to bind Gulp tasks to specific Visual Studio events. See [Running default tasks](xref:client-side/using-gulp#running-default-tasks) for instructions on doing that.

## Additional resources

* [Using Gulp](xref:client-side/using-gulp)
* [Using Grunt](xref:client-side/using-grunt)
* [Working with Multiple Environments](xref:fundamentals/environments)
* [Tag Helpers](xref:mvc/views/tag-helpers/intro)
