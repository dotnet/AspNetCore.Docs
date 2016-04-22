using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMovie.Models
{
    public class MovieIValidatable : IValidatableObject
    {
        private const int _classicYear = 1960;
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required()]
        [Range(0, 999.99)]
        public float Price { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public Audience Audience { get; set; }
        public List<Review> Reviews { get; set; }

        public IEnumerable<ValidationResult> 
            Validate(ValidationContext validationContext)
        {
            if (Genre == Genre.Classic)
            {
                if (ReleaseDate.Year > _classicYear)
                {
                    yield return new ValidationResult(
                        "Classic movies must have a release year earlier than " + _classicYear, 
                        new[] { "ReleaseDate" });
                }
            }
        }
    }
}
