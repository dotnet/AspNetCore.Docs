using System.ComponentModel.DataAnnotations;

namespace WebApiSample.DataAccess.Models
{
    #region snippet_ProductClass
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
    #endregion
}
