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


        // GET api/values
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return Contacts.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}", Name="Get")]
        public IActionResult Get(string id)
        {
            var contact = Contacts.Get(id);
            if (contact == null)
            {
                return NotFound();
            }
            return new ObjectResult(contact);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            Contacts.Add(contact);
            return CreatedAtRoute("Get", new { id = contact.ID }, contact);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]Contact contact)
        {
            if (contact == null || id == null || id != contact.ID)
            {
                return BadRequest();
            }

            var contactToUpdate = Contacts.Get(id);
            if (contactToUpdate == null)
            {
                return NotFound();
            }

            Contacts.Update(contact);
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var contact = Contacts.Get(id);
            if (contact == null)
            {
                return NotFound();
            }

            Contacts.Remove(id);
            return new NoContentResult();
        }
    }
}
