using System;
using System.ComponentModel.DataAnnotations;

namespace ValidationIssue.Data.Validation
{
    #region snippet
    class CurrentOrFutureDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, 
                                               ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            DateTime dt = (DateTime)value;
            if (dt >= DateTime.Today)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Date can't be in the past.",
                                        new[] { validationContext.MemberName });
        }
        #endregion
    }
}
