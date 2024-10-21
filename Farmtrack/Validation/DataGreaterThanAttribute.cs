using System.ComponentModel.DataAnnotations;

namespace Farmtrack.Validation
{
    public class DataGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DataGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (property == null)
            {
                return new ValidationResult($"Unknown property {_comparisonProperty}");
            }

            var comparisonValue = property.GetValue(validationContext.ObjectInstance);
            if (value == null || comparisonValue == null)
            {
                return ValidationResult.Success;
            }

            if ((value as IComparable).CompareTo(comparisonValue) > 0)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"{validationContext.DisplayName} should be greater than {property.Name}");
        }
    }
}
