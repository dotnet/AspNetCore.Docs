using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.DataAccess.Models;
using WebApiSample.DataAccess.Repositories;

namespace WebApiSample.Api._22.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductsRepository _repository;

        public ProductsController(ProductsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Product>> GetByIdAsync(int id)
        {
            var product = await _repository.GetProductAsync(id);

            #region snippet_ProblemDetailsStatusCode
            if (product == null)
            {
                return NotFound();
            }
            #endregion

            return product;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAsync(
            [FromQuery] bool discontinuedOnly = false)
        {
            List<Product> products = null;

            if (discontinuedOnly)
            {
                products = await _repository.GetDiscontinuedProductsAsync();
            }
            else
            {
                products = await _repository.GetProductsAsync();
            }

            return products;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Product>> CreateAsync(Product product)
        {
            await _repository.AddProductAsync(product);

            return CreatedAtAction(nameof(GetByIdAsync),
                new { id = product.Id }, product);
        }
    }
}
