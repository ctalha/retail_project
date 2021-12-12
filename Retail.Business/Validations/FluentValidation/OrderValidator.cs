using FluentValidation;
using Retail.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Business.Validations.FluentValidation
{
    public class OrderValidator :  ValidatorEngine<Order>
    {
        public OrderValidator()
        {
            RuleFor(p => p.CustomerId).NotNull().NotEmpty();
            RuleFor(p => p.DeliveryMode).NotNull().NotEmpty();
            RuleFor(p => p.ServiceMode).NotNull().NotEmpty();
            RuleFor(p => p.Situation).NotNull().NotEmpty();

        }
    }
}
