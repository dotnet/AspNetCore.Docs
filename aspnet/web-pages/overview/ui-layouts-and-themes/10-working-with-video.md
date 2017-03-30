---
uid: web-pages/overview/ui-layouts-and-themes/10-working-with-video
title: "Displaying Video in an ASP.NET Web Pages (Razor) Site | Microsoft Docs"
author: tfitzmac
description: "This chapter explains how to display video in an ASP.NET Web Pages with Razor syntax page."
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/20/2014
ms.topic: article
ms.assetid: 332fb3da-e2a5-460d-bb90-dd911e1e2c95
ms.technology: dotnet-webpages
ms.prod: .net-framework
msc.legacyurl: /web-pages/overview/ui-layouts-and-themes/10-working-with-video
msc.type: authoredcontent
---
Displaying Video in an ASP.NET Web Pages (Razor) Site
====================
by [Tom FitzMacken](https://github.com/tfitzmac)

> This article explains how to use a video (media) player in an ASP.NET Web Pages (Razor) website to let users view videos that are stored on the site. ASP.NET Web Pages with Razor syntax lets you play Flash (*.swf*), Media Player (*.wmv*), and Silverlight (*.xap*) videos.
> 
> What you'll learn:
> 
> - How to choose a video player.
> - How to add video to a web page.
> - How to set video player attributes.
> 
> These are the ASP.NET Razor pages features introduced in the article:
> 
> - The `Video` helper.
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


## Introduction

You might want to display a video on your site. One way to do that is to link to a site that already has the video, like YouTube. If you want to embed a video from these sites directly in your own pages, you can usually get HTML markup from the site and then copy it into your page. For example, the following example shows how to embed a YouTube video:

[!code-html[Main](10-working-with-video/samples/sample1.html?highlight=10-14)]

If you want to play a video that's on your own website (not on a public video-sharing site), you can't directly link to it using embedded markup like this. However, you can play videos from your site by using the `Video` helper, which renders a media player directly in a page.

<a id="Choosing_a_Video_Player"></a>
## Choosing a Video Player

There are lots of formats for video files, and each format typically requires a different player and a different way to configure the player. In ASP.NET Razor pages, you can play a video in a web page using the `Video` helper. The `Video` helper simplifies the process of embedding videos in a web page because it automatically generates the `object` and `embed` HTML elements that are normally used to add video to the page.

The `Video` helper supports the following media players:

- Adobe Flash
- Windows MediaPlayer
- Microsoft Silverlight

### The Flash Player

The `Flash` player of the `Video` helper let you play Flash videos (*.swf* files) in a web page. At a minimum, you have to provide a path to the video file. If you specify nothing but the path, the player uses default values that are set by the current version of Flash. Typical default settings are:

- The video is displayed using its default width and height and without a background color.
- The video plays automatically when the page loads.
- The video loops continuously until it's explicitly stopped.
- The video is scaled to show all of the video, rather than cropping the video to fit a specific size.
- The video plays in a window.

### The MediaPlayer Player

The `MediaPlayer` player of the `Video` helper lets you play Windows Media videos (*.wmv* files), Windows Media audio (*.wma* files), and MP3 (*.mp3* files) in a web page. You must include path of the media file to play; all other parameters are optional. If you specify only a path, the player uses default settings set by the current version of MediaPlayer, such as:

- The video is displayed using its default width and height.
- The video plays automatically when the page loads.
- The video plays once (it doesn't loop).
- The player displays the full set of controls in the user interface.
- The video plays in in a window.

### The Silverlight Player

The `Silverlight` player of the `Video` helper lets you play Windows Media Video (*.wmv* files), Windows Media Audio (*.wma* files), and MP3 (*.mp3* files). You must set the path parameter to point to a Silverlight-based application package (*.xap* file). You also must set the width and height parameters. All other parameters are optional. When you use the Silverlight player for video, if you set only the required parameters, the Silverlight player displays the video without a background color.

> [!NOTE]
> In case you don't already know Silverlight: the *.xap* file is a compressed file that contains layout instructions in a *.xaml* file, managed code in assemblies, and optional resources. You can create a *.xap* file in Visual Studio as a Silverlight application project.


The `Silverlight` video player uses both the settings that you provide for the player and the settings that are provided in the *.xap* file.

> [!TIP] 
> 
> <a id="SB_MimeTypes"></a>
> ### MIME Types
> 
> When a browser downloads a file, the browser makes sure that the file type matches the MIME type that's specified for the document that's being rendered. The MIME type is the content type or media type of a file. The `Video` helper uses the following MIME types:
> 
> - `application/x-shockwave-flash`
> - `application/x-mplayer2`
> - `application/x-silverlight-2`


<a id="Playing_Flash"></a>
## Playing Flash (.swf) Videos

This procedure shows you how to play a Flash video named *sample.swf*. The procedure assumes that you've got a folder named *Media* on your site and that the *.swf* file is in that folder.

1. Add the ASP.NET Web Helpers Library to your website as described in [Installing Helpers in an ASP.NET Web Pages Site](https://go.microsoft.com/fwlink/?LinkId=252372), if you haven't already added it.
2. In the website, add a page and name it *FlashVideo.cshtml*.
3. Add the following markup to the page: 

    [!code-cshtml[Main](10-working-with-video/samples/sample2.cshtml)]
4. Run the page in a browser. (Make sure the page is selected in the **Files** workspace before you run it.) The page is displayed and the video plays automatically. 

    ![[image]](10-working-with-video/_static/image1.jpg "ch08_video-1.jpg")

You can set the `quality` parameter for a Flash video to `low`, `autolow`, `autohigh`, `medium`, `high`, and `best`:

[!code-cshtml[Main](10-working-with-video/samples/sample3.cshtml)]

You can change the Flash video to play at a specific size using the `scale` parameter, which you can set to the following:

- `showall`. This makes the entire video visible while maintaining the original aspect ratio. However, you might end up with borders on each side.
- `noorder`. This scales the video while maintaining the original aspect ratio, but it might be cropped.
- `exactfit`. This makes the entire video visible without preserving the original aspect ratio, but distortion may occur.

If you don't specify a `scale` parameter, the entire video will be visible and the original aspect ratio will be maintained without any cropping. The following example shows how to use the `scale` parameter:

[!code-cshtml[Main](10-working-with-video/samples/sample4.cshtml)]

The Flash player supports a video mode setting named `windowMode`. You can set this to `window`, `opaque`, and `transparent`. By default, the `windowMode` is set to `window`, which displays the video in a separate window on the web page. The `opaque` setting hides everything behind the video on the web page. The `transparent` setting lets the background of the web page show through the video, assuming any part of the video is transparent.

<a id="Playing_MediaPlayer"></a>
## Playing MediaPlayer (*.wmv*) Videos

The following procedure shows you how to play a Window Media video named *sample.wmv* that's in the *Media* folder.

1. Add the ASP.NET Web Helpers Library to your website as described in [Installing Helpers in an ASP.NET Web Pages Site](https://go.microsoft.com/fwlink/?LinkId=252372), if you haven't already.
2. Create a new page named *MediaPlayerVideo.cshtml*.
3. Add the following markup to the page: 

    [!code-cshtml[Main](10-working-with-video/samples/sample5.cshtml)]
4. Run the page in a browser. The video loads and plays automatically. 

    ![[image]](10-working-with-video/_static/image2.jpg "ch08_video-2.jpg")

You can set `playCount` to an integer that indicates how many times to play the video automatically:

[!code-cshtml[Main](10-working-with-video/samples/sample6.cshtml)]

The `uiMode` parameter lets you specify which controls show up in the user interface. You can set `uiMode` to `invisible`, `none`, `mini`, or `full`. If you don't specify a `uiMode` parameter, the video will be displayed with the status window, seek bar, control buttons, and volume controls in addition to the video window. These controls will also be displayed if you use the player to play an audio file. Here's an example of how to use the `uiMode` parameter:

[!code-cshtml[Main](10-working-with-video/samples/sample7.cshtml)]

By default, audio is on when the video plays. You can mute the audio by setting the `mute` parameter to true:

[!code-cshtml[Main](10-working-with-video/samples/sample8.cshtml)]

You can control the audio level of the MediaPlayer video by setting the `volume` parameter to a value between 0 and 100. The default value is 50. Here's an example:

[!code-cshtml[Main](10-working-with-video/samples/sample9.cshtml)]

<a id="Playing_Silverlight"></a>
## Playing Silverlight Videos

This procedure shows you how to play video contained in a Silverlight *.xap* page that's in a folder named *Media*.

1. Add the ASP.NET Web Helpers Library to your website as described in [Installing Helpers in an ASP.NET Web Pages Site](https://go.microsoft.com/fwlink/?LinkId=252372), if you haven't already .
2. Create a new page named *SilverlightVideo.cshtml*.
3. Add the following markup to the page: 

    [!code-cshtml[Main](10-working-with-video/samples/sample10.cshtml)]
4. Run the page in a browser. 

    ![[image]](10-working-with-video/_static/image3.jpg "ch08_video-3.jpg")

<a id="Additional_Resources"></a>
## Additional Resources


[Silverlight Overview](https://msdn.microsoft.com/en-us/library/bb404700(VS.95).aspx)

[Flash OBJECT and EMBED tag attributes](http://kb2.adobe.com/cps/127/tn_12701.html)

[Windows Media Player 11 SDK PARAM Tags](https://msdn.microsoft.com/en-us/library/aa392321(VS.85).aspx)