using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.DataAccess.Models;
using WebApiSample.DataAccess.Repositories;

namespace WebApiSample.Api.Pre21.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductsRepository _repository;

        public ProductsController(ProductsRepository repository)
        {
            _repository = repository;
        }

        #region snippet_Get
        [HttpGet]
        public List<Product> Get() =>
            _repository.GetProducts();
        #endregion

        #region snippet_GetById
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            if (!_repository.TryGetProduct(id, out var product))
            {
                return NotFound();
            }

            return Ok(product);
        }
        #endregion

        #region snippet_CreateAsync
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] Product product)
        {
            if (product.Description.Contains("XYZ Widget"))
            {
                return BadRequest();
            }

            await _repository.AddProductAsync(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
        #endregion
    }
}
