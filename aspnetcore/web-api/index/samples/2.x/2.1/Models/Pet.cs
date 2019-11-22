using System.ComponentModel.DataAnnotations;

namespace WebApiSample.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        public string Breed { get; set; }

        public string Name { get; set; }

        [Required]
        public PetType PetType { get; set; }
    }

    public enum PetType
    {
        Dog = 0,
        Cat = 1
    }
}
