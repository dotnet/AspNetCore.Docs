---
title: ASP.NET Core Blazor file uploads
author: guardrex
description: Learn how to upload files in Blazor with the InputFile component.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
ms.date: 10/27/2020
uid: blazor/file-uploads
---
# ASP.NET Core Blazor file uploads

By [Daniel Roth](https://github.com/danroth27) and [Pranav Krishnamoorthy](https://github.com/pranavkm)

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/blazor/file-uploads/samples/) ([how to download](xref:index#how-to-download-a-sample))

Use the `InputFile` component to read browser file data into .NET code, including for file uploads.

> [!WARNING]
> Always follow file upload security best practices. For more information, see <xref:mvc/models/file-uploads#security-considerations>.

## `InputFile` component

The `InputFile` component renders as an HTML input of type `file`.

By default, the user selects single files. Add the `multiple` attribute to permit the user to upload multiple files at once. When one or more files is selected by the user, the `InputFile` component fires an `OnChange` event and passes in an `InputFileChangeEventArgs` that provides access to the selected file list and details about each file.

To read data from a user-selected file:

* Call `Microsoft.AspNetCore.Components.Forms.IBrowserFile.OpenReadStream` on the file and read from the returned stream. For more information, see the [File streams](#file-streams) section.
* The <xref:System.IO.Stream> returned by `OpenReadStream` enforces a maximum size in bytes of the `Stream` being read. By default, only files smaller than 524,288 KB (512 KB) in size are allowed to be read before any further reads would result in an exception. This limit is present to prevent developers from accidentally reading large files in to memory. The `maxAllowedSize` parameter on `Microsoft.AspNetCore.Components.Forms.IBrowserFile.OpenReadStream` can be used to specify a larger size if required.
* Avoid reading the incoming file stream directly into memory. For example, don't copy file bytes into a <xref:System.IO.MemoryStream> or read as a byte array. These approaches can result in performance and security problems, especially in Blazor Server. Instead, consider copying file bytes to an external store, such as a a blob or a file on disk.

A component that receives an image file can call the `RequestImageFileAsync` convenience method on the file to resize the image data within the browser's JavaScript runtime before the image is streamed into the app.

The following example demonstrates multiple image file upload in a component. `InputFileChangeEventArgs.GetMultipleFiles` allows reading multiple files. Specify the maximum number of files you expect to read to prevent a malicious user from uploading a larger number of files than the app expects. `InputFileChangeEventArgs.File` allows reading the first and only file if the file upload does not support multiple files.

```razor
<h3>Upload PNG images</h3>

<p>
    <InputFile OnChange="@OnInputFileChange" multiple />
</p>

@if (imageDataUrls.Count > 0)
{
    <h4>Images</h4>

    <div class="card" style="width:30rem;">
        <div class="card-body">
            @foreach (var imageDataUrl in imageDataUrls)
            {
                <img class="rounded m-1" src="@imageDataUrl" />
            }
        </div>
    </div>
}

@code {
    IList<string> imageDataUrls = new List<string>();

    private async Task OnInputFileChange(InputFileChangeEventArgs e)
    {
        var maxAllowedFiles = 3;
        var format = "image/png";

        foreach (var imageFile in e.GetMultipleFiles(maxAllowedFiles))
        {
            var resizedImageFile = await imageFile.RequestImageFileAsync(format, 
                100, 100);
            var buffer = new byte[resizedImageFile.Size];
            await resizedImageFile.OpenReadStream().ReadAsync(buffer);
            var imageDataUrl = 
                $"data:{format};base64,{Convert.ToBase64String(buffer)}";
            imageDataUrls.Add(imageDataUrl);
        }
    }
}
```

`IBrowserFile` returns metadata [exposed by the browser](https://developer.mozilla.org/docs/Web/API/File#Instance_properties) as properties. This metadata can be useful to preliminary validation. For example, see the [`FileUpload.razor` and `FilePreview.razor` sample components](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/blazor/file-uploads/samples/).

## File streams

In a Blazor WebAssembly app, the data is streamed directly into the .NET code within the browser.

In a Blazor Server app, the file data is streamed over the SignalR connection into .NET code on the server as the file is read from the stream. [`Forms.RemoteBrowserFileStreamOptions`](https://github.com/dotnet/aspnetcore/blob/master/src/Components/Web/src/Forms/InputFile/RemoteBrowserFileStreamOptions.cs) allows configuring file upload characteristics for Blazor Server.

## Additional resources

* <xref:mvc/models/file-uploads#security-considerations>
* <xref:blazor/forms-validation>
