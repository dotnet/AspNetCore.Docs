public class TodoController : Controller
{
    private readonly ILogger _logger;

    public TodoController(ILogger<TodoController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id}", Name = "GetTodo")]
    public IActionResult GetById(string id)
    {
        _logger.LogInformation(LoggingEvents.GetItem, "Getting item {ID}", id);
        // Item lookup code removed.
        if (item == null)
        {
            _logger.LogWarning(LoggingEvents.GetItemNotFound, "GetById({ID}) NOT FOUND", id);
            return NotFound();
        }
        return new ObjectResult(item);
    }
}