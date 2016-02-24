//#define Second
#if Second

using Microsoft.AspNet.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

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
        var items = await GetItemsAsync(maxPriority, isDone);
        return View(items);
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

#endif