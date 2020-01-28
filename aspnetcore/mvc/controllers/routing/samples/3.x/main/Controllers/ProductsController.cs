#define First
//#define Second
//#define Third

using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMvcRouting.Controllers
{
#if First
    #region snippet
    [Route("[controller]/[action]")]
    public class ProductsController : Controller
    {
        #region snippet10
        [HttpGet]               // Matches '/Products/List'
        public IActionResult List() {
            #endregion
            return View("Generic");
        }

        #region snippet11
        [HttpGet("{id}")]       // Matches '/Products/Edit/{id}'
        public IActionResult Edit(int id) {
            #endregion
            ViewData["Message"] = id.ToString();
            return View("Generic");
        }
    }
    #endregion
    // Was products2 controller
#elif Second
    #region snippet20
    public class ProductsController : Controller
    {
        #region snippet21
        [HttpGet("[controller]/[action]")] // Matches '/Products/List'
        public IActionResult List()
        {
            #endregion
            return View("Generic");
        }

        [HttpGet("[controller]/[action]/{id}")] // Matches '/Products/Edit/{id}'
        public IActionResult Edit(int id)
        {
            ViewData["Message"] = id.ToString();
            return View("Generic");
        }
    }
    #endregion
#elif Third
     [Route("[controller]")]
    public class ProductsController : Controller
    {
        [Route("")] // Matches 'Products'
        [Route("Index")] // Matches 'Products/Index'
        public IActionResult Index()
        {
            // ...
            return View("Generic");
        }
    }
#endif

}