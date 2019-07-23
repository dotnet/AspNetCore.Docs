using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwaggerApp.Data;
using SwaggerApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SwaggerApp.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class FruitsController : ControllerBase
    {
        private readonly SampleContext _context;

        public FruitsController(SampleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Fruit>> Get() =>
            _context.Fruits.ToList();

        [HttpGet("{id}")]
        public async Task<ActionResult<Fruit>> GetById(int id)
        {
            var fruit = await _context.Fruits.FindAsync(id);
            
            if (fruit == null)
            {
                return NotFound();
            }

            return fruit;
        }

        [HttpPost]
        public async Task<ActionResult<Fruit>> Create(Fruit fruit)
        {
            _context.Fruits.Add(fruit);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = fruit.Id }, fruit);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Fruit fruit)
        {
            if (id != fruit.Id)
            {
                return BadRequest();
            }

            _context.Entry(fruit).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            var fruit = await _context.Fruits.FindAsync(id);

            if (fruit == null)
            {
                return NotFound();
            }

            _context.Fruits.Remove(fruit);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
