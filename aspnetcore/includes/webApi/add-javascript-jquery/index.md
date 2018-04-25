## Call the Web API with jQuery

In this section, an HTML page is added that uses jQuery to call the Web API. jQuery initiates the request and updates the page with the details from the API's response.

Configure the project to serve static files and to enable default file mapping. This is accomplished by invoking the [UseStaticFiles](/dotnet/api/microsoft.aspnetcore.builder.staticfileextensions.usestaticfiles#Microsoft_AspNetCore_Builder_StaticFileExtensions_UseStaticFiles_Microsoft_AspNetCore_Builder_IApplicationBuilder_) and [UseDefaultFiles](/dotnet/api/microsoft.aspnetcore.builder.defaultfilesextensions.usedefaultfiles#Microsoft_AspNetCore_Builder_DefaultFilesExtensions_UseDefaultFiles_Microsoft_AspNetCore_Builder_IApplicationBuilder_) extension methods in *Startup.Configure*. For more information, see [Work with static files in ASP.NET Core](xref:fundamentals/static-files).

```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    app.UseDefaultFiles();
    app.UseStaticFiles();

    app.UseMvc();
}
```

Add an HTML page to the project by following these steps:

* Right-click the *wwwroot* directory, and select **Add** > **New Item** > **HTML Page**.
* Name the file *index.html*, and include the following markup in the file:

[!code-html[Main](samples/sample3.html)]

A change to the ASP.NET Core project's launch settings may be required to test the HTML page locally. Open *launchSettings.json* in the *Properties* directory of the project. Remove the `launchUrl` property to force the app to open at *index.html*&mdash;the project's default file.

There are several ways to get jQuery. In the preceding snippet, the library is loaded from a CDN. This sample is a complete CRUD example of calling the API with jQuery. There are additional features in this sample to make the experience richer. Below are explanations around the calls to the API.

### Get a list of to-do items

To get a list of to-do items, send an HTTP GET request to */api/todo*.

The jQuery [ajax](https://api.jquery.com/jquery.ajax/) function sends an AJAX request to the API, which returns JSON representing an object or array. This function can handle all forms of HTTP interaction, sending an HTTP request to the specified `url`. `GET` is used as the `type`. The `success` callback function is invoked if the request succeeds. In the callback, the DOM is updated with the to-do information.

[!code-javascript[Main](samples/sample4.html)]

### Add a to-do item

To add a to-do item, send an HTTP POST request to */api/todo/*. The request body should contain a to-do object. The [ajax](https://api.jquery.com/jquery.ajax/) function is using `POST` to call the API. For `POST` and `PUT` requests, the request body represents the data sent to the API. The API is expecting a JSON request body. The `accepts` and `contentType` options are set to `application/json` to classify the media type being received and sent, respectively. The data is converted to a JSON object using [`JSON.stringify`](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/JSON/stringify). When the API returns a successful status code, the `getData` function is invoked to update the HTML table.

[!code-javascript[Main](samples/sample5.js)]

### Update a to-do item

Updating a to-do item is very similar to adding one, since both rely on a request body. The only real difference between the two in this case is that the `url` changes to add the unique identifier of the item, and the `type` is `PUT`.

[!code-javascript[Main](samples/sample6.js)]

### Delete a to-do item

Deleting a to-do item is accomplished by setting the `type` on the ajax call to `DELETE` and specifing the item's unique identifier in the url.

[!code-javascript[Main](samples/sample6.js)]
