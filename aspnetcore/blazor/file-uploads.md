---
title: ASP.NET Core Blazor file uploads
author: guardrex
description: Learn how to upload files in Blazor with the InputFile component.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 02/04/2023
uid: blazor/file-uploads
zone_pivot_groups: blazor-hosting-models
---
# ASP.NET Core Blazor file uploads

This article explains how to upload files in Blazor with the <xref:Microsoft.AspNetCore.Components.Forms.InputFile> component.

> [!WARNING]
> Always follow security best practices when permitting users to upload files. For more information, see <xref:mvc/models/file-uploads#security-considerations>.

Use the <xref:Microsoft.AspNetCore.Components.Forms.InputFile> component to read browser file data into .NET code. The <xref:Microsoft.AspNetCore.Components.Forms.InputFile> component renders an HTML `<input>` element of type `file`. By default, the user selects single files. Add the `multiple` attribute to permit the user to upload multiple files at once.

File selection isn't cumulative when using an <xref:Microsoft.AspNetCore.Components.Forms.InputFile> component or its underlying [HTML `<input type="file">`](https://developer.mozilla.org/docs/Web/HTML/Element/input/file), so you can't add files to an existing file selection. The component always replaces the user's initial file selection, so file references from prior selections aren't available.

The following <xref:Microsoft.AspNetCore.Components.Forms.InputFile> component executes the `LoadFiles` method when the <xref:Microsoft.AspNetCore.Components.Forms.InputFile.OnChange> ([`change`](https://developer.mozilla.org/docs/Web/API/HTMLElement/change_event)) event occurs. An <xref:Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs> provides access to the selected file list and details about each file:

```razor
<InputFile OnChange="@LoadFiles" multiple />

@code {
    private void LoadFiles(InputFileChangeEventArgs e)
    {
        ...
    }
}
```

Rendered HTML:

```html
<input multiple="" type="file" _bl_2="">
```

> [!NOTE]
> In the preceding example, the `<input>` element's `_bl_2` attribute is used for Blazor's internal processing.

To read data from a user-selected file, call <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile.OpenReadStream%2A?displayProperty=nameWithType> on the file and read from the returned stream. For more information, see the [File streams](#file-streams) section.

<xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile.OpenReadStream%2A> enforces a maximum size in bytes of its <xref:System.IO.Stream>. Reading one file or multiple files larger than 500 KB results in an exception. This limit prevents developers from accidentally reading large files into memory. The `maxAllowedSize` parameter of <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile.OpenReadStream%2A> can be used to specify a larger size if required.

If you need access to a <xref:System.IO.Stream> that represents the file's bytes, use <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile.OpenReadStream%2A?displayProperty=nameWithType>. Avoid reading the incoming file stream directly into memory all at once. For example, don't copy all of the file's bytes into a <xref:System.IO.MemoryStream> or read the entire stream into a byte array all at once. These approaches can result in performance and security problems, especially for Blazor Server apps. Instead, consider adopting either of the following approaches:

* On the server of a hosted Blazor WebAssembly app or a Blazor Server app, copy the stream directly to a file on disk without reading it into memory. Note that Blazor apps aren't able to access the client's file system directly. 
* Upload files from the client directly to an external service. For more information, see the [Upload files to an external service](#upload-files-to-an-external-service) section.

In the following examples, `browserFile` represents the uploaded file and implements <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile>. Working implementations for <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile> are shown in the file upload components later in this article.

<span aria-hidden="true">❌</span><span class="visually-hidden">Unsupported:</span> The following approach is **NOT recommended** because the file's <xref:System.IO.Stream> content is read into a <xref:System.String> in memory (`reader`):

```csharp
var reader = 
    await new StreamReader(browserFile.OpenReadStream()).ReadToEndAsync();
```

<span aria-hidden="true">❌</span><span class="visually-hidden">Unsupported:</span> The following approach is **NOT recommended** for [Microsoft Azure Blob Storage](/azure/storage/blobs/storage-blobs-overview) because the file's <xref:System.IO.Stream> content is copied into a <xref:System.IO.MemoryStream> in memory (`memoryStream`) before calling <xref:Azure.Storage.Blobs.BlobContainerClient.UploadBlobAsync%2A>:

```csharp
var memoryStream = new MemoryStream();
browserFile.OpenReadStream().CopyToAsync(memoryStream);
await blobContainerClient.UploadBlobAsync(
    trustedFilename, memoryStream));
```

<span aria-hidden="true">✔️</span><span class="visually-hidden">Supported:</span> The following approach is **recommended** because the file's <xref:System.IO.Stream> is provided directly to the consumer, a <xref:System.IO.FileStream> that creates the file at the provided path:

```csharp
await using FileStream fs = new(path, FileMode.Create);
await browserFile.OpenReadStream().CopyToAsync(fs);
```

<span aria-hidden="true">✔️</span><span class="visually-hidden">Supported:</span> The following approach is **recommended** for [Microsoft Azure Blob Storage](/azure/storage/blobs/storage-blobs-overview) because the file's <xref:System.IO.Stream> is provided directly to <xref:Azure.Storage.Blobs.BlobContainerClient.UploadBlobAsync%2A>:

```csharp
await blobContainerClient.UploadBlobAsync(
    trustedFilename, browserFile.OpenReadStream());
```

A component that receives an image file can call the <xref:Microsoft.AspNetCore.Components.Forms.BrowserFileExtensions.RequestImageFileAsync%2A?displayProperty=nameWithType> convenience method on the file to resize the image data within the browser's JavaScript runtime before the image is streamed into the app. Use cases for calling <xref:Microsoft.AspNetCore.Components.Forms.BrowserFileExtensions.RequestImageFileAsync%2A> are most appropriate for Blazor WebAssembly apps.

## File size read and upload limits

:::moniker range=">= aspnetcore-6.0"

:::zone pivot="server"

There's no file size read or upload limit for the <xref:Microsoft.AspNetCore.Components.Forms.InputFile> component in Blazor Server apps.

:::zone-end

:::zone pivot="webassembly"

Prior to the release of ASP.NET Core 6.0, the <xref:Microsoft.AspNetCore.Components.Forms.InputFile> component had a file size read limit of 2 GB. In ASP.NET Core 6.0 or later, the <xref:Microsoft.AspNetCore.Components.Forms.InputFile> component has no file size read limit.

In all versions of ASP.NET Core to date, Blazor WebAssembly reads the file's bytes into a single JavaScript array buffer when marshalling the data from JavaScript to C#, so large file uploads (> 250 MB) may fail. For more information, see [Net6P7: Blazor WASM can't upload large files (500MB, 1GB, 2GB) (dotnet/aspnetcore #35899)](https://github.com/dotnet/aspnetcore/issues/35899).

[!INCLUDE[](~/includes/package-reference.md)]

A future runtime release may address the file upload limitation. For more information, see [[browser][wasm] Request Streaming upload via http handler (dotnet/runtime #36634)](https://github.com/dotnet/runtime/issues/36634), where you can express your interest in the proposal by adding a thumbs-up (&#128077;) to the issue's opening comment.

To resolve the file size upload limitation in Blazor WebAssembly apps, we recommend implementing file uploads entirely in JavaScript by [streaming requests with the fetch API](https://developer.chrome.com/articles/fetch-streaming-requests/). Using Ranges avoids the problem and is more reliable, allowing the app to avoid re-uploading entire files when a file upload fails, only missing chunks are updated.

:::zone-end

:::moniker-end

:::moniker range="< aspnetcore-6.0"

The maximum supported file size for the <xref:Microsoft.AspNetCore.Components.Forms.InputFile> component is 2 GB.

To resolve the file size read limitation, we recommend implementing file uploads entirely in JavaScript by [streaming requests with the fetch API](https://developer.chrome.com/articles/fetch-streaming-requests/). Using Ranges avoids the file limitation problem and is more reliable, allowing the app to avoid re-uploading entire files when a file upload fails (only the missing chunk is updated).

:::moniker-end

## Upload files example

The following example demonstrates multiple file upload in a component. <xref:Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs.GetMultipleFiles%2A?displayProperty=nameWithType> allows reading multiple files. Specify the maximum number of files to prevent a malicious user from uploading a larger number of files than the app expects. <xref:Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs.File?displayProperty=nameWithType> allows reading the first and only file if the file upload doesn't support multiple files.

> [!NOTE]
> <xref:Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs> is in the <xref:Microsoft.AspNetCore.Components.Forms?displayProperty=fullName> namespace, which is typically one of the namespaces in the app's `_Imports.razor` file. When the namespace is present in the `_Imports.razor` file, it provides API member access to the app's components:
>
> ```razor
> using Microsoft.AspNetCore.Components.Forms
> ```
>
> Namespaces in the `_Imports.razor` file aren't applied to C# files (`.cs`). C# files require an explicit [`using`](/dotnet/csharp/language-reference/language-specification/namespaces#using-directives) directive.

> [!NOTE]
> For testing file upload components, you can create test files of any size with [PowerShell](/powershell/):
>
> ```powershell
> $out = new-object byte[] {SIZE}; (new-object Random).NextBytes($out); [IO.File]::WriteAllBytes('{PATH}', $out)
> ```
>
> In the preceding command:
>
> * The `{SIZE}` placeholder is the size of the file in bytes (for example, `2097152` for a 2 MB file).
> * The `{PATH}` placeholder is the path and file with file extension (for example, `D:/test_files/testfile2MB.txt`).

`Pages/FileUpload1.razor`:

:::zone pivot="server"

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_Server/Pages/file-uploads/FileUpload1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_Server/Pages/file-uploads/FileUpload1.razor":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_Server/Pages/file-uploads/FileUpload1.razor":::

:::moniker-end

:::zone-end

:::zone pivot="webassembly"

> [!NOTE]
> The following example merely processes file bytes and doesn't send (upload) files to a destination outside of the app. For an example of a Razor component that sends a file to a server or service, see the following sections:
> 
> * [Upload files to a server](#upload-files-to-a-server)
> * [Upload files to an external service](#upload-files-to-an-external-service)

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/file-uploads/FileUpload1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/file-uploads/FileUpload1.razor":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/file-uploads/FileUpload1.razor":::

:::moniker-end

:::zone-end

<xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile> returns metadata [exposed by the browser](https://developer.mozilla.org/docs/Web/API/File#Instance_properties) as properties. Use this metadata for preliminary validation.

> [!WARNING]
> Never trust the values of the following properties, especially the <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile.Name> property for display in the UI. Treat all user-supplied data as a significant security risk to the app, server, and network. For more information, see <xref:mvc/models/file-uploads#security-considerations>.

* <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile.Name>
* <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile.Size>
* <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile.LastModified>
* <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile.ContentType>

## Upload files to a server

:::zone pivot="server"

The following example demonstrates uploading files from a Blazor Server app to a backend web API controller in a separate app, possibly on a separate server.

In the Blazor Server app, add <xref:System.Net.Http.IHttpClientFactory> and related services that allow the app to create <xref:System.Net.Http.HttpClient> instances.

In `Program.cs`:

```csharp
builder.Services.AddHttpClient();
```

For more information, see <xref:fundamentals/http-requests>.

For the examples in this section:

* The web API runs at the URL: `https://localhost:5001`
* The Blazor Server app runs at the URL: `https://localhost:5003`

For testing, the preceding URLs are configured in the projects' `Properties/launchSettings.json` files.

:::zone-end

:::zone pivot="webassembly"

The following example demonstrates uploading files to a web API controller in the **:::no-loc text="Server":::** app of a hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln).

> [!IMPORTANT]
> When executing a hosted Blazor WebAssembly app, run the app from the solution's **:::no-loc text="Server":::** project.

:::zone-end

### Upload result class

:::zone pivot="server"

The following `UploadResult` class is placed in the client project and in the web API project to maintain the result of an uploaded file. When a file fails to upload on the server, an error code is returned in `ErrorCode` for display to the user. A safe file name is generated on the server for each file and returned to the client in `StoredFileName` for display. Files are keyed between the client and server using the unsafe/untrusted file name in `FileName`.

`UploadResult.cs`:

:::moniker range=">= aspnetcore-6.0"

```csharp
public class UploadResult
{
    public bool Uploaded { get; set; }
    public string? FileName { get; set; }
    public string? StoredFileName { get; set; }
    public int ErrorCode { get; set; }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
public class UploadResult
{
    public bool Uploaded { get; set; }
    public string FileName { get; set; }
    public string StoredFileName { get; set; }
    public int ErrorCode { get; set; }
}
```

:::moniker-end

:::zone-end

:::zone pivot="webassembly"

The following `UploadResult` class in the **:::no-loc text="Shared":::** project maintains the result of an uploaded file. When a file fails to upload on the server, an error code is returned in `ErrorCode` for display to the user. A safe file name is generated on the server for each file and returned to the client in `StoredFileName` for display. Files are keyed between the client and server using the unsafe/untrusted file name in `FileName`. In the following example, the project's namespace is `BlazorSample.Shared`.

`UploadResult.cs` in the **:::no-loc text="Shared":::** project of the hosted Blazor WebAssembly [solution](xref:blazor/tooling#visual-studio-solution-file-sln):

:::moniker range=">= aspnetcore-6.0"

```csharp
namespace BlazorSample.Shared
{
    public class UploadResult
    {
        public bool Uploaded { get; set; }
        public string? FileName { get; set; }
        public string? StoredFileName { get; set; }
        public int ErrorCode { get; set; }
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
namespace BlazorSample.Shared
{
    public class UploadResult
    {
        public bool Uploaded { get; set; }
        public string FileName { get; set; }
        public string StoredFileName { get; set; }
        public int ErrorCode { get; set; }
    }
}
```

:::moniker-end

To make the `UploadResult` class available to the **:::no-loc text="Client":::** project, add an import to the **:::no-loc text="Client":::** project's `_Imports.razor` file for the **:::no-loc text="Shared":::** project:

```razor
@using BlazorSample.Shared
```

:::zone-end

> [!NOTE]
> A security best practice for production apps is to avoid sending error messages to clients that might reveal sensitive information about an app, server, or network. Providing detailed error messages can aid a malicious user in devising attacks on an app, server, or network. The example code in this section only sends back an error code number (`int`) for display by the component client-side if a server-side error occurs. If a user requires assistance with a file upload, they provide the error code to support personnel for support ticket resolution without ever knowing the exact cause of the error.

### Upload component

The following `FileUpload2` component:

* Permits users to upload files from the client.
* Displays the untrusted/unsafe file name provided by the client in the UI. The untrusted/unsafe file name is automatically HTML-encoded by Razor for safe display in the UI.

> [!WARNING]
> **Don't trust file names supplied by clients** for:
>
> * Saving the file to a file system or service.
> * Display in UIs that don't encode file names automatically or via developer code.
>
> For more information on security considerations when uploading files to a server, see <xref:mvc/models/file-uploads#security-considerations>.

:::zone pivot="server"

`Pages/FileUpload2.razor` in the Blazor Server app:

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_Server/Pages/file-uploads/FileUpload2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_Server/Pages/file-uploads/FileUpload2.razor":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_Server/Pages/file-uploads/FileUpload2.razor":::

:::moniker-end

:::zone-end

:::zone pivot="webassembly"

`Pages/FileUpload2.razor` in the **:::no-loc text="Client":::** project:

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/file-uploads/FileUpload2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/file-uploads/FileUpload2.razor":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/file-uploads/FileUpload2.razor":::

:::moniker-end

:::zone-end

### Upload controller

:::zone pivot="server"

The following controller in the web API project saves uploaded files from the client.

> [!IMPORTANT]
> The controller in this section is intended for use in a separate web API project from the Blazor Server app.

:::moniker range="= aspnetcore-6.0"

> [!NOTE]
> Binding form values with the [`[FromForm]` attribute](xref:Microsoft.AspNetCore.Mvc.FromFormAttribute) isn't natively supported for [Minimal APIs](xref:fundamentals/minimal-apis?view=aspnetcore-6.0#explicit-parameter-binding) in ASP.NET Core 6.0. Therefore, the following `Filesave` controller example can't be converted to use Minimal APIs. Support for binding from form values with Minimal APIs is available in ASP.NET Core 7.0 or later.

:::moniker-end

**To use the following code, create a `Development/unsafe_uploads` folder at the root of the web API project for the app running in the `Development` environment.**

Because the example uses the app's [environment](xref:blazor/fundamentals/environments) as part of the path where files are saved, additional folders are required if other environments are used in testing and production. For example, create a `Staging/unsafe_uploads` folder for the `Staging` environment. Create a `Production/unsafe_uploads` folder for the `Production` environment.

> [!WARNING]
> The example saves files without scanning their contents, and the guidance in this article doesn't take into account additional security best practices for uploaded files. On staging and production systems, disable execute permission on the upload folder and scan files with an anti-virus/anti-malware scanner API immediately after upload. For more information, see <xref:mvc/models/file-uploads#security-considerations>.

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
        long maxFileSize = 1024 * 15;
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

                        await using FileStream fs = new(path, FileMode.Create);
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

:::zone-end

:::zone pivot="webassembly"

The following controller in the **:::no-loc text="Server":::** project saves uploaded files from the client.

:::moniker range="< aspnetcore-6.0"

> [!NOTE]
> Binding form values with the [`[FromForm]` attribute](xref:Microsoft.AspNetCore.Mvc.FromFormAttribute) isn't natively supported for [Minimal APIs](xref:fundamentals/minimal-apis?view=aspnetcore-6.0#explicit-parameter-binding) in ASP.NET Core 6.0. Therefore, the following `Filesave` controller example can't be converted to use Minimal APIs. Support for binding from form values with Minimal APIs is available in ASP.NET Core 7.0 or later.

:::moniker-end

**To use the following code, create a `Development/unsafe_uploads` folder at the root of the :::no-loc text="Server"::: project for the app running in the `Development` environment.**

Because the example uses the app's [environment](xref:blazor/fundamentals/environments) as part of the path where files are saved, additional folders are required if other environments are used in testing and production. For example, create a `Staging/unsafe_uploads` folder for the `Staging` environment. Create a `Production/unsafe_uploads` folder for the `Production` environment.

> [!WARNING]
> The example saves files without scanning their contents, and the guidance in this article doesn't take into account additional security best practices for uploaded files. On staging and production systems, disable execute permission on the upload folder and scan files with an anti-virus/anti-malware scanner API immediately after upload. For more information, see <xref:mvc/models/file-uploads#security-considerations>.

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
using BlazorSample.Shared;

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
        long maxFileSize = 1024 * 15;
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

                        await using FileStream fs = new(path, FileMode.Create);
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

:::zone-end

In the preceding code, <xref:System.IO.Path.GetRandomFileName%2A> is called to generate a secure filename. Never trust the filename provided by the browser, as an attacker may choose an existing filename that overwrites an existing file or send a path that attempts to write outside of the app.

## Cancel a file upload

A file upload component can detect when a user has cancelled an upload by using a <xref:System.Threading.CancellationToken> when calling into the <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile.OpenReadStream%2A?displayProperty=nameWithType> or <xref:System.IO.StreamReader.ReadAsync%2A?displayProperty=nameWithType>.

Create a <xref:System.Threading.CancellationTokenSource> for the `InputFile` component. At the start of the `OnInputFileChange` method, check if a previous upload is in progress.

If a file upload is in progress:

* Call <xref:System.Threading.CancellationTokenSource.Cancel%2A> on the previous upload.
* Create a new <xref:System.Threading.CancellationTokenSource> for the next upload and pass the <xref:System.Threading.CancellationTokenSource.Token?displayProperty=nameWithType> to <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile.OpenReadStream%2A> or <xref:System.IO.StreamReader.ReadAsync%2A>.

:::zone pivot="server"

## Upload files with progress

The following example demonstrates how to upload files in a Blazor Server app with upload progress displayed to the user.

To use the following example in a test app:

* **Create a folder to save uploaded files for the `Development` environment: `Development/unsafe_uploads`.**
* Configure the maximum file size (`maxFileSize`, 15 KB in the following example) and maximum number of allowed files (`maxAllowedFiles`, 3 in the following example).
* Set the buffer to a different value (10 KB in the following example), if desired, for increased granularity in progress reporting. We don't recommended using a buffer larger than 30 KB due to performance and security concerns.

> [!WARNING]
> The example saves files without scanning their contents, and the guidance in this article doesn't take into account additional security best practices for uploaded files. On staging and production systems, disable execute permission on the upload folder and scan files with an anti-virus/anti-malware scanner API immediately after upload. For more information, see <xref:mvc/models/file-uploads#security-considerations>.

`Pages/FileUpload3.razor`:

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_Server/Pages/file-uploads/FileUpload3.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_Server/Pages/file-uploads/FileUpload3.razor":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_Server/Pages/file-uploads/FileUpload3.razor":::

:::moniker-end

For more information, see the following API resources:

* <xref:System.IO.FileStream>: Provides a <xref:System.IO.Stream> for a file, supporting both synchronous and asynchronous read and write operations.
* <xref:System.IO.FileStream.ReadAsync%2A?displayProperty=nameWithType>: The preceding `FileUpload3` component reads the stream asynchronously with <xref:System.IO.FileStream.ReadAsync%2A>. Reading a stream synchronously with <xref:System.IO.FileStream.Read%2A> isn't supported in Razor components.

:::zone-end

## File streams

:::zone pivot="server"

In Blazor Server, file data is streamed over the SignalR connection into .NET code on the server as the file is read.

:::moniker range="= aspnetcore-5.0"

<xref:Microsoft.AspNetCore.Components.Forms.RemoteBrowserFileStreamOptions> allows configuring file upload characteristics for Blazor Server.

:::moniker-end

:::zone-end

:::zone pivot="webassembly"

In Blazor WebAssembly, file data is streamed directly into the .NET code within the browser.

:::zone-end

:::moniker range=">= aspnetcore-6.0"

## Upload image preview

For an image preview of uploading images, start by adding an `InputFile` component with a component reference and an `OnChange` handler:

```razor
<InputFile @ref="inputFile" OnChange="@ShowPreview" />
```

Add an image element with an [element reference](xref:blazor/js-interop/call-javascript-from-dotnet#capture-references-to-elements), which serves as the placeholder for the image preview:

```razor
<img @ref="previewImageElem" />
```

Add the associated references:

```razor
@code {
    private InputFile? inputFile;
    private ElementReference previewImageElem;
}
```

In JavaScript, add a function called with an HTML [`input`](https://developer.mozilla.org/docs/Web/HTML/Element/input/) and [`img`](https://developer.mozilla.org/docs/Web/HTML/Element/img) element that performs the following:

* Extracts the selected file.
* Creates an object URL with [`createObjectURL`](https://developer.mozilla.org/docs/Web/API/URL/createObjectURL).
* Sets an event listener to revoke the object URL with [`revokeObjectURL`](https://developer.mozilla.org/docs/Web/API/URL/revokeObjectURL) after the image is loaded, so memory isn't leaked.
* Sets the `img` element's source to display the image.

```javascript
window.previewImage = (inputElem, imgElem) => {
  const url = URL.createObjectURL(inputElem.files[0]);
  imgElem.addEventListener('load', () => URL.revokeObjectURL(url), { once: true });
  imgElem.src = url;
}
```

Finally, use an injected <xref:Microsoft.JSInterop.IJSRuntime> to add the `OnChange` handler that calls the JavaScript function:

```razor
@inject IJSRuntime JS

...

@code {
    ...

    private async Task ShowPreview() => await JS.InvokeVoidAsync(
        "previewImage", inputFile!.Element, previewImageElem);
}
```

The preceding example is for uploading a single image. The approach can be expanded to support `multiple` images.

The following `FileUpload4` component shows the full working example.

`Pages/FileUpload4.razor`:

```razor
@page "/file-upload-4"
@inject IJSRuntime JS

<h1>File Upload Example</h1>

<InputFile @ref="inputFile" OnChange="@ShowPreview" />

<img style="max-width:200px;max-height:200px" @ref="previewImageElem" />

@code {
    private InputFile? inputFile;
    private ElementReference previewImageElem;

    private async Task ShowPreview() => await JS.InvokeVoidAsync(
        "previewImage", inputFile!.Element, previewImageElem);
}
```

:::moniker-end

## Upload files to an external service

Instead of an app handling file upload bytes and the app's server receiving uploaded files, clients can directly upload files to an external service. The app can safely process the files from the external service on demand. This approach hardens the app and its server against malicious attacks and potential performance problems.

Consider an approach that uses [Azure Files](https://azure.microsoft.com/services/storage/files/), [Azure Blob Storage](https://azure.microsoft.com/services/storage/blobs/), or a third-party service with the following potential benefits:

* Upload files from the client directly to an external service with a JavaScript client library or REST API. For example, Azure offers the following client libraries and APIs:
  * [Azure Storage File Share client library](/javascript/api/overview/azure/storage-file-share-readme)
  * [Azure Files REST API](/rest/api/storageservices/file-service-rest-api)
  * [Azure Storage Blob client library for JavaScript](/javascript/api/overview/azure/storage-blob-readme)
  * [Blob service REST API](/rest/api/storageservices/blob-service-rest-api)
* Authorize user uploads with a user-delegated shared-access signature (SAS) token generated by the app (server-side) for each client file upload. For example, Azure offers the following SAS features:
  * [Azure Storage File Share client library for JavaScript: with SAS Token](/javascript/api/overview/azure/storage-file-share-readme#with-sas-token)
  * [Azure Storage Blob client library for JavaScript: with SAS Token](/javascript/api/overview/azure/storage-blob-readme#with-sas-token)
* Provide automatic redundancy and file share backup.
* Limit uploads with quotas. Note that Azure Blob Storage's quotas are set at the account level, not the container level. However, Azure Files quotas are at the file share level and might provide better control over upload limits. For more information, see the Azure documents linked earlier in this list.
* Secure files with server-side encryption (SSE).

For more information on Azure Blob Storage and Azure Files, see the [Azure Storage documentation](/azure/storage/).

:::zone pivot="server"

## SignalR message size limit

File uploads may fail even before they start, when Blazor retrieves data about the files that exceeds the maximum SignalR message size.

SignalR defines a message size limit that applies to every message Blazor receives, and the <xref:Microsoft.AspNetCore.Components.Forms.InputFile> component streams files to the server in messages that respect the configured limit. However, the first message, which indicates the set of files to upload, is sent as a unique single message. The size of the first message may exceed the SignalR message size limit. The issue isn't related to the size of the files, it's related to the number of files.

The logged error is similar to the following:

> :::no-loc text="Error: Connection disconnected with error 'Error: Server returned an error on close: Connection closed with an error.'. e.log @ blazor.server.js:1":::

When uploading files, reaching the message size limit on the first message is rare. If the limit is reached, the app can configure <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize?displayProperty=nameWithType> with a larger value.

For more information on SignalR configuration and how to set <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize>, see <xref:blazor/fundamentals/signalr#circuit-handler-options-for-blazor-server-apps>.

:::zone-end

## Additional resources

:::moniker range=">= aspnetcore-6.0"

* <xref:blazor/file-downloads>
* <xref:mvc/models/file-uploads#security-considerations>
* <xref:blazor/forms-and-input-components>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* <xref:mvc/models/file-uploads#security-considerations>
* <xref:blazor/forms-and-input-components>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

:::moniker-end
