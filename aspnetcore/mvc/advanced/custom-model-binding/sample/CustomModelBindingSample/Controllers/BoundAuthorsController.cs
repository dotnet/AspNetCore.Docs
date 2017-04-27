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
        #region demo1
        [HttpGet("{id}")]
        public IActionResult GetById(Author author)
        {
            if (author == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(author);
        }
        #endregion

        // GET: api/boundauthors/get/1
        #region demo2
        [HttpGet("get/{authorId}")]
        public IActionResult GetById2(Author author)
        {
            // this example works with the AuthorEntityBinderProvider
            // you must remove the ModelBinder attribute from Author
            // for this provider to work
            return Ok(author);
        }
        #endregion
    }
}
