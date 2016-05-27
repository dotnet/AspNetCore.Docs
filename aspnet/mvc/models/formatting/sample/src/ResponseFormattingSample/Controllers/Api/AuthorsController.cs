using Microsoft.AspNet.Mvc;
using ResponseFormattingSample.Interfaces;
using ResponseFormattingSample.Model;

namespace ResponseFormattingSample.Controllers.Api
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        // GET: api/authors
        [HttpGet]
        public JsonResult Get()
        {
            return Json(_authorRepository.List());
        }

        // GET api/authors/ardalis
        [HttpGet("{alias}")]
        public Author Get(string alias)
        {
            return _authorRepository.GetByAlias(alias);
        }

        // GET api/authors/about
        [HttpGet("About")]
        public ContentResult About()
        {
            return Content("An API listing authors of docs.asp.net.");
        }

        // GET api/authors/version
        [HttpGet("version")]
        public string Version()
        {
            return "Version 1.0.0";
        }
    }
}
