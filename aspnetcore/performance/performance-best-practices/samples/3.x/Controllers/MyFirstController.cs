using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

/*
namespace performance_best_practices.Controllers
{
[Route("api/[controller]")]
[ApiController]

#if BAD
    #region snippet1
    public class MyFirstController : Controller
    {
        [HttpGet("/pokemon")]
        public ActionResult<PokemonData> Get()
        {
            // This synchronously reads the entire http request body into memory.
            // If the client is slowly uploading, we're doing sync over async because Kestrel does *NOT* support synchronous reads.
            var json = new StreamReader(Request.Body).ReadToEnd();

            return JsonConvert.DeserializeObject<PokemonData>(json);
        }
    }
    #endregion
#else
    #region snippet2
    public class MyFirstController : Controller
    {
        [HttpGet("/pokemon")]
        public async Task<ActionResult<PokemonData>> Get()
        {
            // This asynchronously reads the entire http request body into memory.
            var json = await new StreamReader(Request.Body).ReadToEndAsync();

            return JsonConvert.DeserializeObject<PokemonData>(json);
        }
    }
    #endregion
#endif

}
*/
