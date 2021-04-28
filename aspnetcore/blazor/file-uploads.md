---
title: ASP.NET Core Blazor file uploads
author: guardrex
description: Learn how to upload files in Blazor with the InputFile component.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
ms.date: 04/28/2021
uid: blazor/file-uploads
zone_pivot_groups: blazor-hosting-models
---
# ASP.NET Core Blazor file uploads

Use the <xref:Microsoft.AspNetCore.Components.Forms.InputFile> component to read browser file data into .NET code, including for file uploads. The <xref:Microsoft.AspNetCore.Components.Forms.InputFile> component renders as an HTML `<input>` element of type `file`:

```html
<input type="file">
```

> [!WARNING]
> Always follow file upload security best practices. For more information, see <xref:mvc/models/file-uploads#security-considerations>.

By default, the user selects single files. Add the `multiple` attribute to permit the user to upload multiple files at once. When one or more files is selected by the user, the <xref:Microsoft.AspNetCore.Components.Forms.InputFile> component triggers an <xref:Microsoft.AspNetCore.Components.Forms.InputFile.OnChange> event and passes in an <xref:Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs> that provides access to the selected file list and details about each file.

To read data from a user-selected file:

* Call <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile.OpenReadStream%2A?displayProperty=nameWithType> on the file and read from the returned stream. For more information, see the [File streams](#file-streams) section.
* The <xref:System.IO.Stream> returned by <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile.OpenReadStream%2A> enforces a maximum size in bytes of the <xref:System.IO.Stream> being read. By default, files no larger than 512,000 bytes (500 KB) in size are allowed to be read before any further reads would result in an exception. This limit is present to prevent developers from accidentally reading large files in to memory. The `maxAllowedSize` parameter on <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile.OpenReadStream%2A> can be used to specify a larger size if required.
* Avoid reading the incoming file stream directly into memory. For example, don't copy file bytes into a <xref:System.IO.MemoryStream> or read as a byte array. These approaches can result in performance and security problems, especially in Blazor Server. Instead, consider copying file bytes to an external store, such as a blob or a file on disk. If you need access to a <xref:System.IO.Stream> that represents the file's bytes, use <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile.OpenReadStream%2A?displayProperty=nameWithType>.

  In the following examples, `broswerFile` represents the uploaded file and implements <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile>.

  ❌ The following approach is **NOT recommended** because the file's content is read into a string in memory (`reader`):

  ```csharp
  var reader = 
      await new StreamReader(browserFile.OpenReadStream()).ReadToEndAsync();
  ```

  ❌ The following approach is **NOT recommended** because the file's content is copied into a <xref:System.IO.MemoryStream> in memory (`memoryStream`):

  ```csharp
  var memoryStream = new MemoryStream();
  browserFile.OpenReadStream().CopyToAsync(memoryStream);
  var blobContainerClient = 
      new BlobContainerClient(storageConnectionString, container);
  await blobContainerClient.UploadBlobAsync(
      browserFile.Name, memoryStream));
  ```

  ✔️ Recommended:

  ```csharp
  var blobContainerClient = 
      new BlobContainerClient(storageConnectionString, container);
  await blobContainerClient.UploadBlobAsync(
      browserFile.Name, browserFile.OpenReadStream());
  ```

A component that receives an image file can call the <xref:Microsoft.AspNetCore.Components.Forms.BrowserFileExtensions.RequestImageFileAsync%2A?displayProperty=nameWithType> convenience method on the file to resize the image data within the browser's JavaScript runtime before the image is streamed into the app.

The following example demonstrates multiple file upload in a component. <xref:Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs.GetMultipleFiles%2A?displayProperty=nameWithType> allows reading multiple files. Specify the maximum number of files you expect to read to prevent a malicious user from uploading a larger number of files than the app expects. <xref:Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs.File?displayProperty=nameWithType> allows reading the first and only file if the file upload doesn't support multiple files.

> [!NOTE]
> <xref:Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs> is in the <xref:Microsoft.AspNetCore.Components.Forms?displayProperty=fullName> namespace, which is typically one of the namespaces in the app's `_Imports.razor` file.

`Pages/FileUpload1.razor`:

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/file-uploads/FileUpload1.razor)]

