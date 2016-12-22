using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ViewComponentSample.Models;

namespace ViewComponentSample.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext _ToDoContext;

        public ToDoController(ToDoContext context)
        {
            _ToDoContext = context;
        }

        public IActionResult Index()
        {
            var model = _ToDoContext.ToDo.ToList();
            return View(model);
        }
        public string Index2()
        {
            return "View()";
        }
    }
}
