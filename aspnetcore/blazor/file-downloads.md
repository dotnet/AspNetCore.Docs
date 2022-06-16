---
title: ASP.NET Core Blazor file downloads
author: guardrex
description: Learn how to download files using Blazor Server and Blazor WebAssembly.
monikerRange: '>= aspnetcore-6.0'
ms.author: taparik
ms.custom: mvc
ms.date: 06/17/2022
uid: blazor/file-downloads
---
# ASP.NET Core Blazor file downloads

This article explains how to download files in Blazor Server and Blazor WebAssembly apps.

Files can be downloaded from the app's own static assets or from any other location. When downloading files, Cross-Origin Resource Sharing (CORS) considerations apply. More information on CORS is in the [Cross-Origin Resource Sharing (CORS)](#cross-origin-resource-sharing-cors) section later in this article.

> [!WARNING]
> Always follow security best practices when allowing users to download files. For more information, see the [Security considerations](#security-considerations) section.

## Download from a stream

The recommended approach for downloading files less than 250 MB in size uses [JavaScript (JS) interop](xref:blazor/js-interop/index) to receive the file's name with the file's data stream to trigger the client-side download. The `downloadFileFromStream` function, which is shown in the following example, is used in a Razor component later in this article.

> [!WARNING]
> The approach in this section reads the file's content into an [`ArrayBuffer`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/ArrayBuffer). This approach loads the entire file into the client's memory, which can impair performance. For file downloads over 250 MB, we recommend following the guidance in the [Download from a URL](#download-from-a-url) section to download the file from a URL instead.

The following `downloadFileFromStream` JS function performs the following steps:

* Read the provided stream into an [`ArrayBuffer`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/ArrayBuffer).
* Create a [`Blob`](https://developer.mozilla.org/docs/Web/API/Blob) to wrap the `ArrayBuffer`.
* Create an object URL to serve as the file's download address.

The `fileName` and object `url` are passed to `triggerFileDownload`, which performs the following steps:

* Create an [`HTMLAnchorElement`](https://developer.mozilla.org/docs/Web/API/HTMLAnchorElement) (`<a>` element).
* Assign the `url` and `fileName` for the download.
* Trigger the download via `click`.
* Remove the anchor (`<a>`) element.

At this point, the file download is triggered and then the temporary object URL is revoked by calling [`revokeObjectURL`](https://developer.mozilla.org/docs/Web/API/URL/revokeObjectURL) on the URL. **This is an important step to ensure memory isn't leaked on the client.**

Inside the closing `</body>` tag of `Pages/_Layout.razor` (Blazor Server) or `wwwroot/index.html` (Blazor WebAssembly):

```html
<script>
  window.downloadFileFromStream = async (fileName, contentStreamReference) => {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    triggerFileDownload(fileName, url);
    URL.revokeObjectURL(url);
  }
</script>
```

The following example component:

* Uses native byte-streaming interop to ensure efficient transfer of the file to the client.
* Has a method named `GetFileStream` to retrieve a <xref:System.IO.Stream> for the file that's downloaded to clients. Alternative approaches include retrieving a file from storage or generating a file dynamically in C# code. For this demonstration, the app creates a 50 KB file of random data from a new byte array (`new byte[]`). The bytes are wrapped with a <xref:System.IO.MemoryStream> to serve as the example's dynamically-generated binary file.
* The `DownloadFileFromStream` method performs the following steps:
  * Retrieves the <xref:System.IO.Stream> from `GetFileStream`.
  * Specify a file name when file is saved on the user's machine. The following example names the file `quote.txt`.
  * Wraps the <xref:System.IO.Stream> in a <xref:Microsoft.JSInterop.DotNetStreamReference>, which allows streaming the file data to the client.
  * Invokes `downloadFileFromStream`, which is the JavaScript function shown earlier in this article that accepts the data on the client.

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/file-downloads/FileDownload1.razor":::

## Download from a URL

The recommended approach for downloading files less than 250 MB in size uses

The example in this section uses a dummy log file named `quote.txt`, which is placed in a folder named `files` in the app's `wwwroot` folder:

```wwwroot/files/quote.txt`:

:::code language="text" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/wwwroot/files/quote.txt":::

Inside the closing `</body>` tag of `Pages/_Layout.razor` (Blazor Server) or `wwwroot/index.html` (Blazor WebAssembly):

```html
<script>
  window.triggerFileDownload = (fileName, url) => {
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName ?? '';
    anchorElement.click();
    anchorElement.remove();
  }
</script>
```

In the following example component:

* Downloads the file from the same origin (same domain) that the app uses. If the file download is attempted from a different origin (different domain), configure Cross-Origin Resource Sharing (CORS). For more information, see the [Cross-Origin Resource Sharing (CORS)](#cross-origin-resource-sharing-cors) section later in this article.
* xxx

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/file-downloads/FileDownload2.razor":::

## Cross-Origin Resource Sharing (CORS)

Without taking further steps to enable cross-origin requests, downloading files won't pass [Cross-Origin Resource Sharing (CORS)](https://developer.mozilla.org/docs/Web/HTTP/CORS) checks made by the browser.

For more information on CORS with ASP.NET Core apps and other Microsoft products and services that host files for download, see the following resources:

* <xref:security/cors>
* [Using Azure CDN with CORS (Azure documentation)](/azure/cdn/cdn-cors)
* [Cross-Origin Resource Sharing (CORS) support for Azure Storage (REST documentation)](/rest/api/storageservices/cross-origin-resource-sharing--cors--support-for-the-azure-storage-services)
* [Core Cloud Services - Set up CORS for your website and storage assets (Learn Module)](/learn/modules/set-up-cors-website-storage/)
* [IIS CORS module Configuration Reference (IIS documentation)](/iis/extensions/cors-module/cors-module-configuration-reference)

For more information on CORS with non-ASP.NET Core apps and non-Microsoft services, consult the external framework or service CORS documentation.

## Security considerations

Use caution when providing users with the ability to download files from a server. Attackers may execute [denial of service (DOS)](/windows-hardware/drivers/ifs/denial-of-service) attacks, [API exploitation attacks](https://developer.mozilla.org/docs/Web/HTML/Element/a#security_and_privacy), or attempt to compromise networks and servers in other ways.

Security steps that reduce the likelihood of a successful attack are:

* Download files from a dedicated file download area on the server, preferably from a non-system drive. Using a dedicated location makes it easier to impose security restrictions on downloadable files. Disable execute permissions on the file download area.
* Verify that client-side checks are also performed on the server. Client-side checks are easy to circumvent.

## Additional resources

* [`<a>`: The Anchor element: Security and privacy (MDN documentation)](https://developer.mozilla.org/docs/Web/HTML/Element/a#security_and_privacy)
* <xref:blazor/file-uploads>
* <xref:mvc/models/file-uploads#security-considerations>
* <xref:blazor/forms-validation>
