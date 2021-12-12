using Retail.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Entities.Entities
{
    public class AfterSaleDetail : IEntity
    {
        public int AfterSaleDetailId { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
    }
}
