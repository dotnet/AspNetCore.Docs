using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly TodoContext _context;

        public TestController(TodoContext context, ILogger<TodoItemsController> logger)
        {
            _logger = logger;
            _context = context;
        }

        #region snippet_Exp
        [HttpGet("{id}")]
        public IActionResult TestExp(int id)
        {
            var routeInfo = ControllerContext.ToCtxString(id);
            _logger.LogInformation(MyLogEvents.TestItem, routeInfo);

            try
            {
                if (id == 3)
                {
                    throw new Exception("Test exception");
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(MyLogEvents.GetItemNotFound, ex, "TestExp({Id})", id);
                return NotFound();
            }

            return ControllerContext.MyDisplayRouteInfo();
        }
        #endregion

        #region snippet0
        [HttpGet]
        public IActionResult Test1(int id)
        {
            var routeInfo = ControllerContext.ToCtxString(id);

            _logger.Log(LogLevel.Information, MyLogEvents.TestItem, routeInfo);
            _logger.LogInformation(MyLogEvents.TestItem, routeInfo);

            return ControllerContext.MyDisplayRouteInfo();
        }
        #endregion

        #region snippet_Scopes
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
        {
            TodoItem todoItem;

            using (_logger.BeginScope("using block message"))
            {
                _logger.LogInformation(MyLogEvents.GetItem, "Getting item {Id}", id);

                todoItem = await _context.TodoItems.FindAsync(id);

                if (todoItem == null)
                {
                    _logger.LogWarning(MyLogEvents.GetItemNotFound, 
                        "Get({Id}) NOT FOUND", id);
                    return NotFound();
                }
            }

            return ItemToDTO(todoItem);
        }
        #endregion

        private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
    new TodoItemDTO
    {
        Id = todoItem.Id,
        Name = todoItem.Name,
        IsComplete = todoItem.IsComplete
    };
    }
}
