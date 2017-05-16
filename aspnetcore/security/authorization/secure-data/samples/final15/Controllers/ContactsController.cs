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
    #region snippet_ContactsControllerCtor
    [Authorize(Policy = "ContactUserPolicy")]
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

            var contacts = from c in _context.Contact
                           select c;

            var contactDB = await _context.Contact.FirstOrDefaultAsync();

            var isAuthorized = await _authorizationService.AuthorizeAsync(
                                                       User, contactDB,
                                                       ContactOperations.Approve);

            if (!isAuthorized)
            {
                contacts = contacts.Where(c => c.Status == ContactStatus.Approved);
            }

            return View(await contacts.ToListAsync());
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
            return View(new ContactEditViewModel
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
                            [Bind("ContactId,Address,City,Email,Name,State,Zip")]
                            ContactEditViewModel editModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editModel);
            }

            var contact = new Contact();
            contact.Address = editModel.Address;
            contact.City = editModel.City;
            contact.Email = editModel.Email;
            contact.Name = editModel.Name;
            contact.State = editModel.State;
            contact.Zip = editModel.Zip;
            contact.OwnerID = _userManager.GetUserId(User);
            var isAuthorized = await _authorizationService.AuthorizeAsync(
                                                        User, contact,
                                                        ContactOperations.Create);
            if (!isAuthorized)
            {
                return new ChallengeResult();
            }
            
            _context.Add(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");            
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

            var contactDB = await _context.Contact.SingleOrDefaultAsync(
                                                        m => m.ContactId == id);
            if (contactDB == null)
            {
                return NotFound();
            }

            var isAuthorized = await _authorizationService.AuthorizeAsync(
                                                        User, contactDB, 
                                                        ContactOperations.Update);
            if (!isAuthorized)
            {
                return new ChallengeResult();
            }

            var editModel = new ContactEditViewModel();
            editModel.ContactId = contactDB.ContactId;
            editModel.Address = contactDB.Address;
            editModel.City = contactDB.City;
            editModel.Email = contactDB.Email;
            editModel.Name = contactDB.Name;
            editModel.State = contactDB.State;
            editModel.Zip = contactDB.Zip;

            return View(editModel);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("ContactId,Address,City,Email,Name,State,Zip")] ContactEditViewModel editModel)
        {
            // Why is this here? Scaffolding??
            if (id != editModel.ContactId)
            {
                return NotFound();
            }

            if(!ModelState.IsValid)
            {
                return View(editModel);
            }

            // Fetch Contact from DB to get OwnerID.
            var contact = await _context.Contact.SingleOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, contact,
                                        ContactOperations.Update);
            if (!isAuthorized)
            {
                return new ChallengeResult();
            }
            
            contact.Address = editModel.Address;
            contact.City = editModel.City;
            contact.Email = editModel.Email;
            contact.Name = editModel.Name;
            contact.State = editModel.State;
            contact.Zip = editModel.Zip;
            
            if(contact.Status == ContactStatus.Approved)
            {
                // If the contact is updated after approval, 
                // and the user cannot approve set the status back to submitted
                var canApprove = await _authorizationService.AuthorizeAsync(User, contact,
                                        ContactOperations.Approve);

                if(!canApprove) contact.Status = ContactStatus.Submitted;
            }
            
            _context.Update(contact);
            await _context.SaveChangesAsync();
           
            return RedirectToAction("Index");
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
                                        ContactOperations.Delete);
            if (!isAuthorized)
            {
                return new ChallengeResult();
            }

            var editModel = new ContactEditViewModel();
            editModel.ContactId = contact.ContactId;
            editModel.Address = contact.Address;
            editModel.City = contact.City;
            editModel.Email = contact.Email;
            editModel.Name = contact.Name;
            editModel.State = contact.State;
            editModel.Zip = contact.Zip;

            return View(editModel);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contact.SingleOrDefaultAsync(m => m.ContactId == id);

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, contact,
                                        ContactOperations.Delete);
            if (!isAuthorized)
            {
                return new ChallengeResult();
            }

            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var contact = await _context.Contact.SingleOrDefaultAsync(m => m.ContactId == id);

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, contact,
                                        ContactOperations.Approve);
            if (!isAuthorized)
            {
                return new ChallengeResult();
            }
            contact.Status = ContactStatus.Approved;
            _context.Contact.Update(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            var contact = await _context.Contact.SingleOrDefaultAsync(m => m.ContactId == id);

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, contact,
                                        ContactOperations.Reject);
            if (!isAuthorized)
            {
                return new ChallengeResult();
            }
            contact.Status = ContactStatus.Rejected;
            _context.Contact.Update(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ContactExists(int id)
        {
            return _context.Contact.Any(e => e.ContactId == id);
        }
    }
}
