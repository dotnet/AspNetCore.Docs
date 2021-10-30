---
title: ASP.NET Core Blazor file downloads
author: TanayParikh
description: Learn how to download files using Blazor.
monikerRange: '>= aspnetcore-6.0'
ms.author: taparik
ms.custom: mvc
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
ms.date: 10/29/2021
uid: blazor/file-downloads
zone_pivot_groups: blazor-hosting-models
---
# ASP.NET Core Blazor file download

::: moniker range=">= aspnetcore-6.0"

> [!WARNING]
> Always follow security best practices when allowing users to download files. For more information, see [Security Considerations](#security-considerations).

## How to Download a File Using Streaming

The following example demonstrates how to facilitate downloading a file in Blazor. Native `byte[]` streaming interop is used to ensure efficient transfer to the client.

In your `.razor` file, add the following `@using` and `@inject` statements:

```razor
@using System.IO
@inject IJSRuntime JS
```

Then we can add a button to trigger the file download:

```razor
<button class="btn btn-primary" @onclick="DownloadFileFromStream">Download File From Stream</button>
```

Now we write a function (`GetFileStream`) that retrieves a <xref:System.IO.Stream> to the file that will be downloaded by the client. Note, you may choose to retrieve a file from storage or dynamically generate a file. For this demo, we create a 50 kB `byte[]`, and wrap it with a `MemoryStream`, to serve as a sample dynamically generated binary file to be downloaded by the user.

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

Finally, we can examine the `DownloadFileFromStream` which is executed when the `button` we added above is pressed. Here, we first retrieve the <xref:System.IO.Stream> from `GetFileStream`, and specify a file name (`log.bin`) to be used when the file is saved on the user's machine. Then, we wrap the <xref:System.IO.Stream> in a <xref:Microsoft.JSInterop.DotNetStreamReference> which will allow streaming the file data to the client. Finally, we invoke `downloadFileFromStream`, which is a JavaScript function which will accept the data on the client. 

```razor
@code {
    private async Task DownloadFileFromStream()
    {
        // Start off by fetching the Stream for the file we want to let the user download
        var fileStream = GetFileStream();

        // Then specify the file name for the download. Note this may be overridden by the user.
        var fileName = "log.bin";

        // Proceed to create a `DotNetStreamReference` that wraps the file stream
        using var streamRef = new DotNetStreamReference(stream: fileStream);

        // Provide the file name and stream to the client for download
        await JS.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
    }
}
```

Next, we examine the JavaScript `downloadFileFromStream` which will accept the file name and data stream, and trigger the client side download. For `downloadFileFromStream`, we first read the provided stream into an [`ArrayBuffer`](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/ArrayBuffer). We then create a [`Blob`](https://developer.mozilla.org/en-US/docs/Web/API/Blob) to wrap the `ArrayBuffer`. Finally, we create an object URL which will serve as the address for the file to be downloaded.

The `fileName` and object `url` are passed to `triggerFileDownload` which creates a [`HTMLAnchorElement`](https://developer.mozilla.org/en-US/docs/Web/API/HTMLAnchorElement) (`<a>` element), assigns the `url` and `fileName` to be used for the download, and triggers the download via `click`. Finally, this anchor element is removed.

At this point the file download has been triggered, and it should be safe to revoke the temporary object URL we created. This is an important step to ensure memory isn't leaked on the client.


```js
async function downloadFileFromStream(fileName, contentStreamReference) {
    // Create a `Blob` by reading the stream as an `ArrayBuffer`
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer]);

    // Create a temporary object URL to download the file from
    const url = URL.createObjectURL(blob);

    triggerFileDownload(fileName, url);

    // Free the temporary object URL to ensure memory isn't leaked
    URL.revokeObjectURL(url);
}

function triggerFileDownload(fileName, url) {
    // Create a temporary `a` HTML element to trigger the download
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

::: zone pivot="webassembly"

In Blazor WebAssembly, file data is streamed directly from .NET code into the browser.

::: zone-end

::: zone pivot="server"

In Blazor Server, file data is streamed over the SignalR connection from .NET code into the browser.

::: zone-end


## Security considerations

Use caution when providing users with the ability to download files from a server. Attackers may execute [denial of service](/windows-hardware/drivers/ifs/denial-of-service) attacks or attempt to compromise networks and servers in other ways.

Security steps that reduce the likelihood of a successful attack are:

* Download files from a dedicated file download area on the system, preferably to a non-system drive. Use of a dedicated location makes it easier to impose security measures on downloadable files. Disable execute permissions on the file download location.&dagger;
* Verify that client-side checks are also performed on the server. Client-side checks are easy to circumvent.&dagger;

## Additional resources

* <xref:blazor/file-uploads>
* <xref:mvc/models/file-uploads#security-considerations>
* <xref:blazor/forms-validation>

::: moniker-end
