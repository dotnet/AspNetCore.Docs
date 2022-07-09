using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewComponentSample.Models;

namespace ViewComponentSample.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext _ToDoContext;
        [BindProperty(SupportsGet = true)]
        public int maxPriority { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool isDone { get; set; }

        public ToDoController(ToDoContext context)
        {
            _ToDoContext = context;

            // EnsureCreated() is used to call OnModelCreating for In-Memory databases as migration is not possible
            // see: https://github.com/aspnet/EntityFrameworkCore/issues/11666 
            _ToDoContext.Database.EnsureCreated();
        }

        public IActionResult Index()
        {
            var model = _ToDoContext.ToDo!.ToList();
            return View(model);
        }
        #region snippet_IndexVC
        public IActionResult IndexVC(int maxPriority = 2, bool isDone = false)
        {
            return ViewComponent("PriorityList",
                new { 
                   maxPriority = maxPriority,
                   isDone = isDone
                });
        }
        #endregion

        #region snippet_IndexPP
        public async Task<IActionResult> IndexPP(int maxPriority=2, bool isDone=false)
        {
            ViewData["maxPriority"] = maxPriority;
            ViewData["isDone"] = isDone;
            return View(await _ToDoContext.ToDo!.ToListAsync());
        }
        #endregion

        public async Task<IActionResult> IndexFinal(int maxPriority = 2, bool isDone = false)
        {
            return View(await _ToDoContext.ToDo!.ToListAsync());
        }

        public IActionResult IndexNameof()
        {
            return View(_ToDoContext.ToDo!.ToList());
        }
        public IActionResult IndexTypeof()
        {
            return View(_ToDoContext.ToDo!.ToList());
        }

        public IActionResult IndexFirst()
        {
            return View(_ToDoContext.ToDo!.ToList());
        }

        public IActionResult IndexTagHelper(int maxPriority = 2, bool isDone = false)
        {
            ViewData["maxPriority"] = maxPriority;
            ViewData["isDone"] = isDone;
            return View(_ToDoContext.ToDo!.ToList());
        }
    }
}
