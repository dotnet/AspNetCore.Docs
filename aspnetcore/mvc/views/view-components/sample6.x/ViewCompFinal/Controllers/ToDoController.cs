using Microsoft.AspNetCore.Mvc;
using ViewComponentSample.Models;

namespace ViewComponentSample.Controllers;

public class ToDoController : Controller
{
    private readonly ToDoContext _ToDoContext;

    public ToDoController(ToDoContext context)
    {
        _ToDoContext = context;

        // EnsureCreated() is used to call OnModelCreating for In-Memory databases as migration is not possible
        // see: https://github.com/aspnet/EntityFrameworkCore/issues/11666 
        _ToDoContext.Database.EnsureCreated();
    }

    #region snippet
    public IActionResult Index(int maxPri = 2, bool isComplete = false)
    {
        var model = _ToDoContext!.ToDo!.ToList();
        ViewData["maxPri"] = maxPri;
        ViewData["isComplete"] = isComplete;
        return View(model);
    }
    #endregion

    public string Index2()
    {
        return "View()";
    }
}
