#define IActionResult // or ActionResultOfT

using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.DataAccess.Models;
using WebApiSample.DataAccess.Repositories;

namespace WebApiSample.Api._31.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsRepository _repository;

        public ProductsController(ProductsRepository repository)
        {
            _repository = repository;
        }

#if IActionResult
        // <snippet_GetByIdIActionResult>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            if (!_repository.TryGetProduct(id, out var product))
            {
                return NotFound();
            }

            return Ok(product);
        }
        // </snippet_GetByIdIActionResult>

        // <snippet_CreateAsyncIActionResult>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(Product product)
        {
            if (product.Description.Contains("XYZ Widget"))
            {
                return BadRequest();
            }

            await _repository.AddProductAsync(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
        // </snippet_CreateAsyncIActionResult>
#endif

#if ActionResultOfT
        // <snippet_GetByIdActionResultOfT>
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
        // </snippet_GetByIdActionResultOfT>

        // <snippet_CreateAsyncActionResultOfT>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
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
        // </snippet_CreateAsyncActionResultOfT>
#endif

        // <snippet_Get>
        [HttpGet]
        public List<Product> Get() =>
            _repository.GetProducts();
        // </snippet_Get>

        // <snippet_GetOnSaleProducts>
        [HttpGet("syncsale")]
        public IEnumerable<Product> GetOnSaleProducts()
        {
            var products = _repository.GetProducts();

            foreach (var product in products)
            {
                if (product.IsOnSale)
                {
                    yield return product;
                }
            }
        }
        // </snippet_GetOnSaleProducts>

        // <snippet_GetOnSaleProductsAsync>
        [HttpGet("asyncsale")]
        public async IAsyncEnumerable<Product> GetOnSaleProductsAsync()
        {
            var products = _repository.GetProductsAsync();

            await foreach (var product in products)
            {
                if (product.IsOnSale)
                {
                    yield return product;
                }
            }
        }
        // </snippet_GetOnSaleProductsAsync>
    }
}
