using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiSample.DataAccess.Models;
using WebApiSample.DataAccess.Repositories;

namespace WebApiSample.Api.Controllers
{
    #region snippet_OrdersController
    public class OrdersController : Controller
    {
        private readonly OrdersRepository _repository;

        public OrdersController(OrdersRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index() => View();

        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        public ActionResult<Order> GetById(int id)
        {
            if (!_repository.TryGetOrder(id, out var order))
            {
                return NotFound();
            }

            return order;
        }

        [HttpPost]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Order>> CreateAsync(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddOrderAsync(order);

            return CreatedAtAction(nameof(GetById),
                new { id = order.Id }, order);
        }
    }
    #endregion
}