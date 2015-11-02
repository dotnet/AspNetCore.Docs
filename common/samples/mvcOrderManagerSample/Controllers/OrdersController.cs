using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mvcOrderManagerSample.Models;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace mvcOrderManagerSample.Controllers
{
    [Route("orders")]
    public class OrdersController : Controller
    {
        [Route("")]
        public IActionResult ViewOrders()
        {
            var orderList = new List<OrderModel>()
            {
                new OrderModel()
                {
                    OrderID = 1000,
                    Client = "Scott",
                    Cost = 10m,
                    Description = "Erasers"
                },
                new OrderModel()
                {
                    OrderID = 1001,
                    Client = "Rob",
                    Cost = 12m,
                    Description = "Markers"
                },
                new OrderModel()
                {
                    OrderID = 1002,
                    Client = "ScottHa",
                    Cost = 14m,
                    Description = "BluRay"
                }
            };
            return View(orderList);
        }

        [Route("{orderId}")]
        public IActionResult GetByOrderID(int orderId)
        {
            return View(new OrderViewModel() {OrderID = orderId});
        }
    }
}
