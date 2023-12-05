:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

This tutorial shows how to call an ASP.NET Core web API with JavaScript, using the [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API).

## Prerequisites

* Complete [Tutorial: Create a web API](xref:tutorials/first-web-api)
* Familiarity with CSS, HTML, and JavaScript

## Call the web API with JavaScript

In this section, you'll add an HTML page containing forms for creating and managing to-do items. Event handlers are attached to elements on the page. The event handlers result in HTTP requests to the web API's action methods. The Fetch API's `fetch` function initiates each HTTP request.

The `fetch` function returns a [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) object, which contains an HTTP response represented as a `Response` object. A common pattern is to extract the JSON response body by invoking the `json` function on the `Response` object. JavaScript updates the page with the details from the web API's response.

The simplest `fetch` call accepts a single parameter representing the route. A second parameter, known as the `init` object, is optional. `init` is used to configure the HTTP request.

1. Configure the app to [serve static files](xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles(Microsoft.AspNetCore.Builder.IApplicationBuilder)) and [enable default file mapping](xref:Microsoft.AspNetCore.Builder.DefaultFilesExtensions.UseDefaultFiles(Microsoft.AspNetCore.Builder.IApplicationBuilder)). The following highlighted code is needed in `Program.cs`:
:::code language="csharp" source="~/tutorials/first-web-api/samples/6.0/TodoApi/ProgramJavaScript.cs" id="snippet" highlight="17-18":::

1. Create a *wwwroot* folder in the project root.

1. Create a *css* folder inside of the *wwwroot* folder.

1. Create a *js* folder inside of the *wwwroot* folder.

1. Add an HTML file named `index.html` to the *wwwroot* folder. Replace the contents of `index.html` with the following markup:

    [!code-html[](~/tutorials/first-web-api/samples/6.0/TodoApi/wwwroot/index.html)]

1. Add a CSS file named `site.css` to the *wwwroot/css* folder. Replace the contents of `site.css` with the following styles:

    [!code-css[](~/tutorials/first-web-api/samples/6.0/TodoApi/wwwroot/css/site.css)]

1. Add a JavaScript file named `site.js` to the *wwwroot/js* folder. Replace the contents of `site.js` with the following code:

    [!code-javascript[](~/tutorials/first-web-api/samples/6.0/TodoApi/wwwroot/js/site.js?name=snippet_SiteJs)]

A change to the ASP.NET Core project's launch settings may be required to test the HTML page locally:

1. Open *Properties\launchSettings.json*.
1. Remove the `launchUrl` property to force the app to open at `index.html`&mdash;the project's default file.

This sample calls all of the CRUD methods of the web API. Following are explanations of the web API requests.

### Get a list of to-do items

In the following code, an HTTP GET request is sent to the *api/todoitems* route:

[!code-javascript[](~/tutorials/first-web-api/samples/6.0/TodoApi/wwwroot/js/site.js?name=snippet_GetItems)]

When the web API returns a successful status code, the `_displayItems` function is invoked. Each to-do item in the array parameter accepted by `_displayItems` is added to a table with **Edit** and **Delete** buttons. If the web API request fails, an error is logged to the browser's console.

### Add a to-do item

In the following code:

* An `item` variable is declared to construct an object literal representation of the to-do item.
* A Fetch request is configured with the following options:
  * `method`&mdash;specifies the POST HTTP action verb.
  * `body`&mdash;specifies the JSON representation of the request body. The JSON is produced by passing the object literal stored in `item` to the [JSON.stringify](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/JSON/stringify) function.
  * `headers`&mdash;specifies the `Accept` and `Content-Type` HTTP request headers. Both headers are set to `application/json` to specify the media type being received and sent, respectively.
* An HTTP POST request is sent to the *api/todoitems* route.

[!code-javascript[](~/tutorials/first-web-api/samples/6.0/TodoApi/wwwroot/js/site.js?name=snippet_AddItem)]

When the web API returns a successful status code, the `getItems` function is invoked to update the HTML table. If the web API request fails, an error is logged to the browser's console.

### Update a to-do item

Updating a to-do item is similar to adding one; however, there are two significant differences:

* The route is suffixed with the unique identifier of the item to update. For example, *api/todoitems/1*.
* The HTTP action verb is PUT, as indicated by the `method` option.

[!code-javascript[](~/tutorials/first-web-api/samples/6.0/TodoApi/wwwroot/js/site.js?name=snippet_UpdateItem)]

### Delete a to-do item

To delete a to-do item, set the request's `method` option to `DELETE` and specify the item's unique identifier in the URL.

[!code-javascript[](~/tutorials/first-web-api/samples/6.0/TodoApi/wwwroot/js/site.js?name=snippet_DeleteItem)]

Advance to the next tutorial to learn how to generate web API help pages:

> [!div class="nextstepaction"]
> <xref:tutorials/get-started-with-swashbuckle>

:::moniker-end
