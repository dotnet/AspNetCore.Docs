using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiSample.DataAccess.Models;
using WebApiSample.DataAccess.Repositories;

namespace WebApiSample.Api.Controllers
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
        public ActionResult<Product> GetById(int id)
        {
            if (!_repository.TryGetProduct(id, out var product))
            {
                return NotFound();
            }

            return product;
        }
        #endregion

        #region snippet_BindingSourceAttributes
        [HttpGet]
        public ActionResult<List<Product>> Get([FromQuery] bool discontinuedOnly = false)
        {
            List<Product> products = null;

            if (discontinuedOnly)
            {
                products = _repository.GetDiscontinuedProducts();
            }
            else
            {
                products = _repository.GetProducts();
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

            return CreatedAtAction(nameof(GetById), 
                new { id = product.Id }, product);
        }
    }
}