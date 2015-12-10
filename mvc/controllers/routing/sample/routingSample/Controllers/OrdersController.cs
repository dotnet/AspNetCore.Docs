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

        [HttpPost]
        [Route("{orderId:int}")]
        public IActionResult UpdateOrderById(int orderId, OrderViewModel order)
        {
            return Redirect($"/orders/{orderId}");
        }

        [HttpGet]
        [Route("{orderId:int}")]
        public IActionResult GetByOrderID(int orderId)
        {
            var order = new OrderViewModel()
            {
                OrderID = orderId,
                Cost = 100m,
                Subject = "BackToSchoolOrder"
            };

            return View(order);
        }

        [Route("{subject:alpha}")]
        public IActionResult GetByOrderSubject(string subject)
        {
            return View(new OrderViewModel() { Subject = subject });
        }

        [Route("~/my-orders")]
        public IActionResult GetMyOrders()
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

            // Normally we'd not hard code this :)
            return View(orderList.Where(o => o.Client == "Scott").ToList());
        }

#if not_a_symbol
       
        [Route("orders/{orderId}")]
        public IActionResult GetByOrderID(int orderId)
        {
            var order = new OrderViewModel()
            {
                OrderID = orderId,
                Cost = 100m,
                Subject = "BackToSchoolOrder"
            };

            return View(order);
        }

#endif

    }
}
