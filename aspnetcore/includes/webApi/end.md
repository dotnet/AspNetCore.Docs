## Implement the other CRUD operations

In the following sections, `Create`, `Update`, and `Delete` methods are added to the controller.

### Create

Add the following `Create` method:

::: moniker range="<= aspnetcore-2.0"
[!code-csharp[](../../tutorials/first-web-api/samples/2.0/TodoApi/Controllers/TodoController.cs?name=snippet_Create)]

The preceding code is an HTTP POST method, as indicated by the [[HttpPost]](/dotnet/api/microsoft.aspnetcore.mvc.httppostattribute) attribute. The [[FromBody]](/dotnet/api/microsoft.aspnetcore.mvc.frombodyattribute) attribute tells MVC to get the value of the to-do item from the body of the HTTP request.
::: moniker-end
::: moniker range=">= aspnetcore-2.1"
[!code-csharp[](../../tutorials/first-web-api/samples/2.1/TodoApi/Controllers/TodoController.cs?name=snippet_Create)]

The preceding code is an HTTP POST method, as indicated by the [[HttpPost]](/dotnet/api/microsoft.aspnetcore.mvc.httppostattribute) attribute. MVC gets the value of the to-do item from the body of the HTTP request.
::: moniker-end

The `CreatedAtRoute` method:

* Returns a 201 response. HTTP 201 is the standard response for an HTTP POST method that creates a new resource on the server.
* Adds a Location header to the response. The Location header specifies the URI of the newly created to-do item. See [10.2.2 201 Created](https://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html).
* Uses the "GetTodo" named route to create the URL. The "GetTodo" named route is defined in `GetById`:

::: moniker range="<= aspnetcore-2.0"
[!code-csharp[](../../tutorials/first-web-api/samples/2.0/TodoApi/Controllers/TodoController.cs?name=snippet_GetByID&highlight=1-2)]
::: moniker-end
::: moniker range=">= aspnetcore-2.1"
[!code-csharp[](../../tutorials/first-web-api/samples/2.1/TodoApi/Controllers/TodoController.cs?name=snippet_GetByID&highlight=1-2)]
::: moniker-end

### Use Postman to send a Create request

* Start the app.
* Open Postman.

![Postman console](../../tutorials/first-web-api/_static/pmc.png)

* Update the port number in the localhost URL.
* Set the HTTP method to *POST*.
* Click the **Body** tab.
* Select the **raw** radio button.
* Set the type to *JSON (application/json)*.
* Enter a request body with a to-do item resembling the following JSON:

```json
{
  "name":"walk dog",
  "isComplete":true
}
```

* Click the **Send** button.

::: moniker range=">= aspnetcore-2.1"
> [!TIP]
> If no response displays after clicking **Send**, disable the **SSL certification verification** option. This is found under **File** > **Settings**. Click the **Send** button again after disabling the setting.
::: moniker-end

Click the **Headers** tab in the **Response** pane and copy the **Location** header value:

![Headers tab of the Postman console](../../tutorials/first-web-api/_static/pmc2.png)

The Location header URI can be used to access the new item.

### Update

Add the following `Update` method:

::: moniker range="<= aspnetcore-2.0"
[!code-csharp[](../../tutorials/first-web-api/samples/2.0/TodoApi/Controllers/TodoController.cs?name=snippet_Update)]
::: moniker-end
::: moniker range=">= aspnetcore-2.1"
[!code-csharp[](../../tutorials/first-web-api/samples/2.1/TodoApi/Controllers/TodoController.cs?name=snippet_Update)]
::: moniker-end

`Update` is similar to `Create`, except it uses HTTP PUT. The response is [204 (No Content)](https://www.w3.org/Protocols/rfc2616/rfc2616-sec9.html). According to the HTTP specification, a PUT request requires the client to send the entire updated entity, not just the deltas. To support partial updates, use HTTP PATCH.

Use Postman to update the to-do item's name to "walk cat":

![Postman console showing 204 (No Content) response](../../tutorials/first-web-api/_static/pmcput.png)

### Delete

Add the following `Delete` method:

[!code-csharp[](../../tutorials/first-web-api/samples/2.0/TodoApi/Controllers/TodoController.cs?name=snippet_Delete)]

The `Delete` response is [204 (No Content)](https://www.w3.org/Protocols/rfc2616/rfc2616-sec9.html).

Use Postman to delete the to-do item:

![Postman console showing 204 (No Content) response](../../tutorials/first-web-api/_static/pmd.png)
