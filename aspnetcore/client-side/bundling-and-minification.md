---
title: Bundling and minification | Microsoft Docs
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: d54230f9-8e5f-4861-a29c-1d3a14e0b0d9
ms.technology: aspnet
ms.prod: aspnet-core
uid: client-side/bundling-and-minification
---
# Bundling and minification

>[!WARNING]
> This page documents version 1.0.0-rc2 and has not yet been updated for version 1.0.0

By [Rick Anderson](https://twitter.com/RickAndMSFT), [Erik Reitan](https://github.com/Erikre), and [Daniel Roth](https://github.com/danroth27)

Bundling and minification are two techniques you can use in ASP.NET to improve page load performance for your web application. Bundling combines multiple files into a single file. Minification performs a variety of different code optimizations to scripts and CSS, which results in smaller payloads. Used together, bundling and minification improves load time performance by reducing the number of requests to the server and reducing the size of the requested assets (such as CSS and JavaScript files).

This article explains the benefits of using bundling and minification, including how these features can be used with ASP.NET Core applications.

## Overview

In ASP.NET Core apps, you bundle and minify the client-side resources during design-time using third party tools, such as [Gulp](using-gulp.md) and [Grunt](using-grunt.md). By using design-time bundling and minification, the minified files are created prior to the application’s deployment. Bundling and minifying before deployment provides the advantage of reduced server load. However, it’s important to recognize that design-time bundling and minification increases build complexity and only works with static files.

Bundling and minification primarily improve the first page request load time. Once a web page has been requested, the browser caches the assets (JavaScript, CSS and images) so bundling and minification won’t provide any performance boost when requesting the same page, or pages on the same site requesting the same assets. If you don’t set the expires header correctly on your assets, and you don’t use bundling and minification, the browsers freshness heuristics will mark the assets stale after a few days and the browser will require a validation request for each asset. In this case, bundling and minification provide a performance increase even after the first page request.

## Bundling

Bundling is a feature that makes it easy to combine or bundle multiple files into a single file. Because bundling combines multiple files into a single file, it reduces the number of requests to the server that is required to retrieve and display a web asset, such as a web page. You can create CSS, JavaScript and other bundles. Fewer files, means fewer HTTP requests from your browser to the server or from the service providing your application. This results in improved first page load performance.

Bundling can be accomplished using the [gulp-concat](https://www.npmjs.com/package/gulp-concat) plugin, which is installed with the Node Package Manager ([npm](https://www.npmjs.com/)). Add the `gulp-concat` package to the `devDependencies` section of your *package.json* file. To edit your *package.json* file from Visual Studio right-click on the **npm** node under **Dependencies** in the solution explorer and select **Open package.json**:

[!code-json[Main](../client-side/bundling-and-minification/samples/WebApplication1/src/WebApplication1/package.json?highlight=7)]

Run `npm install` to install the specified packages. Visual Studio will automatically install npm packages whenever *package.json* is modified.

In your *gulpfile.js* import the `gulp-concat` module:

[!code-js[Main](bundling-and-minification/samples/WebApplication1/src/WebApplication1/gulpfile.js?highlight=3&range=4-8)]

Use [globbing](http://www.tldp.org/LDP/abs/html/globbingref.html) patterns to specify the files that you want to bundle and minify:

[!code-js[Main](bundling-and-minification/samples/WebApplication1/src/WebApplication1/gulpfile.js?range=12-19)]

You can then define gulp tasks that run `concat` on the desired files and output the result to your webroot:

[!code-js[Main](bundling-and-minification/samples/WebApplication1/src/WebApplication1/gulpfile.js?highlight=3,10&range=31-43)]

The [gulp.src](https://github.com/gulpjs/gulp/blob/master/docs/API.md#gulpsrcglobs-options) function emits a stream of files that can be [piped](http://nodejs.org/api/stream.html#stream_readable_pipe_destination_options) to gulp plugins. An array of globs specifies the files to emit using [node-glob syntax](https://github.com/isaacs/node-glob). The glob beginning with `!` excludes matching files from the glob results up to that point.

## Minification

Minification performs a variety of different code optimizations to reduce the size of requested assets (such as CSS, image, JavaScript files). Common results of minification include removing unnecessary white space and comments, and shortening variable names to one character.

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

After minification, the function is reduced to the following:

```javascript
AddAltToImg=function(t,a){var r=$(t,a);r.attr("alt",r.attr("id").replace(/ID/,""))};
```

In addition to removing the comments and unnecessary whitespace, the following parameters and variable names were renamed (shortened) as follows:

Original | Renamed
--- | :---:
imageTagAndImageID | t
imageContext | a
imageElement | r

To minify your JavaScript files you can use the [gulp-uglify](https://www.npmjs.com/package/gulp-uglify) plugin. For CSS you can use the [gulp-cssmin](https://www.npmjs.com/package/gulp-cssmin) plugin. Install these packages using npm as before:

[!code-json[Main](../client-side/bundling-and-minification/samples/WebApplication1/src/WebApplication1/package.json?highlight=8,9)]

Import the `gulp-uglify` and `gulp-cssmin` modules in your *gulpfile.js* file:

[!code-js[Main](bundling-and-minification/samples/WebApplication1/src/WebApplication1/gulpfile.js?highlight=4,5&range=4-8)]

Add `uglify` to minify your bundled JavaScript files and `cssmin` to minify your bundled CSS files.

[!code-js[Main](bundling-and-minification/samples/WebApplication1/src/WebApplication1/gulpfile.js?highlight=4,11&range=31-43)]

You can run bundling and minification tasks from a command prompt using gulp (`gulp min`), or you can also execute any of your gulp tasks from within Visual Studio using the **Task Runner Explorer**. To use the **Task Runner Explorer** select *gulpfile.js* in the Solution Explorer and then select **Tools > Task Runner Explorer**:

![Task Runner Explorer](bundling-and-minification/_static/task-runner-explorer.png)

> [!NOTE]
> The gulp tasks for bundling and minification do not general run when your project is built and must be run manually.

## Impact of bundling and minification

The following table shows several important differences between listing all the assets individually and using bundling and minification on a simple web page:

Action | With B/M | Without B/M | Change
--- | :---: | :---: | :---:
File Requests |7 | 18 | 157%
KB Transferred | 156 | 264.68 | 70%
Load Time (MS) | 885 | 2360 | 167%

The bytes sent had a significant reduction with bundling as browsers are fairly verbose with the HTTP headers that they apply on requests. The load time shows a big improvement, however this example was run locally. You will get greater gains in performance when using bundling and minification with assets transferred over a network.

## Controlling bundling and minification

In general, you want to use the bundled and minified files of your app only in a production environment. During development, you want to use your original files so your app is easier to debug.

You can specify which scripts and CSS files to include in your pages using the environment tag helper in your layout pages(See [Tag Helpers](../mvc/views/tag-helpers/index.md)). The environment tag helper will only render its contents when running in specific environments. See [Working with Multiple Environments](../fundamentals/environments.md) for details on specifying the current environment.

The following environment tag will render the unprocessed CSS files when running in the `Development` environment:

[!code-html[Main](../client-side/bundling-and-minification/samples/WebApplication1/src/WebApplication1/Views/Shared/_Layout.cshtml?highlight=3&range=8-11)]

This environment tag will render the bundled and minified CSS files only when running in `Production` or `Staging`:

[!code-html[Main](../client-side/bundling-and-minification/samples/WebApplication1/src/WebApplication1/Views/Shared/_Layout.cshtml?highlight=5&range=12-17)]

## Additional resources

* [Using Gulp](using-gulp.md)

* [Using Grunt](using-grunt.md)

* [Working with Multiple Environments](../fundamentals/environments.md)

* [Tag Helpers](../mvc/views/tag-helpers/index.md)
