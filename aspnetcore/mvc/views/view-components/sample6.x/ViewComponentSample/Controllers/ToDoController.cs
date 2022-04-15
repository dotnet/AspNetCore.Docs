using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewComponentSample.Models;

namespace ViewComponentSample.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext _ToDoContext;
        [BindProperty(SupportsGet = true)]
        public int maxPri { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool isComplete { get; set; }

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
        public IActionResult IndexVC(int maxPri = 2, bool isComplete = false)
        {
            return ViewComponent("PriorityList",
                new { 
                   maxPriority = maxPri,
                   isDone = isComplete
                });
        }
        #endregion

        #region snippet_IndexPP
        public async Task<IActionResult> IndexPP(int maxPri=2, bool isComplete=false)
        {
            ViewData["maxPri"] = maxPri;
            ViewData["isComplete"] = isComplete;
            return View(await _ToDoContext.ToDo!.ToListAsync());
        }
        #endregion

        public async Task<IActionResult> IndexFinal(int maxPri = 2, bool isComplete = false)
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

        public IActionResult IndexTagHelper(int maxPri = 2, bool isComplete = false)
        {
            ViewData["maxPri"] = maxPri;
            ViewData["isComplete"] = isComplete;
            return View(_ToDoContext.ToDo!.ToList());
        }
    }
}
