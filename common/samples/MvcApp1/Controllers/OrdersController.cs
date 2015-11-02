using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcApp1.Controllers
{
    public class OrdersController : Controller
    {
        [Route("orders/{orderid}")]
        public IActionResult GetOrderByID(int orderid)
        {
            return View(new { OrderID = orderid });
        }
    }
}
