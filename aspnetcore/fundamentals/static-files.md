---
title: Static files in ASP.NET Core
author: rick-anderson
description: Learn how to serve and secure static files and configure static file hosting middleware behaviors in an ASP.NET Core web app.
ms.author: riande
ms.custom: mvc
ms.date: 10/07/2019
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/static-files
---
# Static files in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Scott Addie](https://twitter.com/Scott_Addie)

Static files, such as HTML, CSS, images, and JavaScript, are assets an ASP.NET Core app serves directly to clients. Some configuration is required to enable serving of these files.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/static-files/samples) ([how to download](xref:index#how-to-download-a-sample))

## Serve static files

Static files are stored within the project's [web root](xref:fundamentals/index#web-root) directory. The default directory is *{content root}/wwwroot*, but it can be changed via the [UseWebRoot](/dotnet/api/microsoft.aspnetcore.hosting.hostingabstractionswebhostbuilderextensions.usewebroot#Microsoft_AspNetCore_Hosting_HostingAbstractionsWebHostBuilderExtensions_UseWebRoot_Microsoft_AspNetCore_Hosting_IWebHostBuilder_System_String_) method. See [Content root](xref:fundamentals/index#content-root) and [Web root](xref:fundamentals/index#web-root) for more information.

The app's web host must be made aware of the content root directory.

::: moniker range=">= aspnetcore-2.0"

The `WebHost.CreateDefaultBuilder` method sets the content root to the current directory:

[!code-csharp[](../common/samples/WebApplication1DotNetCore2.0App/Program.cs?name=snippet_Main&highlight=9)]

::: moniker-end

::: moniker range="< aspnetcore-2.0"

Set the content root to the current directory by invoking [UseContentRoot](/dotnet/api/microsoft.aspnetcore.hosting.hostingabstractionswebhostbuilderextensions.usecontentroot#Microsoft_AspNetCore_Hosting_HostingAbstractionsWebHostBuilderExtensions_UseContentRoot_Microsoft_AspNetCore_Hosting_IWebHostBuilder_System_String_) inside of `Program.Main`:

[!code-csharp[](static-files/samples/1x/Program.cs?name=snippet_ProgramClass&highlight=7)]

::: moniker-end

Static files are accessible via a path relative to the [web root](xref:fundamentals/index#web-root). For example, the **Web Application** project template contains several folders within the *wwwroot* folder:

* **wwwroot**
  * **css**
  * **images**
  * **js**

The URI format to access a file in the *images* subfolder is *http://\<server_address>/images/\<image_file_name>*. For example, *http://localhost:9189/images/banner3.svg*.

::: moniker range=">= aspnetcore-2.1"

If targeting .NET Framework, add the [Microsoft.AspNetCore.StaticFiles](https://www.nuget.org/packages/Microsoft.AspNetCore.StaticFiles/) package to the project. If targeting .NET Core, the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app) includes this package.

::: moniker-end

::: moniker range="= aspnetcore-2.0"

If targeting .NET Framework, add the [Microsoft.AspNetCore.StaticFiles](https://www.nuget.org/packages/Microsoft.AspNetCore.StaticFiles/) package to the project. If targeting .NET Core, the [Microsoft.AspNetCore.All metapackage](xref:fundamentals/metapackage) includes this package.

::: moniker-end

::: moniker range="< aspnetcore-2.0"

Add the [Microsoft.AspNetCore.StaticFiles](https://www.nuget.org/packages/Microsoft.AspNetCore.StaticFiles/) package to the project.

::: moniker-end

Configure the [middleware](xref:fundamentals/middleware/index) which enables the serving of static files.

### Serve files inside of web root

Invoke the [UseStaticFiles](/dotnet/api/microsoft.aspnetcore.builder.staticfileextensions.usestaticfiles#Microsoft_AspNetCore_Builder_StaticFileExtensions_UseStaticFiles_Microsoft_AspNetCore_Builder_IApplicationBuilder_) method within `Startup.Configure`:

[!code-csharp[](static-files/samples/1x/StartupStaticFiles.cs?name=snippet_ConfigureMethod&highlight=3)]

The parameterless `UseStaticFiles` method overload marks the files in [web root](xref:fundamentals/index#web-root) as servable. The following markup references *wwwroot/images/banner1.svg*:

[!code-cshtml[](static-files/samples/1x/Views/Home/Index.cshtml?name=snippet_static_file_wwwroot)]

In the preceding code, the tilde character `~/` points to the [web root](xref:fundamentals/index#web-root).

### Serve files outside of web root

Consider a directory hierarchy in which the static files to be served reside outside of the [web root](xref:fundamentals/index#web-root):

* **wwwroot**
  * **css**
  * **images**
  * **js**
* **MyStaticFiles**
  * **images**
    * *banner1.svg*

A request can access the *banner1.svg* file by configuring the Static File Middleware as follows:

[!code-csharp[](static-files/samples/1x/StartupTwoStaticFiles.cs?name=snippet_ConfigureMethod&highlight=5-10)]

In the preceding code, the *MyStaticFiles* directory hierarchy is exposed publicly via the *StaticFiles* URI segment. A request to *http://\<server_address>/StaticFiles/images/banner1.svg* serves the *banner1.svg* file.

The following markup references *MyStaticFiles/images/banner1.svg*:

[!code-cshtml[](static-files/samples/1x/Views/Home/Index.cshtml?name=snippet_static_file_outside)]

### Set HTTP response headers

A [StaticFileOptions](/dotnet/api/microsoft.aspnetcore.builder.staticfileoptions) object can be used to set HTTP response headers. In addition to configuring static file serving from the [web root](xref:fundamentals/index#web-root), the following code sets the `Cache-Control` header:

[!code-csharp[](static-files/samples/1x/StartupAddHeader.cs?name=snippet_ConfigureMethod)]
[!INCLUDE[about the series](~/includes/code-comments-loc.md)]

The [HeaderDictionaryExtensions.Append](/dotnet/api/microsoft.aspnetcore.http.headerdictionaryextensions.append) method exists in the [Microsoft.AspNetCore.Http](https://www.nuget.org/packages/Microsoft.AspNetCore.Http/) package.

The files have been made publicly cacheable for 10 minutes (600 seconds) in the Development environment:

![Response headers showing the Cache-Control header has been added](static-files/_static/add-header.png)

## Static file authorization

The Static File Middleware doesn't provide authorization checks. Any files served by it, including those under *wwwroot*, are publicly accessible. To serve files based on authorization:

* Store them outside of *wwwroot* and any directory accessible to the Static File Middleware.
* Serve them via an action method to which authorization is applied. Return a [FileResult](/dotnet/api/microsoft.aspnetcore.mvc.fileresult) object:

  [!code-csharp[](static-files/samples/1x/Controllers/HomeController.cs?name=snippet_BannerImageAction)]

## Enable directory browsing

Directory browsing allows users of your web app to see a directory listing and files within a specified directory. Directory browsing is disabled by default for security reasons (see [Considerations](#considerations)). Enable directory browsing by invoking the [UseDirectoryBrowser](/dotnet/api/microsoft.aspnetcore.builder.directorybrowserextensions.usedirectorybrowser#Microsoft_AspNetCore_Builder_DirectoryBrowserExtensions_UseDirectoryBrowser_Microsoft_AspNetCore_Builder_IApplicationBuilder_Microsoft_AspNetCore_Builder_DirectoryBrowserOptions_) method in `Startup.Configure`:

[!code-csharp[](static-files/samples/1x/StartupBrowse.cs?name=snippet_ConfigureMethod&highlight=12-17)]

Add required services by invoking the [AddDirectoryBrowser](/dotnet/api/microsoft.extensions.dependencyinjection.directorybrowserserviceextensions.adddirectorybrowser#Microsoft_Extensions_DependencyInjection_DirectoryBrowserServiceExtensions_AddDirectoryBrowser_Microsoft_Extensions_DependencyInjection_IServiceCollection_) method from `Startup.ConfigureServices`:

[!code-csharp[](static-files/samples/1x/StartupBrowse.cs?name=snippet_ConfigureServicesMethod&highlight=3)]

The preceding code allows directory browsing of the *wwwroot/images* folder using the URL *http://\<server_address>/MyImages*, with links to each file and folder:

![directory browsing](static-files/_static/dir-browse.png)

See [Considerations](#considerations) on the security risks when enabling browsing.

Note the two `UseStaticFiles` calls in the following example. The first call enables the serving of static files in the *wwwroot* folder. The second call enables directory browsing of the *wwwroot/images* folder using the URL *http://\<server_address>/MyImages*:

[!code-csharp[](static-files/samples/1x/StartupBrowse.cs?name=snippet_ConfigureMethod&highlight=3,5)]

## Serve a default document

Setting a default home page provides visitors a logical starting point when visiting your site. To serve a default page without the user fully qualifying the URI, call the [UseDefaultFiles](/dotnet/api/microsoft.aspnetcore.builder.defaultfilesextensions.usedefaultfiles#Microsoft_AspNetCore_Builder_DefaultFilesExtensions_UseDefaultFiles_Microsoft_AspNetCore_Builder_IApplicationBuilder_) method from `Startup.Configure`:

[!code-csharp[](static-files/samples/1x/StartupEmpty.cs?name=snippet_ConfigureMethod&highlight=3)]

> [!IMPORTANT]
> `UseDefaultFiles` must be called before `UseStaticFiles` to serve the default file. `UseDefaultFiles` is a URL rewriter that doesn't actually serve the file. Enable Static File Middleware via `UseStaticFiles` to serve the file.

With `UseDefaultFiles`, requests to a folder search for:

* *default.htm*
* *default.html*
* *index.htm*
* *index.html*

The first file found from the list is served as though the request were the fully qualified URI. The browser URL continues to reflect the URI requested.

The following code changes the default file name to *mydefault.html*:

[!code-csharp[](static-files/samples/1x/StartupDefault.cs?name=snippet_ConfigureMethod)]

## UseFileServer

<xref:Microsoft.AspNetCore.Builder.FileServerExtensions.UseFileServer*> combines the functionality of `UseStaticFiles`, `UseDefaultFiles`, and optionally `UseDirectoryBrowser`.

The following code enables the serving of static files and the default file. Directory browsing isn't enabled.

```csharp
app.UseFileServer();
```

The following code builds upon the parameterless overload by enabling directory browsing:

```csharp
app.UseFileServer(enableDirectoryBrowsing: true);
```

Consider the following directory hierarchy:

* **wwwroot**
  * **css**
  * **images**
  * **js**
* **MyStaticFiles**
  * **images**
    * *banner1.svg*
  * *default.html*

The following code enables static files, default files, and directory browsing of `MyStaticFiles`:

[!code-csharp[](static-files/samples/1x/StartupUseFileServer.cs?name=snippet_ConfigureMethod&highlight=5-11)]

`AddDirectoryBrowser` must be called when the `EnableDirectoryBrowsing` property value is `true`:

[!code-csharp[](static-files/samples/1x/StartupUseFileServer.cs?name=snippet_ConfigureServicesMethod)]

Using the file hierarchy and preceding code, URLs resolve as follows:

| URI            |                             Response  |
| ------- | ------|
| *http://\<server_address>/StaticFiles/images/banner1.svg*    |      MyStaticFiles/images/banner1.svg |
| *http://\<server_address>/StaticFiles*             |     MyStaticFiles/default.html |

If no default-named file exists in the *MyStaticFiles* directory, *http://\<server_address>/StaticFiles* returns the directory listing with clickable links:

![Static files list](static-files/_static/db2.png)

> [!NOTE]
> <xref:Microsoft.AspNetCore.Builder.DefaultFilesExtensions.UseDefaultFiles*> and <xref:Microsoft.AspNetCore.Builder.DirectoryBrowserExtensions.UseDirectoryBrowser*> perform a client-side redirect from `http://{SERVER ADDRESS}/StaticFiles` (without a trailing slash) to `http://{SERVER ADDRESS}/StaticFiles/` (with a trailing slash). Relative URLs within the *StaticFiles* directory are invalid without a trailing slash.

## FileExtensionContentTypeProvider

The [FileExtensionContentTypeProvider](/dotnet/api/microsoft.aspnetcore.staticfiles.fileextensioncontenttypeprovider) class contains a `Mappings` property serving as a mapping of file extensions to MIME content types. In the following sample, several file extensions are registered to known MIME types. The *.rtf* extension is replaced, and *.mp4* is removed.

[!code-csharp[](static-files/samples/1x/StartupFileExtensionContentTypeProvider.cs?name=snippet_ConfigureMethod&highlight=3-12,19)]

See [MIME content types](https://www.iana.org/assignments/media-types/media-types.xhtml).

## Non-standard content types

Static File Middleware understands almost 400 known file content types. If the user requests a file with an unknown file type, Static File Middleware passes the request to the next middleware in the pipeline. If no middleware handles the request, a *404 Not Found* response is returned. If directory browsing is enabled, a link to the file is displayed in a directory listing.

The following code enables serving unknown types and renders the unknown file as an image:

[!code-csharp[](static-files/samples/1x/StartupServeUnknownFileTypes.cs?name=snippet_ConfigureMethod)]

With the preceding code, a request for a file with an unknown content type is returned as an image.

> [!WARNING]
> Enabling [ServeUnknownFileTypes](/dotnet/api/microsoft.aspnetcore.builder.staticfileoptions.serveunknownfiletypes#Microsoft_AspNetCore_Builder_StaticFileOptions_ServeUnknownFileTypes) is a security risk. It's disabled by default, and its use is discouraged. [FileExtensionContentTypeProvider](#fileextensioncontenttypeprovider) provides a safer alternative to serving files with non-standard extensions.

## Serve files from multiple locations

`UseStaticFiles` and `UseFileServer` defaults to the file provider pointing at *wwwroot*. You can provide additional instances of `UseStaticFiles` and `UseFileServer` with other file providers to serve files from other locations. For more information, see [this GitHub issue](https://github.com/dotnet/AspNetCore.Docs/issues/15578).

### Considerations

> [!WARNING]
> `UseDirectoryBrowser` and `UseStaticFiles` can leak secrets. Disabling directory browsing in production is highly recommended. Carefully review which directories are enabled via `UseStaticFiles` or `UseDirectoryBrowser`. The entire directory and its sub-directories become publicly accessible. Store files suitable for serving to the public in a dedicated directory, such as *\<content_root>/wwwroot*. Separate these files from MVC views, Razor Pages (2.x only), configuration files, etc.

* The URLs for content exposed with `UseDirectoryBrowser` and `UseStaticFiles` are subject to the case sensitivity and character restrictions of the underlying file system. For example, Windows is case insensitive&mdash;macOS and Linux aren't.

* ASP.NET Core apps hosted in IIS use the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module) to forward all requests to the app, including static file requests. The IIS static file handler isn't used. It has no chance to handle requests before they're handled by the module.

* Complete the following steps in IIS Manager to remove the IIS static file handler at the server or website level:
    1. Navigate to the **Modules** feature.
    1. Select **StaticFileModule** in the list.
    1. Click **Remove** in the **Actions** sidebar.

> [!WARNING]
> If the IIS static file handler is enabled **and** the ASP.NET Core Module is configured incorrectly, static files are served. This happens, for example, if the *web.config* file isn't deployed.

* Place code files (including *.cs* and *.cshtml*) outside of the app project's [web root](xref:fundamentals/index#web-root). A logical separation is therefore created between the app's client-side content and server-based code. This prevents server-side code from being leaked.

## Additional resources

* [Middleware](xref:fundamentals/middleware/index)
* [Introduction to ASP.NET Core](xref:index)
