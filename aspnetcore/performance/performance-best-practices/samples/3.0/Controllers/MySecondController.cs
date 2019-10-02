using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace performance_best_practices.Controllers
{
    // Requires review, Original
    //  var form = HttpRequest.Form;
    #region snippet1
    [Route("api/[controller]")]
    [ApiController]
    public class BadReadController : Controller
    {
        [HttpPost("/form-body")]
        public IActionResult Post()
        {
            var form =  HttpContext.Request.Form;

            Process(form["id"], form["name"]);

            return Accepted();
        }
    #endregion
        private void Process(object p1, object p2)
        {
            throw new NotImplementedException();
        }
    }

    // Requires review, Original
    //  var form = await HttpRequest.ReadAsFormAsync();
    #region snippet2
    [Route("api/[controller]")]
    [ApiController]
    public class GoodReadController : Controller
    {
        [HttpPost("/form-body")]
        public async Task<IActionResult> Post()
        {
           var form = await HttpContext.Request.ReadFormAsync();

            Process(form["id"], form["name"]);

            return Accepted();
        }
        #endregion
        private void Process(object p1, object p2)
        {
            throw new NotImplementedException();
        }
    }

}

