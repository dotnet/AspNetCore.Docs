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
            return await JsonSerializer.DeserializeAsync<PokemonData>(Request.Body);
        }

    }
    #endregion
    public class PokemonData
    {
    }
}

