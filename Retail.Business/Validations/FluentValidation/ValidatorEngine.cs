using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Business.Validations.FluentValidation
{
    public class ValidatorEngine<T>:AbstractValidator<T>
    {
        public override ValidationResult Validate(ValidationContext<T> context)
        {
            var validationResult = base.Validate(context);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            return validationResult;
        }
    }
}
