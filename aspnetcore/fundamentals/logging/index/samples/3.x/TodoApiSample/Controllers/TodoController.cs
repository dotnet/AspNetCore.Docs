#define LoggerDI // or CreateLogger or LogException or Scopes

// Test this with the code in Program snippet_TemplateCode with all the #defines 
// commented out. That uses the default template code and default providers.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoApiSample.Core;
using TodoApiSample.Core.Interfaces;
using TodoApiSample.Core.Model;

namespace TodoApiSample.Controllers
{
#if LoggerDI
    [Route("api/[controller]")]
    #region snippet_LoggerDI
    public class TodoController : Controller
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ILogger _logger;

        public TodoController(ITodoRepository todoRepository,
            ILogger<TodoController> logger)
        {
            _todoRepository = todoRepository;
            _logger = logger;
        }
        #endregion
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            using (_logger.BeginScope("Message {HoleValue}", DateTime.Now))
            {
                _logger.LogInformation(LoggingEvents.ListItems, "Listing all items");
                EnsureItems();
            }
            return _todoRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        #region snippet_CallLogMethods
        public IActionResult GetById(string id)
        {
            _logger.LogInformation(LoggingEvents.GetItem, "Getting item {Id}", id);
            var item = _todoRepository.Find(id);
            if (item == null)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "GetById({Id}) NOT FOUND", id);
                return NotFound();
            }
            return new ObjectResult(item);
        }
        #endregion

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _todoRepository.Add(item);
            _logger.LogInformation(LoggingEvents.InsertItem, "Item {Id} Created", item.Key);
            return CreatedAtRoute("GetTodo", new { controller = "Todo", id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var todo = _todoRepository.Find(id);
            if (todo == null)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "Update({Id}) NOT FOUND", id);
                return NotFound();
            }

            _todoRepository.Update(item);
            _logger.LogInformation(LoggingEvents.UpdateItem, "Item {Id} Updated", item.Key);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _todoRepository.Remove(id);
            _logger.LogInformation(LoggingEvents.DeleteItem, "Item {Id} Deleted", id);
        }

        private void EnsureItems()
        {
            if (!_todoRepository.GetAll().Any())
            {
                _logger.LogInformation(LoggingEvents.GenerateItems, "Generating sample items.");
                for (int i = 1; i < 11; i++)
                {
                    _todoRepository.Add(new TodoItem() { Name = "Item " + i });
                }
            }
        }
    }
#elif CreateLogger
    [Route("api/[controller]")]
    #region snippet_CreateLogger
    public class TodoController : Controller
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ILogger _logger;

        public TodoController(ITodoRepository todoRepository,
            ILoggerFactory logger)
        {
            _todoRepository = todoRepository;
            _logger = logger.CreateLogger("TodoApiSample.Controllers.TodoController");
        }
    #endregion
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            _logger.LogInformation(LoggingEvents.ListItems, "Listing all items");
            EnsureItems();
            return _todoRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            _logger.LogInformation(LoggingEvents.GetItem, "Getting item {Id}", id);
            var item = _todoRepository.Find(id);
            if (item == null)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "GetById({Id}) NOT FOUND", id);
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _todoRepository.Add(item);
            _logger.LogInformation(LoggingEvents.InsertItem, "Item {Id} Created", item.Key);
            return CreatedAtRoute("GetTodo", new { controller = "Todo", id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var todo = _todoRepository.Find(id);
            if (todo == null)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "Update({Id}) NOT FOUND", id);
                return NotFound();
            }

            _todoRepository.Update(item);
            _logger.LogInformation(LoggingEvents.UpdateItem, "Item {Id} Updated", item.Key);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _todoRepository.Remove(id);
            _logger.LogInformation(LoggingEvents.DeleteItem, "Item {Id} Deleted", id);
        }

        private void EnsureItems()
        {
            if (!_todoRepository.GetAll().Any())
            {
                _logger.LogInformation(LoggingEvents.GenerateItems, "Generating sample items.");
                for (int i = 1; i < 11; i++)
                {
                    _todoRepository.Add(new TodoItem() { Name = "Item " + i });
                }
            }
        }
    }
