### Describe binary file responses

ASP.NET Core 11 Preview 1 introduces support for generating OpenAPI descriptions for operations that return binary file responses. This support maps the `FileContentResult` result type to an OpenAPI schema with `type: string` and `format: binary`.

#### [Minimal APIs](#tab/minimal-apis)

Use the `Produces<T>` extension method with `T` of `FileContentResult` to specify the response type and content type:
<!-- UPDATE 11.0 - API cross-link needs to be entered in the line above for the new API
such as: <xref:Microsoft.AspNetCore.NEW_API_TO_BE_ENTERED_>
-->

```csharp
app.MapPost("/filecontentresult", () =>
{
    var content = "This endpoint returns a FileContentResult!"u8.ToArray();
    return TypedResults.File(content);
})
.Produces<FileContentResult>(contentType: MediaTypeNames.Application.Octet);
```

#### [Controllers](#tab/controllers)

Use the `ProducesResponseType<T>` attribute with `T` of `FileContentResult` to specify the response type and content type:

```csharp
[HttpPost("filecontentresult")]
[ProducesResponseType<FileContentResult>(StatusCodes.Status200OK, MediaTypeNames.Application.Octet)]
public IActionResult PostFileContentResult()
{
    var content = "This endpoint returns a FileContentResult!"u8.ToArray();
    return new FileContentResult(content, MediaTypeNames.Application.Octet);
}
```

---

The generated OpenAPI document describes the endpoint response as:

```yaml
responses:
  '200':
    description: OK
    content:
      application/octet-stream:
        schema:
          $ref: '#/components/schemas/FileContentResult'
```

With `FileContentResult` defined in `components/schemas` as:

```yaml
components:
  schemas:
    FileContentResult:
      type: string
      format: binary
```
