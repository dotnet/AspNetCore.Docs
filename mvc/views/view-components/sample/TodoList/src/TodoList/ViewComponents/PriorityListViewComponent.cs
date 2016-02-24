//#define First
#if First

using System.Linq;
using Microsoft.AspNet.Mvc;
using TodoList.Models;

namespace TodoList.ViewComponents
{
    public class PriorityListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public PriorityListViewComponent(ApplicationDbContext context)
        {
            db = context;
        }

        public IViewComponentResult Invoke(int maxPriority)
        {
            var items = db.TodoItem.Where(x => x.IsDone == false &&
                x.Priority <= maxPriority);

            return View(items);
        }
    }
}

#endif