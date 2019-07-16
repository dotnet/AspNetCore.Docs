using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ValidationSample.Models;

namespace ValidationSample.Attributes
{
    // The ClassicMovie attribute is an
    // example that uses an AttributeAdapter to
    // provide client-side validation.

    #region snippet_ClassicMovieAttribute
    public class ClassicMovieAttribute : ValidationAttribute
    {
        private int _year;

        public ClassicMovieAttribute(int year)
        {
            _year = year;
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            var releaseYear = ((DateTime)value).Year;

            if (movie.Genre == Genre.Classic && releaseYear > _year)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        public int Year => _year;

        public string GetErrorMessage()
        {
            return $"Classic movies must have a release year no later than {_year}.";
        }
    }
#endregion
}
