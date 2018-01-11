---
title: Work with static files in ASP.NET Core
author: rick-anderson
description: Learn how to serve static files and configure static file hosting behaviors in an ASP.NET Core web app.
keywords: ASP.NET Core,static files,static assets,HTML,CSS,JavaScript
manager: wpickett
ms.author: riande
ms.custom: mvc
ms.date: 01/11/2018
ms.devlang: csharp
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: fundamentals/static-files
---
# Work with static files in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

Static files, such as HTML, CSS, images, and JavaScript, are assets an ASP.NET Core app serves directly to clients.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/static-files/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Serve static files

Static files are stored within the web root (*\<content-root>/wwwroot*) folder. See [Content root](xref:fundamentals/index#content-root) and [Web root](xref:fundamentals/index#web-root) for more information. Set the content root to the current directory so that your project's web root is accessible during development.

[!code-csharp[](../common/samples/WebApplication1/Program.cs?highlight=5&start=12&end=22)]

Static files are accessible via a path relative to the web root. For example, a default Web Application project created in Visual Studio contains several folders within the *wwwroot* folder, including *css*, *images*, and *js*. The URI to access a file in the *images* subfolder:

* `http://<app>/images/<imageFileName>`
* `http://localhost:9189/images/banner3.svg`

To serve static files, configure the [middleware](xref:fundamentals/middleware) to add static files to the pipeline. Configure that static file middleware by adding the [Microsoft.AspNetCore.StaticFiles](https://www.nuget.org/packages/Microsoft.AspNetCore.StaticFiles/) NuGet package to your project and calling the `UseStaticFiles` extension method from `Startup.Configure`:

[!code-csharp[](../fundamentals/static-files/sample/StartupStaticFiles.cs?highlight=3&name=snippet1)]

`app.UseStaticFiles();` makes the files in web root (*wwwroot* by default) servable. Later, I'll show how to make other directory contents servable with `UseStaticFiles`.

> [!NOTE]
> The web root defaults to the *wwwroot* directory, but you can change the web root directory via `UseWebRoot`.

Suppose you have a project hierarchy in which the static files to be served reside outside of the web root. For example:

* **wwwroot**
  * **css**
  * **images**
  * **...**
* **MyStaticFiles**
  * *test.png*

A request can access the *test.png* file by configuring the static files middleware as follows:

[!code-csharp[](../fundamentals/static-files/sample/StartupTwoStaticFiles.cs?highlight=5,6,7,8,9,10&name=snippet1)]

A request to `http://<app>/StaticFiles/test.png` serves the *test.png* file.

`StaticFileOptions()` can set response headers. For example, the following code configures static file serving from the *wwwroot* folder and sets the `Cache-Control` header to make them publicly cacheable for 10 minutes (600 seconds):

[!code-csharp[](../fundamentals/static-files/sample/StartupAddHeader.cs?name=snippet1)]

The [HeaderDictionaryExtensions.Append](/dotnet/api/microsoft.aspnetcore.http.headerdictionaryextensions.append) method is available from the [Microsoft.AspNetCore.Http](https://www.nuget.org/packages/Microsoft.AspNetCore.Http/) package. Add `using Microsoft.AspNetCore.Http;` to your *csharp* file if the method is unavailable.

![Response headers showing the Cache-Control header has been added](static-files/_static/add-header.png)

## Static file authorization

The static file module doesn't provide authorization checks. Any files served by it, including those under *wwwroot*, are publicly available. To serve files based on authorization:

* Store them outside of *wwwroot* and any directory accessible to the static file middleware **and**

* Serve them through a controller action, returning a `FileResult` where authorization is applied

## Enable directory browsing

Directory browsing allows users of your web app to see a list of directories and files within a specified directory. Directory browsing is disabled by default for security reasons (see [Considerations](#considerations)). Enable directory browsing by invoking the `UseDirectoryBrowser` method in `Startup.Configure`:

[!code-csharp[](static-files/sample/StartupBrowse.cs?name=snippet1)]

Add required services by invoking the `AddDirectoryBrowser` extension method from `Startup.ConfigureServices`:

[!code-csharp[](static-files/sample/StartupBrowse.cs?name=snippet2)]

The preceding code allows directory browsing of the *wwwroot/images* folder using the URL http://\<app>/MyImages, with links to each file and folder:

![directory browsing](static-files/_static/dir-browse.png)

See [Considerations](#considerations) on the security risks when enabling browsing.

Note the two `UseStaticFiles` calls. The first one is required to serve the CSS, images, and JavaScript in the *wwwroot* folder. The second call is required for directory browsing of the *wwwroot/images* folder using the URL http://\<app>/MyImages:

[!code-csharp[](static-files/sample/StartupBrowse.cs?highlight=3,5&name=snippet1)]

## Serve a default document

Setting a default home page gives site visitors a place to start when visiting your site. In order for your web app to serve a default page without the user having to fully qualify the URI, call the `UseDefaultFiles` extension method from `Startup.Configure` as follows:

[!code-csharp[](../fundamentals/static-files/sample/StartupEmpty.cs?highlight=3&name=snippet1)]

> [!NOTE]
> `UseDefaultFiles` must be called before `UseStaticFiles` to serve the default file. `UseDefaultFiles` is a URL rewriter that doesn't actually serve the file. You must enable the static file middleware (`UseStaticFiles`) to serve the file.

With `UseDefaultFiles`, requests to a folder search for:

* *default.htm*
* *default.html*
* *index.htm*
* *index.html*

The first file found from the list is served as though the request were the fully qualified URI (although the browser URL continues to show the URI requested).

The following code changes the default file name to *mydefault.html*:

[!code-csharp[](static-files/sample/StartupDefault.cs?name=snippet1)]

## UseFileServer

`UseFileServer` combines the functionality of `UseStaticFiles`, `UseDefaultFiles`, and `UseDirectoryBrowser`.

The following code enables both static files and the default file to be served, but does not allow directory browsing:

```csharp
app.UseFileServer();
```

The following code enables static files, default files, and directory browsing:

```csharp
app.UseFileServer(enableDirectoryBrowsing: true);
```

See [Considerations](#considerations) on the security risks when enabling browsing. As with `UseStaticFiles`, `UseDefaultFiles`, and `UseDirectoryBrowser`, if you wish to serve files that exist outside the `web root`, instantiate and configure an `FileServerOptions` object that you pass as a parameter to `UseFileServer`. For example, consider the following directory hierarchy in your web app:

* **wwwroot**
  * **css**
  * **images**
  * **...**

* **MyStaticFiles**
  * *test.png*
  * *default.html*

To enable static files, default files, and browsing for the `MyStaticFiles` directory, call `FileServerOptions` as follows:

[!code-csharp[](static-files/sample/StartupUseFileServer.cs?highlight=5,6,7,8,9,10,11&name=snippet1)]

If `enableDirectoryBrowsing` is set to `true`, you are required to invoke the `AddDirectoryBrowser` method in `Startup.ConfigureServices`:

[!code-csharp[](static-files/sample/StartupUseFileServer.cs?name=snippet2)]

Using the file hierarchy and preceding code:

| URI            |                             Response  |
| ------- | ------|
| `http://<app>/StaticFiles/test.png`    |      MyStaticFiles/test.png |
| `http://<app>/StaticFiles`              |     MyStaticFiles/default.html |

If no default-named file exists in the *MyStaticFiles* directory, http://\<app>/StaticFiles returns the directory listing with clickable links:

![Static files list](static-files/_static/db2.png)

> [!NOTE]
> `UseDefaultFiles` and `UseDirectoryBrowser` take the URL http://\<app>/StaticFiles without the trailing slash and cause a client-side redirect to http://\<app>/StaticFiles/ (adding the trailing slash). Relative URLs within the documents are incorrect without a trailing slash.

## FileExtensionContentTypeProvider

The `FileExtensionContentTypeProvider` class contains a collection that maps file extensions to MIME content types. In the following sample, several file extensions are registered to known MIME types. The ".rtf" extension is replaced, and ".mp4" is removed.

[!code-csharp[](../fundamentals/static-files/sample/StartupFileExtensionContentTypeProvider.cs?highlight=3,4,5,6,7,8,9,10,11,12,19&name=snippet1)]

See [MIME content types](http://www.iana.org/assignments/media-types/media-types.xhtml).

## Non-standard content types

The static file middleware understands almost 400 known file content types. If the user requests a file of an unknown file type, the static file middleware returns a HTTP 404 (Not Found) response. If directory browsing is enabled, a link to the file is displayed. The URI returns an HTTP 404 error.

The following code enables serving unknown types and renders the unknown file as an image:

[!code-csharp[](static-files/sample/StartupServeUnknownFileTypes.cs?name=snippet1)]

With the preceding code, a request for a file with an unknown content type is returned as an image.

> [!WARNING]
> Enabling `ServeUnknownFileTypes` is a security risk. Consequently, using it is discouraged. [FileExtensionContentTypeProvider](#FileExtensionContentTypeProvider) provides a safer alternative to serving files with non-standard extensions.

### Considerations

> [!WARNING]
> `UseDirectoryBrowser` and `UseStaticFiles` can leak secrets. We recommend that you **not** enable directory browsing in production. Be careful about which directories you enable with `UseStaticFiles` or `UseDirectoryBrowser`, as the entire directory and all sub-directories become accessible. We recommend keeping public content in its own directory such as *\<content root>/wwwroot*, away from app views, configuration files, etc.

* The URLs for content exposed with `UseDirectoryBrowser` and `UseStaticFiles` are subject to the case sensitivity and character restrictions of their underlying file system. For example, Windows is case insensitive&mdash;Mac and Linux aren't.

* ASP.NET Core apps hosted in IIS use the ASP.NET Core Module to forward all requests to the app, including static file requests. The IIS static file handler isn't used because it doesn't get a chance to handle requests before they are handled by the ASP.NET Core Module.

* To remove the IIS static file handler (at the server or website level):
     1. Navigate to the **Modules** feature
     1. Select **StaticFileModule** in the list
     1. Tap **Remove** in the **Actions** sidebar

> [!WARNING]
> If the IIS static file handler is enabled **and** the ASP.NET Core Module (ANCM) isn't correctly configured (for example, if *web.config* wasn't deployed), static files are served.

* Place code files (including *.cs* and *.cshtml*) outside of the app project's web root. A logical separation is therefore created between the app's client-side content and server-based code. This prevents server-side code from being leaked.

## Additional resources

* [Middleware](xref:fundamentals/middleware)

* [Introduction to ASP.NET Core](xref:index)
