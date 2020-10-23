/*using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMvcRouting2.Controllers
{
    
    public class ProductsController : Controller
    {
        [HttpGet("[controller]/[action]")] // Matches '/Products/List'
        public IActionResult List() {
            return View("Generic");
            // ...
        }

        [HttpGet("[controller]/[action]/{id}")] // Matches '/Products/Edit/{id}'
        public IActionResult Edit(int id) {
            ViewData["Message"] = id.ToString();
            return View("Generic");
            // ...
        }
    }

}
*/