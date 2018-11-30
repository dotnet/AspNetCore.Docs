using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiSample.DataAccess.Models;
using WebApiSample.DataAccess.Repositories;

namespace WebApiSample.Api._21.Controllers
{
    #region snippet_ControllerSignature
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    #endregion
    {
        private readonly ProductsRepository _repository;

        public ProductsController(ProductsRepository repository)
        {
            _repository = repository;
        }

        #region snippet_GetById
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Product>> GetByIdAsync(int id)
        {
            var product = await _repository.GetProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        #endregion

        #region snippet_BindingSourceAttributes
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
        #endregion

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