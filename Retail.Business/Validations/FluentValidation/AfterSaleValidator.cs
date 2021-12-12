using Retail.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Retail.Business.Validations.FluentValidation
{
    public class AfterSaleValidator : ValidatorEngine<AfterSale>
    {
        public AfterSaleValidator()
        {
            RuleFor(p => p.AfterSaleId).NotEmpty().NotNull();
            RuleFor(p => p.Detail).NotEmpty().NotNull();
            RuleFor(p => p.OrderId).NotEmpty().NotNull();
            RuleFor(p => p.Situation).NotEmpty().NotNull();
        }
    }
}
