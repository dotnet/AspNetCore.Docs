using System.Collections.Generic;
using System.Linq;

namespace MvcApplication1.Models
{
    public class ProductRepository : MvcApplication1.Models.IProductRepository
    {
        private ProductDBEntities _entities = new ProductDBEntities();

        public IEnumerable<Product> ListProducts()
        {
            return _entities.ProductSet.ToList();
        }

        public bool CreateProduct(Product productToCreate)
        {
            try
            {
                _entities.AddToProductSet(productToCreate);
                _entities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }

    public interface IProductRepository
    {
        bool CreateProduct(Product productToCreate);
        IEnumerable<Product> ListProducts();
    }

}