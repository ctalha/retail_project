using Retail.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Entities.Entities
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public decimal Price { get; set; }
    }
}
