using Microsoft.AspNet.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MVCMovie.Models
{
    public class ClassicMovieAttribute : ValidationAttribute, IClientModelValidator
    {
        private int _year;
        public ClassicMovieAttribute(int Year)
        {
            _year = Year;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Movie movie = (Movie)validationContext.ObjectInstance;

            if (movie.Genre == Genre.Classic)
            {
                if (movie.ReleaseDate.Year < this._year)
                {
                    return new ValidationResult(
                        "Classic movies must have a release year earlier than " + this._year);

                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule>
        GetClientValidationRules(ClientModelValidationContext context)
        {
            yield return new ModelClientValidationRule("classicmovie", 
                "Classic movies must have a release year earlier than " + this._year);
        }
    }
}
