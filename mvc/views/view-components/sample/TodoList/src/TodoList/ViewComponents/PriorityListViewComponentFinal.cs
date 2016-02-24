#define Final
#if Final

using System.Linq;
using Microsoft.AspNet.Mvc;
using TodoList.Models;
using System.Threading.Tasks;

namespace TodoList.ViewComponents
{

    public class PriorityListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public PriorityListViewComponent(ApplicationDbContext context)
        {
            db = context;
        }

        // Synchronous Invoke removed.

        public async Task<IViewComponentResult> InvokeAsync(
            int maxPriority, bool isDone)
        {
            string MyView = "Default";
            // If asking for all completed tasks, render with the "PVC" view.
            if (maxPriority > 3 && isDone == true)
            {
                MyView = "PVC";
            }
            var items = await GetItemsAsync(maxPriority, isDone);
            return View(MyView, items);
        }

        private Task<IQueryable<TodoItem>> GetItemsAsync(
              int maxPriority, bool isDone)
        {
            return Task.FromResult(GetItems(maxPriority, isDone));
        }
        private IQueryable<TodoItem> GetItems(int maxPriority, bool isDone)
        {
            var items = db.TodoItem.Where(x => x.IsDone == isDone &&
                                                x.Priority <= maxPriority);

            string msg = "Priority <= " + maxPriority.ToString() +
                         " && isDone == " + isDone.ToString();
            ViewBag.PriorityMessage = msg;

            return items;
        }
    }
}

#endif