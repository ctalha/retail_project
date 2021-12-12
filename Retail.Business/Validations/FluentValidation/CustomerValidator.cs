using Retail.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Retail.Business.Validations.FluentValidation
{
    public class CustomerValidator : ValidatorEngine<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().MaximumLength(11).MinimumLength(11);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.TcNo).MaximumLength(11).MinimumLength(11);
        }
    }
}
