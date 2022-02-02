using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;

namespace ValidationSample.Validation;

// <snippet_Class>
public class CustomValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
{
    private readonly IValidationAttributeAdapterProvider baseProvider =
        new ValidationAttributeAdapterProvider();

    public IAttributeAdapter? GetAttributeAdapter(
        ValidationAttribute attribute, IStringLocalizer? stringLocalizer)
    {
        if (attribute is ClassicMovieAttribute classicMovieAttribute)
        {
            return new ClassicMovieAttributeAdapter(classicMovieAttribute, stringLocalizer);
        }

        return baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
    }
}
// </snippet_Class>
