using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiConventions.Models;
using Microsoft.AspNetCore.Http;

namespace ApiConventions.Controllers
{
    [ApiController]
#region apiconventiontypeattribute
    [ApiConventionType(typeof(DefaultApiConvention))]
#endregion
    [Route("api/[controller]")]
    public class ContactsConventionController : Controller
    {
        public ContactsConventionController(IContactRepository contacts)
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
        [HttpGet("{id}")]
        public ActionResult<Contact> Get(string id)
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
        public IActionResult Post(Contact contact)
        {
            Contacts.Add(contact);
            return CreatedAtRoute("Get", new { id = contact.ID }, contact);
        }

        #region apiconventionmethod
        // PUT api/contacts/{guid}
        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public IActionResult Update(string id, Contact contact)
        {
            var contactToUpdate = Contacts.Get(id);
            if (contactToUpdate == null)
            {
                return NotFound();
            }

            Contacts.Update(contact);
            return new NoContentResult();
        }
        #endregion

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
