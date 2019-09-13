---
title: Call a web API from ASP.NET Core Blazor
author: guardrex
description: Learn how to call a web API from a Blazor app using JSON helpers, including making cross-origin resource sharing (CORS) requests.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 08/13/2019
uid: blazor/call-web-api
---
# Call a web API from ASP.NET Core Blazor

By [Luke Latham](https://github.com/guardrex) and [Daniel Roth](https://github.com/danroth27)

Blazor WebAssembly apps call web APIs using a preconfigured `HttpClient` service. Compose requests, which can include JavaScript [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API) options, using Blazor JSON helpers or with <xref:System.Net.Http.HttpRequestMessage>.

Blazor Server apps call web APIs using <xref:System.Net.Http.HttpClient> instances typically created using <xref:System.Net.Http.IHttpClientFactory>. For more information, see <xref:fundamentals/http-requests>.

[View or download sample code](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/blazor/common/samples/) ([how to download](xref:index#how-to-download-a-sample))

For Blazor WebAssembly examples, see the following components in the sample app:

* Call Web API (*Pages/CallWebAPI.razor*)
* HTTP Request Tester (*Components/HTTPRequestTester.razor*)

## HttpClient and JSON helpers

In Blazor WebAssembly apps, [HttpClient](xref:fundamentals/http-requests) is available as a preconfigured service for making requests back to the origin server. To use `HttpClient` JSON helpers, add a package reference to `Microsoft.AspNetCore.Blazor.HttpClient`. `HttpClient` and JSON helpers are also used to call third-party web API endpoints. `HttpClient` is implemented using the browser [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API) and is subject to its limitations, including enforcement of the same origin policy.

The client's base address is set to the originating server's address. Inject an `HttpClient` instance using the `@inject` directive:

```cshtml
@using System.Net.Http
@inject HttpClient Http
```

In the following examples, a Todo web API processes create, read, update, and delete (CRUD) operations. The examples are based on a `TodoItem` class that stores the:

* ID (`Id`, `long`) &ndash; Unique ID of the item.
* Name (`Name`, `string`) &ndash; Name of the item.
* Status (`IsComplete`, `bool`) &ndash; Indication if the Todo item is finished.

```csharp
private class TodoItem
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool IsComplete { get; set; }
}
```

JSON helper methods send requests to a URI (a web API in the following examples) and process the response:

* `GetJsonAsync` &ndash; Sends an HTTP GET request and parses the JSON response body to create an object.

  In the following code, the `_todoItems` are displayed by the component. The `GetTodoItems` method is triggered when the component is finished rendering ([OnInitializedAsync](xref:blazor/components#lifecycle-methods)). See the sample app for a complete example.

  ```cshtml
  @using System.Net.Http
  @inject HttpClient Http

  @code {
      private TodoItem[] _todoItems;

      protected override async Task OnInitializedAsync() => 
          _todoItems = await Http.GetJsonAsync<TodoItem[]>("api/todo");
  }
  ```

* `PostJsonAsync` &ndash; Sends an HTTP POST request, including JSON-encoded content, and parses the JSON response body to create an object.

  In the following code, `_newItemName` is provided by a bound element of the component. The `AddItem` method is triggered by selecting a `<button>` element. See the sample app for a complete example.

  ```cshtml
  @using System.Net.Http
  @inject HttpClient Http

  <input @bind="_newItemName" placeholder="New Todo Item" />
  <button @onclick="@AddItem">Add</button>

  @code {
      private string _newItemName;

      private async Task AddItem()
      {
          var addItem = new TodoItem { Name = _newItemName, IsComplete = false };
          await Http.PostJsonAsync("api/todo", addItem);
      }
  }
  ```

* `PutJsonAsync` &ndash; Sends an HTTP PUT request, including JSON-encoded content.

  In the following code, `_editItem` values for `Name` and `IsCompleted` are provided by bound elements of the component. The item's `Id` is set when the item is selected in another part of the UI and `EditItem` is called. The `SaveItem` method is triggered by selecting the Save `<button>` element. See the sample app for a complete example.

  ```cshtml
  @using System.Net.Http
  @inject HttpClient Http

  <input type="checkbox" @bind="_editItem.IsComplete" />
  <input @bind="_editItem.Name" />
  <button @onclick="@SaveItem">Save</button>

  @code {
      private TodoItem _editItem = new TodoItem();

      private void EditItem(long id)
      {
          var editItem = _todoItems.Single(i => i.Id == id);
          _editItem = new TodoItem { Id = editItem.Id, Name = editItem.Name, 
              IsComplete = editItem.IsComplete };
      }

      private async Task SaveItem() =>
          await Http.PutJsonAsync($"api/todo/{_editItem.Id}, _editItem);
  }
  ```

<xref:System.Net.Http> includes additional extension methods for sending HTTP requests and receiving HTTP responses. [HttpClient.DeleteAsync](xref:System.Net.Http.HttpClient.DeleteAsync*) is used to send an HTTP DELETE request to a web API.

In the following code, the Delete `<button>` element calls the `DeleteItem` method. The bound `<input>` element supplies the `id` of the item to delete. See the sample app for a complete example.

```cshtml
@using System.Net.Http
@inject HttpClient Http

<input @bind="_id" />
<button @onclick="@DeleteItem">Delete</button>

@code {
    private long _id;

    private async Task DeleteItem() =>
        await Http.DeleteAsync($"api/todo/{_id}");
}
```

## Cross-origin resource sharing (CORS)

Browser security prevents a webpage from making requests to a different domain than the one that served the webpage. This restriction is called the *same-origin policy*. The same-origin policy prevents a malicious site from reading sensitive data from another site. To make requests from the browser to an endpoint with a different origin, the *endpoint* must enable [cross-origin resource sharing (CORS)](https://www.w3.org/TR/cors/).

The sample app demonstrates the use of CORS in the Call Web API component (*Pages/CallWebAPI.razor*).

To allow other sites to make cross-origin resource sharing (CORS) requests to your app, see <xref:security/cors>.

## HttpClient and HttpRequestMessage with Fetch API request options

When running on WebAssembly in a Blazor WebAssembly app, use [HttpClient](xref:fundamentals/http-requests) and <xref:System.Net.Http.HttpRequestMessage> to customize requests. For example, you can specify the request URI, HTTP method, and any desired request headers.

Supply request options to the underlying JavaScript [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API) using the `WebAssemblyHttpMessageHandler.FetchArgs` property on the request. As shown in the following example, the `credentials` property is set to any of the following values:

* `FetchCredentialsOption.Include` ("include") &ndash; Advises the browser to send credentials (such as cookies or HTTP authentication headers) even for cross-origin requests. Only allowed when the CORS policy is configured to allow credentials.
* `FetchCredentialsOption.Omit` ("omit") &ndash; Advises the browser never to send credentials (such as cookies or HTTP auth headers).
* `FetchCredentialsOption.SameOrigin` ("same-origin") &ndash; Advises the browser to send credentials (such as cookies or HTTP auth headers) only if the target URL is on the same origin as the calling application.

```cshtml
@using System.Net.Http
@using System.Net.Http.Headers
@inject HttpClient Http

@code {
    private async Task PostRequest()
    {
        Http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", "{OAUTH TOKEN}");

        var requestMessage = new HttpRequestMessage()
        {
            Method = new HttpMethod("POST"),
            RequestUri = new Uri("https://localhost:10000/api/todo"),
            Content = 
                new StringContent(
                    @"{""name"":""A New Todo Item"",""isComplete"":false}")
        };

        requestMessage.Content.Headers.ContentType = 
            new System.Net.Http.Headers.MediaTypeHeaderValue(
                "application/json");

        requestMessage.Content.Headers.TryAddWithoutValidation(
            "x-custom-header", "value");
        
        requestMessage.Properties[WebAssemblyHttpMessageHandler.FetchArgs] = new
        { 
            credentials = FetchCredentialsOption.Include
        };

        var response = await Http.SendAsync(requestMessage);
        var responseStatusCode = response.StatusCode;
        var responseBody = await response.Content.ReadAsStringAsync();
    }
}
```

For more information on Fetch API options, see [MDN web docs: WindowOrWorkerGlobalScope.fetch():Parameters](https://developer.mozilla.org/docs/Web/API/WindowOrWorkerGlobalScope/fetch#Parameters).

When sending credentials (authorization cookies/headers) on CORS requests, the `Authorization` header must be allowed by the CORS policy.

The following policy includes configuration for:

* Request origins (`http://localhost:5000`, `https://localhost:5001`).
* Any method (verb).
* `Content-Type` and `Authorization` headers. To allow a custom header (for example, `x-custom-header`), list the header when calling <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.WithHeaders*>.
* Credentials set by client-side JavaScript code (`credentials` property set to `include`).

```csharp
app.UseCors(policy => 
    policy.WithOrigins("http://localhost:5000", "https://localhost:5001")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization, "x-custom-header")
    .AllowCredentials());
```

For more information, see <xref:security/cors> and the sample app's HTTP Request Tester component (*Components/HTTPRequestTester.razor*).

## Additional resources

* <xref:fundamentals/http-requests>
* [Cross Origin Resource Sharing (CORS) at W3C](https://www.w3.org/TR/cors/)
