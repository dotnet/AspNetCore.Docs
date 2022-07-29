---
title: ASP.NET Core Blazor file downloads
author: guardrex
description: Learn how to download files using Blazor Server and Blazor WebAssembly.
monikerRange: '>= aspnetcore-6.0'
ms.author: taparik
ms.custom: mvc
ms.date: 06/20/2022
uid: blazor/file-downloads
---
# ASP.NET Core Blazor file downloads

This article explains how to download files in Blazor Server and Blazor WebAssembly apps.

:::moniker range="< aspnetcore-7.0"

Files can be downloaded from the app's own static assets or from any other location. When downloading files from a different origin than the app, Cross-Origin Resource Sharing (CORS) considerations apply. For more information, see the [Cross-Origin Resource Sharing (CORS)](#cross-origin-resource-sharing-cors) section.

## Security considerations

Use caution when providing users with the ability to download files from a server. Attackers may execute [denial of service (DOS)](/windows-hardware/drivers/ifs/denial-of-service) attacks, [API exploitation attacks](https://developer.mozilla.org/docs/Web/HTML/Element/a#security_and_privacy), or attempt to compromise networks and servers in other ways.

Security steps that reduce the likelihood of a successful attack are:

* Download files from a dedicated file download area on the server, preferably from a non-system drive. Using a dedicated location makes it easier to impose security restrictions on downloadable files. Disable execute permissions on the file download area.
* Client-side security checks are easy to circumvent by malicious users. Always perform client-side security checks on the server, too.
* Don't receive files from users or other untrusted sources and then make the files available for immediate download without performing security checks on the files. For more information, see <xref:mvc/models/file-uploads#security-considerations>.

## Download from a stream

*This section applies to files that are typically up to 250 MB in size.*

The recommended approach for downloading relatively small files (\< 250 MB) is to stream file content to a raw binary data buffer on the client with [JavaScript (JS) interop](xref:blazor/js-interop/index).

> [!WARNING]
> The approach in this section reads the file's content into a [JS `ArrayBuffer`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/ArrayBuffer). This approach loads the entire file into the client's memory, which can impair performance. To download relatively large files (\>= 250 MB), we recommend following the guidance in the [Download from a URL](#download-from-a-url) section.

The following `downloadFileFromStream` JS function performs the following steps:

* Read the provided stream into an [`ArrayBuffer`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/ArrayBuffer).
* Create a [`Blob`](https://developer.mozilla.org/docs/Web/API/Blob) to wrap the `ArrayBuffer`.
* Create an object URL to serve as the file's download address.
* Create an [`HTMLAnchorElement`](https://developer.mozilla.org/docs/Web/API/HTMLAnchorElement) (`<a>` element).
* Assign the file's name (`fileName`) and URL (`url`) for the download.
* Trigger the download by firing a [`click` event](https://developer.mozilla.org/docs/Web/API/HTMLElement/click) on the anchor element.
* Remove the anchor element.
* Revoke the object URL (`url`) by calling [`URL.revokeObjectURL`](https://developer.mozilla.org/docs/Web/API/URL/revokeObjectURL). **This is an important step to ensure memory isn't leaked on the client.**

```html
<script>
  window.downloadFileFromStream = async (fileName, contentStreamReference) => {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName ?? '';
    anchorElement.click();
    anchorElement.remove();
    URL.revokeObjectURL(url);
  }
</script>
```

[!INCLUDE[](~/blazor/includes/js-location.md)]

The following example component:

* Uses native byte-streaming interop to ensure efficient transfer of the file to the client.
* Has a method named `GetFileStream` to retrieve a <xref:System.IO.Stream> for the file that's downloaded to clients. Alternative approaches include retrieving a file from storage or generating a file dynamically in C# code. For this demonstration, the app creates a 50 KB file of random data from a new byte array (`new byte[]`). The bytes are wrapped with a <xref:System.IO.MemoryStream> to serve as the example's dynamically-generated binary file.
* The `DownloadFileFromStream` method performs the following steps:
  * Retrieve the <xref:System.IO.Stream> from `GetFileStream`.
  * Specify a file name when file is saved on the user's machine. The following example names the file `quote.txt`.
  * Wrap the <xref:System.IO.Stream> in a <xref:Microsoft.JSInterop.DotNetStreamReference>, which allows streaming the file data to the client.
  * Invoke the `downloadFileFromStream` JS function to accept the data on the client.

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/file-downloads/FileDownload1.razor":::

For a component in a Blazor Server app that must return a <xref:System.IO.Stream> for a physical file, the component can call <xref:System.IO.File.OpenRead%2A?displayProperty=nameWithType>, as the following example demonstrates:

```csharp
private Stream GetFileStream()
{
    return File.OpenRead(@"{PATH}");
}
```

In the preceding example, the `{PATH}` placeholder is the path to the file. The `@` prefix indicates that the string is a [*verbatim string literal*](/dotnet/csharp/programming-guide/strings/#verbatim-string-literals), which permits the use of backslashes (`\`) in a Windows OS path and embedded double-quotes (`""`) for a single quote in the path. Alternatively, avoid the string literal (`@`) and use either of the following approaches:

* Use escaped backslashes (`\\`) and quotes (`\"`).
* Use forward slashes (`/`) in the path, which are supported across platforms in ASP.NET Core apps, and escaped quotes (`\"`).

## Download from a URL

*This section applies to files that are relatively large, typically 250 MB or larger.*

The example in this section uses a download file named `quote.txt`, which is placed in a folder named `files` in the app's web root (`wwwroot` folder). The use of the `files` folder is only for demonstration purposes. You can organize downloadable files in any folder layout within the web root (`wwwroot` folder) that you prefer, including serving the files directly from the `wwwroot` folder.

`wwwroot/files/quote.txt`:

:::code language="text" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/wwwroot/files/quote.txt":::

The following `triggerFileDownload` JS function performs the following steps:

* Create an [`HTMLAnchorElement`](https://developer.mozilla.org/docs/Web/API/HTMLAnchorElement) (`<a>` element).
* Assign the file's name (`fileName`) and URL (`url`) for the download.
* Trigger the download by firing a [`click` event](https://developer.mozilla.org/docs/Web/API/HTMLElement/click) on the anchor element.
* Remove the anchor element.

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

[!INCLUDE[](~/blazor/includes/js-location.md)]

The following example component downloads the file from the same origin that the app uses. If the file download is attempted from a different origin, configure Cross-Origin Resource Sharing (CORS). For more information, see the [Cross-Origin Resource Sharing (CORS)](#cross-origin-resource-sharing-cors) section.

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/file-downloads/FileDownload2.razor":::

## Cross-Origin Resource Sharing (CORS)

Without taking further steps to enable [Cross-Origin Resource Sharing (CORS)](https://developer.mozilla.org/docs/Web/HTTP/CORS) for files that don't have the same origin as the app, downloading files won't pass CORS checks made by the browser.

For more information on CORS with ASP.NET Core apps and other Microsoft products and services that host files for download, see the following resources:

* <xref:security/cors>
* [Using Azure CDN with CORS (Azure documentation)](/azure/cdn/cdn-cors)
* [Cross-Origin Resource Sharing (CORS) support for Azure Storage (REST documentation)](/rest/api/storageservices/cross-origin-resource-sharing--cors--support-for-the-azure-storage-services)
* [Core Cloud Services - Set up CORS for your website and storage assets (Learn Module)](/learn/modules/set-up-cors-website-storage/)
* [IIS CORS module Configuration Reference (IIS documentation)](/iis/extensions/cors-module/cors-module-configuration-reference)

## Additional resources

* <xref:blazor/js-interop/index>
* [`<a>`: The Anchor element: Security and privacy (MDN documentation)](https://developer.mozilla.org/docs/Web/HTML/Element/a#security_and_privacy)
* <xref:blazor/file-uploads>
* <xref:blazor/forms-validation>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

Files can be downloaded from the app's own static assets or from any other location. When downloading files from a different origin than the app, Cross-Origin Resource Sharing (CORS) considerations apply. For more information, see the [Cross-Origin Resource Sharing (CORS)](#cross-origin-resource-sharing-cors) section.

## Security considerations

Use caution when providing users with the ability to download files from a server. Attackers may execute [denial of service (DOS)](/windows-hardware/drivers/ifs/denial-of-service) attacks, [API exploitation attacks](https://developer.mozilla.org/docs/Web/HTML/Element/a#security_and_privacy), or attempt to compromise networks and servers in other ways.

Security steps that reduce the likelihood of a successful attack are:

* Download files from a dedicated file download area on the server, preferably from a non-system drive. Using a dedicated location makes it easier to impose security restrictions on downloadable files. Disable execute permissions on the file download area.
* Client-side security checks are easy to circumvent by malicious users. Always perform client-side security checks on the server, too.
* Don't receive files from users or other untrusted sources and then make the files available for immediate download without performing security checks on the files. For more information, see <xref:mvc/models/file-uploads#security-considerations>.

## Download from a stream

*This section applies to files that are typically up to 250 MB in size.*

The recommended approach for downloading relatively small files (\< 250 MB) is to stream file content to a raw binary data buffer on the client with [JavaScript (JS) interop](xref:blazor/js-interop/index).

> [!WARNING]
> The approach in this section reads the file's content into a [JS `ArrayBuffer`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/ArrayBuffer). This approach loads the entire file into the client's memory, which can impair performance. To download relatively large files (\>= 250 MB), we recommend following the guidance in the [Download from a URL](#download-from-a-url) section.

The following `downloadFileFromStream` JS function performs the following steps:

* Read the provided stream into an [`ArrayBuffer`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/ArrayBuffer).
* Create a [`Blob`](https://developer.mozilla.org/docs/Web/API/Blob) to wrap the `ArrayBuffer`.
* Create an object URL to serve as the file's download address.
* Create an [`HTMLAnchorElement`](https://developer.mozilla.org/docs/Web/API/HTMLAnchorElement) (`<a>` element).
* Assign the file's name (`fileName`) and URL (`url`) for the download.
* Trigger the download by firing a [`click` event](https://developer.mozilla.org/docs/Web/API/HTMLElement/click) on the anchor element.
* Remove the anchor element.
* Revoke the object URL (`url`) by calling [`URL.revokeObjectURL`](https://developer.mozilla.org/docs/Web/API/URL/revokeObjectURL). **This is an important step to ensure memory isn't leaked on the client.**

```html
<script>
  window.downloadFileFromStream = async (fileName, contentStreamReference) => {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName ?? '';
    anchorElement.click();
    anchorElement.remove();
    URL.revokeObjectURL(url);
  }
</script>
```

[!INCLUDE[](~/blazor/includes/js-location.md)]

The following example component:

* Uses native byte-streaming interop to ensure efficient transfer of the file to the client.
* Has a method named `GetFileStream` to retrieve a <xref:System.IO.Stream> for the file that's downloaded to clients. Alternative approaches include retrieving a file from storage or generating a file dynamically in C# code. For this demonstration, the app creates a 50 KB file of random data from a new byte array (`new byte[]`). The bytes are wrapped with a <xref:System.IO.MemoryStream> to serve as the example's dynamically-generated binary file.
* The `DownloadFileFromStream` method performs the following steps:
  * Retrieve the <xref:System.IO.Stream> from `GetFileStream`.
  * Specify a file name when file is saved on the user's machine. The following example names the file `quote.txt`.
  * Wrap the <xref:System.IO.Stream> in a <xref:Microsoft.JSInterop.DotNetStreamReference>, which allows streaming the file data to the client.
  * Invoke the `downloadFileFromStream` JS function to accept the data on the client.

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/file-downloads/FileDownload1.razor":::

For a component in a Blazor Server app that must return a <xref:System.IO.Stream> for a physical file, the component can call <xref:System.IO.File.OpenRead%2A?displayProperty=nameWithType>, as the following example demonstrates:

```csharp
private Stream GetFileStream()
{
    return File.OpenRead(@"{PATH}");
}
```

In the preceding example, the `{PATH}` placeholder is the path to the file. The `@` prefix indicates that the string is a [*verbatim string literal*](/dotnet/csharp/programming-guide/strings/#verbatim-string-literals), which permits the use of backslashes (`\`) in a Windows OS path and embedded double-quotes (`""`) for a single quote in the path. Alternatively, avoid the string literal (`@`) and use either of the following approaches:

* Use escaped backslashes (`\\`) and quotes (`\"`).
* Use forward slashes (`/`) in the path, which are supported across platforms in ASP.NET Core apps, and escaped quotes (`\"`).

## Download from a URL

*This section applies to files that are relatively large, typically 250 MB or larger.*

The example in this section uses a download file named `quote.txt`, which is placed in a folder named `files` in the app's web root (`wwwroot` folder). The use of the `files` folder is only for demonstration purposes. You can organize downloadable files in any folder layout within the web root (`wwwroot` folder) that you prefer, including serving the files directly from the `wwwroot` folder.

`wwwroot/files/quote.txt`:

:::code language="text" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/wwwroot/files/quote.txt":::

The following `triggerFileDownload` JS function performs the following steps:

* Create an [`HTMLAnchorElement`](https://developer.mozilla.org/docs/Web/API/HTMLAnchorElement) (`<a>` element).
* Assign the file's name (`fileName`) and URL (`url`) for the download.
* Trigger the download by firing a [`click` event](https://developer.mozilla.org/docs/Web/API/HTMLElement/click) on the anchor element.
* Remove the anchor element.

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

[!INCLUDE[](~/blazor/includes/js-location.md)]

The following example component downloads the file from the same origin that the app uses. If the file download is attempted from a different origin, configure Cross-Origin Resource Sharing (CORS). For more information, see the [Cross-Origin Resource Sharing (CORS)](#cross-origin-resource-sharing-cors) section.

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/file-downloads/FileDownload2.razor":::

## Cross-Origin Resource Sharing (CORS)

Without taking further steps to enable [Cross-Origin Resource Sharing (CORS)](https://developer.mozilla.org/docs/Web/HTTP/CORS) for files that don't have the same origin as the app, downloading files won't pass CORS checks made by the browser.

For more information on CORS with ASP.NET Core apps and other Microsoft products and services that host files for download, see the following resources:

* <xref:security/cors>
* [Using Azure CDN with CORS (Azure documentation)](/azure/cdn/cdn-cors)
* [Cross-Origin Resource Sharing (CORS) support for Azure Storage (REST documentation)](/rest/api/storageservices/cross-origin-resource-sharing--cors--support-for-the-azure-storage-services)
* [Core Cloud Services - Set up CORS for your website and storage assets (Learn Module)](/learn/modules/set-up-cors-website-storage/)
* [IIS CORS module Configuration Reference (IIS documentation)](/iis/extensions/cors-module/cors-module-configuration-reference)

## Additional resources

* <xref:blazor/js-interop/index>
* [`<a>`: The Anchor element: Security and privacy (MDN documentation)](https://developer.mozilla.org/docs/Web/HTML/Element/a#security_and_privacy)
* <xref:blazor/file-uploads>
* <xref:blazor/forms-validation>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)


:::moniker-end
