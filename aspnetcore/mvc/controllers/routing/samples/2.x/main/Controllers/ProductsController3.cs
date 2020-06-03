#define A3
#if A3
using Microsoft.AspNetCore.Mvc;

namespace WebMvcRouting3.Controllers
{

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

}

#endif