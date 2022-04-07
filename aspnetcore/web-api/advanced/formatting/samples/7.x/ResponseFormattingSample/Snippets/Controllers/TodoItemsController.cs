using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ResponseFormattingSample.Models;

namespace ResponseFormattingSample.Snippets.Controllers;

[NonController]
// <snippet_ClassDeclaration>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TodoItemsController : ControllerBase
// </snippet_ClassDeclaration>
{
    private readonly TodoItemStore _todoItemStore;

    public TodoItemsController(TodoItemStore todoItemStore)
        => _todoItemStore = todoItemStore;

    // <snippet_Get>
    [HttpGet]
    public IActionResult Get() 
        => new JsonResult(
            _todoItemStore.GetList(),
            new JsonSerializerOptions { PropertyNamingPolicy = null });
    // </snippet_Get>

    // <snippet_GetNewtonsoftJson>
    [HttpGet]
    public IActionResult GetNewtonsoftJson()
        => new JsonResult(
            _todoItemStore.GetList(),
            new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() });
    // </snippet_GetNewtonsoftJson>

    // <snippet_GetById>
    [HttpGet("{id:long}")]
    public TodoItem? GetById(long id)
        => _todoItemStore.GetById(id);
    // </snippet_GetById>
}
