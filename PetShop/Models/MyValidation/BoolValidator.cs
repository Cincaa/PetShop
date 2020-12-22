using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetShop.Models.MyValidation
{
    public class BoolValidator: ValidationAttribute
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

            return cond ? ValidationResult.Success : new ValidationResult("This is not a bool number!");
        }

    }
}