Route handlers are methods that execute when the route matches. Route handlers can be a lambda expression, a local function, an instance method, or a static method. Route handlers can be synchronous or asynchronous.

The following sections provide examples of different route handlers.

### Lambda expression

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_le)]

### Local function

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_lf)]

### Instance method

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_im)]

### Static method

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_sm)]

### Endpoint defined outside of Program.cs

Minimal APIs don't have to be located in the _Program.cs_ file. For example, you can set up the structure in the _Program.cs_ file, and define the endpoint in a separate file:

**Program.cs**

[!code-csharp[](~/fundamentals/minimal-apis/8.0-samples/MinAPISeparateFile/Program.cs)]

**TodoEndpoints.cs**

[!code-csharp[](~/fundamentals/minimal-apis/8.0-samples/MinAPISeparateFile/TodoEndpoints.cs)]

For more information, see the [Route groups](#route-groups) section later in this article.

### Named endpoints and link generation

You can supply a name for your endpoints to generate URLs that target the endpoint. Using a named endpoint avoids having to hard code paths in an app:

[!code-csharp[](~/fundamentals/minimal-apis/samples/WebMinAPIs/Program.cs?name=snippet_nr)]

The preceding code displays the message _`The link to the hello route is /hello`_ from the `/` (forward slash) endpoint.

#### Criteria for endpoint names

Endpoint names must satisfy the following criteria:

* Endpoint names are case sensitive.
* Endpoint names must be globally unique.
* Endpoint names are used as the OpenAPI operation identifier (ID) when OpenAPI support is enabled. For more information, see [Generate OpenAPI documents](xref:fundamentals/openapi/aspnetcore-openapi).

### Route parameters

Route parameters can be captured as part of the route pattern definition:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_rp)]

The preceding code returns the message _The user id is 3 and book id is 7_ from the URI `/users/3/books/7`.

The route handler can declare the parameters to capture. When a request is made to a route with parameters declared to capture, the parameters are parsed and passed to the handler. This approach makes it easy to capture the values in a type-safe way. In the preceding code, the `userId` and `bookId` parameters are both type `int`.

In the preceding code, if either route value can't be converted to an `int`, an exception is thrown. The GET request `/users/hello/books/3` throws the following exception:

```output
BadHttpRequestException: Failed to bind parameter "int userId" from "hello".
```

### Wildcard and catch all routes

The following catch all route returns _Routing to hello_ from the `/posts/hello` endpoint:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_wild)]

### Route constraints

Route constraints restrict the matching behavior of a route.

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/todos/{id:int}", (int id) => db.Todos.Find(id));
app.MapGet("/todos/{text}", (string text) => db.Todos.Where(t => t.Text.Contains(text));
app.MapGet("/posts/{slug:regex(^[a-z0-9_-]+$)}", (string slug) => $"Post {slug}");

app.Run();
```

The following table demonstrates the preceding route templates and their behavior:

| Route template | Example matching URI |
|---|---|
| `/todos/{id:int}` | `/todos/1` |
| `/todos/{text}` | `/todos/something` |
| `/posts/{slug:regex(^[a-z0-9_-]+$)}` | `/posts/mypost` |

For more information, see [Route constraint reference](xref:fundamentals/routing#route-constraints) in <xref:fundamentals/routing>.

### Route groups

[!INCLUDE[](~/includes/route-groups.md)]
