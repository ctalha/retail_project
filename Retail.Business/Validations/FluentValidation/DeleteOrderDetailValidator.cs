using Retail.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace Retail.Business.Validations.FluentValidation
{
    public class DeleteOrderDetailValidator : ValidatorEngine<DeleteOrderDetail>
    {
        public DeleteOrderDetailValidator()
        {
            RuleFor(p => p.CustomerId).NotNull().NotNull();
            RuleFor(p => p.OrderId).NotNull().NotNull();
            RuleFor(p => p.ProductIds).NotNull().NotNull();
        }
    }
}
