---
title: ASP.NET Core Blazor Images
author: TanayParikh
description: Learn how to work with Images using Blazor.
monikerRange: '>= aspnetcore-6.0'
ms.author: taparik
ms.custom: mvc
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
ms.date: 11/02/2021
uid: blazor/images
---
# ASP.NET Core Blazor Images

This page examines working with images within Blazor. 

## Dynamically Set Image Source Using Blazor

The following example demonstrates how to dynamically set the image source using Blazor. Start by creating a `images` folder in `wwwroot` and adding three (random) images.

For this example, we'll assume images are named `wallpaper1.jpg`, `wallpaper2.jpg`, `wallpaper3.jpg`. Your project directory should look something like below:

```
- Pages
- Shared
- ...
- wwwroot
  - css
  - ...
  - images
    - wallpaper1.jpg
    - wallpaper2.jpg
    - wallpaper3.jpg
    - ...
```

Next add the following to your `razor` file:

```razor
<img src="@ImageSource" />

@code {
  private string ImageSource { get; set; } = string.Empty;
}
```

The `img` component's source will now be dynamically set based on the `ImageSource` property in C#.

We can now add a `ShowWallpaper` method which updates the `ImageSource` based on an image `id` passed in. Note, you may have to update the image path if you've arranged your images differently from this example.

```razor
@code {
  private void ShowWallpaper(int id)
  {
      ImageSource = $"images/wallpaper{id}.jpg";
  }
}
```

Finally, add buttons to toggle between showing the three images:

```razor
@for (var i = 1; i <= 3; i++)
{
  var imageId = i;
  <button @onclick="() => ShowWallpaper(imageId)">
    Wallpaper @imageId
  </button>
}
```

Each button will call `ShowWallpaper` with the associated `imageId`.

## Stream Image Data to Client

Sometimes it is necessary to send the image directly to the client instead of hosting the image in a public directory. We'll now examine how this can be done using Blazor streaming interop.

First add [`@inject`](xref:mvc/views/razor#inject) directives for the following:

* <xref:System.Net.Http.HttpClient?displayProperty=fullName>
* <xref:Microsoft.JSInterop.IJSRuntime?displayProperty=fullName>

Note, for Blazor Server, if you haven't already added a `HttpClient` to your services, do so now by adding `builder.Services.AddHttpClient();` in your `Program.cs` file before `builder.Build()`. For more information, see <xref:fundamentals/http-requests>.

Then create an `img` component to display the image, as well as a `button` which will trigger .NET to send the image to the client.

```razor
<img id="imageUsingImageStream" />
<button @onclick="SetImageUsingStreamingAsync">
    Set Image Using Image Stream
</button>
```

Next, add a C# method that retrieves a <xref:System.IO.Stream> for the image to be displayed. This is where you may dynamically generate an image based on the specific user, or retrieve the image from storage. In this example, we retrieve the `dotnet` avatar from GitHub.

```razor
@code {
  private async Task<Stream> GetImageStreamAsync()
  {
      return await HttpClient.GetStreamAsync("https://avatars.githubusercontent.com/u/9141961");
  }
}
```

We can now add the `SetImageUsingStreamingAsync` method which is triggered on `button` press. `SetImageUsingStreamingAsync` performs the following steps:

* Retrieves the <xref:System.IO.Stream> from `GetImageStreamAsync`
* Wraps the <xref:System.IO.Stream> in a <xref:Microsoft.JSInterop.DotNetStreamReference>, which allows streaming the image data to the client.
* Invokes `setImageUsingStreaming`, which is a JavaScript function that accepts the data on the client. The `setImageUsingStreaming` function is shown later in this article.

```razor
@code {
    private async Task SetImageUsingStreamingAsync()
    {
        var imageStream = await GetImageStreamAsync();
        var dotnetImageStream = new DotNetStreamReference(imageStream);
        await JSRuntime.InvokeVoidAsync("setImageUsingStreaming", "imageUsingImageStream", dotnetImageStream);
    }
}
```

The JavaScript `setImageUsingStreaming` function accepts the `img` tag `id` and data stream for the image. The function performs the following steps:

* Read the provided stream into an [`ArrayBuffer`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/ArrayBuffer).
* Create a [`Blob`](https://developer.mozilla.org/docs/Web/API/Blob) to wrap the `ArrayBuffer`.
* Create an object URL to serve as the address for the image to be shown.
* Update the `img` element with the specified `imageElementId` with the object URL just created.

```js
async function setImageUsingStreaming(imageElementId, imageStream) {
  const arrayBuffer = await imageStream.arrayBuffer();
  const blob = new Blob([arrayBuffer]);
  
  const url = URL.createObjectURL(blob);

  document.getElementById(imageElementId).src = url;
}
```

Note, once you're done working with the image, you should [dispose of the Object `url`]() to prevent memory leaks:

```js
URL.revokeObjectURL(url);
```

For more information on `revokeObjectURL`, please see [this](https://developer.mozilla.org/docs/Web/API/URL/revokeObjectURL).


### Previewing an image provided by the [`InputFile`](<xref:Microsoft.AspNetCore.Components.Forms.InputFile>) Component

The <xref:Microsoft.AspNetCore.Components.Forms.InputFile> component can be used to read browser file data into .NET code. In some applications you may wish to allow previewing of the selected image.

Add an `img` tag which will be used to display the image preview.

```html
<img id="showImageHere" />
```

Then add the following <xref:Microsoft.AspNetCore.Components.Forms.InputFile> tag into your `razor` file:

```razor
<InputFile OnChange="ResizeAndDisplayImageUsingStreaming" />
```

When a file is selected, the `ResizeAndDisplayImageUsingStreaming` method is called with <xref:Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs>. Let's examine that method next:

```razor
@code {
    private async Task ResizeAndDisplayImageUsingStreaming(InputFileChangeEventArgs e)
    {
        var imageFile = e.File;
        var resizedImage = await imageFile.RequestImageFileAsync("image/jpg", 250, 250);
        var jsImageStream = resizedImage.OpenReadStream();
        var dotnetImageStream = new DotNetStreamReference(jsImageStream);
        await JSRuntime.InvokeVoidAsync("setImageUsingStreaming", "showImageHere", dotnetImageStream);
    }
}
```

`ResizeAndDisplayImageUsingStreaming` performs the following steps:

* Accesses the <xref:Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs.File> which is an <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile>.
* Requests an image file from the specified <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile>, and resizes it to 250 pixels by 250 pixels.
* Opens a <xref:System.IO.Stream> to read the `resizedImage`
* Wrap the `resizedImage` <xref:System.IO.Stream> in a <xref:Microsoft.JSInterop.DotNetStreamReference>, which allows streaming the image data to the client.
* Invokes `setImageUsingStreaming`, which is a JavaScript function that accepts the data on the client. The `setImageUsingStreaming` function is shown in the prior section.

Note this technique involves round-tripping the image data from the client to the server, and back. In a future version of .NET this area may be optimized to better facilitate image previews. In the meantime, you may elect to create an event listener for the `InputFile` component which captures the [`FileList`](https://developer.mozilla.org/docs/Web/API/FileList) and displays a preview using JavaScript. This is left as an exercise for the reader.

## Additional resources

* <xref:blazor/file-uploads>
* <xref:blazor/file-downloads>
* <xref:blazor/js-interop/call-dotnet-from-javascript#stream-from-javascript-to-dotnet>
* <xref:blazor/js-interop/call-javascript-from-dotnet#stream-from-dotnet-to-javascript>
