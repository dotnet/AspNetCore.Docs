---
title: Call a web API
author: guardrex
description: Learn how to call a web API from a Blazor app using JSON helpers, including making cross-origin resource sharing (CORS) requests.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/20/2019
uid: blazor/call-web-api
---
# Call a web API

By [Luke Latham](https://github.com/guardrex)

Blazor apps call web API services using [HttpClient](xref:fundamentals/http-requests). Compose requests using Blazor JSON helpers or with <xref:System.Net.Http.HttpRequestMessage>, which can include JavaScript [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API) request options.

[View or download sample code](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/blazor/common/samples/) ([how to download](xref:index#how-to-download-a-sample))

See the following components in the sample app:

* Call Web API (*Pages/CallWebAPI.razor*)
* HTTP Request Tester (*Components/HTTPRequestTester.razor*)

## HttpClient and JSON helpers

Use [HttpClient](xref:fundamentals/http-requests) and JSON helpers to call a web API service endpoint in a Razor component. Blazor client-side uses the [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API), while Blazor server-side uses <xref:System.Net.Http.HttpClient?displayProperty=fullName>.

Include an `@using` statement for <xref:System.Threading.Tasks> for asynchronous web API calls and inject an `HttpClient` instance:

```cshtml
@using System.Threading.Tasks
@inject HttpClient Http
```

In the following examples, a Todo web API service processes create, read, update, and delete (CRUD) operations. The examples are based on a `TodoItem` class that stores the:

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

* `GetJsonAsync` &ndash; Sends a GET request and parses the JSON response body to create an object.

  In the following code, the `_todoItems` are displayed by the component. The `GetTodoItems` method is triggered when the component is finished rendering ([OnInitAsync](xref:blazor/components#lifecycle-methods)). See the sample app for a complete example.

  ```cshtml
  @using Microsoft.AspNetCore.Blazor.Http
  @inject HttpClient Http

  @functions {
      private const string ServiceEndpoint = "https://localhost:10000/api/todo";
      private TodoItem[] _todoItems;

      protected override async Task OnInitAsync() => 
          await GetTodoItems();

      private async Task GetTodoItems() => 
          _todoItems = await Http.GetJsonAsync<TodoItem[]>(ServiceEndpoint);
  }
  ```

* `PostJsonAsync` &ndash; Sends a POST request, including JSON-encoded content, and parses the JSON response body to create an object.

  In the following code, `_newItemName` is provided by a bound element of the component. The `AddItem` method is triggered by selecting a `<button>` element. See the sample app for a complete example.

  ```cshtml
  @using Microsoft.AspNetCore.Blazor.Http
  @inject HttpClient Http

  <input type="text" bind="@_newItemName" placeholder="New Todo Item" />
  <button onclick="@(async () => await AddItem())">Add</button>

  @functions {
      private const string ServiceEndpoint = "https://localhost:10000/api/todo";
      private string _newItemName;

      private async Task AddItem()
      {
          var addItem = new TodoItem { Name = _newItemName, IsComplete = false };
          await Http.PostJsonAsync(ServiceEndpoint, addItem);
      }
  }
  ```

* `PutJsonAsync` &ndash; Sends a PUT request, including JSON-encoded content.

  In the following code, `_editItem` values (`Id`, `Name`, `IsCompleted`) are provided by bound elements of the component. The `SaveItem` method is triggered by selecting the Save `<button>` element. See the sample app for a complete example.

  ```cshtml
  @using Microsoft.AspNetCore.Blazor.Http
  @inject HttpClient Http

  <input type="text" bind="@_editItem.Id" />
  <input type="checkbox" bind="@_editItem.IsComplete" />
  <input type="text" bind="@_editItem.Name" />
  <button onclick="@(async () => await SaveItem())">Save</button>

  @functions {
      private const string ServiceEndpoint = "https://localhost:10000/api/todo";
      private TodoItem _editItem = new TodoItem();

      private async Task SaveItem()
      {
          await Http.PutJsonAsync(
              Path.Combine(ServiceEndpoint, _editItem.Id.ToString()), _editItem);
      }
  }
  ```

<xref:System.Net.Http> includes additional extension methods for sending HTTP requests and receiving HTTP responses. [HttpClient.DeleteAsync](xref:System.Net.Http.HttpClient.DeleteAsync*) is used to send a DELETE request to a web API.

In the following code, the Delete `<button>` element supplies the `id` when it's selected in the UI. See the sample app for a complete example.

```cshtml
@using Microsoft.AspNetCore.Blazor.Http
@inject HttpClient Http

<input type="text" bind="@_id" />
<button onclick="@(async () => await DeleteItem())">Delete</button>

@functions {
    private const string ServiceEndpoint = "https://localhost:10000/api/todo";
    private long _id;

    private async Task DeleteItem()
    {
        await Http.DeleteAsync(Path.Combine(ServiceEndpoint, _id.ToString()));
    }
}
```

## HttpClient and HttpRequestMessage with Fetch API request options

Use [HttpClient](xref:fundamentals/http-requests) and <xref:System.Net.Http.HttpRequestMessage> to supply request options to the underlying JavaScript [Fetch API](https://developer.mozilla.org/docs/Web/API/Fetch_API).

In the following example:

* JSON serialization and deserialization must be handled by user code (*not shown*).
* The `credentials` property is set to any of the following values:

  * `FetchCredentialsOption.Include` ("include") &ndash; Advises the browser to send credentials (such as cookies or HTTP auth headers) even for cross-origin requests. Only allowed when the CORS Middleware policy in the web API is configured to <xref:Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder.AllowCredentials*>.
  * `FetchCredentialsOption.Omit` ("omit") &ndash; Advises the browser never to send credentials (such as cookies or HTTP auth headers).
  * `FetchCredentialsOption.SameOrigin` ("same-origin") &ndash; Advises the browser to send credentials (such as cookies or HTTP auth headers) only if the target URL is on the same origin as the calling application.

```cshtml
@using System.Net.Http.Headers
@using Microsoft.AspNetCore.Blazor.Http
@inject HttpClient Http

@functions {
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

For more information on Fetch API options, see [MDN web docs: Window​OrWorker​Global​Scope​.fetch():Parameters](https://developer.mozilla.org/docs/Web/API/WindowOrWorkerGlobalScope/fetch#Parameters).

When sending credentials (authorization cookies/headers) on CORS requests, allow the `Authorization` header when creating the CORS policy for CORS middleware. The following policy includes configuration for:

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

## Cross-origin resource sharing (CORS)

For more information on making cross-origin resource sharing (CORS) requests, see <xref:security/cors>. The sample app demonstrates CORS. See the Call Web API component (*Pages/CallWebAPI.razor*).

## HTTP Request Tester

The sample app includes an HTTP Request Tester component (*Components/HTTPRequestTester.razor*). The component is included in the Call Web API component:

```cshtml
<HTTPRequestTester />
```

Use the component to test request-responses against web API service endpoints.

## Additional resources

* <xref:fundamentals/http-requests>
* [Cross Origin Resource Sharing (CORS) at W3C](https://www.w3.org/TR/cors/)
