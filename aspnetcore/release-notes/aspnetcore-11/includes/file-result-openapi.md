### File stream result types appear in OpenAPI documents

`FileStreamResult`, `FileContentHttpResult`, and `FileStreamHttpResult` are now described as binary string schemas in generated OpenAPI documents, so clients see accurate response shapes for endpoints that stream files. Annotate the endpoint with `.Produces<FileContentHttpResult>(contentType: "application/pdf")` (or the equivalent `FileStreamHttpResult`/`FileStreamResult` type) so OpenAPI sees the result type and emits the binary schema.

Thank you [@marcominerva](https://github.com/marcominerva) for this contribution!
