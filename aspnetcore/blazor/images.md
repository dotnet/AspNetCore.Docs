---
title: Work with images in ASP.NET Core Blazor
author: guardrex
description: Learn how to work with images in ASP.NET Core Blazor apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: taparik
ms.custom: mvc
ms.date: 07/15/2022
uid: blazor/images
---
# Work with images in ASP.NET Core Blazor

This article describes common scenarios for working with images in Blazor apps. 

:::moniker range="< aspnetcore-7.0"

## Dynamically set an image source

The following example demonstrates how to dynamically set an image's source with a C# field.

For the example in this section:

* Obtain three images from any source or right-click each of the following images to save them locally. Name the images `image1.png`, `image2.png`, and `image3.png`.

  ![Computer icon](~/blazor/images/_static/image1.png) &nbsp;&nbsp; ![Smiley icon](~/blazor/images/_static/image2.png) &nbsp;&nbsp; ![Earth icon](~/blazor/images/_static/image3.png)

* Place the images in a new folder named `images` in the app's web root (`wwwroot`). The use of the `images` folder is only for demonstration purposes. You can organize images in any folder layout that you prefer, including serving the images directly from the `wwwroot` folder.

In the following `ShowImage1` component:

* The image's source (`src`) is dynamically set to the value of `imageSource` in C#.
* The `ShowImage` method updates the `imageSource` field based on an image `id` argument passed to the method.
* Rendered buttons call the `ShowImage` method with an image argument for each of the three available images in the `images` folder. The file name is composed using the argument passed to the method and matches one of the three images in the `images` folder.

`Pages/ShowImage1.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/images/ShowImage1.razor":::

The preceding example uses a C# field to hold the image's source data, but you can also use a C# property to hold the data.

> [!NOTE]
> Do **not** use a loop variable directly in a lambda expression, such as `i` in the preceding `for` loop example. Otherwise, the same variable is used by all lambda expressions, which results in use of the same value in all lambdas. Always capture the variable's value in a local variable and then use the local variable. In the preceding example:
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

## Stream image data

An image can be directly sent to the client using Blazor's streaming interop features instead of hosting the image at a public URL.

The example in this section streams image source data using [JavaScript (JS) interop](xref:blazor/js-interop/index). The following `setImage` JS function accepts the `<img>` tag `id` and data stream for the image. The function performs the following steps:

* Reads the provided stream into an [`ArrayBuffer`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/ArrayBuffer).
* Creates a [`Blob`](https://developer.mozilla.org/docs/Web/API/Blob) to wrap the `ArrayBuffer`.
* Creates an object URL to serve as the address for the image to be shown.
* Updates the `<img>` element with the specified `imageElementId` with the object URL just created.
* To prevent memory leaks, the function calls [`revokeObjectURL`](https://developer.mozilla.org/docs/Web/API/URL/revokeObjectURL) to dispose of the object URL when the component is finished working with an image.

```html
<script>
  window.setImage = async (imageElementId, imageStream) => {
    const arrayBuffer = await imageStream.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    document.getElementById(imageElementId).src = url;
    URL.revokeObjectURL(url);
  }
</script>
```

[!INCLUDE[](~/blazor/includes/js-location.md)]

The following `ShowImage2` component:

* Injects services for an <xref:System.Net.Http.HttpClient?displayProperty=fullName> and <xref:Microsoft.JSInterop.IJSRuntime?displayProperty=fullName>.
* Includes an `<img>` tag to display an image.
* Has a `GetImageStreamAsync` C# method to retrieve a <xref:System.IO.Stream> for an image. A production app may dynamically generate an image based on the specific user or retrieve an image from storage. The following example retrieves the .NET avatar for the `dotnet` GitHub repository.
* Has a `SetImageAsync` method that's triggered on the button's selection by the user. `SetImageAsync` performs the following steps:
  * Retrieves the <xref:System.IO.Stream> from `GetImageStreamAsync`.
  * Wraps the <xref:System.IO.Stream> in a <xref:Microsoft.JSInterop.DotNetStreamReference>, which allows streaming the image data to the client.
  * Invokes the `setImage` JavaScript function, which accepts the data on the client.

> [!NOTE]
> Blazor Server apps use a dedicated <xref:System.Net.Http.HttpClient> service to make requests, so no action is required by the developer in Blazor Server apps to register an <xref:System.Net.Http.HttpClient> service. Blazor WebAssembly apps have a default <xref:System.Net.Http.HttpClient> service registration when the app is created from a Blazor WebAssembly project template. If an <xref:System.Net.Http.HttpClient> service registration isn't present in `Program.cs` of a Blazor WebAssembly app, provide one by adding `builder.Services.AddHttpClient();`. For more information, see <xref:fundamentals/http-requests>.

`Pages/ShowImage2.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/images/ShowImage2.razor":::

## Additional resources

<!--

* <xref:blazor/forms-validation#preview-an-image-provided-by-the-inputfile-component>

-->

