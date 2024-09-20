using System.ComponentModel.DataAnnotations;

namespace UTB.Eshop.Domain.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class FirstLetterCapitalizedCZAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            else if (value is string text)
            {
                if (text == String.Empty)
                    return ValidationResult.Success;

                if (text.First() >= 'A' && text.First() <= 'Z'
                 || text.First() == 'Š' || text.First() == 'Č' || text.First() == 'Ř' || text.First() == 'Ž'
                 || text.First() == 'Ý' || text.First() == 'Á' || text.First() == 'Í' || text.First() == 'É'
                 || text.First() == 'Ú' || text.First() == 'Ď' || text.First() == 'Ň' || text.First() == 'Ó'
                 || text.First() == 'Ť' || text.First() == 'Ě' || text.First() == 'Ů')
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"The {validationContext.MemberName} field does not contain the first capital letter.");
                }
            }
            else
            {
                throw new NotImplementedException($"The {nameof(FirstLetterCapitalizedCZAttribute)} is not implemented for the type: {value.GetType()}");
            }
        }
    }
}
