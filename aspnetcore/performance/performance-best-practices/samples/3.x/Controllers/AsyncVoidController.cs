using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

#if BAD
namespace performance_best_practices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    #region snippit1
    public class AsyncVoidController : Controller
    {
        [HttpGet("/async")]
        public async void Get()
        {
            await Task.Delay(1000);

            // THIS will crash the process since we're writing after the response has completed on a background thread
            await Response.WriteAsync("Hello World");
        }
    }
    #endregion
}
#endif