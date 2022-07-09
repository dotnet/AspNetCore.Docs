Use the <xref:Microsoft.AspNetCore.Components.Forms.InputFile> component to read browser file data into .NET code. In some apps, you may wish to show a preview of a selected image.

Inject a JavaScript runtime instance at the top of a Razor component (`.razor`):

```razor
@inject IJSRuntime JS
```

Add an `<img>` tag for displaying the image preview to the component:

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
        await JS.InvokeVoidAsync("setImage", 
            "showImageHere", dotnetImageStream);
    }
}
```

The preceding `ResizeAndDisplayImageUsingStreaming` method performs the following steps:

* Accesses the <xref:Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs.File> which is an <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile>.
* Requests an image file from the specified <xref:Microsoft.AspNetCore.Components.Forms.IBrowserFile> and resizes it to 250 pixels by 250 pixels.
* Opens a <xref:System.IO.Stream> to read the `resizedImage`.
* Wraps the `resizedImage` <xref:System.IO.Stream> in a <xref:Microsoft.JSInterop.DotNetStreamReference>, which allows streaming the image data to the client.
* Invokes a JavaScript function, `setImage`, to stream image source data using JS interop (see [example `setImage` function](xref:blazor/images#stream-images)). **NOTE**: Because `setImage` is called from a form, it isn't necessary for the `setImage` function to call [`revokeObjectURL`](https://developer.mozilla.org/docs/Web/API/URL/revokeObjectURL), as shown in the <xref:blazor/images> article. The object URL is typically revoked after the user submits the form for processing, as the object URL is no longer required at that point. Therefore, the example demonstrated in this section can use `setImage` without the call to [`revokeObjectURL`](https://developer.mozilla.org/docs/Web/API/URL/revokeObjectURL).

> [!NOTE]
> The image preview technique described in this section involves round-tripping the image data from the client to the server and back. In a future release, this aspect might be optimized to better facilitate image previews. In the meantime, you may elect to create an event listener for the `InputFile` component that captures the [`FileList`](https://developer.mozilla.org/docs/Web/API/FileList) and displays a preview using JavaScript.