* <xref:blazor/file-uploads>
* <xref:blazor/file-downloads>
* <xref:blazor/js-interop/call-dotnet-from-javascript#stream-from-javascript-to-net>
* <xref:blazor/js-interop/call-javascript-from-dotnet#stream-from-net-to-javascript>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

## Dynamically set an image source

The following example demonstrates how to dynamically set an image's source with a C# field.

For the example in this section:

* Obtain three images from any source or right-click each of the following images to save them locally. Name the images `image1.png`, `image2.png`, and `image3.png`.

  ![Computer icon](~/blazor/images/_static/image1.png) &nbsp;&nbsp; ![Smiley icon](~/blazor/images/_static/image2.png) &nbsp;&nbsp; ![Earth icon](~/blazor/images/_static/image3.png)

* Place the images in a new folder named `images` in the app's web root (`wwwroot`). The use of the `images` folder is only for demonstration purposes. You can organize images in any folder layout that you prefer, including serving the images directly from the `wwwroot` folder.

In the following `ShowImage1` component:

* The image's source (`src`) is dynamically set to the value of `imageSource` in C#.
* The `ShowImage` method updates the `imageSource` field based on an image `id` argument passed to the method.
* Rendered buttons call the `ShowImage` method with an image argument for each of the three available images in the `images` folder. The file name is composed using the argument passed to the method and matches one of the three images in the `images` folder.

`Pages/ShowImage1.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/images/ShowImage1.razor":::

The preceding example uses a C# field to hold the image's source data, but you can also use a C# property to hold the data.

> [!NOTE]
> Do **not** use a loop variable directly in a lambda expression, such as `i` in the preceding `for` loop example. Otherwise, the same variable is used by all lambda expressions, which results in use of the same value in all lambdas. Always capture the variable's value in a local variable and then use the local variable. In the preceding example:
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

## Stream image data

An image can be directly sent to the client using Blazor's streaming interop features instead of hosting the image at a public URL.

The example in this section streams image source data using [JavaScript (JS) interop](xref:blazor/js-interop/index). The following `setImage` JS function accepts the `<img>` tag `id` and data stream for the image. The function performs the following steps:

* Reads the provided stream into an [`ArrayBuffer`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/ArrayBuffer).
* Creates a [`Blob`](https://developer.mozilla.org/docs/Web/API/Blob) to wrap the `ArrayBuffer`.
* Creates an object URL to serve as the address for the image to be shown.
* Updates the `<img>` element with the specified `imageElementId` with the object URL just created.
* To prevent memory leaks, the function calls [`revokeObjectURL`](https://developer.mozilla.org/docs/Web/API/URL/revokeObjectURL) to dispose of the object URL when the component is finished working with an image.

```html
<script>
  window.setImage = async (imageElementId, imageStream) => {
    const arrayBuffer = await imageStream.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    document.getElementById(imageElementId).src = url;
    URL.revokeObjectURL(url);
  }
</script>
```

[!INCLUDE[](~/blazor/includes/js-location.md)]

The following `ShowImage2` component:

* Injects services for an <xref:System.Net.Http.HttpClient?displayProperty=fullName> and <xref:Microsoft.JSInterop.IJSRuntime?displayProperty=fullName>.
* Includes an `<img>` tag to display an image.
* Has a `GetImageStreamAsync` C# method to retrieve a <xref:System.IO.Stream> for an image. A production app may dynamically generate an image based on the specific user or retrieve an image from storage. The following example retrieves the .NET avatar for the `dotnet` GitHub repository.
* Has a `SetImageAsync` method that's triggered on the button's selection by the user. `SetImageAsync` performs the following steps:
  * Retrieves the <xref:System.IO.Stream> from `GetImageStreamAsync`.
  * Wraps the <xref:System.IO.Stream> in a <xref:Microsoft.JSInterop.DotNetStreamReference>, which allows streaming the image data to the client.
  * Invokes the `setImage` JavaScript function, which accepts the data on the client.

> [!NOTE]
> Blazor Server apps use a dedicated <xref:System.Net.Http.HttpClient> service to make requests, so no action is required by the developer in Blazor Server apps to register an <xref:System.Net.Http.HttpClient> service. Blazor WebAssembly apps have a default <xref:System.Net.Http.HttpClient> service registration when the app is created from a Blazor WebAssembly project template. If an <xref:System.Net.Http.HttpClient> service registration isn't present in `Program.cs` of a Blazor WebAssembly app, provide one by adding `builder.Services.AddHttpClient();`. For more information, see <xref:fundamentals/http-requests>.

`Pages/ShowImage2.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/images/ShowImage2.razor":::

## Additional resources

<!--

* <xref:blazor/forms-validation#preview-an-image-provided-by-the-inputfile-component>

-->

* <xref:blazor/file-uploads>
* <xref:blazor/file-downloads>
* <xref:blazor/js-interop/call-dotnet-from-javascript#stream-from-javascript-to-net>
* <xref:blazor/js-interop/call-javascript-from-dotnet#stream-from-net-to-javascript>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

:::moniker-end


