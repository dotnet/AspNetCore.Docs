using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValidationResultErrorMessage.Data;
using ValidationResultErrorMessage.Models;

namespace ValidationResultErrorMessage.Controllers;

public class ContactsController : Controller
{
    private readonly ValidationResultErrorMessageContext _context;

    public ContactsController(ValidationResultErrorMessageContext context)
    {
        _context = context;
    }

    // GET: Contacts
    public async Task<IActionResult> Index()
    {
        return _context.Contact != null ?
                    View(await _context.Contact.ToListAsync()) :
                    View("Error", new ErrorViewModel
                    {
                        Message = "Contact is null",
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    });
    }

    // GET: Contacts/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null || _context.Contact == null)
        {
            return NotFound();
        }

        var contact = await _context.Contact
            .FirstOrDefaultAsync(m => m.Id == id);
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
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Email,PhoneNumber")] Contact contact)
    {
        if (ModelState.IsValid)
        {
            contact.Id = Guid.NewGuid();
            _context.Add(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(contact);
    }

    // GET: Contacts/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null || _context.Contact == null)
        {
            return NotFound();
        }

        var contact = await _context.Contact.FindAsync(id);
        if (contact == null)
        {
            return NotFound();
        }
        return View(contact);
    }

    // POST: Contacts/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Email,PhoneNumber")] Contact contact)
    {
        if (id != contact.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(contact);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(contact.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(contact);
    }

    // GET: Contacts/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null || _context.Contact == null)
        {
            return NotFound();
        }

        var contact = await _context.Contact
            .FirstOrDefaultAsync(m => m.Id == id);
        if (contact == null)
        {
            return NotFound();
        }

        return View(contact);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        if (_context.Contact == null)
        {
            return View("Error", new ErrorViewModel
            {
                Message = $"Contact with id {id} is null.",
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }

        var contact = await _context.Contact.FindAsync(id);
        if (contact != null)
        {
            _context.Contact.Remove(contact);
        }
        else
        {
            return View("Error", new ErrorViewModel
            {
                Message = $"Contact with id {id} not found.",
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ContactExists(Guid id)
    {
        return (_context.Contact?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
