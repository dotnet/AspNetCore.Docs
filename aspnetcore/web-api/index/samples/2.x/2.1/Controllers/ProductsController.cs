using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.Models;

namespace WebApiSample.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : MyControllerBase
    {
        private static readonly List<Product> _productsInMemoryStore = 
            new List<Product>();

        public ProductsController()
        {
            if (_productsInMemoryStore.Count == 0)
            {
                _productsInMemoryStore.Add(
                    new Product
                    {
                        Id = 1,
                        Name = "Learning EF Core 2nd edition",
                        Description = "The fundamentals of Entity Framework Core"
                    });
                _productsInMemoryStore.Add(
                    new Product
                    {
                        Id = 2,
                        Name = "Learning EF Core 1st edition",
                        Description = "The fundamentals of Entity Framework Core",
                        IsDiscontinued = true
                    });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> GetById(int id)
        {
            var product = _productsInMemoryStore.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        #region snippet_BindingSourceAttributes
        [HttpGet]
        public ActionResult<List<Product>> Get(
            [FromQuery] bool discontinuedOnly = false)
        {
            List<Product> products = null;

            if (discontinuedOnly)
            {
                products = _productsInMemoryStore.Where(p => p.IsDiscontinued).ToList();
            }
            else
            {
                products = _productsInMemoryStore;
            }

            return products;
        }
        #endregion

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> Create(Product product)
        {
            product.Id = _productsInMemoryStore.Any() ? 
                         _productsInMemoryStore.Max(p => p.Id) + 1 : 1;
            _productsInMemoryStore.Add(product);

            return CreatedAtAction(
                nameof(GetById), new { id = product.Id }, product);
        }
    }
}
