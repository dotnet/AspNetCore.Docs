---
title: Display images and documents in ASP.NET Core Blazor
author: guardrex
description: Learn how to display images and documents in ASP.NET Core Blazor apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 08/13/2024
uid: blazor/images-and-documents
---
# Display images and documents in ASP.NET Core Blazor

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes approaches for displaying images and documents in Blazor apps.

The examples in this article are available for inspection and use in the [Blazor sample apps](xref:blazor/fundamentals/index#sample-apps):

[`dotnet/blazor-samples` GitHub repository](https://github.com/dotnet/blazor-samples): Navigate to the app named `BlazorSample_BlazorWebApp` (8.0 or later), `BlazorSample_Server` (7.0 or earlier), or `BlazorSample_WebAssembly`.

## Dynamically set an image source

The following example demonstrates how to dynamically set an image's source with a C# field.

The example in this section uses three image files, named `image1.png`, `image2.png`, and `image3.png`. The images are placed in a folder named `images` in the app's web root (`wwwroot`). The use of the `images` folder is only for demonstration purposes. You can organize static assets in any folder layout that you prefer, including serving assets directly from the `wwwroot` folder.

In the following `ShowImage1` component:

* The image's source (`src`) is dynamically set to the value of `imageSource` in C#.
* The `ShowImage` method updates the `imageSource` field based on an image `id` argument passed to the method.
* Rendered buttons call the `ShowImage` method with an image argument for each of the three available images in the `images` folder. The file name is composed using the argument passed to the method and matches one of the three images in the `images` folder.

`ShowImage1.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/ShowImage1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/images/ShowImage1.razor":::

:::moniker-end

:::moniker range="< aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/images/ShowImage1.razor":::

:::moniker-end

The preceding example uses a C# field to hold the image's source data, but you can also use a C# property to hold the data.

> [!NOTE]
> Avoid using a loop variable directly in a lambda expression, such as `i` in the preceding `for` loop example. Otherwise, the same variable is used by all lambda expressions, which results in use of the same value in all lambdas. Capture the variable's value in a local variable. In the preceding example:
>
> * The loop variable `i` is assigned to `imageId`.
> * `imageId` is used in the lambda expression.
>
> Alternatively, use a `foreach` loop with <xref:System.Linq.Enumerable.Range%2A?displayProperty=nameWithType>, which doesn't suffer from the preceding problem:
>
> ```razor
> @foreach (var imageId in Enumerable.Range(1,3))
> {
>     <button @onclick="() => ShowImage(imageId)">
>         Image @imageId
>     </button>
> }
> ```
>
> For more information, see <xref:blazor/components/event-handling#lambda-expressions>.

## Stream image or document data

An image or other document type, such as a PDF, can be directly transmitted to the client using Blazor's streaming interop features instead of hosting the file at a public URL.

The example in this section streams source data using [JavaScript (JS) interop](xref:blazor/js-interop/index). The following `setSource` JS function:

* Can be used to stream content for the following elements: `<body>`, `<embed>`, `<iframe>`, `<img>`, `<link>`, `<object>`, `<script>`, `<style>`, and `<track>`.
* Accepts an element `id` to display the file's contents, a data stream for the document, the content type, and a title for the display element.

The function:

* Reads the provided stream into an [`ArrayBuffer`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/ArrayBuffer).
* Creates a [`Blob`](https://developer.mozilla.org/docs/Web/API/Blob) to wrap the `ArrayBuffer`, setting the blob's content type.
* Creates an object URL to serve as the address for the document to be shown.
* Set's the element's title (`title`) from the `title` parameter and sets the element's source (`src`) from the created object URL.
* To prevent memory leaks, the function calls [`revokeObjectURL`](https://developer.mozilla.org/docs/Web/API/URL/revokeObjectURL) to dispose of the object URL after the element loads the resource ([`load` event](https://developer.mozilla.org/docs/Web/API/HTMLElement/load_event)).

```html
<script>
  window.setSource = async (elementId, stream, contentType, title) => {
    const arrayBuffer = await stream.arrayBuffer();
    let blobOptions = {};
    if (contentType) {
      blobOptions['type'] = contentType;
    }
    const blob = new Blob([arrayBuffer], blobOptions);
    const url = URL.createObjectURL(blob);
    const element = document.getElementById(elementId);
    element.title = title;
    element.onload = () => {
      URL.revokeObjectURL(url);
    }
    element.src = url;
  }
</script>
```

> [!NOTE]
> For general guidance on JS location and our recommendations for production apps, see <xref:blazor/js-interop/javascript-location>.

The following `ShowImage2` component:

* Injects services for an <xref:System.Net.Http.HttpClient?displayProperty=fullName> and <xref:Microsoft.JSInterop.IJSRuntime?displayProperty=fullName>.
* Includes an `<img>` tag to display an image.
* Has a `GetImageStreamAsync` C# method to retrieve a <xref:System.IO.Stream> for an image. A production app may dynamically generate an image based on the specific user or retrieve an image from storage. The following example retrieves the .NET avatar for the `dotnet` GitHub repository.
* Has a `SetImageAsync` method that's triggered on the button's selection by the user. `SetImageAsync` performs the following steps:
  * Retrieves the <xref:System.IO.Stream> from `GetImageStreamAsync`.
  * Wraps the <xref:System.IO.Stream> in a <xref:Microsoft.JSInterop.DotNetStreamReference>, which allows streaming the image data to the client.
  * Invokes the `setSource` JavaScript function, which accepts the data on the client.

> [!NOTE]
> Server-side apps use a dedicated <xref:System.Net.Http.HttpClient> service to make requests, so no action is required by the developer of a server-side Blazor app to register an <xref:System.Net.Http.HttpClient> service. Client-side apps have a default <xref:System.Net.Http.HttpClient> service registration when the app is created from a Blazor project template. If an <xref:System.Net.Http.HttpClient> service registration isn't present in the `Program` file of a client-side app, provide one by adding `builder.Services.AddHttpClient();`. For more information, see <xref:fundamentals/http-requests>.

`ShowImage2.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/ShowImage2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/images/ShowImage2.razor":::

:::moniker-end

:::moniker range="< aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/images/ShowImage2.razor":::

:::moniker-end

The following `ShowFile` component loads either a text file (`files/quote.txt`) or a PDF file (`files/quote.pdf`) into an [`<iframe>` element (MDN documentation)](https://developer.mozilla.org/docs/Web/HTML/Element/iframe).

> [!CAUTION]
> Use of the `<iframe>` element in the following example is safe and doesn't require [sandboxing](https://developer.mozilla.org/docs/Web/HTML/Element/iframe#sandbox) because content is loaded from the app, a trusted source.
>
> When loading content from an untrusted source or user input, an improperly implemented `<iframe>` element risks creating security vulnerabilities.

`ShowFile.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/ShowFile.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/images/ShowFile.razor":::

:::moniker-end

:::moniker range="< aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/images/ShowFile.razor":::

:::moniker-end

## Additional resources

* <xref:blazor/file-uploads>
* [File uploads: Upload image preview](xref:blazor/file-uploads#upload-image-preview)
* <xref:blazor/file-downloads>
* <xref:blazor/js-interop/call-dotnet-from-javascript#stream-from-javascript-to-net>
* <xref:blazor/js-interop/call-javascript-from-dotnet#stream-from-net-to-javascript>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps))
