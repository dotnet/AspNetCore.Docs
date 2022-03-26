---
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
---
Use the <xref:Microsoft.AspNetCore.Components.Forms.InputFile> component to read browser file data into .NET code. In some apps, you may wish to show a preview of a selected image.

Add an `<img>` tag for displaying the image preview in a Razor component (`.razor`):

```html
<img id="showImageHere" />
```

Add the following <xref:Microsoft.AspNetCore.Components.Forms.InputFile> tag to the component:

```razor
<InputFile OnChange="ResizeAndDisplayImageUsingStreaming" />
```

When a file is selected, the `ResizeAndDisplayImageUsingStreaming` method is called with <xref:Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs>. Examine the following `ResizeAndDisplayImageUsingStreaming` method example:

```razor
@code {
    private async Task ResizeAndDisplayImageUsingStreaming(InputFileChangeEventArgs e)
    {
        var imageFile = e.File;
        var resizedImage = 
            await imageFile.RequestImageFileAsync("image/jpg", 250, 250);
        var jsImageStream = resizedImage.OpenReadStream();
        var dotnetImageStream = new DotNetStreamReference(jsImageStream);
        await JSRuntime.InvokeVoidAsync("setImageUsingStreaming", 
            "showImageHere", dotnetImageStream);
    }
}
```

The preceding `ResizeAndDisplayImageUsingStreaming` method performs the following steps:

* Accesses the <xref:Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs.File> which is an <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile>.
* Requests an image file from the specified <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile> and resizes it to 250 pixels by 250 pixels.
* Opens a <xref:System.IO.Stream> to read the `resizedImage`.
* Wraps the `resizedImage` <xref:System.IO.Stream> in a <xref:Microsoft.JSInterop.DotNetStreamReference>, which allows streaming the image data to the client.
* Invokes a JavaScript function, `setImageUsingStreaming`, to stream image source data using JS interop (see [example `setImageUsingStreaming` function](xref:blazor/images#streaming-examples)).

> [!NOTE]
> The image preview technique described in this section involves round-tripping the image data from the client to the server and back. In a future release, this aspect might be optimized to better facilitate image previews. In the meantime, you may elect to create an event listener for the `InputFile` component that captures the [`FileList`](https://developer.mozilla.org/docs/Web/API/FileList) and displays a preview using JavaScript.
