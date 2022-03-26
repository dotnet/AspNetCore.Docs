---
title: Work with images in ASP.NET Core Blazor
author: TanayParikh
description: Learn how to work with images in ASP.NET Core Blazor apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: taparik
ms.custom: mvc
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
ms.date: 11/09/2021
uid: blazor/images
---
# Work with images in ASP.NET Core Blazor

This article describes common scenarios for working with images in Blazor apps. 

## Dynamically set an image source

The following example demonstrates how to dynamically set an image's source with a C# field.

For the example in this section:

* Obtain three small PNG images from any source.
* Name the images `image1.png`, `image2.png`, and `image3.png`.
* Place the images in a new folder (`images`) in the app's static assets folder (`wwwroot`).

The following directory tree shows the images in the `wwwroot/images` folder:

* `wwwroot`
  * ...
  * `images`
    * `image1.png`
    * `image2.png`
    * `image3.png`

In the following `ShowImage` component:

* The image's source (`src`) is dynamically set to the value of `imageSource` in C#.
* The `ShowImage` method updates the `imageSource` field based on an image `id` argument passed to the method.
* Rendered buttons call the `ShowImage` method with an image ID argument for each of the three available images in the `images` folder.

`Pages/ShowImage.razor`:

```razor
@page "/show-image"

@if (imageSource is not null)
{
    <div>
        <img src="@imageSource" />
    </div>
}

@for (var i = 1; i <= 3; i++)
{
    var imageId = i;
    <button @onclick="() => ShowImage(imageId)">
        Image @imageId
    </button>
}

@code {
    private string? imageSource;

    private void ShowImage(int id)
    {
        imageSource = $"images/image{id}.png";
    }
}
```

The preceding example uses a C# field to hold the image's source data, but you can also use a C# property to hold the data.

> [!NOTE]
> Do **not** use a loop variable directly in a lambda expression, such as `i` in the preceding `for` loop example. Otherwise, the same variable is used by all lambda expressions, which results in use of the same value in all lambdas. Always capture the variable's value in a local variable and then use the local variable. In the preceding example:
>
> * The loop variable `i` is assigned to `imageId`.
> * `imageId` is used in the lambda expression.

## Streaming examples

The examples in this section stream image source data using JS interop. The following JavaScript `setImageUsingStreaming` function accepts the `<img>` tag `id` and data stream for the image. The function performs the following steps:

* Reads the provided stream into an [`ArrayBuffer`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/ArrayBuffer).
* Creates a [`Blob`](https://developer.mozilla.org/docs/Web/API/Blob) to wrap the `ArrayBuffer`.
* Creates an object URL to serve as the address for the image to be shown.
* Updates the `<img>` element with the specified `imageElementId` with the object URL just created.

```javascript
async function setImageUsingStreaming(imageElementId, imageStream) {
  const arrayBuffer = await imageStream.arrayBuffer();
  const blob = new Blob([arrayBuffer]);
  const url = URL.createObjectURL(blob);
  document.getElementById(imageElementId).src = url;
}
```

To prevent memory leaks, call [`URL.revokeObjectURL()`](https://developer.mozilla.org/docs/Web/API/URL/revokeObjectURL) to dispose of the object URL (`url` in the preceding example) when the component is finished working with an image. In a form, the object URL is typically revoked after the user submits the form for processing, as the object URL is no longer required at that point.

```javascript
URL.revokeObjectURL(url);
```

### Stream image data to a client

Sometimes, it's necessary to send an image directly to the client instead of hosting the image in a public directory. The following guidance explains how how to accomplish this goal using Blazor's streaming interop features.

Add [`@inject`](xref:mvc/views/razor#inject) directives for the following services to a Razor component (`.razor`):

* <xref:System.Net.Http.HttpClient?displayProperty=fullName>
* <xref:Microsoft.JSInterop.IJSRuntime?displayProperty=fullName>

> [!NOTE]
> Blazor Server apps use a dedicated `HttpClient` service to make requests. If you haven't already added an `HttpClient` to the app's service collection, do so now by adding `builder.Services.AddHttpClient();` in the `Program.cs` file before `builder.Build()`. For more information, see <xref:fundamentals/http-requests>.

Add an `<img>` tag to display the image. Also, add a button to trigger .NET to send the image to the client with a click event handler that calls a `SetImageUsingStreamingAsync` method:

```razor
<img id="image1" />

<button @onclick="SetImageUsingStreamingAsync">
    Set Image Using Image Stream
</button>
```

Add a C# method that retrieves a <xref:System.IO.Stream> for the image. At this point, you may dynamically generate an image based on the specific user or retrieve an image from storage. The following example retrieves the `dotnet` avatar from GitHub:

```razor
@code {
    private async Task<Stream> GetImageStreamAsync()
    {
        return await HttpClient.GetStreamAsync(
            "https://avatars.githubusercontent.com/u/9141961");
    }
}
```

Add the following `SetImageUsingStreamingAsync` method, which is triggered on the button's selection by the user. `SetImageUsingStreamingAsync` performs the following steps:

* Retrieves the <xref:System.IO.Stream> from `GetImageStreamAsync`.
* Wraps the <xref:System.IO.Stream> in a <xref:Microsoft.JSInterop.DotNetStreamReference>, which allows streaming the image data to the client.
* Invokes `setImageUsingStreaming` ([shown earlier](#streaming-examples)), which is a JavaScript function that accepts the data on the client. The `setImageUsingStreaming` function is shown later in this article.

```razor
@code {
    private async Task SetImageUsingStreamingAsync()
    {
        var imageStream = await GetImageStreamAsync();
        var dotnetImageStream = new DotNetStreamReference(imageStream);
        await JSRuntime.InvokeVoidAsync("setImageUsingStreaming", 
            "image1", dotnetImageStream);
    }
}
```

### Preview an image provided by the `InputFile` component

[!INCLUDE[](includes/inputfile-preview-images.md)]

## Additional resources

* <xref:blazor/file-uploads>
* <xref:blazor/file-downloads>
* <xref:blazor/js-interop/call-dotnet-from-javascript#stream-from-javascript-to-net>
* <xref:blazor/js-interop/call-javascript-from-dotnet#stream-from-net-to-javascript>
