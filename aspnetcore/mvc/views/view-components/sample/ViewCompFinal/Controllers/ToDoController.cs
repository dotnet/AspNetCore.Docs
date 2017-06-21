using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ViewComponentSample.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        #region snippet_IndexVC
        public IActionResult IndexVC()
        {
            return ViewComponent("PriorityList", new { maxPriority = 3, isDone = false });
        }
        #endregion

        public async Task<IActionResult> IndexFinal()
        {
            return View(await _ToDoContext.ToDo.ToListAsync());
        }

        public IActionResult IndexNameof()
        {
            return View(_ToDoContext.ToDo.ToList());
        }

        public IActionResult IndexFirst()
        {
            return View(_ToDoContext.ToDo.ToList());
        }
    }
}
