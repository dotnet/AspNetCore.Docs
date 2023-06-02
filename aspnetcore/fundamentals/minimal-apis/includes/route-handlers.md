Route handlers are methods that execute when the route matches. Route handlers can be a lambda expression, a local function, an instance method or a static method. Route handlers can be synchronous or asynchronous. 

### Lambda expression

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_le)]

### Local function

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_lf)]

### Instance method

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_im)]

### Static method

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_sm)]

### Endpoint defined outside of `Program.cs`

Minimal APIs don't have to be located in `Program.cs`.

`Program.cs`

[!code-csharp[](~/fundamentals/minimal-apis/8.0-samples/MinAPISeparateFile/Program.cs)]

`TodoEndpoints.cs`

[!code-csharp[](~/fundamentals/minimal-apis/8.0-samples/MinAPISeparateFile/TodoEndpoints.cs)]

See also [Route groups](#route-groups) later in this article.

### Named endpoints and link generation

Endpoints can be given names in order to generate URLs to the endpoint. Using a named endpoint avoids having to hard code paths in an app:

[!code-csharp[](~/fundamentals/minimal-apis/samples/WebMinAPIs/Program.cs?name=snippet_nr)]

The preceding code displays `The link to the hello endpoint is /hello` from the `/` endpoint.

**NOTE**: Endpoint names are case sensitive.

Endpoint names:

* Must be globally unique.
* Are used as the OpenAPI operation id when OpenAPI support is enabled. For more information, see [OpenAPI](xref:fundamentals/minimal-apis/openapi).

### Route Parameters

Route parameters can be captured as part of the route pattern definition:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_rp)]

The preceding code returns `The user id is 3 and book id is 7` from the URI `/users/3/books/7`.

The route handler can declare the parameters to capture. When a request is made a route with parameters declared to capture, the parameters are parsed and passed to the handler. This makes it easy to capture the values in a type safe way. In the preceding code, `userId` and `bookId` are both `int`.

In the preceding code, if either route value cannot be converted to an `int`, an exception is thrown. The GET request `/users/hello/books/3` throws the following exception:

**`BadHttpRequestException: Failed to bind parameter "int userId" from "hello".`**

### Wildcard and catch all routes

The following catch all route returns `Routing to hello` from the `/posts/hello' endpoint:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_wild)]

### Route constraints

Route constraints constrain the matching behavior of a route.

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/todos/{id:int}", (int id) => db.Todos.Find(id));
app.MapGet("/todos/{text}", (string text) => db.Todos.Where(t => t.Text.Contains(text));
app.MapGet("/posts/{slug:regex(^[a-z0-9_-]+$)}", (string slug) => $"Post {slug}");

app.Run();
```

The following table demonstrates the preceding route templates and their behavior:

| Route Template | Example Matching URI |
|--|--|
| `/todos/{id:int}` | `/todos/1` |
| `/todos/{text}` | `/todos/something` |
| `/posts/{slug:regex(^[a-z0-9_-]+$)}` | `/posts/mypost` |

For more information, see [Route constraint reference](xref:fundamentals/routing) in <xref:fundamentals/routing>.

### Route groups

[!INCLUDE[](~/includes/route-groups.md)]
