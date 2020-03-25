using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                        Name = "Learning EF Core",
                        Description = "A best-selling book covering the fundamentals of Entity Framework Core"
                    },
                    new Product
                    {
                        Name = "Learning ASP.NET Core",
                        Description = "A best-selling book covering the fundamentals of ASP.NET Core"
                    });
                _context.SaveChanges();
            }
        }

        public List<Product> GetProducts() =>
            _context.Products.OrderBy(p => p.Name).ToList();

        public bool TryGetProduct(int id, out Product product)
        {
            product = _context.Products.Find(id);
            
            return (product != null);
        }

        public async Task<int> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }
    }
}
