using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace performance_best_practices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    #region snippet1
    public class BadStreamReaderController : Controller
    {
        [HttpGet("/pokemon")]
        public ActionResult<PokemonData> Get()
        {
            // This synchronously reads the entire http request body into memory.
            // If the client is slowly uploading, app is doing sync over async because 
            // Kestrel does *NOT* support synchronous reads.
            var json = new StreamReader(Request.Body).ReadToEnd();

            return JsonSerializer.Deserialize<PokemonData>(json);
        }
    }
    #endregion

    #region snippet2
    public class GoodStreamReaderController : Controller
    {
        [HttpGet("/pokemon")]
        public async Task<ActionResult<PokemonData>> Get()
        {
            // This asynchronously reads the entire http request body into memory.
            var json = await new StreamReader(Request.Body).ReadToEndAsync();

            return JsonSerializer.Deserialize<PokemonData>(json);
        }

    }
    #endregion
    public class PokemonData
    {
    }
}

