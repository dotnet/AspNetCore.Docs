using Microsoft.AspNetCore.Mvc;
using CustomModelBindingSample.Data;

namespace CustomModelBindingSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoundAuthorsController : ControllerBase
    {
        #region snippet_GetById
        [HttpGet("{id}")]
        public IActionResult GetById([ModelBinder(Name = "id")] Author author)
        {
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }
        #endregion

        #region snippet_Get
        [HttpGet("get/{authorId}")]
        public IActionResult Get(Author author)
        {
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }
        #endregion
    }
}
