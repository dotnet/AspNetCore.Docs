using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ValidationSample.Models
{
    // <snippet_Class>
    public class ValidatableMovie : IValidatableObject
    {
        private const int _classicYear = 1960;

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Range(0, 999.99)]
        public decimal Price { get; set; }

        public Genre Genre { get; set; }

        public bool Preorder { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Genre == Genre.Classic && ReleaseDate.Year > _classicYear)
            {
                yield return new ValidationResult(
                    $"Classic movies must have a release year no later than {_classicYear}.",
                    new[] { nameof(ReleaseDate) });
            }
        }
    }
    // </snippet_Class>
}
