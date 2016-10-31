/*using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMvcRouting.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductsController : Controller
    {
        [HttpGet] // Matches '/Products/List'
        public IActionResult List() {
            return View("Generic");
            // ...
        }

        [HttpGet("{id}")] // Matches '/Products/Edit/{id}'
        public IActionResult Edit(int id) {
            ViewData["Message"] = id.ToString();
            return View("Generic");
            // ...
        }
    }

}
*/