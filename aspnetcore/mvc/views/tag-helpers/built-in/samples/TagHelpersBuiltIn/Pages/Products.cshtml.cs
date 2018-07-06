using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TagHelpersBuiltIn.Models;

namespace TagHelpersBuiltIn.Pages
{
    public class ProductsModel : PageModel
    {
        public List<Product> Products { get; private set; }

        public void OnGet()
        {
            Products = new List<Product>
            {
                new Product
                {
                    Number = 1,
                    Name = "Test product 1",
                    Description = "This is a test product"
                },
                new Product
                {
                    Number = 2,
                    Name = "Test product 2",
                    Description = "This is another test product"
                }
            };
        }
    }
}
