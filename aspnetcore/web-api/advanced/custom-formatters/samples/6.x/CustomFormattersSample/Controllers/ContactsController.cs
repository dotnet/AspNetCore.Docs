using System.Collections.Concurrent;
using CustomFormattersSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomFormattersSample.Controllers;

// [ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private static readonly ConcurrentDictionary<Guid, Contact> _contacts = new();

    public ContactsController()
    {
        if (_contacts.Count == 0)
        {
            Add(new("Nancy", "Davolio"));
        }
    }

    [HttpGet]
    public IEnumerable<Contact> Get()
        => _contacts.Values;

    [HttpGet("{id:guid}")]
    public ActionResult<Contact> Get(Guid id)
    {
        if (!_contacts.TryGetValue(id, out var contact))
        {
            return NotFound();
        }

        return contact;
    }

    [HttpPost]
    public IActionResult Post([FromBody] Contact contact)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Add(contact);

        return CreatedAtAction(nameof(Get), new { id = contact.Id }, contact);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_contacts.ContainsKey(id))
        {
            return NotFound();
        }

        _contacts.TryRemove(id, out _);

        return NoContent();
    }

    private static void Add(Contact contact)
    {
        var newContact = contact with { Id = Guid.NewGuid() };
        _contacts[newContact.Id] = newContact;
    }
}
