using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown ||
               customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Data de nascimento é necessário para esse tipo de plano.");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age > 18)
                ? ValidationResult.Success
                : new ValidationResult("Clientes precisam ter, pelo menos, 18 anos para aderir à algum plano.");
        }
    }
}