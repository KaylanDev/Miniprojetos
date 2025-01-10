using System.ComponentModel.DataAnnotations;

namespace Catalogo.Validations
{
    public class PrimeiraLetraMaiusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString())) {
             return ValidationResult.Success;
            }

            string PrimeiraLetra = value.ToString()[0].ToString();
            if (PrimeiraLetra != PrimeiraLetra.ToUpper())
            {
                return new ValidationResult("A primeira Letra deve ser maiuscula!");
            }
            return ValidationResult.Success;
        }
    }
}
