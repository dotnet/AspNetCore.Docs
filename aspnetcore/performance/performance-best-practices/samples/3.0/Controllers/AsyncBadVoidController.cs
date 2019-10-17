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

            // The following line will crash the process because of writing after the 
            // response has completed on a background thread. Notice async void Get()

            await Response.WriteAsync("Hello World");
        }
    }
    #endregion
}