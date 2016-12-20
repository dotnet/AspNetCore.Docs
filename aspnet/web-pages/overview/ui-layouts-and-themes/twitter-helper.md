---
title: "Twitter Helper with ASP.NET Web Pages | Microsoft Docs"
author: tfitzmac
description: "This topic and application show how to add a Twitter Helper to your WebMatrix 3 project. It contains the Twitter Helper code and shows how to call the helper..."
ms.author: riande
manager: wpickett
ms.date: 02/07/2014
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webpages
ms.prod: .net-framework
msc.legacyurl: /web-pages/overview/ui-layouts-and-themes/twitter-helper
---
Twitter Helper with ASP.NET Web Pages
====================
by [Tom FitzMacken](https://github.com/tfitzmac)

> This topic and application show how to add a Twitter Helper to your WebMatrix 3 project. It contains the Twitter Helper code and shows how to call the helper methods.
> 
> This code for the Twitter.cshtml file was developed by **Tian Pan** of Microsoft.
> 
> ## Software versions used in the tutorial
> 
> 
> - ASP.NET Web Pages (Razor) 3
>   
> 
> This tutorial also works with ASP.NET Web Pages 2.


## Introduction

This topic demonstrates how to add a Twitter Helper to your application and use Razor syntax to call the helper methods. The Twitter Helper makes it easy to incorporate Twitter buttons and widgets in your application. To use a Twitter widget, such as a user's timeline or the search results for a hashtag, you must first create the [widget on Twitter](https://twitter.com/settings/widgets). After creating your widget, you will receive a widget id. You pass this widget id as a parameter when calling the helper methods that show widget.

This topic was written for version 1.1 of the Twitter API. By directly adding the Twitter Helper code to your project, you can update the helper code if the Twitter API changes.

For information about installing WebMatrix, see [Introducing ASP.NET Web Pages 2 - Getting Started](../getting-started/introducing-aspnet-web-pages-2/getting-started.md).

## Add Twitter Helper to your project

To add the Twitter Helper, first, add a folder named **App\_Code** to your project. Then, create a file named **Twitter.cshtml**.

![App_Code folder](twitter-helper/_static/image1.png)

Replace the default code in Twitter.cshtml with the following code.

    @* This Twitter helper is compatible with version 1.1 of the Twitter API. *@
    
    @using System.Globalization
    
    @* For more about the twitter follow button, please visit
       https://dev.twitter.com/docs/follow-button *@
    @helper FollowButton(
                string userName,
                bool showCount = false,
                bool showUserName = true,
                bool largeButton = false,
                bool optOutOfTailoring = false,
                string language = "",
                bool alignLeft = true)
    {
        var showCountAttribute = new HtmlString(showCount ? "" : "data-show-count=\"false\"");
        var showUserNameAttribute = new HtmlString(showUserName ? "" : "data-show-screen-name=\"false\"");
        var largeButtonAttribute = new HtmlString(largeButton ? "data-size=\"large\"" : "");
        var optOutOfTailoringAttribute = new HtmlString(optOutOfTailoring ? "data-dnt=\"true\"" : "");
        var languageAttribute = new HtmlString(!language.IsEmpty() && !language.Equals("en", StringComparison.OrdinalIgnoreCase) ? String.Format(CultureInfo.InvariantCulture, " data-lang=\"" + HttpUtility.HtmlAttributeEncode(language) + "\"") : "");
        var alignAttribute = new HtmlString(alignLeft ? "" : "data-align=\"right\"");
        <a href="https://twitter.com/@HttpUtility.UrlEncode(userName)" class="twitter-follow-button" @showCountAttribute @showUserNameAttribute @largeButtonAttribute @optOutOfTailoringAttribute @languageAttribute @alignAttribute>Follow @@@userName)</a>
        <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
    }
    
    @* For more about the tweet button, please visit https://dev.twitter.com/docs/tweet-button *@
    @helper TweetButton(string url = "",
                string tweetText = "",
                bool showCount = true,
                string via = "",
                string recommend = "",
                string hashtag = "",
                bool largeButton = false,
                bool optOutOfTailoring = false,
                string language = "")
    {
        var urlAttribute = new HtmlString(url.IsEmpty() ? "" : String.Format(CultureInfo.InvariantCulture, " data-url=\"" + HttpUtility.HtmlAttributeEncode(url) + "\""));
        var tweetTextAttribute = new HtmlString(tweetText.IsEmpty() ? "" : "data-text=\"" + HttpUtility.HtmlAttributeEncode(tweetText) + "\"");
        var showCountAttribute = new HtmlString(showCount ? "" : "data-show-count=\"false\"");
        var viaAttribute = new HtmlString(via.IsEmpty() ? "" : "data-via=\"" + HttpUtility.HtmlAttributeEncode(via) + "\"");
        var recommendAttribute = new HtmlString(recommend.IsEmpty() ? "" : "data-related=\"" + HttpUtility.HtmlAttributeEncode(recommend) + "\"");
        var hashtagAttribute = new HtmlString(hashtag.IsEmpty() ? "" : "data-hashtags=\"" + HttpUtility.HtmlAttributeEncode(hashtag) + "\"");
        var largeButtonAttribute = new HtmlString(largeButton ? "data-size=\"large\"" : "");
        var optOutOfTailoringAttribute = new HtmlString(optOutOfTailoring ? "data-dnt=\"true\"" : "");
        var languageAttribute = new HtmlString(!language.IsEmpty() && !language.Equals("en", StringComparison.OrdinalIgnoreCase) ? String.Format(CultureInfo.InvariantCulture, " data-lang=\"{0}\"", HttpUtility.HtmlAttributeEncode(language)) : "");
        <a href="https://twitter.com/share" class="twitter-share-button" @urlAttribute @tweetTextAttribute @showCountAttribute @viaAttribute @recommendAttribute @hashtagAttribute @largeButtonAttribute @optOutOfTailoringAttribute @languageAttribute>Tweet</a>
        <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
    }
    
    @helper TimeLine(string userName,
                string widgetId,
                string theme = "",
                string linkColor = "",
                string language = "",
                int? tweetLimit = null,
                string relatedUsers = "",
                string ariaPolite = "",
                int? width = null,
                int? height = null,
                string title = "Tweets")
    {
        var themeAttribute = new HtmlString(theme.IsEmpty() ? "" : "data-theme=\"" + theme + "\"");
        var linkColorAttribute = new HtmlString(linkColor.IsEmpty() ? "" : "data-link-color=\"" + linkColor + "\"");
        var languageAttribute = new HtmlString(!language.IsEmpty() && !language.Equals("en", StringComparison.OrdinalIgnoreCase) ? String.Format(CultureInfo.InvariantCulture, " data-lang=\"{0}\"", HttpUtility.HtmlAttributeEncode(language)) : "");
        var relatedUsersAttribute = new HtmlString(relatedUsers.IsEmpty() ? "" : "data-related=\"" + relatedUsers + "\"");
        var ariaPoliteAttribute = new HtmlString(ariaPolite.IsEmpty() ? "" : "data-aria-polite=\"" + ariaPolite + "\"");
        <a class="twitter-timeline" href="https://twitter.com/@userName" width="@width.ToString()" height="@height.ToString()" data-widget-id="@HttpUtility.HtmlEncode(widgetId)" @themeAttribute @linkColorAttribute @languageAttribute data-tweet-limit="@tweetLimit.ToString()" @relatedUsersAttribute @ariaPoliteAttribute>@title</a>
        <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");</script>
    }
    
    @helper Profile(string userName,
                string widgetId,
                string theme = "",
                string linkColor = "",
                string language = "",
                int? tweetLimit = null,
                string relatedUsers = "",
                string ariaPolite = "",
                int? width = null,
                int? height = null)
    {
        @Twitter.TimeLine(userName, widgetId, theme, linkColor, language, tweetLimit, relatedUsers, ariaPolite, width, height, "Tweets by @" + HttpUtility.HtmlEncode(userName));
    }
    
    @helper Faves(string userName,
                string widgetId,
                string theme = "",
                string linkColor = "",
                string language = "",
                int? tweetLimit = null,
                string relatedUsers = "",
                string ariaPolite = "",
                int? width = null,
                int? height = null)
    {
        @Twitter.TimeLine(userName + "/favorites", widgetId, theme, linkColor, language, tweetLimit, relatedUsers, ariaPolite, width, height, "Favorite Tweets by @" + HttpUtility.HtmlEncode(userName));
    }
    
    @helper List(string userName,
                string list,
                string widgetId,
                string theme = "",
                string linkColor = "",
                string language = "",
                int? tweetLimit = null,
                string relatedUsers = "",
                string ariaPolite = "",
                int? width = null,
                int? height = null)
    {
        @Twitter.TimeLine(userName + "/" + list, widgetId, theme, linkColor, language, tweetLimit, relatedUsers, ariaPolite, width, height, "Tweets from @" + HttpUtility.HtmlEncode(userName) + "/" + HttpUtility.HtmlEncode(list));
    }
    
    @helper Search(string query,
                string widgetId,
                string theme = "",
                string linkColor = "",
                string language = "",
                int? tweetLimit = null,
                string relatedUsers = "",
                string ariaPolite = "",
                int? width = null,
                int? height = null)
    {
        @Twitter.TimeLine("search?q=" + HttpUtility.UrlEncode(query), widgetId, theme, linkColor, language, tweetLimit, relatedUsers, ariaPolite, width, height, "Tweets about \"" + HttpUtility.HtmlEncode(query) + "\"");
    }

