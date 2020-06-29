using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomFormatterDemo.Models;

namespace CustomFormatterDemo.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        public ContactsController(IContactRepository contacts)
        {
            Contacts = contacts;
        }
        public IContactRepository Contacts { get; set; }


        // GET api/contacts
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return Contacts.GetAll();
        }

        // GET api/contacts/{guid}
        [HttpGet("{id}", Name="Get")]
        public IActionResult Get(string id)
        {
            var contact = Contacts.Get(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        // POST api/contacts
        [HttpPost]
        public IActionResult Post([FromBody]Contact contact)
        {
            if (ModelState.IsValid)
            {
                Contacts.Add(contact);
                return CreatedAtRoute("Get", new { id = contact.ID }, contact);
            }
            return BadRequest();
        }

        // PUT api/contacts/{guid}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]Contact contact)
        {
            if (ModelState.IsValid && id == contact.ID)
            {
                var contactToUpdate = Contacts.Get(id);
                if (contactToUpdate != null)
                {
                    Contacts.Update(contact);
                    return new NoContentResult();
                }
                return NotFound();
            }
            return BadRequest();
        }

        // DELETE api/contacts/{guid}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var contact = Contacts.Get(id);
            if (contact == null)
            {
                return NotFound();
            }

            Contacts.Remove(id);
            return NoContent();
        }
    }
}
