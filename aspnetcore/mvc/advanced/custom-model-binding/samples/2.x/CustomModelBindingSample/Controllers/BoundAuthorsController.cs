using Microsoft.AspNetCore.Mvc;
using CustomModelBindingSample.Data;

namespace CustomModelBindingSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoundAuthorsController : ControllerBase
    {
        #region demo1
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

        #region demo2
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
