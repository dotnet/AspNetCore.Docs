using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiSample.DataAccess.Models;

namespace WebApiSample.DataAccess.Repositories
{
    public class ProductsRepository
    {
        private readonly ProductContext _context;

        public ProductsRepository(ProductContext context)
        {
            _context = context;

            if (_context.Products.Count() == 0)
            {
                _context.Products.AddRange(
                    new Product
                    {
                        Name = "Learning ASP.NET Core",
                        Description = "A best-selling book covering the fundamentals of ASP.NET Core"
                    },
                    new Product
                    {
                        Name = "Learning EF Core",
                        Description = "A best-selling book covering the fundamentals of Entity Framework Core"
                    },
                    new Product
                    {
                        Name = "Learning .NET Standard",
                        Description = "A best-selling book covering the fundamentals of .NET Standard"
                    },
                    new Product
                    {
                        Name = "Learning .NET Core",
                        Description = "A best-selling book covering the fundamentals of .NET Core"
                    },
                    new Product
                    {
                        Name = "Learning C#",
                        Description = "A best-selling book covering the fundamentals of C#"
                    });
                _context.SaveChanges();
            }
        }

        public IEnumerable<Product> GetProducts() =>
            _context.Products.ToList();

        public async IAsyncEnumerable<Product> GetProductsByPageAsync(
            int pageNumber, 
            int pageSize)
        {
            var products = _context.Products
                                   .Skip(pageSize * (pageNumber - 1))
                                   .Take(pageSize)
                                   .AsAsyncEnumerable();

            await foreach (var product in products)
            {
                yield return product;
            }
        }

        public IEnumerable<Product> GetProductsByPage(
            int pageNumber,
            int pageSize)
        {
            var products = _context.Products
                                   .Skip(pageSize * (pageNumber - 1))
                                   .Take(pageSize);

            return products;
        }

        public bool TryGetProduct(int id, out Product product)
        {
            product = _context.Products.Find(id);

            return (product != null);
        }

        public async Task<int> AddProductAsync(Product product)
        {
            int rowsAffected = 0;

            _context.Products.Add(product);
            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }
    }
}
