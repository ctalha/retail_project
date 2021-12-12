using FluentValidation;
using FluentValidation.Results;
using Retail.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Business.Validations.FluentValidation
{
    public class OrderDetailDtoValidator : ValidatorEngine<OrderDetailDto>
    {
        public OrderDetailDtoValidator()
        {
            RuleFor(p => p.Customer).NotNull();
            RuleFor(p => p.Products).NotNull();
        }
    }
}
