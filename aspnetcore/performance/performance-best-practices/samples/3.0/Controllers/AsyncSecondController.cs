using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace performance_best_practices.Controllers
{
    #region snippet1
    public class AsyncGoodTaskController : Controller
    {
        [HttpGet("/async")]
        public async Task Get()
        {
            await Task.Delay(1000);

            await Response.WriteAsync("Hello World");
        }
    }
    #endregion
}
