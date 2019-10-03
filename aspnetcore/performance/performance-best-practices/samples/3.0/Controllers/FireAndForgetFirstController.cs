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
        public IActionResult BadFireAndForget()
        {
            _ = Task.Run(async () =>
            {
                await Task.Delay(1000);

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
        public IActionResult GoodFireAndForget()
        {
            string path = HttpContext.Request.Path;
            _ = Task.Run(async () =>
            {
                await Task.Delay(1000);

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

