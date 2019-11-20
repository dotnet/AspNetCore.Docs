using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using ValidationSample.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ValidationSample.Attributes
{
    #region snippet_ClassicMovieAttributeAdapter
    public class ClassicMovieAttributeAdapter : AttributeAdapterBase<ClassicMovieAttribute>
    {
        private int _year;

        public ClassicMovieAttributeAdapter(ClassicMovieAttribute attribute, IStringLocalizer stringLocalizer) : base (attribute, stringLocalizer)
        {
            _year = attribute.Year;
        }
        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-classicmovie", GetErrorMessage(context));

            var year = Attribute.Year.ToString(CultureInfo.InvariantCulture);
            MergeAttribute(context.Attributes, "data-val-classicmovie-year", year);
        }
        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return Attribute.GetErrorMessage();
        }
    }
    #endregion
}
