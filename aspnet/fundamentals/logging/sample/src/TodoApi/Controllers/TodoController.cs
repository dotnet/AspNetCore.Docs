using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using TodoApi.Core;
using TodoApi.Core.Interfaces;
using TodoApi.Core.Model;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;

        [FromServices]
        public ITodoRepository TodoItems { get; set; }

        public TodoController(ILogger<TodoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            _logger.LogInformation(LoggingEvents.LIST_ITEMS, "Listing all items");
            EnsureItems();
            return TodoItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            _logger.LogInformation(LoggingEvents.GET_ITEM, "Getting item {0}", id);
            var item = TodoItems.Find(id);
            if (item == null)
            {
                _logger.LogWarning(LoggingEvents.GET_ITEM_NOTFOUND, "GetById({0}) NOT FOUND", id);
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return HttpBadRequest();
            }
            TodoItems.Add(item);
            _logger.LogInformation(LoggingEvents.INSERT_ITEM, "Item {0} Created", item.Key);
            return CreatedAtRoute("GetTodo", new { controller = "Todo", id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item)
        {
            if (item == null || item.Key != id)
            {
                return HttpBadRequest();
            }

            var todo = TodoItems.Find(id);
            if (todo == null)
            {
                _logger.LogWarning(LoggingEvents.GET_ITEM_NOTFOUND, "Update({0}) NOT FOUND", id);
                return HttpNotFound();
            }

            TodoItems.Update(item);
            _logger.LogInformation(LoggingEvents.UPDATE_ITEM, "Item {0} Updated", item.Key);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            TodoItems.Remove(id);
            _logger.LogInformation(LoggingEvents.DELETE_ITEM, "Item {0} Deleted", id);
        }

        private void EnsureItems()
        {
            if (!TodoItems.GetAll().Any())
            {
                _logger.LogInformation(LoggingEvents.GENERATE_ITEMS, "Generating sample items.");
                for (int i = 1; i < 11; i++)
                {
                    TodoItems.Add(new TodoItem() { Name = "Item " + i });
                }
            }
        }
    }
}
