## Routing with special characters

Routing with special characters can lead to unexpected results. For example, consider a controller with the following action method:

```csharp
[HttpGet("{id?}/name")]
public async Task<ActionResult<string>> GetName(string id)
{
    var todoItem = await _context.TodoItems.FindAsync(id);

    if (todoItem == null || todoItem.Name == null)
    {
        return NotFound();
    }

    return todoItem.Name;
}
```

When `string id` contains the following encoded values, unexpected results might occur:

| ASCII  | Encoded |
| ----| ---------- |
| `/` | `%2F`  |
| ` ` | `+`  |

Route parameters are not always URL decoded. This problem may be addressed in the future. For more information, see [this GitHub issue](https://github.com/dotnet/aspnetcore/issues/11544);
