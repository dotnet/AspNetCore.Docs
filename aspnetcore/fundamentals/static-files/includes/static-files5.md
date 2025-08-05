## Directory browsing

Directory browsing allows directory listing within specified directories.

Directory browsing is disabled by default for security reasons. For more information, see [Security considerations for static files](#security-considerations-for-static-files).

Enable directory browsing with:

* <xref:Microsoft.Extensions.DependencyInjection.DirectoryBrowserServiceExtensions.AddDirectoryBrowser%2A> in `Startup.ConfigureServices`.
* <xref:Microsoft.AspNetCore.Builder.DirectoryBrowserExtensions.UseDirectoryBrowser%2A> in `Startup.Configure`.

[!code-csharp[](~/fundamentals/static-files/samples/3.x/StaticFilesSample/StartupBrowse.cs?name=snippet_ClassMembers&highlight=4,21-35)]

The preceding code allows directory browsing of the *wwwroot/images* folder using the URL `https://<hostname>/MyImages`, with links to each file and folder.

![directory browsing](~/fundamentals/static-files/_static/dir-browse.png)

## Serve default documents

Setting a default page provides visitors a starting point on a site. To serve a default file from `wwwroot` without requiring the request URL to include the file's name, call the <xref:Microsoft.AspNetCore.Builder.DefaultFilesExtensions.UseDefaultFiles%2A> method:

[!code-csharp[](~/fundamentals/static-files/samples/3.x/StaticFilesSample/StartupEmpty.cs?name=snippet_Configure&highlight=15)]

`UseDefaultFiles` must be called before `UseStaticFiles` to serve the default file. `UseDefaultFiles` is a URL rewriter that doesn't serve the file.

With `UseDefaultFiles`, requests to a folder in `wwwroot` search for:

* `default.htm`
* `default.html`
* `index.htm`
* `index.html`

The first file found from the list is served as though the request included the file's name. The browser URL continues to reflect the URI requested.

The following code changes the default file name to `mydefault.html`:

[!code-csharp[](~/fundamentals/static-files/samples/3.x/StaticFilesSample/StartupDefault.cs?name=snippet_DefaultFiles)]

The following code shows `Startup.Configure` with the preceding code:

[!code-csharp[](~/fundamentals/static-files/samples/3.x/StaticFilesSample/StartupDefault.cs?name=snippet_Configure&highlight=15-19)]

### UseFileServer for default documents

<xref:Microsoft.AspNetCore.Builder.FileServerExtensions.UseFileServer*> combines the functionality of `UseStaticFiles`, `UseDefaultFiles`, and optionally `UseDirectoryBrowser`.

Call `app.UseFileServer` to enable the serving of static files and the default file. Directory browsing isn't enabled. The following code shows `Startup.Configure` with `UseFileServer`:

[!code-csharp[](~/fundamentals/static-files/samples/3.x/StaticFilesSample/StartupEmpty2.cs?name=snippet_Configure&highlight=15)]

The following code enables the serving of static files, the default file, and directory browsing:

```csharp
app.UseFileServer(enableDirectoryBrowsing: true);
```

The following code shows `Startup.Configure` with the preceding code:

[!code-csharp[](~/fundamentals/static-files/samples/3.x/StaticFilesSample/StartupEmpty3.cs?name=snippet_Configure&highlight=15)]

Consider the following directory hierarchy:

* `wwwroot`
  * `css`
  * `images`
  * `js`
* `MyStaticFiles`
  * `images`
    * `MyImage.jpg`
  * `default.html`

The following code enables the serving of static files, the default file, and directory browsing of `MyStaticFiles`:

[!code-csharp[](~/fundamentals/static-files/samples/3.x/StaticFilesSample/StartupFileServer.cs?name=snippet_ClassMembers&highlight=4,21-31)]

<xref:Microsoft.Extensions.DependencyInjection.DirectoryBrowserServiceExtensions.AddDirectoryBrowser%2A> must be called when the `EnableDirectoryBrowsing` property value is `true`.

Using the file hierarchy and preceding code, URLs resolve as follows:

| URI | Response |
| --- | --- |
| `https://<hostname>/StaticFiles/images/MyImage.jpg` | `MyStaticFiles/images/MyImage.jpg` |
| `https://<hostname>/StaticFiles` | `MyStaticFiles/default.html` |

If no default-named file exists in the *MyStaticFiles* directory, `https://<hostname>/StaticFiles` returns the directory listing with clickable links:

![Static files list](~/fundamentals/static-files/_static/db2.png)

<xref:Microsoft.AspNetCore.Builder.DefaultFilesExtensions.UseDefaultFiles*> and <xref:Microsoft.AspNetCore.Builder.DirectoryBrowserExtensions.UseDirectoryBrowser*> perform a client-side redirect from the target URI without a trailing `/`  to the target URI with a trailing `/`. For example, from `https://<hostname>/StaticFiles` to `https://<hostname>/StaticFiles/`. Relative URLs within the *StaticFiles* directory are invalid without a trailing slash (`/`).

## FileExtensionContentTypeProvider

The <xref:Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider> class contains a `Mappings` property that serves as a mapping of file extensions to MIME content types. In the following sample, several file extensions are mapped to known MIME types. The *.rtf* extension is replaced, and *.mp4* is removed:

[!code-csharp[](~/fundamentals/static-files/samples/3.x/StaticFilesSample/StartupFileExtensionContentTypeProvider.cs?name=snippet_Provider)]

The following code shows `Startup.Configure` with the preceding code:

[!code-csharp[](~/fundamentals/static-files/samples/3.x/StaticFilesSample/StartupFileExtensionContentTypeProvider.cs?name=snippet_Configure&highlight=15-43)]

See [MIME content types](https://www.iana.org/assignments/media-types/media-types.xhtml).

## Non-standard content types

The Static File Middleware understands almost 400 known file content types. If the user requests a file with an unknown file type, the Static File Middleware passes the request to the next middleware in the pipeline. If no middleware handles the request, a *404 Not Found* response is returned. If directory browsing is enabled, a link to the file is displayed in a directory listing.

The following code enables serving unknown types and renders the unknown file as an image:

[!code-csharp[](~/fundamentals/static-files/samples/3.x/StaticFilesSample/StartupServeUnknownFileTypes.cs?name=snippet_UseStaticFiles)]

The following code shows `Startup.Configure` with the preceding code:

[!code-csharp[](~/fundamentals/static-files/samples/3.x/StaticFilesSample/StartupServeUnknownFileTypes.cs?name=snippet_Configure&highlight=15-19)]

With the preceding code, a request for a file with an unknown content type is returned as an image.

> [!WARNING]
> Enabling <xref:Microsoft.AspNetCore.Builder.StaticFileOptions.ServeUnknownFileTypes> is a security risk. It's disabled by default, and its use is discouraged. [FileExtensionContentTypeProvider](#fileextensioncontenttypeprovider) provides a safer alternative to serving files with non-standard extensions.

## Security considerations for static files

> [!WARNING]
> `UseDirectoryBrowser` and `UseStaticFiles` can leak secrets. Disabling directory browsing in production is highly recommended. Carefully review which directories are enabled via `UseStaticFiles` or `UseDirectoryBrowser`. The entire directory and its sub-directories become publicly accessible. Store files suitable for serving to the public in a dedicated directory, such as `<content_root>/wwwroot`. Separate these files from MVC views, Razor Pages, configuration files, etc.

* The URLs for content exposed with `UseDirectoryBrowser` and `UseStaticFiles` are subject to the case sensitivity and character restrictions of the underlying file system. For example, Windows is case insensitive, but macOS and Linux aren't.

* ASP.NET Core apps hosted in IIS use the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module) to forward all requests to the app, including static file requests. The IIS static file handler isn't used and has no chance to handle requests.

* Complete the following steps in IIS Manager to remove the IIS static file handler at the server or website level:
    1. Navigate to the **Modules** feature.
    1. Select **StaticFileModule** in the list.
    1. Click **Remove** in the **Actions** sidebar.

> [!WARNING]
> If the IIS static file handler is enabled **and** the ASP.NET Core Module is configured incorrectly, static files are served. This happens, for example, if the *web.config* file isn't deployed.

* Place code files, including `.cs` and `.cshtml`, outside of the app project's [web root](xref:fundamentals/index#web-root). A logical separation is therefore created between the app's client-side content and server-based code. This prevents server-side code from being leaked.
