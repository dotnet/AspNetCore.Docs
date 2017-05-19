using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class ContactEditViewModel
    {
        public int ContactId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
