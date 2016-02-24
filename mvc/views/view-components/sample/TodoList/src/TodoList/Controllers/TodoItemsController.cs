using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using TodoList.Models;
using System.Threading.Tasks;

namespace TodoList.Controllers
{
    public class TodoItemsController : Controller
    {
        private ApplicationDbContext _context;

        public TodoItemsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: TodoItems
        public IActionResult Index()
        {
            return View(_context.TodoItem.ToList());
        }

        // GET: TodoItems
        public IActionResult IndexVC()
        {
            return ViewComponent("PriorityList", 3);
        }

        public async Task<IActionResult> IndexFinal()
        {
            return View(await _context.TodoItem.ToListAsync());
        }

        // GET: TodoItems/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TodoItem todoItem = _context.TodoItem.Single(m => m.Id == id);
            if (todoItem == null)
            {
                return HttpNotFound();
            }

            return View(todoItem);
        }

        // GET: TodoItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TodoItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                _context.TodoItem.Add(todoItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoItem);
        }

        // GET: TodoItems/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TodoItem todoItem = _context.TodoItem.Single(m => m.Id == id);
            if (todoItem == null)
            {
                return HttpNotFound();
            }
            return View(todoItem);
        }

        // POST: TodoItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                _context.Update(todoItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoItem);
        }

        // GET: TodoItems/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TodoItem todoItem = _context.TodoItem.Single(m => m.Id == id);
            if (todoItem == null)
            {
                return HttpNotFound();
            }

            return View(todoItem);
        }

        // POST: TodoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            TodoItem todoItem = _context.TodoItem.Single(m => m.Id == id);
            _context.TodoItem.Remove(todoItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
