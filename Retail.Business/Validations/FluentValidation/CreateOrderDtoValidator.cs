using Retail.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace Retail.Business.Validations.FluentValidation
{
    public class CreateOrderDtoValidator:ValidatorEngine<CreateOrderDto>
    {
        public CreateOrderDtoValidator()
        {
            //RuleFor(p => p.CustomerId).NotEmpty().NotNull();
        }
    }
}
