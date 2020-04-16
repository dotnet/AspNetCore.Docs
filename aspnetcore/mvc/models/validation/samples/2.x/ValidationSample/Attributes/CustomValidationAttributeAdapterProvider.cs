using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using ValidationSample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ValidationSample.Attributes
{
    #region snippet_CustomValidationAttributeAdapterProvider
    public class CustomValidationAttributeAdapterProvider :
        IValidationAttributeAdapterProvider
    {
        IValidationAttributeAdapterProvider baseProvider =
            new ValidationAttributeAdapterProvider();
        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute,
            IStringLocalizer stringLocalizer)
        {
            if (attribute is ClassicMovieAttribute classicMovieAttribute)
            {
                return new ClassicMovieAttributeAdapter(classicMovieAttribute, stringLocalizer);
            }
            else
            {
                return baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
            }
        }
    }
    #endregion
}
