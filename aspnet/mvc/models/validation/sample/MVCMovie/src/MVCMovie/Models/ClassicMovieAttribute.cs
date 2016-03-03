using Microsoft.AspNet.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MVCMovie.Models
{
    public class ClassicMovieAttribute : ValidationAttribute 
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
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Classic movies must have a release year earlier than " + this._year);
                }
            }
            return ValidationResult.Success;
        }
    }
}













//, IClientModelValidator
//IEnumerable<ModelClientValidationRule> IClientModelValidator.GetClientValidationRules(ClientModelValidationContext context)
//{
//    var rule = new ModelClientValidationRule("classicmovie","Classic movies must have a release year earlier than " + this._year);
//    yield return rule;
//}