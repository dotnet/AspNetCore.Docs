using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using TagHelpersBuiltIn.Models;

namespace TagHelpersBuiltIn.Pages
{
    public class ProductsModel : PageModel
    {
        public List<Product> Products { get; set; }

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
                    Name = "Test Product 2",
                    Description = "This is another test product"
                }
            };
        }
    }
}