## Call Twitter methods from your web pages

The following example shows how to use the Twitter Helper methods from a page in your project. In your project, you will want to replace the parameter values with values that are relevant to your needs. You can use the provided widget ids to explore how the methods work, but you will want to generate your own widgets for your project.

Not all of the parameters shown below are required. The optional parameters are used to customize how the button or widget is displayed. For example, the Follow Button only requires the user name to follow, but the example shows how to include the number of followers, and how specify the size of the button and the language.

    <!DOCTYPE html>
    
    <html lang="en">
        <head>
            <meta charset="utf-8" />
            <title>Show the Twitter Helper</title>
        </head>
        <body>
            <h1>Twitter Buttons and Widgets</h1>
    
            <h2>1. Follow Button</h2>
            <p>@Twitter.FollowButton(userName: "aspnet", showCount: true, largeButton: false, language: "es")</p>
    
            <h2>2. Tweet Button</h2>
            <p>@Twitter.TweetButton(url: "https://www.asp.net/mvc", largeButton: true, hashtag: "awesome")</p>
            
            <h2>3. User Timeline (Profile)</h2>
            <p>@Twitter.Profile("aspnet", "370310677673422848")</p>
    
            <h2>4. Favorites</h2>
            <p>@Twitter.Faves("Microsoft", "372486349795753984")</p>
    
            <h2>5. List</h2>
            <p>@Twitter.List("MS_Consumer_Bands", "Microsoft", "372485258974748672")</p>
    
            <h2>6. Search</h2>
            <p>@Twitter.Search("#asp.net", "370310477957435392")</p>
        </body>
    </html>

## See the results

The above code produces the following buttons and widgets. These buttons and widgets are fully-functional, not screenshots. The Follow Button is displayed in Spanish because the language parameter was set to **es**.

### Follow Button

[Follow @aspnet)](https://twitter.com/aspnet)<script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>

### Tweet Button

[Tweet](https://twitter.com/share)<script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>

### User Timeline (Profile)

[Tweets by @aspnet](https://twitter.com/aspnet)<script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");</script>

### Favorites

[Favorite Tweets by @Microsoft](https://twitter.com/Microsoft/favorites)<script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");</script>

### List

[Tweets from @Microsoft/MS\_Consumer\_Bands](https://twitter.com/microsoft/ms-consumer-brands/)<script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");</script>

### Search

[Tweets about &quot;#asp.net&quot;](https://twitter.com/search?q=%23asp.net)<script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");</script>