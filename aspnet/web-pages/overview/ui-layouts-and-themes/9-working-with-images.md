---
uid: web-pages/overview/ui-layouts-and-themes/9-working-with-images
title: "Working with Images in an ASP.NET Web Pages (Razor) Site | Microsoft Docs"
author: tfitzmac
description: "This chapter shows you how to add, display, and manipulate images (resize, flip, and add watermarks) in your website."
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/20/2014
ms.topic: article
ms.assetid: 778c4e58-4372-4d25-bab9-aec4a8d8e38d
ms.technology: dotnet-webpages
ms.prod: .net-framework
msc.legacyurl: /web-pages/overview/ui-layouts-and-themes/9-working-with-images
msc.type: authoredcontent
---
Working with Images in an ASP.NET Web Pages (Razor) Site
====================
by [Tom FitzMacken](https://github.com/tfitzmac)

> This article shows you how to add, display, and manipulate images (resize, flip, and add watermarks) in an ASP.NET Web Pages (Razor) website.
> 
> What you'll learn:
> 
> - How to add an image to a page dynamically.
> - How to let users upload an image.
> - How to resize an image.
> - How to flip or rotate an image.
> - How to add a watermark to an image.
> - How to use an image as a watermark.
> 
> These are the ASP.NET programming features introduced in the article:
> 
> - The `WebImage` helper.
> - The `Path` object, which provides methods that let you manipulate path and file names.
>   
> 
> ## Software versions used in the tutorial
> 
> 
> - ASP.NET Web Pages (Razor) 2
> - WebMatrix 2
>   
> 
> This tutorial also works with WebMatrix 3.


<a id="Adding_an_Image"></a>
## Adding an Image to a Web Page Dynamically

You can add images to your website and to individual pages while you're developing the website. You can also let users upload images, which might be useful for tasks like letting them add a profile photo.

If an image is already available on your site and you just want to display it on a page, you use an HTML `<img>` element like this:

[!code-html[Main](9-working-with-images/samples/sample1.html)]

Sometimes, though, you need to be able to display images dynamically &#8212; that is, you don't know what image to display until the page is running.

The procedure in this section shows how to display an image on the fly where users specify the image file name from a list of image names. They select the name of the image from a drop-down list, and when they submit the page, the image they selected is displayed.

![[image]](9-working-with-images/_static/image1.jpg "ch9images-1.jpg")

1. In WebMatrix, create a new website.
2. Add a new page named *DynamicImage.cshtml*.
3. In the root folder of the website, add a new folder and name it *images*.
4. Add four images to the *images* folder you just created. (Any images you have handy will do, but they should fit onto a page.) Rename the images *Photo1.jpg*, *Photo2.jpg*, *Photo3.jpg*, and *Photo4.jpg*. (You won't use *Photo4.jpg* in this procedure, but you'll use it later in the article.)
5. Verify that the four images are not marked as read-only.
6. Replace the existing content in the page with the following:

    [!code-cshtml[Main](9-working-with-images/samples/sample2.cshtml)]

    The body of the page has a drop-down list (a `<select>` element) that's named `photoChoice`. The list has three options, and the `value` attribute of each list option has the name of one of the images that you put in the *images* folder. Essentially, the list lets the user select a friendly name like &quot;Photo 1&quot;, and it then passes the *.jpg* file name when the page is submitted.

    In the code, you can get the user's selection (in other words, the image file name) from the list by reading `Request["photoChoice"]`. You first see if there's a selection at all. If there is, you construct a path for the image that consists of the name of the folder for the images and the user's image file name. (If you tried to construct a path but there was nothing in `Request["photoChoice"]`, you'd get an error.) This results in a relative path like this:

    *images/Photo1.jpg*

    The path is stored in variable named `imagePath` that you'll need later in the page.

    In the body, there's also an `<img>` element that's used to display the image that the user picked. The `src` attribute isn't set to a file name or URL, like you'd do to display a static element. Instead, it's set to `@imagePath`, meaning that it gets its value from the path you set in code.

    The first time that the page runs, though, there's no image to display, because the user hasn't selected anything. This would normally mean that the `src` attribute would be empty and the image would show up as a red &quot;x&quot; (or whatever the browser renders when it can't find an image). To prevent this, you put the `<img>` element in an `if` block that tests to see whether the `imagePath` variable has anything in it. If the user made a selection, `imagePath` contains the path. If the user didn't pick an image or if this is the first time the page is displayed, the `<img>` element isn't even rendered.
7. Save the file and run the page in a browser. (Make sure the page is selected in the **Files** workspace before you run it.)
8. Select an image from the drop-down list and then click **Sample Image**. Make sure that you see different images for different choices.

<a id="Uploading_an_Image"></a>
## Uploading an Image

The previous example showed you how to display an image dynamically, but it worked only with images that were already on your website. This procedure shows how to let users upload an image, which is then displayed on the page. In ASP.NET, you can manipulate images on the fly using the `WebImage` helper, which has methods that let you create, manipulate, and save images. The `WebImage` helper supports all the common web image file types, including *.jpg*, *.png*, and *.bmp*. Throughout this article, you'll use *.jpg* images, but you can use any of the image types.

![[image]](9-working-with-images/_static/image2.jpg "ch9images-2.jpg")

1. Add a new page and name it *UploadImage.cshtml*.
2. Replace the existing content in the page with the following: 

    [!code-cshtml[Main](9-working-with-images/samples/sample3.cshtml)]

    The body of the text has an `<input type="file">` element, which lets users select a file to upload. When they click **Submit**, the file they picked is submitted along with the form.

    To get the uploaded image, you use the `WebImage` helper, which has all sorts of useful methods for working with images. Specifically, you use `WebImage.GetImageFromRequest` to get the uploaded image (if any) and store it in a variable named `photo`.

    A lot of the work in this example involves getting and setting file and path names. The issue is that you want to get the name (and just the name) of the image that the user uploaded, and then create a new path for where you're going to store the image. Because users could potentially upload multiple images that have the same name, you use a bit of extra code to create unique names and make sure that users don't overwrite existing pictures.

    If an image actually has been uploaded (the test `if (photo != null)`), you get the image name from the image's `FileName` property. When the user uploads the image, `FileName` contains the user's original name, which includes the path from the user's computer. It might look like this:

    *C:\Users\Joe\Pictures\SamplePhoto1.jpg*

    You don't want all that path information, though &#8212; you just want the actual file name (*SamplePhoto1.jpg*). You can strip out just the file from a path by using the `Path.GetFileName` method, like this:

    [!code-csharp[Main](9-working-with-images/samples/sample4.cs)]

    You then create a new unique file name by adding a GUID to the original name. (For more about GUIDs, see [About GUIDs](#SB_AboutGUIDs) later in this article.) Then you construct a complete path that you can use to save the image. The save path is made up of the new file name, the folder (images), and the current website location.

    > [!NOTE]
    > In order for your code to save files in the *images* folder, the application needs read-write permissions for that folder. On your development computer this is not typically an issue. However, when you publish your site to a hosting provider's web server, you might need to explicitly set those permissions. If you run this code on a hosting provider's server and get errors, check with the hosting provider to find out how to set those permissions.

    Finally, you pass the save path to the `Save` method of the `WebImage` helper. This stores the uploaded image under its new name. The save method looks like this: `photo.Save(@"~\" + imagePath)`. The complete path is appended to `@"~\"`, which is the current website location. (For information about the `~` operator, see [Introduction to ASP.NET Web Programming Using the Razor Syntax](https://go.microsoft.com/fwlink/?LinkId=202890#ID_WorkingWithFileAndFolderPaths).)

    As in the previous example, the body of the page contains an `<img>` element to display the image. If `imagePath` has been set, the `<img>` element is rendered and its `src` attribute is set to the `imagePath` value.
3. Run the page in a browser.
4. Upload an image and make sure it's displayed in the page.
5. In your site, open the *images* folder. You see that a new file has been added whose file name looks something like this:: 

    *45ea4527-7ddd-4965-b9ca-c6444982b342\_MyPhoto.png*

    This is the image that you uploaded with a GUID prefixed to the name. (Your own file will have a different GUID and probably is named something different than *MyPhoto.png*.)

> [!TIP] 
> 
> <a id="SB_AboutGUIDs"></a>
> ### About GUIDs
> 
> A GUID (globally-unique ID) is an identifier that's usually rendered in a format like this: `936DA01F-9ABD-4d9d-80C7-02AF85C822A8`. The numbers and letters (from A-F) differ for each GUID, but they all follow the pattern of using groups of 8-4-4-4-12 characters. (Technically, a GUID is a 16-byte/128-bit number.) When you need a GUID, you can call specialized code that generates a GUID for you. The idea behind GUIDs is that between the enormous size of the number (3.4 x 10<sup>38</sup>) and the algorithm for generating it, the resulting number is virtually guaranteed to be one of a kind. GUIDs therefore are a good way to generate names for things when you must guarantee that you won't use the same name twice. The downside, of course, is that GUIDs aren't particularly user friendly, so they tend to be used when the name is used only in code.


<a id="Resizing_an_Image"></a>
## Resizing an Image

If your website accepts images from a user, you might want to resize the images before you display or save them. You can again use the `WebImage` helper for this.

This procedure shows how to resize an uploaded image to create a thumbnail and then save the thumbnail and original image in the website. You display the thumbnail on the page and use a hyperlink to redirect users to the full-sized image.

![[image]](9-working-with-images/_static/image3.jpg "ch9images-3.jpg")

1. Add a new page named *Thumbnail.cshtml*.
2. In the *images* folder, create a subfolder named *thumbs*.
3. Replace the existing content in the page with the following: 

    [!code-cshtml[Main](9-working-with-images/samples/sample5.cshtml)]

    This code is similar to the code from the previous example. The difference is that this code saves the image twice, once normally and once after you create a thumbnail copy of the image. First you get the uploaded image and save it in the *images* folder. You then construct a new path for the thumbnail image. To actually create the thumbnail, you call the `WebImage` helper's `Resize` method to create a 60-pixel by 60-pixel image. The example shows how you preserve the aspect ratio and how you can prevent the image from being enlarged (in case the new size would actually make the image larger). The resized image is then saved in the *thumbs* subfolder.

    At the end of the markup, you use the same `<img>` element with the dynamic `src` attribute that you've seen in the previous examples to conditionally show the image. In this case, you display the thumbnail. You also use an `<a>` element to create a hyperlink to the big version of the image. As with the `src` attribute of the `<img>` element, you set the `href` attribute of the `<a>` element dynamically to whatever is in `imagePath`. To make sure that the path can work as a URL, you pass `imagePath` to the `Html.AttributeEncode` method, which converts reserved characters in the path to characters that are ok in a URL.
4. Run the page in a browser.
5. Upload a photo and verify that the thumbnail is shown.
6. Click the thumbnail to see the full-size image.
7. In the *images* and *images/thumbs*, note that new files have been added.

<a id="Rotating_and_Flipping"></a>
## Rotating and Flipping an Image

The `WebImage` helper also lets you flip and rotate images. This procedure shows how to get an image from the server, flip the image upside down (vertically), save it, and then display the flipped image on the page. In this example, you're just using a file you already have on the server (*Photo2.jpg*). In a real application, you'd probably flip an image whose name you get dynamically, like you did in previous examples.

![[image]](9-working-with-images/_static/image4.jpg "ch9images-4.jpg")

1. Add a new page named *FlipImage.cshtml*.
2. Replace the existing content in the page with the following: 

    [!code-cshtml[Main](9-working-with-images/samples/sample6.cshtml)]

    The code uses the `WebImage` helper to get an image from the server. You create the path to the image using the same technique you used in earlier examples for saving images, and you pass that path when you create an image using `WebImage`:

    [!code-javascript[Main](9-working-with-images/samples/sample7.js)]

    If an image is found, you construct a new path and file name, like you did in earlier examples. To flip the image, you call the `FlipVertical` method, and then you save the image again.

    The image is again displayed on the page by using the `<img>` element with the `src` attribute set to `imagePath`.
3. Run the page in a browser. The image for *Photo2.jpg* is shown upside down.
4. Refresh the page or request the page again to see the image is flipped right side up again.

To rotate an image, you use the same code, except that instead of calling the `FlipVertical` or `FlipHorizontal`, you call `RotateLeft` or `RotateRight`.

<a id="Adding_a_Watermark"></a>
## Adding a Watermark to an Image

When you add images to your website, you might want to add a watermark to the image before you save it or display it on a page. People often use watermarks to add copyright information to an image or to advertise their business name.

![[image]](9-working-with-images/_static/image5.jpg "ch9images-5.jpg")

1. Add a new page named *Watermark.cshtml*.
2. Replace the existing content in the page with the following: 

    [!code-cshtml[Main](9-working-with-images/samples/sample8.cshtml)]

    This code is like the code in the *FlipImage.cshtml* page from earlier (although this time it uses the *Photo3.jpg* file). To add the watermark, you call the `WebImage` helper's `AddTextWatermark` method before you save the image. In the call to `AddTextWatermark`, you pass the text &quot;My Watermark&quot;, set the font color to yellow, and set the font family to Arial. (Although it's not shown here, the `WebImage` helper also lets you specify opacity, font family and font size, and the position of the watermark text.) When you save the image it must not be read-only.

    As you've seen before, the image is displayed on the page by using the `<img>` element with the src attribute set to `@imagePath`.
3. Run the page in a browser. Notice the text "My Watermark" at the bottom-right corner of the image.

<a id="Using_an_Image_as_a_Watermark"></a>
## Using an Image As a Watermark

Instead of using text for a watermark, you can use another image. People sometimes use images like a company logo as a watermark, or they use a watermark image instead of text for copyright information.

![[image]](9-working-with-images/_static/image6.jpg "ch9images-6.jpg")

1. Add a new page named *ImageWatermark.cshtml*.
2. Add an image to the *images* folder that you can use as a logo, and rename the image *MyCompanyLogo.jpg*. This image should be an image that you can see clearly when it's set to 80 pixels wide and 20 pixels high.
3. Replace the existing content in the page with the following: 

    [!code-cshtml[Main](9-working-with-images/samples/sample9.cshtml)]

    This is another variation on the code from earlier examples. In this case, you call `AddImageWatermark` to add the watermark image to the target image (*Photo3.jpg*) before you save the image. When you call `AddImageWatermark`, you set its width to 80 pixels and the height to 20 pixels. The *MyCompanyLogo.jpg* image is horizontally aligned in the center and vertically aligned at the bottom of the target image. The opacity is set to 100% and the padding is set to 10 pixels. If the watermark image is bigger than the target image, nothing will happen. If the watermark image is bigger than the target image and you set the padding for the image watermark to zero, the watermark is ignored.

    As before, you display the image using the `<img>` element and a dynamic `src` attribute.
4. Run the page in a browser. Notice that the watermark image appears at the bottom of the main image.

<a id="Additional_Resources"></a>
## Additional Resources


[Working with Files in an ASP.NET Web Pages Site](https://go.microsoft.com/fwlink/?LinkId=202896)

[Introduction to ASP.NET Web Pages Programming Using the Razor Syntax](https://go.microsoft.com/fwlink/?LinkID=251587)