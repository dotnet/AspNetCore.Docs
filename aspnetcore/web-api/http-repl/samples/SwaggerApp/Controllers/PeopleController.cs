using Microsoft.AspNetCore.Mvc;
using SwaggerApp.Data;
using SwaggerApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerApp.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly SampleContext _context;

        public PeopleController(SampleContext context)
        { 
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get() =>
            _context.People.ToList();

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(int id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPost]
        public async Task<ActionResult<Person>> Create(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }
    }
}