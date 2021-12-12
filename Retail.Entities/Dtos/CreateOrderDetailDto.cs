using Retail.Entities.Enums;
using Retail.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Retail.Entities.Dtos
{
    public class CreateOrderDetailDto : IDto
    {
        public int OrderId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public DeliveryMode DeliveryMode { get; set; }
        public ServiceMode ServiceMode { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal NetPrice { get; set; }
        public decimal CartDeposit { get; set; }
        public decimal CashDeposit { get; set; }
        public decimal Debt { get; set; }
        public Situation Situation { get; set; }
        public string Note { get; set; }
    }
}