`IBrowserFile` returns metadata [exposed by the browser](https://developer.mozilla.org/docs/Web/API/File#Instance_properties) as properties. This metadata can be useful for preliminary validation.

## Upload files to a server

::: zone pivot="webassembly"

The following example demonstrates uploading files to a server using a hosted Blazor WebAssembly solution.

::: zone-end

::: zone pivot="server"

The following example demonstrates uploading files to a server using a Blazor Server app and a backend server API app.

::: zone-end

> [!WARNING]
> Use caution when providing users with the ability to upload files to a server. For more information, see <xref:mvc/models/file-uploads#security-considerations>.

### Upload result class

::: zone pivot="webassembly"

The following `UploadResult` class in the **`Shared`** project maintains the result of an uploaded file. When a file fails to upload on the server, an error code is returned in `ErrorCode` for display to the user. A safe stored file name is generated on the server for each file and returned to the client in `StoredFileName` for display. Files are keyed between the client and server using the unsafe/untrusted file name in `FileName`.

::: zone-end

::: zone pivot="server"

The following `UploadResult` class is placed in the client project and in the server API project to maintain the result of an uploaded file. When a file fails to upload on the server, an error code is returned in `ErrorCode` for display to the user. A safe stored file name is generated on the server for each file and returned to the client in `StoredFileName` for display. Files are keyed between the client and server using the unsafe/untrusted file name in `FileName`.

::: zone-end

`UploadResult.cs`:

```csharp
public class UploadResult
{
    public bool Uploaded { get; set; }
    public string FileName { get; set; }
    public string StoredFileName { get; set; }
    public int ErrorCode { get; set; }
}
```

### Upload component

::: zone pivot="webassembly"

The following `FileUpload2` component in the **`Client`** project:

* Permits users to upload files from the client.
* Displays the untrusted/unsafe file name provided by the client in the UI because Razor automatically HTML-encodes strings.

  **Don't trust file names supplied by clients for other uses**, such as:

  * Saving the file to a file system or service.
  * Display in UIs that don't encode file names automatically or via developer code.

  For more information on security considerations when uploading files to a server, see <xref:mvc/models/file-uploads#security-considerations>.

`Pages/FileUpload2.razor`:

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/file-uploads/FileUpload2.razor)]

To use the following code, create a `Development/unsafe_uploads` folder at the root of the **`Server`** project. Because the example uses the app's [environment](xref:blazor/fundamentals/environments), additional folders are required if other environments are used in testing and production (for example, `Staging/unsafe_uploads`, `Production/unsafe_uploads`).

::: zone-end

::: zone pivot="server"

The following `FileUpload2` component:

* Permits users to upload files from the client.
* Displays the untrusted/unsafe file name provided by the client in the UI because Razor automatically HTML-encodes strings.

  **Don't trust file names supplied by clients for other uses**, such as:

  * Saving the file to a file system or service.
  * Display in UIs that don't encode file names automatically or via developer code.

  For more information on security considerations when uploading files to a server, see <xref:mvc/models/file-uploads#security-considerations>.

`Pages/FileUpload2.razor`:

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_Server/Pages/file-uploads/FileUpload2.razor)]

To use the following code, create a `Development/unsafe_uploads` folder at the root of the server API project. Because the example uses the app's [environment](xref:blazor/fundamentals/environments), additional folders are required if other environments are used in testing and production (for example, `Staging/unsafe_uploads`, `Production/unsafe_uploads`).

::: zone-end

### Upload controller

::: zone pivot="webassembly"

