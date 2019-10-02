using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace performance_best_practices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FireAndForgetBadController : Controller
    {
        #region snippet1
        [HttpGet("/fire-and-forget-1")]
        public IActionResult FireAndForget1()
        {
            _ = Task.Run(async () =>
            {
                await Task.Delay(1000);

                // This closure is capturing the context from the Controller property. This
                // is bad because this work item could run outside of the HTTP request 
                // leading to reading of incorrect data.
                var path = HttpContext.Request.Path;
                Log(path);
            });

            return Accepted();
        }
        #endregion

        private void Log(PathString path)
        {
            throw new NotImplementedException();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class FireAndForgetGoodController : Controller
    {
        #region snippet2
        [HttpGet("/fire-and-forget-3")]
        public IActionResult FireAndForget3()
        {
            string path = HttpContext.Request.Path;
            _ = Task.Run(async () =>
            {
                await Task.Delay(1000);

                // This captures just the path.
                Log(path);
            });

            return Accepted();
        }
        #endregion
        private void Log(PathString path)
        {
            throw new NotImplementedException();
        }
    }

}

