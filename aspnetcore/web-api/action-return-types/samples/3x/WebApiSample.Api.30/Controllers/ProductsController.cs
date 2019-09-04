using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.DataAccess.Models;
using WebApiSample.DataAccess.Repositories;

namespace WebApiSample.Api._30.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsRepository _repository;

        public ProductsController(ProductsRepository repository)
        {
            _repository = repository;
        }

        #region snippet_Get
        [HttpGet]
        public IEnumerable<Product> Get() =>
            _repository.GetProducts();
        #endregion

        #region snippet_GetById
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> GetById(int id)
        {
            if (!_repository.TryGetProduct(id, out var product))
            {
                return NotFound();
            }

            return product;
        }
        #endregion

        #region snippet_GetNRecords
        [HttpGet("page/{pageSize:int:min(1)}")]
        public async IAsyncEnumerable<Product> GetNRecords(int pageSize)
        {
            var products = _repository.GetProductsByPage(1, pageSize);
            
            await foreach (var product in products)
            {
                yield return product;
            }
        }
        #endregion

        #region snippet_GetNPages
        [HttpGet("pages/{numPages:int:min(1)}/{pageSize:int:min(1)}")]
        public async IAsyncEnumerable<Product> GetNPages(int numPages, int pageSize)
        {
            for (int pageIndex = 0; pageIndex < numPages; pageIndex++)
            {
                var products = _repository.GetProductsByPage(pageIndex + 1, pageSize);

                await foreach (var product in products)
                {
                    yield return product;
                }
            }
        }
        #endregion

        #region snippet_CreateAsync
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> CreateAsync(Product product)
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
