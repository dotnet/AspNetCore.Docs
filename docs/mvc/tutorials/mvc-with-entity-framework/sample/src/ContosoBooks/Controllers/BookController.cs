using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ContosoBooks.Models;
using Microsoft.Framework.Logging;
using Microsoft.Data.Entity.Storage;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ContosoBooks.Controllers
{
    public class BookController : Controller
    {
        [FromServices]
        public BookContext DbContext { get; set; }

        [FromServices]
        public ILogger<BookController> Logger { get; set; }

        // GET: /<controller>/
        public IActionResult Index()
        {
           var books = DbContext.Books.Include(b => b.Author);
           return View(books);
        }

        public async Task<ActionResult> Details(int id)
        {
            Book book = await DbContext.Books
                .Include(x => x.Author)
                .SingleOrDefaultAsync(x => x.BookID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult Create()
        {
            ViewBag.Items = GetAuthorsListItems();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Title", "Year", "Price", "Genre", "AuthorID")] Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DbContext.Books.Add(book);
                    await DbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DataStoreException ex)
            {
                Logger.LogError("Unable to save changes.", ex);
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(book);
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<ActionResult> ConfirmDelete(int id, bool? retry)
        {
            Book book = await FindBookAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.Retry = retry ?? false;
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Book book = await FindBookAsync(id);
                DbContext.Books.Remove(book);
                await DbContext.SaveChangesAsync();
            }
            catch (DataStoreException ex)
            {
                Logger.LogError("Unable to delete record.", ex);
                return RedirectToAction("Delete", new { id = id, retry = true });
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            Book book = await FindBookAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            ViewBag.Items = GetAuthorsListItems(book.AuthorID);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, [Bind("Title", "Year", "Price", "Genre", "AuthorID")] Book book)
        {
            try
            {
                book.BookID = id;
                DbContext.Books.Attach(book);
                DbContext.Entry(book).State = EntityState.Modified;
                await DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DataStoreException ex)
            {
                Logger.LogError("Unable to update.", ex);
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(book);
        }

        private Task<Book> FindBookAsync(int id)
        {
            return DbContext.Books.SingleOrDefaultAsync(x => x.BookID == id);
        }

        private IEnumerable<SelectListItem> GetAuthorsListItems(int selected = -1)
        {
            var tmp = DbContext.Authors.ToList();  // Workaround for https://github.com/aspnet/EntityFramework/issues/325

            // Create authors list for <select> dropdown
            return tmp
                .OrderBy(x => x.LastName)
                .Select(x => new SelectListItem
                {
                    Text = String.Format("{0}, {1}", x.LastName, x.FirstMidName),
                    Value = x.AuthorID.ToString(),
                    Selected = x.AuthorID == selected
                });
        }



    }


}
