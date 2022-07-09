#region snippet
using Microsoft.AspNetCore.Mvc;
using ViewComponentSample.Models;

namespace ViewComponentSample.Controllers;
public class ToDoController : Controller
{
    private readonly ToDoContext _ToDoContext;

    public ToDoController(ToDoContext context)
    {
        _ToDoContext = context;
        _ToDoContext.Database.EnsureCreated();
    }

    public IActionResult Index(int maxPriority = 2, bool isDone = false)
    {
        var model = _ToDoContext!.ToDo!.ToList();
        ViewData["maxPriority"] = maxPriority;
        ViewData["isDone"] = isDone;
        return View(model);
    }
    #endregion

    public IActionResult IndexVC(int maxPriority = 2, bool isDone = false)
    {
        return ViewComponent("PriorityList",
            new
            {
                maxPriority = maxPriority,
                isDone = isDone
            });
    }

    public IActionResult IndexTypeof(int maxPriority = 2, bool isDone = false)
    {
        var model = _ToDoContext!.ToDo!.ToList();
        ViewData["maxPriority"] = maxPriority;
        ViewData["isDone"] = isDone;
        return View(model);
    }
        
    public IActionResult IndexNameOf(int maxPriority = 2, bool isDone = false)
    {
        var model = _ToDoContext!.ToDo!.ToList();
        ViewData["maxPriority"] = maxPriority;
        ViewData["isDone"] = isDone;
        return View(model);
    }

    public IActionResult IndexSync(int maxPriority = 2, bool isDone = false)
    {
        var model = _ToDoContext!.ToDo!.ToList();
        ViewData["maxPriority"] = maxPriority;
        ViewData["isDone"] = isDone;
        return View(model);
    }
}
