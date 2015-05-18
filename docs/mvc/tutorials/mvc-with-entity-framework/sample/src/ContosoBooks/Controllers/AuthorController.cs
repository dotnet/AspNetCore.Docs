using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ContosoBooks.Models;
using Microsoft.Framework.Logging;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity.Storage;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ContosoBooks.Controllers
{
    public class AuthorController : Controller
    {
        [FromServices]
        public BookContext DbContext { get; set; }

        [FromServices]
        public ILogger<AuthorController> Logger { get; set; }

        public IActionResult Index()
        {
            return View(DbContext.Authors);
        }

        public async Task<ActionResult> Details(int id)
        {
            Author author = await DbContext.Authors
                .SingleOrDefaultAsync(x => x.AuthorID == id);
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
                    DbContext.Authors.Add(author);
                    await DbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DataStoreException ex)
            {
                Logger.LogError("Unable to save changes.", ex);
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
                DbContext.Authors.Remove(author);
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
                DbContext.Authors.Attach(author);
                DbContext.Entry(author).State = EntityState.Modified;
                await DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DataStoreException ex)
            {
                Logger.LogError("Unable to update.", ex);
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return View(author);
        }

        private Task<Author> FindAuthorAsync(int id)
        {
            return DbContext.Authors.SingleOrDefaultAsync(x => x.AuthorID == id);
        }
    }
}
