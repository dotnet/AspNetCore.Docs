using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwashbuckleSample.Models;

namespace SwashbuckleSample.Controllers;

// <snippet_ClassDeclaration>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TodoController : ControllerBase
{
    // </snippet_ClassDeclaration>
    private readonly TodoContext _context;

    public TodoController(TodoContext context) =>
        _context = context;

    [HttpGet]
    public async Task<List<TodoItem>> Get() =>
        await _context.TodoItems.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItem>> Get(long id)
    {
        var item = await _context.TodoItems.FindAsync(id);

        if (item is null)
        {
            return NotFound();
        }

        return item;
    }

    // <snippet_Create>
    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>A newly created TodoItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item #1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(TodoItem item)
    {
        _context.TodoItems.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }
    // </snippet_Create>

    // <snippet_Delete>
    /// <summary>
    /// Deletes a specific TodoItem.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var item = await _context.TodoItems.FindAsync(id);

        if (item is null)
        {
            return NotFound();
        }

        _context.TodoItems.Remove(item);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    // </snippet_Delete>
}
