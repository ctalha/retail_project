using Retail.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Entities.Dtos
{
    public class UpdateOrderSituation : IDto
    {
        public int OrderId { get; set; }
        public int DeliveryMode { get; set; }
        public int ServiceMode { get; set; }
        public int Situation { get; set; }
    }
}
