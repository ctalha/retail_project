using Retail.Entities.Entities;
using Retail.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Entities.Dtos
{
    public class ResponseOrderDetailDto : IDto
    {
        public Order Order { get; set; }
        public Customer Customer { get; set; }
    }
}
