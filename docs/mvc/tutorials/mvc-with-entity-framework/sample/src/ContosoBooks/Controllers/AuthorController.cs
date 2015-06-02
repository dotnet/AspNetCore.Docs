using ContosoBooks.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Storage;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoBooks.Controllers
{
    public class AuthorController : Controller
    {
        [FromServices]
        public BookContext BookContext { get; set; }

        public IActionResult Index()
        {
            return View(BookContext.Authors);
        }

        public async Task<ActionResult> Details(int id)
        {
            Author author = await BookContext.Authors
                .SingleOrDefaultAsync(a => a.AuthorID == id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("LastName", "FirstMidName")] Author author)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BookContext.Authors.Add(author);
                    await BookContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DataStoreException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }

            return View(author);
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<ActionResult> ConfirmDelete(int id, bool? retry)
        {
            Author author = await FindAuthorAsync(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            ViewBag.Retry = retry ?? false;
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Author author = await FindAuthorAsync(id);
                BookContext.Authors.Remove(author);
                await BookContext.SaveChangesAsync();
            }
            catch (DataStoreException)
            {
                return RedirectToAction("Delete", new { id = id, retry = true });
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            Author author = await FindAuthorAsync(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, [Bind("LastName", "FirstMidName")] Author author)
        {
            try
            {
                author.AuthorID= id;
                BookContext.Authors.Attach(author);
                BookContext.Entry(author).State = EntityState.Modified;
                await BookContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DataStoreException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(author);
        }

        private Task<Author> FindAuthorAsync(int id)
        {
            return BookContext.Authors.SingleOrDefaultAsync(author => author.AuthorID == id);
        }
    }
}
