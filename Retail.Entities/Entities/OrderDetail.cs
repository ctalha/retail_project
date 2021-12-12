using Retail.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Entities.Entities
{
    public class OrderDetail : IEntity
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
