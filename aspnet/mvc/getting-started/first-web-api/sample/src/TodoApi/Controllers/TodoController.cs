using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using TodoApi.Models;

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        [FromServices]
        public ITodoRepository TodoItems { get; set; }

        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return TodoItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = TodoItems.Find(id);
            if (item == null)
            {
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
                return HttpNotFound();
            }

            TodoItems.Update(item);
            return new NoContentResult();
        }





        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            TodoItems.Remove(id);
        }
    }
}
