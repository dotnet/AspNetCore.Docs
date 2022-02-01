using System;
using System.ComponentModel.DataAnnotations;
using ValidationSample.Models;

namespace ValidationSample.Validation
{
    // <snippet_Class>
    public class ClassicMovieAttribute : ValidationAttribute
    {
        public ClassicMovieAttribute(int year)
        {
            Year = year;
        }

        public int Year { get; }

        public string GetErrorMessage() =>
            $"Classic movies must have a release year no later than {Year}.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            var releaseYear = ((DateTime)value).Year;

            if (movie.Genre == Genre.Classic && releaseYear > Year)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
    // </snippet_Class>
}
