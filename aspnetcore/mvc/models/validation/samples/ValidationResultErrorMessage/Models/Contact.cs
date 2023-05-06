using System.ComponentModel.DataAnnotations;

namespace ValidationResultErrorMessage.Models;

public class Contact
{
    public Guid Id { get; set; }

    [ValidateName(ErrorMessage = "Name must be at least 3 characters long.")] public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}

public class ValidateNameAttribute : ValidationAttribute
{
    public ValidateNameAttribute()
    {
        // Default error message
        const string defaultErrorMessage = "Error with Inputted Name";
        ErrorMessage ??= defaultErrorMessage;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Name is required.");
        }

        if (value.ToString()!.Length < 3)
        {

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        return ValidationResult.Success;
    }

}
