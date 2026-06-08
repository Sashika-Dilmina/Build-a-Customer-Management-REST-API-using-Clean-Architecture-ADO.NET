using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Application.Validation;

public class DateNotInFutureAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(
        object? value,
        ValidationContext validationContext)
    {
        if (value is DateTime date &&
            date > DateTime.Today)
        {
            return new ValidationResult(
                "Date of birth cannot be in the future.");
        }

        return ValidationResult.Success;
    }
}