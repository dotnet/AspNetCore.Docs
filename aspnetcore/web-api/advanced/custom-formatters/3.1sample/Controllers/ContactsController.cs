using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomFormatterDemo.Models;
using System.Collections.Concurrent;


namespace CustomFormatterDemo.Controllers
{
   // [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private static ConcurrentDictionary<string, Contact> _contacts =
    new ConcurrentDictionary<string, Contact>();

        public ContactsController()
        {
            Add(new Contact() { FirstName = "Nancy", LastName = "Davolio" });
        }

        public void Add(Contact contact)
        {
            contact.ID = Guid.NewGuid().ToString();
            _contacts[contact.ID] = contact;
        }


        // GET api/contacts
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _contacts.Values;
        }

        // GET api/contacts/{guid}
        [HttpGet("{id}", Name="Get")]
        public IActionResult Get(string id)
        {
            Contact contact;
            _contacts.TryGetValue(id, out contact);
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
                Add(contact);
                return CreatedAtRoute("Get", new { id = contact.ID }, contact);
            }
            return BadRequest();
        }

        // This is not a correct PUT so removing
        // PUT api/contacts/{guid}
        //[HttpPut("{id}")]
        //public IActionResult Put(string id, [FromBody]Contact contact)
        //{
        //    if (ModelState.IsValid && id == contact.ID)
        //    {
        //        var contactToUpdate = Contacts.Get(id);
        //        if (contactToUpdate != null)
        //        {
        //            Contacts.Update(contact);
        //            return new NoContentResult();
        //        }
        //        return NotFound();
        //    }
        //    return BadRequest();
        //}

        // DELETE api/contacts/{guid}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Contact contact;
            _contacts.TryGetValue(id, out contact);
            if (contact == null)
            {
                return NotFound();
            }

            _contacts.TryRemove(id, out contact);
            return NoContent();
        }
    }
}
