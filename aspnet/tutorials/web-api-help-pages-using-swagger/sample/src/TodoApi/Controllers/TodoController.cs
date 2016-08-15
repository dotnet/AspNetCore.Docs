using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Swashbuckle.SwaggerGen.Annotations;

namespace TodoApi.Controllers
{
    /// <summary>
    /// API Controller for Todo Items
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="todoItems"></param>
        public TodoController(ITodoRepository todoItems)
        {
            TodoItems = todoItems;
        }

        /// <summary>
        /// repository for Todo items
        /// </summary>
        public ITodoRepository TodoItems { get; set; }

        /// <summary>
        /// returns a collection of TodoItems.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json", Type = typeof(IEnumerable<TodoItem>))]
        public IEnumerable<TodoItem> GetAll()
        {
            return TodoItems.GetAll();
        }

        /// <summary>
        /// Returns a specific TodoItem. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json", Type = typeof(TodoItem))]
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        #region Create_Method
        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Note that the key is a GUID and not an integer.
        ///  
        ///     POST /Todo
        ///     {
        ///        "key": "0e7ad584-7788-4ab1-95a6-ca0a5b444cbb",
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        /// 
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>New Created Todo Item</returns>
        /// <response code="201">Todo Item created</response>
        /// <response code="400">Todo Item invalid</response>
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.Created, "Returns the newly created Todo item.", typeof(TodoItem))]
        [SwaggerResponse(HttpStatusCode.BadRequest, "If the item is null", typeof(TodoItem))]
        public IActionResult Create([FromBody, Required] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            TodoItems.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
        }
        #endregion
        /// <summary>
        /// Updates a specific TodoItem.
        /// </summary>
        /// <remarks>
        /// This is just some additional information that you can put in regarding the method.
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var todo = TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            TodoItems.Update(item);

            return new NoContentResult();
        }
        #region Delete_Method
        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            TodoItems.Remove(id);
        }
        #endregion
    }
}
