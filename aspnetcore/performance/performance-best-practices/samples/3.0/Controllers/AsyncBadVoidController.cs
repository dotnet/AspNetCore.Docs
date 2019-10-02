using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace performance_best_practices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    #region snippet1
    public class AsyncBadVoidController : Controller
    {
        [HttpGet("/async")]
        public async void Get()
        {
            await Task.Delay(1000);

            // THIS will crash the process because it's writing after the response has 
            // completed on a background thread.
            await Response.WriteAsync("Hello World");
        }
    }
    #endregion
}