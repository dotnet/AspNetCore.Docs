//#define NEVER
#if NEVER
// This controller is used only for documentation purposes.
#region snippet_todo1
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;
using Microsoft.AspNet.OData;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (_context.TodoItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }


#region orderOption
        [HttpGet]
        [EnableQuery(AllowedOrderByProperties=nameof(TodoItem.Name))]
        public ActionResult<IQueryable<TodoItem>> GetTodoItemsOrderBy()
        {
            return _context.TodoItems;
        }
#endregion

#region PageSizeOption
        [HttpGet]
        [EnableQuery(PageSize = 3)]
        public ActionResult<IQueryable<TodoItem>> GetTodoItemsPageSize()
        {
            return _context.TodoItems;
        }
#endregion
    }
}
#endregion
#endif
