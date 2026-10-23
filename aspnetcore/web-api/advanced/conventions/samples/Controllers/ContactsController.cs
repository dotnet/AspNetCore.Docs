using System.Collections.Generic;
using ApiConventions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiConventions.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contacts;

        public ContactsController(IContactRepository contacts)
        {
            _contacts = contacts;
        }

        // GET api/contacts
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _contacts.GetAll();
        }

        #region missing404docs
        // GET api/contacts/{guid}
        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
        public IActionResult Get(string id)
        {
            var contact = _contacts.Get(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }
        #endregion

        // POST api/contacts
        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            _contacts.Add(contact);

            return CreatedAtRoute("GetById", new { id = contact.ID }, contact);
        }

        // PUT api/contacts/{guid}
        [HttpPut("{id}")]
        public IActionResult Put(string id, Contact contact)
        {
            if (ModelState.IsValid && id == contact.ID)
            {
                var contactToUpdate = _contacts.Get(id);

                if (contactToUpdate != null)
                {
                    _contacts.Update(contact);
                    return NoContent();
                }

                return NotFound();
            }

            return BadRequest();
        }

        // DELETE api/contacts/{guid}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var contact = _contacts.Get(id);

            if (contact == null)
            {
                return NotFound();
            }

            _contacts.Remove(id);

            return NoContent();
        }
    }
}
