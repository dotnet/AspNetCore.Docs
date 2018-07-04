using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactManager.Data;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contact.ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .SingleOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactEditViewModel editModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editModel);
            }

            var contact = ViewModel_to_model(new Contact(), editModel);          

            _context.Add(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

            var editModel = Model_to_viewModel(contact);

            return View(editModel);
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContactEditViewModel editModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editModel);
            }

            var contact = await _context.Contact.SingleOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }           

            contact = ViewModel_to_model(contact, editModel);           

            _context.Update(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .SingleOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contact.SingleOrDefaultAsync(m => m.ContactId == id);
            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ContactExists(int id)
        {
            return _context.Contact.Any(e => e.ContactId == id);
        }

        private Contact ViewModel_to_model(Contact contact, ContactEditViewModel editModel)
        {
            contact.Address = editModel.Address;
            contact.City = editModel.City;
            contact.Email = editModel.Email;
            contact.Name = editModel.Name;
            contact.State = editModel.State;
            contact.Zip = editModel.Zip;

            return contact;
        }

        private ContactEditViewModel Model_to_viewModel(Contact contact)
        {
            var editModel = new ContactEditViewModel();

            editModel.ContactId = contact.ContactId;
            editModel.Address = contact.Address;
            editModel.City = contact.City;
            editModel.Email = contact.Email;
            editModel.Name = contact.Name;
            editModel.State = contact.State;
            editModel.Zip = contact.Zip;

            return editModel;
        }
    }
}
