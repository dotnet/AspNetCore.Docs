using Microsoft.AspNetCore.Mvc;
using ViewComponentSample.Models;

namespace ViewComponentSample.ViewComponents
{
    public class PriorityListSync : ViewComponent
    {
        private readonly ToDoContext db;

        public PriorityListSync(ToDoContext context)
        {
            db = context;
        }

        public IViewComponentResult Invoke(int maxPriority, bool isDone)
        {
 
            var x = db!.ToDo!.Where(x => x.IsDone == isDone &&
                                  x.Priority <= maxPriority).ToList();
            return View(x);
        }
    }
}
