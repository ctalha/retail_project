using Retail.Entities.Enums;
using Retail.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Entities.Entities
{
    public class AfterSale : IEntity
    {
        public int AfterSaleId { get; set; }
        public string Detail { get; set; }
        public bool Situation { get; set; }
        public int OrderId { get; set; }
    }
}
