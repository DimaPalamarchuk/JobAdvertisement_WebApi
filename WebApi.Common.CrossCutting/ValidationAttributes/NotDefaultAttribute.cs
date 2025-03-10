using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Common.CrossCutting.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
    public class NotDefaultAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "The {0} field must not have the default value";
        public NotDefaultAttribute() : base(DefaultErrorMessage)
        { 
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return ValidationResult.Success;
            }

            var type = value.GetType();
            if (type.IsValueType)
            {
                var defaltValue = Activator.CreateInstance(type);
                return !value.Equals(defaltValue)
                        ? ValidationResult.Success!
                        : new ValidationResult("VALUEE_IS_REQUIRED"); ;
            }

            return ValidationResult.Success!;
        }
    }
}
