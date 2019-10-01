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
    public class FireAndForgetFirstController : Controller
    {
    #region snippet1
        [HttpGet("/fire-and-forget-1")]
        public IActionResult FireAndForget1()
        {
            _ = Task.Run(() =>
            {
                await Task.Delay(1000);

                // This closure is capturing the context from the Controller property. This is bad because this work item could run
                // outside of the http request leading to reading of bogus data.
                var path = HttpContext.Request.Path;
                Log(path);
            });

            return Accepted();
        }
    #endregion
    }
#else
    public class FireAndForgetFirstController : Controller
    {
        #region snippet2
        [HttpGet("/fire-and-forget-3")]
        public IActionResult FireAndForget3()
        {
            string path = HttpContext.Request.Path;
            _ = Task.Run(async () =>
            {
                await Task.Delay(1000);

                // This captures just the path
                Log(path);
            });

            return Accepted();
        }
        #endregion
    }
#endif
}
*/