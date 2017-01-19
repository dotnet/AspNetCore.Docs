using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    public class ProductService : MvcApplication1.Models.IProductService
    {

        private ModelStateDictionary _modelState;
        private IProductRepository _repository;

        public ProductService(ModelStateDictionary modelState, IProductRepository repository)
        {
            _modelState = modelState;
            _repository = repository;
        }

        protected bool ValidateProduct(Product productToValidate)
        {
            if (productToValidate.Name.Trim().Length == 0)
                _modelState.AddModelError("Name", "Name is required.");
            if (productToValidate.Description.Trim().Length == 0)
                _modelState.AddModelError("Description", "Description is required.");
            if (productToValidate.UnitsInStock < 0)
                _modelState.AddModelError("UnitsInStock", "Units in stock cannot be less than zero.");
            return _modelState.IsValid;
        }

        public IEnumerable<Product> ListProducts()
        {
            return _repository.ListProducts();
        }

        public bool CreateProduct(Product productToCreate)
        {
            // Validation logic
            if (!ValidateProduct(productToCreate))
                return false;

            // Database logic
            try
            {
                _repository.CreateProduct(productToCreate);
            }
            catch
            {
                return false;
            }
            return true;
        }

    }

    public interface IProductService
    {
        bool CreateProduct(Product productToCreate);
        IEnumerable<Product> ListProducts();
    }
}