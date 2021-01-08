using System.ComponentModel.DataAnnotations;

namespace PetShop.Models.MyValidation
{
    public class BoolValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var hamster = (Hamster)validationContext.ObjectInstance;
            bool hasCage = hamster.HasCage;
            bool cond = true;
            if (hasCage.GetType() != typeof(bool))
            {
                cond = false;
            }

            return cond ? ValidationResult.Success : new ValidationResult("This is not a bool!");
        }

    }
}