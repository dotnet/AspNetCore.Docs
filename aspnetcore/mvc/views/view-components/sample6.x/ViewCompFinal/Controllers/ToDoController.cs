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

    public IActionResult Index(int maxPri = 2, bool isComplete = false)
    {
        var model = _ToDoContext!.ToDo!.ToList();
        ViewData["maxPri"] = maxPri;
        ViewData["isComplete"] = isComplete;
        return View(model);
    }
    #endregion

    public IActionResult IndexVC(int maxPri = 2, bool isComplete = false)
    {
        return ViewComponent("PriorityList",
            new
            {
                maxPriority = maxPri,
                isDone = isComplete
            });
    }

    public IActionResult IndexFinal(int maxPri = 2, bool isComplete = false)
    {
        var model = _ToDoContext!.ToDo!.ToList();
        ViewData["maxPri"] = maxPri;
        ViewData["isComplete"] = isComplete;
        return View(model);
    }
}