The following controller in the **`Server`** project saves uploaded files from the client.

::: zone-end

::: zone pivot="server"

The following controller in the server API project saves uploaded files from the client.

::: zone-end

> [!WARNING]
> The example saves files without scanning their contents. In production scenarios, an anti-virus/anti-malware scanner API is used on files before making them available for download or for use by other systems. For more information on security considerations when uploading files to a server, see <xref:mvc/models/file-uploads#security-considerations>.

`Controllers/FilesaveController.cs`:

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("[controller]")]
public class FilesaveController : ControllerBase
{
    private readonly IWebHostEnvironment env;
    private readonly ILogger<FilesaveController> logger;

    public FilesaveController(IWebHostEnvironment env,
        ILogger<FilesaveController> logger)
    {
        this.env = env;
        this.logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<IList<UploadResult>>> PostFile(
        [FromForm] IEnumerable<IFormFile> files)
    {
        var maxAllowedFiles = 3;
        long maxFileSize = 1024 * 1024 * 15;
        var filesProcessed = 0;
        var resourcePath = new Uri($"{Request.Scheme}://{Request.Host}/");
        List<UploadResult> uploadResults = new();

        foreach (var file in files)
        {
            var uploadResult = new UploadResult();
            string trustedFileNameForFileStorage;
            var untrustedFileName = file.FileName;
            uploadResult.FileName = untrustedFileName;
            var trustedFileNameForDisplay =
                WebUtility.HtmlEncode(untrustedFileName);

            if (filesProcessed < maxAllowedFiles)
            {
                if (file.Length == 0)
                {
                    logger.LogInformation("{FileName} length is 0 (Err: 1)",
                        trustedFileNameForDisplay);
                    uploadResult.ErrorCode = 1;
                }
                else if (file.Length > maxFileSize)
                {
                    logger.LogInformation("{FileName} of {Length} bytes is " +
                        "larger than the limit of {Limit} bytes (Err: 2)",
                        trustedFileNameForDisplay, file.Length, maxFileSize);
                    uploadResult.ErrorCode = 2;
                }
                else
                {
                    try
                    {
                        trustedFileNameForFileStorage = Path.GetRandomFileName();
                        var path = Path.Combine(env.ContentRootPath,
                            env.EnvironmentName, "unsafe_uploads",
                            trustedFileNameForFileStorage);

                        using FileStream fs = new(path, FileMode.Create);
                        await file.CopyToAsync(fs);

                        logger.LogInformation("{FileName} saved at {Path}",
                            trustedFileNameForDisplay, path);
                        uploadResult.Uploaded = true;
                        uploadResult.StoredFileName = trustedFileNameForFileStorage;
                    }
                    catch (IOException ex)
                    {
                        logger.LogError("{FileName} error on upload (Err: 3): {Message}",
                            trustedFileNameForDisplay, ex.Message);
                        uploadResult.ErrorCode = 3;
                    }
                }

                filesProcessed++;
            }
            else
            {
                logger.LogInformation("{FileName} not uploaded because the " +
                    "request exceeded the allowed {Count} of files (Err: 4)",
                    trustedFileNameForDisplay, maxAllowedFiles);
                uploadResult.ErrorCode = 4;
            }

            uploadResults.Add(uploadResult);
        }

        return new CreatedResult(resourcePath, uploadResults);
    }
}
```

## File streams

::: zone pivot="webassembly"

In Blazor WebAssembly, file data is streamed directly into the .NET code within the browser.

::: zone-end

::: zone pivot="server"

In Blazor Server, file data is streamed over the SignalR connection into .NET code on the server as the file is read from the stream. <xref:Microsoft.AspNetCore.Components.Forms.RemoteBrowserFileStreamOptions> allows configuring file upload characteristics for Blazor Server.

::: zone-end

## Additional resources

* <xref:mvc/models/file-uploads#security-considerations>
* <xref:blazor/forms-validation>
