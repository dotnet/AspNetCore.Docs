using Microsoft.AspNetCore.Mvc;
using CustomModelBindingSample.Data;
using System.Linq;

namespace CustomModelBindingSample.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BoundAuthorsController : Controller
    {
        // GET: api/boundauthors/1
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

        // GET: api/boundauthors/get/1
        [HttpGet("get/{authorId}")]
        public IActionResult GetById2(Author author)
        {
            // this example works with the AuthorEntityBinderProvider
            // you must remove the ModelBinder attribute from Author
            // for this provider to work
            return Ok(author);
        }
    }
}
