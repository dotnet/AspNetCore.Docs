using Microsoft.AspNetCore.Mvc;
using ResponseFormattingSample.Models;

namespace ResponseFormattingSample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoItemsController : ControllerBase
{
    private readonly TodoItemStore _todoItemStore;

    public TodoItemsController(TodoItemStore todoItemStore) =>
        _todoItemStore = todoItemStore;

    // <snippet_Get>
    [HttpGet]
    public IActionResult Get() =>
        Ok(_todoItemStore.GetList());
    // </snippet_Get>

    // <snippet_GetById>
    [HttpGet("{id:long}")]
    public IActionResult GetById(long id)
    {
        var todo = _todoItemStore.GetById(id);

        if (todo is null)
        {
            return NotFound();
        }

        return Ok(todo);
    }
    // </snippet_GetById>

    // <snippet_GetVersion>
    [HttpGet("Version")]
    public ContentResult GetVersion() =>
        Content("v1.0.0");
    // </snippet_GetVersion>

    // <snippet_GetError>
    [HttpGet("Error")]
    public IActionResult GetError() =>
        Problem("Something went wrong.");
    // </snippet_GetError>
}
