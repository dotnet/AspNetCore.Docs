using System.ComponentModel.DataAnnotations;
namespace SuperheroSample.Models
{
    public class Superhero
    {
        [Required]
        public string Name { get; set; }

        public bool WearsCape { get; set; }
    }
}