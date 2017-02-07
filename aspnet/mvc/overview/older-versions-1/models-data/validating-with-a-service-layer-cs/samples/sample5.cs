using System.Collections.Generic;

namespace MvcApplication1.Models
{
    public class ProductService : IProductService
    {

        private IValidationDictionary _validatonDictionary;
        private IProductRepository _repository;

        public ProductService(IValidationDictionary validationDictionary, IProductRepository repository)
        {
            _validatonDictionary = validationDictionary;
            _repository = repository;
        }

        protected bool ValidateProduct(Product productToValidate)
        {
            if (productToValidate.Name.Trim().Length == 0)
                _validatonDictionary.AddError("Name", "Name is required.");
            if (productToValidate.Description.Trim().Length == 0)
                _validatonDictionary.AddError("Description", "Description is required.");
            if (productToValidate.UnitsInStock < 0)
                _validatonDictionary.AddError("UnitsInStock", "Units in stock cannot be less than zero.");
            return _validatonDictionary.IsValid;
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
        System.Collections.Generic.IEnumerable<Product> ListProducts();
    }
}