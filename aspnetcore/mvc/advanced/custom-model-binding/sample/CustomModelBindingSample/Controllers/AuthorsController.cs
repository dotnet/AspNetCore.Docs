using Microsoft.AspNetCore.Mvc;
using CustomModelBindingSample.Data;

namespace CustomModelBindingSample.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly AppDbContext _db;
        public AuthorsController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/authors/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var author = _db.Authors.Find(id);
            if(author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }
    }
}
