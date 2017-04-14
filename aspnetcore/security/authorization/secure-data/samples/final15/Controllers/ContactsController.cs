using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ContactManager.Authorization;

namespace ContactManager.Controllers
{
    #region snippet_ContactsController
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ContactsController(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }
        #endregion

        // GET: Contacts
        public async Task<IActionResult> Index(int? id)
        {
            var viewName = id == null ? "Index" : $"Index{id}";

            return View(viewName, await _context.Contact.ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact.SingleOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            //return View();
            return View(new Contact
            {
                Address = "123 N 456 E",
                City = "GF",
                Email = _userManager.GetUserName(User),
                Name = "Rick Anderson",
                State = "MT",
                Zip = "59405"
            });
        }
        #region snippet_Create
        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
                    [Bind("ContactId,Address,City,Email,Name,State,Zip")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.OwnerID = _userManager.GetUserId(User);
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contact);
        }
        #endregion

        // GET: Contacts/Edit/5
        #region snippet_Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDB = await _context.Contact.SingleOrDefaultAsync(m => m.ContactId == id);
            if (contactDB == null)
            {
                return NotFound();
            }

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, contactDB, 
                                        ContactOperationsRequirements.Update);
            if (!isAuthorized)
            {
                return new ChallengeResult();
            }

            return View(contactDB);
        }

        // Make ContactViewModel -- might need multiple viewModeles
        // POST: Contacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("ContactId,Address,City,Email,Name,State,Zip")] Contact contact)
        {
            // Why is this here? Scaffolding??
            if (id != contact.ContactId)
            {
                return NotFound();
            }

            // Fetch Contact from DB to get OwnerID.
            var contactDB = await _context.Contact.SingleOrDefaultAsync(m => m.ContactId == id);
            if (contactDB == null)
            {
                return NotFound();
            }

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, contactDB,
                                        ContactOperationsRequirements.Update);
            if (!isAuthorized)
            {
                return new ChallengeResult();
            }
            // Review with EF - should I copy changed fields to contactDB and update
            // rather that what I'm doing here.
            contact.OwnerID = contactDB.OwnerID;
            _context.Entry(contactDB).State = EntityState.Detached;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.ContactId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(contact);
        }
        #endregion

        // GET: Contacts/Delete/5
        #region snippet_Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact.SingleOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, contact,
                                        ContactOperationsRequirements.Delete);
            if (!isAuthorized)
            {
                return new ChallengeResult();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contact.SingleOrDefaultAsync(m => m.ContactId == id);

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, contact,
                                        ContactOperationsRequirements.Delete);
            if (!isAuthorized)
            {
                return new ChallengeResult();
            }

            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        private bool ContactExists(int id)
        {
            return _context.Contact.Any(e => e.ContactId == id);
        }
    }
}
