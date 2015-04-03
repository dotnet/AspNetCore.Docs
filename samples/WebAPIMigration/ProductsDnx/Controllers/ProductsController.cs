using Microsoft.AspNet.Mvc;
using ProductsDnx.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductsDnx.Controllers
{
    public class ProductsController : Controller
    {
        Product[] products = new Product[] 
        { 
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(product);
        }
    }
}
