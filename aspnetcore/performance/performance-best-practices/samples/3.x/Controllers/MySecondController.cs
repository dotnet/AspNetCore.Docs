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
    #region snippet1
    public class MySecondController : Controller
    {
        [HttpPost("/form-body")]
        public IActionResult Post()
        {
            var form = HttpRequest.Form;

            Process(form["id"], form["name"]);

            return Accepted();
        }
    }
    #endregion
#else
    #region snippet2
    public class MySecondController : Controller
    {
          [HttpPost("/form-body")]
        public async Task<IActionResult> Post()
        {
            var form = await HttpRequest.ReadAsFormAsync();

            Process(form["id"], form["name"]);

            return Accepted();
        }
    }
    #endregion
#endif
}
*/
