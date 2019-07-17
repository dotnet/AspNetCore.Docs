---
title: "Tutorial: Call a web API with jQuery using ASP.NET Core"
author: rick-anderson
description: Learn how to call an ASP.NET Core web API with jQuery.
ms.author: riande
ms.custom: mvc
monikerRange: '>= aspnetcore-3.0'
ms.date: 07/20/2019
uid: tutorials/web-api-jquery
---

# Tutorial: Call an ASP.NET Core web API with jQuery

By [Rick Anderson](https://twitter.com/RickAndMSFT)

This tutorial shows how to call an ASP.NET Core web API with jQuery

## Prerequisites

Complete [Tutorial: Create a web API](xref:tutorials/first-web-api)

## Call the API with jQuery

In this section, an HTML page is added that uses jQuery to call the web api. jQuery initiates the request and updates the page with the details from the API's response.

Configure the app to [serve static files](/dotnet/api/microsoft.aspnetcore.builder.staticfileextensions.usestaticfiles#Microsoft_AspNetCore_Builder_StaticFileExtensions_UseStaticFiles_Microsoft_AspNetCore_Builder_IApplicationBuilder_) and [enable default file mapping](/dotnet/api/microsoft.aspnetcore.builder.defaultfilesextensions.usedefaultfiles#Microsoft_AspNetCore_Builder_DefaultFilesExtensions_UseDefaultFiles_Microsoft_AspNetCore_Builder_IApplicationBuilder_) by updating *Startup.cs* with the following highlighted code:

[!code-csharp[](first-web-api/samples/3.0/TodoApi/StartupJquery.cs?highlight=8-9&name=snippet_configure)]

Create a *wwwroot* folder in the project directory.

Add an HTML file named *index.html* to the *wwwroot* directory. Replace its contents with the following markup:

[!code-html[](first-web-api/samples/2.2/TodoApi/wwwroot/index.html)]

Add a JavaScript file named *site.js* to the *wwwroot* directory. Replace its contents with the following code:

[!code-javascript[](first-web-api/samples/2.2/TodoApi/wwwroot/site.js?name=snippet_SiteJs)]

A change to the ASP.NET Core project's launch settings may be required to test the HTML page locally:

* Open *Properties\launchSettings.json*.
* Remove the `launchUrl` property to force the app to open at *index.html*&mdash;the project's default file.

There are several ways to get jQuery. In the preceding snippet, the library is loaded from a CDN.

This sample calls all of the CRUD methods of the API. Following are explanations of the calls to the API.

### Get a list of to-do items

The jQuery [ajax](https://api.jquery.com/jquery.ajax/) function sends a `GET` request to the API, which returns JSON representing an array of to-do items. The `success` callback function is invoked if the request succeeds. In the callback, the DOM is updated with the to-do information.

[!code-javascript[](first-web-api/samples/2.2/TodoApi/wwwroot/site.js?name=snippet_GetData)]

### Add a to-do item

The [ajax](https://api.jquery.com/jquery.ajax/) function sends a `POST` request with the to-do item in the request body. The `accepts` and `contentType` options are set to `application/json` to specify the media type being received and sent. The to-do item is converted to JSON by using [JSON.stringify](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/JSON/stringify). When the API returns a successful status code, the `getData` function is invoked to update the HTML table.

[!code-javascript[](first-web-api/samples/2.2/TodoApi/wwwroot/site.js?name=snippet_AddItem)]

### Update a to-do item

Updating a to-do item is similar to adding one. The `url` changes to add the unique identifier of the item, and the `type` is `PUT`.

[!code-javascript[](first-web-api/samples/2.2/TodoApi/wwwroot/site.js?name=snippet_AjaxPut)]

### Delete a to-do item

Deleting a to-do item is accomplished by setting the `type` on the AJAX call to `DELETE` and specifying the item's unique identifier in the URL.

[!code-javascript[](first-web-api/samples/2.2/TodoApi/wwwroot/site.js?name=snippet_AjaxDelete)]

Advance to the next tutorial to learn how to generate API help pages:

> [!div class="nextstepaction"]
> <xref:tutorials/get-started-with-swashbuckle>