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
        [ProducesResponseType(typeof(Order), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            if (!_repository.TryGetOrder(id, out var order))
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Order), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateAsync([FromBody] Order order)
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
