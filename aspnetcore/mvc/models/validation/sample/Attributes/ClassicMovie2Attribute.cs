using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ValidationSample.Models;

namespace ValidationSample.Attributes
{
    // The ClassicMovie2 attribute is an
    // example that doesn't use an AttributeAdapter to
    // provide client-side validation.

    #region snippet_ClassicMovie2Attribute

    public class ClassicMovie2Attribute : ValidationAttribute, IClientModelValidator
    {
        private int _year;

        public ClassicMovie2Attribute(int year)
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

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-classicmovie", GetErrorMessage());

            var year = _year.ToString(CultureInfo.InvariantCulture);
            MergeAttribute(context.Attributes, "data-val-classicmovie-year", year);
        }
        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }

            attributes.Add(key, value);
            return true;
        }
        protected string GetErrorMessage()
        {
            return $"Classic movies must have a release year no later than {_year} [from attribute 2].";
        }
    }
#endregion

}
