using System.ComponentModel.DataAnnotations;

namespace FileUploadSample.Models
{
    public class User
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(5, ErrorMessage = "Name of the user must be at least 5 characters long.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 45, ErrorMessage = "Age must be between 18 and 45 (inclusive)")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Zipcode is required")]
        public int Zipcode { get; set; }
    }
}
