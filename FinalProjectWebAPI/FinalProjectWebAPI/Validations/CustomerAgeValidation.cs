using System.ComponentModel.DataAnnotations;

namespace FinalProjectWebAPI.Validations
{
    public class CustomerAgeValidation : ValidationAttribute
    {
        private readonly int _minimumAge;

        public CustomerAgeValidation(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime birthDate)
            {
                var today = DateTime.Today;
                var age = today.Year - birthDate.Year;
                if (birthDate > today.AddYears(-age))
                    age--;
                if (age >= _minimumAge)
                    return ValidationResult.Success;
                else
                    return new ValidationResult($"You must be at least {_minimumAge} years old.");
            }
            return new ValidationResult("Invalid date format.");
        }
    }
}
