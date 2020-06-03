using Microsoft.AspNetCore.Mvc;
using Microsoft.Docs.Samples;


namespace WebMvcRouting.Controllers
{
    #region snippet
    [Route("api/[controller]")]
    [ApiController]
    public class Test2Controller : ControllerBase
    {
        [HttpGet]   // GET /api/test2
        public IActionResult ListProducts()
        {
            return ControllerContext.MyDisplayRouteInfo();
        }

        #region snippet2
        [HttpGet("{id}")]   // GET /api/test2/xyz
        public IActionResult GetProduct(string id)
        {
           return ControllerContext.MyDisplayRouteInfo(id);
        }
        #endregion

        #region snippet3
        [HttpGet("int/{id:int}")] // GET /api/test2/int/3
        public IActionResult GetIntProduct(int id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }
        #endregion

        #region snippet4
        [HttpGet("int2/{id}")]  // GET /api/test2/int2/3
        public IActionResult GetInt2Product(int id)
        {
            return ControllerContext.MyDisplayRouteInfo(id);
        }
        #endregion
    }
    #endregion
}