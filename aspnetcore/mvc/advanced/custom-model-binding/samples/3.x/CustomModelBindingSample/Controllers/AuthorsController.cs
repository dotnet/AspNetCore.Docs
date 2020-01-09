using Microsoft.AspNetCore.Mvc;
using CustomModelBindingSample.Data;

namespace CustomModelBindingSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly AuthorContext _context;

        public AuthorsController(AuthorContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var author = _context.Authors.Find(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }
    }
}
