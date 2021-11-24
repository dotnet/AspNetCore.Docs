using Microsoft.AspNetCore.Mvc;
using ResponseFormattingSample.Models;

namespace ResponseFormattingSample.Snippets.Controllers.FormatFilter;

[NonController]
// <snippet_ClassGet>
[ApiController]
[Route("api/[controller]")]
[FormatFilter]
public class TodosController : ControllerBase
{
    private readonly TodoItemStore _todoItemStore;

    public TodosController(TodoItemStore todoItemStore) =>
        _todoItemStore = todoItemStore;

    [HttpGet("{id:long}.{format?}")]
    public TodoItem? GetById(long id) =>
        _todoItemStore.GetById(id);
    // </snippet_ClassGet>

    // ...
}
