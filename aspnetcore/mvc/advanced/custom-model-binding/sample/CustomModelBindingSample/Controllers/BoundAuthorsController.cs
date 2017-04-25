using Microsoft.AspNetCore.Mvc;
using CustomModelBindingSample.Data;
using System.Linq;

namespace CustomModelBindingSample.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BoundAuthorsController : Controller
    {
        // GET: api/authors/get/1
        [HttpGet("{id}")]
        public IActionResult GetById(Author author)
        {
            if (!ModelState.IsValid)
            {
                if (ModelState
                    .Any(s => s.Key == "id" &&
                         s.Value.Errors
                            .Any(e => e.ErrorMessage.Contains("not found"))
                        ))
                {
                    return NotFound();
                }
                return BadRequest(ModelState);
            }
            return Ok(author);
        }
    }
}
