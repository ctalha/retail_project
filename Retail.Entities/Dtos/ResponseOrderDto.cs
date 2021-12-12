using Retail.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Entities.Dtos
{
    public class ResponseOrderDto : IDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public string DeliveryMode { get; set; }
        public string ServiceMode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal NetPrice { get; set; }
        public decimal CartDeposit { get; set; }
        public decimal CashDeposit { get; set; }
        public string Situation { get; set; }
        public string Note { get; set; }
    }
}
