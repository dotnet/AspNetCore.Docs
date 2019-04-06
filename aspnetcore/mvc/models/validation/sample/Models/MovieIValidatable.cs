using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ValidationSample.Models
{
    #region snippet
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

        [Range(0, 999.99)]
        public decimal Price { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public bool Preorder { get; set; }

        #region snippet_Validate
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Genre == Genre.Classic && ReleaseDate.Year > _classicYear)
            {
                yield return new ValidationResult(
                    $"Classic movies must have a release year earlier than {_classicYear}.",
                    new[] { "ReleaseDate" });
            }
        }
        #endregion
    }
    #endregion
}
