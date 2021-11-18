---
title: ASP.NET Core Blazor file downloads
author: TanayParikh
description: Learn how to download files using Blazor.
monikerRange: '>= aspnetcore-6.0'
ms.author: taparik
ms.custom: mvc
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
ms.date: 11/09/2021
uid: blazor/file-downloads
---
# ASP.NET Core Blazor file downloads

> [!WARNING]
> Always follow security best practices when allowing users to download files. For more information, see the [Security considerations](#security-considerations) section.

The following example demonstrates how to download a file. Native `byte[]` streaming interop is used to ensure efficient transfer to the client.

In a Razor component (`.razor`), add [`@using`](xref:mvc/views/razor#using) and [`@inject`](xref:mvc/views/razor#inject) directives for the following:

* <xref:System.IO?displayProperty=fullName>
* <xref:Microsoft.JSInterop.IJSRuntime?displayProperty=fullName>

```razor
@using System.IO
@inject IJSRuntime JS
```

Add a button to trigger the file download:

```razor
<button @onclick="DownloadFileFromStream">
    Download File From Stream
</button>
```

Create a method that retrieves a <xref:System.IO.Stream> for the file that's downloaded to clients (`GetFileStream` in the following example). You may choose to retrieve a file from storage or dynamically generate a file.

For this demonstration, the app creates a 50 KB file of random data from a new byte array (`new byte[]`). The bytes are wrapped with a <xref:System.IO.MemoryStream> to serve as the example's dynamically-generated binary file:

```razor
@code {
    private Stream GetFileStream()
    {
        var randomBinaryData = new byte[50 * 1024];
        var fileStream = new MemoryStream(randomBinaryData);

        return fileStream;
    }
}
```

The following `DownloadFileFromStream` method performs the following steps:

* Retrieves the <xref:System.IO.Stream> from `GetFileStream`.
* Specify a file name when file is saved on the user's machine. The following example names the file `log.bin`.
* Wraps the <xref:System.IO.Stream> in a <xref:Microsoft.JSInterop.DotNetStreamReference>, which allows streaming the file data to the client.
* Invokes `downloadFileFromStream`, which is a JavaScript function that accepts the data on the client. The `downloadFileFromStream` function is shown later in this article.

```razor
@code {
    private async Task DownloadFileFromStream()
    {
        var fileStream = GetFileStream();
        var fileName = "log.bin";

        using var streamRef = new DotNetStreamReference(stream: fileStream);

        await JS.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
    }
}
```

The JavaScript `downloadFileFromStream` function accepts the file name and data stream and triggers the client-side download. The function performs the following steps:

* Read the provided stream into an [`ArrayBuffer`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/ArrayBuffer).
* Create a [`Blob`](https://developer.mozilla.org/docs/Web/API/Blob) to wrap the `ArrayBuffer`.
* Create an object URL to serve as the address for the file to be downloaded.

The `fileName` and object `url` are passed to `triggerFileDownload`, which performs the following steps:

* Create an [`HTMLAnchorElement`](https://developer.mozilla.org/docs/Web/API/HTMLAnchorElement) (`<a>` element).
* Assign the `url` and `fileName` for the download.
* Trigger the download via `click`.
* Remove the anchor (`<a>`) element.

At this point, the file download is triggered. It should be safe to revoke the temporary object URL by calling [`revokeObjectURL`](https://developer.mozilla.org/docs/Web/API/URL/revokeObjectURL) on the URL. **This is an important step to ensure memory isn't leaked on the client.**


```javascript
async function downloadFileFromStream(fileName, contentStreamReference) {
  const arrayBuffer = await contentStreamReference.arrayBuffer();
  const blob = new Blob([arrayBuffer]);

  const url = URL.createObjectURL(blob);

  triggerFileDownload(fileName, url);

  URL.revokeObjectURL(url);
}

function triggerFileDownload(fileName, url) {
  const anchorElement = document.createElement('a');
  anchorElement.href = url;

  if (fileName) {
    anchorElement.download = fileName;
  }

  anchorElement.click();
  anchorElement.remove();
}
```

## File streams

In Blazor WebAssembly apps, file data is streamed directly from .NET code into the browser. In Blazor Server apps, file data is streamed over the SignalR connection from .NET code into the browser.

## Security considerations

Use caution when providing users with the ability to download files from a server. Attackers may execute [denial of service (DOS)](/windows-hardware/drivers/ifs/denial-of-service) attacks or attempt to compromise networks and servers in other ways.

Security steps that reduce the likelihood of a successful attack are:

* Download files from a dedicated file download area on the server, preferably from a non-system drive. Using a dedicated location makes it easier to impose security restrictions on downloadable files. Disable execute permissions on the file download area.
* Verify that client-side checks are also performed on the server. Client-side checks are easy to circumvent.

## Additional resources

* <xref:blazor/file-uploads>
* <xref:mvc/models/file-uploads#security-considerations>
* <xref:blazor/forms-validation>
