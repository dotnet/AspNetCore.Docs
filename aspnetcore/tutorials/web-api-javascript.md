---
title: "Tutorial: Call an ASP.NET Core web API with JavaScript"
author: rick-anderson
description: Learn how to call an ASP.NET Core web API with JavaScript.
ms.author: riande
ms.custom: mvc
ms.date: 08/26/2019
uid: tutorials/web-api-javascript
---
# Tutorial: Call an ASP.NET Core web API with JavaScript

By [Rick Anderson](https://twitter.com/RickAndMSFT)

This tutorial shows how to call an ASP.NET Core web API with JavaScript, using the [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API).

::: moniker range="< aspnetcore-3.0"

For ASP.NET Core 2.2, see the 2.2 version of [Call the Web API with JavaScript](xref:tutorials/first-web-api#call-the-api-with-javascript).

::: moniker-end

::: moniker range=">= aspnetcore-3.0"

## Prerequisites

* Complete [Tutorial: Create a web API](xref:tutorials/first-web-api)
* Familiarity with CSS, HTML, and JavaScript

## Call the web API with JavaScript

In this section, an HTML page is added that uses Fetch to call the web API. The `fetch` function initiates the HTTP request. JavaScript updates the page with the details from the web API's response.

1. Configure the app to [serve static files](/dotnet/api/microsoft.aspnetcore.builder.staticfileextensions.usestaticfiles#Microsoft_AspNetCore_Builder_StaticFileExtensions_UseStaticFiles_Microsoft_AspNetCore_Builder_IApplicationBuilder_) and [enable default file mapping](/dotnet/api/microsoft.aspnetcore.builder.defaultfilesextensions.usedefaultfiles#Microsoft_AspNetCore_Builder_DefaultFilesExtensions_UseDefaultFiles_Microsoft_AspNetCore_Builder_IApplicationBuilder_) by updating *Startup.cs* with the following highlighted code:

    [!code-csharp[](first-web-api/samples/3.0/TodoApi/StartupJquery.cs?highlight=8-9&name=snippet_configure)]

1. Create a *wwwroot* directory in the project root.

1. Add an HTML file named *index.html* to the *wwwroot* directory. Replace its contents with the following markup:

    [!code-html[](first-web-api/samples/3.0/TodoApi/wwwroot/index.html)]

1. Add a JavaScript file named *site.js* to the *wwwroot* directory. Replace its contents with the following code:

    [!code-javascript[](first-web-api/samples/3.0/TodoApi/wwwroot/js/site.js?name=snippet_SiteJs)]

A change to the ASP.NET Core project's launch settings may be required to test the HTML page locally:

1. Open *Properties\launchSettings.json*.
1. Remove the `launchUrl` property to force the app to open at *index.html*&mdash;the project's default file.

This sample calls all of the CRUD methods of the web API. Following are explanations of the web API requests.

### Get a list of to-do items

Fetch sends an HTTP GET request to the web API, which returns JSON representing an array of to-do items. The `success` callback function is invoked if the request succeeds. In the callback, the DOM is updated with the to-do information.

[!code-javascript[](first-web-api/samples/3.0/TodoApi/wwwroot/js/site.js?name=snippet_GetItems)]

### Add a to-do item

In the following code:

* An `item` variable is declared to construct an object literal representation of the to-do item.
* A Fetch request is configured with the following options:
    * `method`&mdash;specifies the POST HTTP action verb.
    * `body`&mdash;specifies the JSON representation of the request body. The JSON is produced by passing the object literal stored in `item` to the [JSON.stringify](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/JSON/stringify) function.
    * `headers`&mdash;specifies the `Accept` and `Content-Type` HTTP request headers. Both headers are set to `application/json` to specify the media type being received and sent, respectively.
* An HTTP POST request is sent to the *api/TodoItems* route.

[!code-javascript[](first-web-api/samples/3.0/TodoApi/wwwroot/js/site.js?name=snippet_AddItem)]

The `fetch` function returns a `Promise`. When the web API returns a successful status code, the `getItems` function is invoked to update the HTML table. If the web API request fails, an error is logged to the browser's console.

### Update a to-do item

Updating a to-do item is similar to adding one. The `url` changes to add the unique identifier of the item, and the `type` is `PUT`.

[!code-javascript[](first-web-api/samples/3.0/TodoApi/wwwroot/js/site.js?name=snippet_UpdateItem)]

### Delete a to-do item

To delete a to-do item, set the request's `method` option to `DELETE` and specify the item's unique identifier in the URL.

[!code-javascript[](first-web-api/samples/3.0/TodoApi/wwwroot/js/site.js?name=snippet_DeleteItem)]

Advance to the next tutorial to learn how to generate web API help pages:

> [!div class="nextstepaction"]
> <xref:tutorials/get-started-with-swashbuckle>

::: moniker-end
