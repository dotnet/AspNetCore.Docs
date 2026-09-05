### Server-Sent Events support in OpenAPI 3.2

Endpoints that return `SseItem<T>` are described in the generated OpenAPI document with the OpenAPI 3.2 `itemSchema` shape for `text/event-stream` responses. The `itemSchema` describes a stream's per-event payload shape instead of falling back to a plain `string` schema.

```csharp
app.MapGet("/todos/stream", (CancellationToken ct) =>
    TypedResults.ServerSentEvents(GetTodosAsync(ct)))
   .WithName("StreamTodos");

static async IAsyncEnumerable<SseItem<Todo>> GetTodosAsync(
    [EnumeratorCancellation] CancellationToken ct = default)
{
    foreach (var todo in Todos.All)
    {
        yield return new SseItem<Todo>(todo) { EventId = todo.Id.ToString() };
        await Task.Delay(1000, ct);
    }
}
```

Return the stream through `TypedResults.ServerSentEvents`. A handler that returns `IAsyncEnumerable<SseItem<T>>` directly is serialized as JSON instead of SSE. Use the dedicated `SseItem<T>` overload without `eventType`. To use one event name for the whole stream, pass a plain `IAsyncEnumerable<T>` with `eventType`.

The generated 3.2 document describes the event payload with `itemSchema` referencing `#/components/schemas/Todo`, plus the standard SSE `event` and `id` string fields:

```yaml
responses:
  '200':
    description: OK
    content:
      text/event-stream:
        itemSchema:
          type: object
          required: [data]
          properties:
            data:
              $ref: '#/components/schemas/Todo'
            event: { type: string }
            id: { type: string }
```

If the event payload is a discriminated union (a preview C# 14 feature), OpenAPI also emits the union's case names as an `enum` on the `event` field.
