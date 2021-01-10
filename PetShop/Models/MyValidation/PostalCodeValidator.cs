using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetShop.Models.MyValidation
{
    public class PostalCodeValidator: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var address = (Address)validationContext.ObjectInstance;
            int postalCode = address.PostalCode;
            bool cond = false;
            if (postalCode >= 100000 && postalCode <=999999)
            {
                cond = true;
            }

            return cond ? ValidationResult.Success : new ValidationResult("This is not a valid postal code!");
        }
    }
}