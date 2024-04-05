### Added `InternalServerError` and `InternalServerError<TValue>` to `TypedResults`

`TypedResults` are a helpful vehicle for returning strongly-typed HTTP status code-based responses from a minimal API. The `TypedResults` class now includes factory methods and types for returning "500 Internal Server Error" responses from endpoints. For example:

```csharp
var app = WebApplication.Create();

app.MapGet("/", () => TypedResults.InternalServerError("Something went wrong!"));

app.Run();
```
