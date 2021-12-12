using Retail.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Entities.Dtos
{
    public class DeleteOrderDetail : IDto
    {
        public int CustomerId { get; set; }
        public List<int> ProductIds { get; set; }
        public int OrderId { get; set; }
    }
}
