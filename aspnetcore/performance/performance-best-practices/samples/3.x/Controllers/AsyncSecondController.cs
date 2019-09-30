using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

#if BAD
namespace performance_best_practices.Controllers
{
#region snippet1
    public class AsyncSecondController : Controller
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
#endif