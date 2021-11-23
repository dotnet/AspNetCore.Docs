using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResponseFormattingSample.Model;

namespace ResponseFormattingSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private readonly Authors _authors;

        public AuthorsController()
        {
            _authors = new Authors();
        }

        // <snippet_get>
        // GET: api/authors
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_authors.List());
        }
        // </snippet_get>

        // <snippet_search>
        // GET: api/authors/search?namelike=th
        [HttpGet("Search")]
        public IActionResult Search(string namelike)
        {
            var result = _authors.GetByNameSubstring(namelike);
            if (!result.Any())
            {
                return NotFound(namelike);
            }
            return Ok(result);
        }
        // </snippet_search>

        // <snippet_alias>
        // GET api/authors/RickAndMSFT
        [HttpGet("{alias}")]
        public Author Get(string alias)
        {
            return _authors.GetByAlias(alias);
        }
        // </snippet_alias>

        // <snippet_about>
        // GET api/authors/about
        [HttpGet("About")]
        public ContentResult About()
        {
            return Content("An API listing authors of docs.asp.net.");
        }
        // </snippet_about>

        // <snippet_string>
        // GET api/authors/version
        [HttpGet("version")]
        public string Version()
        {
            return "Version 1.0.0";
        }
        // </snippet_string>

    }

    public class Authors 
    {
        public List<Author> List()
        {
            return new List<Author>
            {
                new Author {Name="Steve Smith", Twitter="ardalis"},
                new Author {Name="Rick Anderson", Twitter="RickAndMSFT"},
                new Author {Name="Rachel Appel", Twitter="rachelappel"},
                new Author {Name="Daniel Roth", Twitter="danroth27"}
            }
            .OrderBy(a => a.Name).ToList();
        }

        public Author GetByAlias(string twitterAlias)
        {
            string loweredAlias = twitterAlias.ToLowerInvariant();
            return List()
                .FirstOrDefault(a => a.Twitter.ToLowerInvariant() == loweredAlias);
        }

        public List<Author> GetByNameSubstring(string nameSubstring)
        {
            return List()
                .Where(a =>
                    a.Name.IndexOf(nameSubstring, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                        .ToList();
        }
    }
}