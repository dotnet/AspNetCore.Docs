### Added `InternalServerError` and `InternalServerError<TValue>` to `TypedResults`

The <xref:Microsoft.AspNetCore.Http.TypedResults> class is a helpful vehicle for returning strongly-typed HTTP status code-based responses from a minimal API.  `TypedResults` now includes factory methods and types for returning "500 Internal Server Error" responses from endpoints. Here's an example that returns a 500 response:

```csharp
var app = WebApplication.Create();

app.MapGet("/", () => TypedResults.InternalServerError("Something went wrong!"));

app.Run();
```
