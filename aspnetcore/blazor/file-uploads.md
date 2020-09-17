---
title: ASP.NET Core Blazor file uploads
author: guardrex
description: Learn how to upload files in Blazor with the InputFile component.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 09/17/2020
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/file-uploads
---
# ASP.NET Core Blazor file uploads

By [Daniel Roth](https://github.com/danroth27)

Use the `InputFile` component to read browser file data into .NET code, including for file uploads. The `InputFile` component renders as an HTML input of type `file`.

By default, the user selects single files. Add the `multiple` attribute to permit the user to upload multiple files at once. When one or more files is selected by the user, the `InputFile` component fires an `OnChange` event and passes in an `InputFileChangeEventArgs` that provides access to the selected file list and details about each file.

A component that receives an image file can call the `RequestImageFileAsync` convenience method on the file to resize the image data within the browser's JavaScript runtime before the image is streamed into the app.

The following example demonstrates multiple image file upload in a component:

```razor
<h3>Upload PNG images</h3>

<p>
    <InputFile OnChange="@OnInputFileChange" multiple />
</p>

@if (imageDataUrls.Count > 0)
{
    <h3>Images</h3>

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
        var imageFiles = e.GetMultipleFiles();
        var format = "image/png";

        foreach (var imageFile in imageFiles)
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

To read data from a user-selected file, call `OpenReadStream` on the file and read from the returned stream. In a Blazor WebAssembly app, the data is streamed directly into the .NET code within the browser. In a Blazor Server app, the file data is streamed into .NET code on the server as the file is read from the stream. 
