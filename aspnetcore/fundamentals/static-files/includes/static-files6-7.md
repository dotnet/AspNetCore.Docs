## Directory browsing

Directory browsing allows directory listing within specified directories.

Directory browsing is disabled by default for security reasons. For more information, see [Security considerations for static files](#security-considerations-for-static-files).

Enable directory browsing with <xref:Microsoft.Extensions.DependencyInjection.DirectoryBrowserServiceExtensions.AddDirectoryBrowser%2A> and <xref:Microsoft.AspNetCore.Builder.DirectoryBrowserExtensions.UseDirectoryBrowser%2A>:

[!code-csharp[](~/fundamentals/static-files/samples/6.x/StaticFilesSample/Program.cs?name=snippet_db&highlight=9,23-37)]  

<!-- Select RP Home > Directory browsing -->
The preceding code allows directory browsing of the *wwwroot/images* folder using the URL `https://<hostname>/MyImages`, with links to each file and folder:

![directory browsing](~/fundamentals/static-files/_static/dir-browse.png)

`AddDirectoryBrowser` [adds services](https://github.com/dotnet/aspnetcore/blob/fc4e391aa58a9fa67fdc3a96da6cfcadd0648b17/src/Middleware/StaticFiles/src/DirectoryBrowserServiceExtensions.cs#L25) required by the directory browsing middleware, including <xref:System.Text.Encodings.Web.HtmlEncoder>. These services may be added by other calls, such as <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddRazorPages%2A>, but we recommend calling `AddDirectoryBrowser` to ensure the services are added in all apps.

## Serve default documents

<!-- Comment out  @*@page*@  default RP file -->

Setting a default page provides visitors a starting point on a site. To serve a default file from `wwwroot` without requiring the request URL to include the file's name, call the <xref:Microsoft.AspNetCore.Builder.DefaultFilesExtensions.UseDefaultFiles%2A> method:

[!code-csharp[](~/fundamentals/static-files/samples/6.x/StaticFilesSample/Program.cs?name=snippet_df&highlight=16)]  

`UseDefaultFiles` must be called before `UseStaticFiles` to serve the default file. `UseDefaultFiles` is a URL rewriter that doesn't serve the file.

With `UseDefaultFiles`, requests to a folder in `wwwroot` search for:

* `default.htm`
* `default.html`
* `index.htm`
* `index.html`

The first file found from the list is served as though the request included the file's name. The browser URL continues to reflect the URI requested.

The following code changes the default file name to `mydefault.html`:

[!code-csharp[](~/fundamentals/static-files/samples/6.x/StaticFilesSample/Program.cs?name=snippet_df2&highlight=16-19)] 

### UseFileServer for default documents

<xref:Microsoft.AspNetCore.Builder.FileServerExtensions.UseFileServer*> combines the functionality of `UseStaticFiles`, `UseDefaultFiles`, and optionally `UseDirectoryBrowser`.

Call `app.UseFileServer` to enable the serving of static files and the default file. Directory browsing isn't enabled:

[!code-csharp[](~/fundamentals/static-files/samples/6.x/StaticFilesSample/Program.cs?name=snippet_ufs&highlight=16)] 

The following code enables the serving of static files, the default file, and directory browsing:

<!--  app.UseFileServer(enableDirectoryBrowsing: true); returns the default HTML doc before the default Razor Page - ie, / returns the default HTML file, not Pages/Index.cshtml --
But when using app.UseDefaultFiles();, I need to comment out Pages/Index.cshtml or / returns  Pages/Index.cshtml, not the default HTML file.
-->
[!code-csharp[](~/fundamentals/static-files/samples/6.x/StaticFilesSample/Program.cs?name=snippet_ufs2&highlight=6,18)] 

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

<!-- https://localhost:44391/StaticFiles/ or the link on https://localhost:44391/Home2/MyStaticFilesRR -->

[!code-csharp[](~/fundamentals/static-files/samples/6.x/StaticFilesSample/Program.cs?name=snippet_tree&highlight=1,8,22-28)]

<xref:Microsoft.Extensions.DependencyInjection.DirectoryBrowserServiceExtensions.AddDirectoryBrowser%2A> must be called when the `EnableDirectoryBrowsing` property value is `true`.

Using the preceding file hierarchy and code, URLs resolve as follows:

| URI | Response |
| --- | --- |
| `https://<hostname>/StaticFiles/images/MyImage.jpg` | `MyStaticFiles/images/MyImage.jpg` |
| `https://<hostname>/StaticFiles` | `MyStaticFiles/default.html` |

If no default-named file exists in the *MyStaticFiles* directory, `https://<hostname>/StaticFiles` returns the directory listing with clickable links:

![Static files list](~/fundamentals/static-files/_static/db2.png)

<xref:Microsoft.AspNetCore.Builder.DefaultFilesExtensions.UseDefaultFiles*> and <xref:Microsoft.AspNetCore.Builder.DirectoryBrowserExtensions.UseDirectoryBrowser*> perform a client-side redirect from the target URI without a trailing `/`  to the target URI with a trailing `/`. For example, from `https://<hostname>/StaticFiles` to `https://<hostname>/StaticFiles/`. Relative URLs within the *StaticFiles* directory are invalid without a trailing slash (`/`) unless the <xref:Microsoft.AspNetCore.StaticFiles.Infrastructure.SharedOptions.RedirectToAppendTrailingSlash> option of <xref:Microsoft.AspNetCore.Builder.DefaultFilesOptions> is used.

## FileExtensionContentTypeProvider

The <xref:Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider> class contains a `Mappings` property that serves as a mapping of file extensions to MIME content types. In the following sample, several file extensions are mapped to known MIME types. The *.rtf* extension is replaced, and *.mp4* is removed:

<!-- test via /mapTest/image1.image and mapTest/test.htm3 /mapTest/TextFile.rtf -->
[!code-csharp[](~/fundamentals/static-files/samples/6.x/StaticFilesSample/Program.cs?name=snippet_fec&highlight=19-33)] 

See [MIME content types](https://www.iana.org/assignments/media-types/media-types.xhtml).

## Non-standard content types

The Static File Middleware understands almost 400 known file content types. If the user requests a file with an unknown file type, the Static File Middleware passes the request to the next middleware in the pipeline. If no middleware handles the request, a *404 Not Found* response is returned. If directory browsing is enabled, a link to the file is displayed in a directory listing.

The following code enables serving unknown types and renders the unknown file as an image:

[!code-csharp[](~/fundamentals/static-files/samples/6.x/StaticFilesSample/Program.cs?name=snippet_ns&highlight=16-20)]

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
