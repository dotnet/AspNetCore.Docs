### HTTP QUERY in generated OpenAPI documents

OpenAPI document generation now recognizes [HTTP QUERY](https://datatracker.ietf.org/doc/draft-ietf-httpbis-safe-method-w-body/) as a known operation type. QUERY is a proposed safe, idempotent method that lets clients send a request body when describing a search, useful when a query is too large or too structured to fit in a URL. Routing already accepts arbitrary verb strings via `MapMethods`, and OpenAPI 3.2 adds a [`query` field to the Path Item Object](https://spec.openapis.org/oas/v3.2.0.html#fixed-fields-6) so this can be described in the OpenAPI document.

Note that `query` is only valid in an OpenAPI 3.2 document, so set the `OpenApiVersion` in the `OpenApiOptions`. In earlier OpenAPI versions, the `query` operation is generated within an `x-oai-additionalOperations` specification extension in the Path Item Object.

```csharp
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi(options =>
{
    options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_2;
});

var app = builder.Build();

app.MapOpenApi();

app.MapMethods("/search", ["QUERY"], (SearchRequest request) =>
    SearchService.Run(request));

app.Run();
```

In an OpenAPI 3.2 document, the QUERY operation is described inline as a sibling of `get`, `post`, and friends:

```json
"paths": {
  "/search": {
    "query": {
      "requestBody": { ... },
      "responses": { "200": { ... } }
    }
  }
}
```

In OpenAPI 3.0 and 3.1 documents, the same operation is represented under the `x-oai-additionalOperations` extension on the Path Item:

```json
"paths": {
  "/search": {
    "x-oai-additionalOperations": {
      "QUERY": {
        "requestBody": { ... },
        "responses": { "200": { ... } }
      }
    }
  }
}
```

Thank you [@kilifu](https://github.com/kilifu) for this contribution!
