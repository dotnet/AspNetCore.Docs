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
        public IActionResult GetById([ModelBinder(Name = "id")]Author author)
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
        public IActionResult Get(Author author)
        {
            return Ok(author);
        }
        #endregion
    }
}