#elif LogException
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ILogger _logger;

        public TodoController(ITodoRepository todoRepository,
            ILoggerFactory logger)
        {
            _todoRepository = todoRepository;
            _logger = logger.CreateLogger("TodoApiSample.Controllers.TodoController");
        }
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            _logger.LogInformation(LoggingEvents.ListItems, "Listing all items");
            EnsureItems();
            return _todoRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            _logger.LogInformation(LoggingEvents.GetItem, "Getting item {Id}", id);
            TodoItem item;
            try
            {
                item = _todoRepository.Find(id);
                if (item == null)
                {
                    throw new Exception("Item not found exception.");
                }
            }
            // <snippet_LogException>
            catch (Exception ex)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, ex, "GetById({Id}) NOT FOUND", id);
                return NotFound();
            }
            return new ObjectResult(item);
            // </snippet_LogException>
        }
        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _todoRepository.Add(item);
            _logger.LogInformation(LoggingEvents.InsertItem, "Item {Id} Created", item.Key);
            return CreatedAtRoute("GetTodo", new { controller = "Todo", id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var todo = _todoRepository.Find(id);
            if (todo == null)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "Update({Id}) NOT FOUND", id);
                return NotFound();
            }

            _todoRepository.Update(item);
            _logger.LogInformation(LoggingEvents.UpdateItem, "Item {Id} Updated", item.Key);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _todoRepository.Remove(id);
            _logger.LogInformation(LoggingEvents.DeleteItem, "Item {Id} Deleted", id);
        }

        private void EnsureItems()
        {
            if (!_todoRepository.GetAll().Any())
            {
                _logger.LogInformation(LoggingEvents.GenerateItems, "Generating sample items.");
                for (int i = 1; i < 11; i++)
                {
                    _todoRepository.Add(new TodoItem() { Name = "Item " + i });
                }
            }
        }
    }
#elif Scopes
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ILogger _logger;

        public TodoController(ITodoRepository todoRepository,
            ILogger<TodoController> logger)
        {
            _todoRepository = todoRepository;
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            using (_logger.BeginScope("Message {HoleValue}", DateTime.Now))
            {
                _logger.LogInformation(LoggingEvents.ListItems, "Listing all items");
                EnsureItems();
            }
            return _todoRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        // <snippet_Scopes>
        public IActionResult GetById(string id)
        {
            TodoItem item;
            using (_logger.BeginScope("Message attached to logs created in the using block"))
            {
                _logger.LogInformation(LoggingEvents.GetItem, "Getting item {Id}", id);
                item = _todoRepository.Find(id);
                if (item == null)
                {
                    _logger.LogWarning(LoggingEvents.GetItemNotFound, "GetById({Id}) NOT FOUND", id);
                    return NotFound();
                }
            }
            return new ObjectResult(item);
        }
        // </snippet_Scopes>

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _todoRepository.Add(item);
            _logger.LogInformation(LoggingEvents.InsertItem, "Item {Id} Created", item.Key);
            return CreatedAtRoute("GetTodo", new { controller = "Todo", id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var todo = _todoRepository.Find(id);
            if (todo == null)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "Update({Id}) NOT FOUND", id);
                return NotFound();
            }

            _todoRepository.Update(item);
            _logger.LogInformation(LoggingEvents.UpdateItem, "Item {Id} Updated", item.Key);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _todoRepository.Remove(id);
            _logger.LogInformation(LoggingEvents.DeleteItem, "Item {Id} Deleted", id);
        }

        private void EnsureItems()
        {
            if (!_todoRepository.GetAll().Any())
            {
                _logger.LogInformation(LoggingEvents.GenerateItems, "Generating sample items.");
                for (int i = 1; i < 11; i++)
                {
                    _todoRepository.Add(new TodoItem() { Name = "Item " + i });
                }
            }
        }
    }

#endif
}
