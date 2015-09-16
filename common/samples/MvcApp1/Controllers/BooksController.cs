using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcApp1.Controllers
{
    [Route("books/[action]/")]
    public class BooksController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sell()
        {

            return View();
        }


        [Route("{bookName}")] // Token = [Something] Template = {something}
        public IActionResult FindBook(string bookName)
        {
            return View();
        }
    }
}
