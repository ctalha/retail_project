
using Retail.Entities.Entities;
using Retail.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Entities.Dtos
{
    #region yeni
    public class OrderDetailDto : IDto
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
        public Customer Customer { get;  set; }

        public List<Product> Products { get; set; }
        public OrderDetailDto()
        {
            Products = new List<Product>();
        }
    }
    #endregion
    #region eski

    //public class OrderDetailDto : IDto
    //{
    //    public int OrderId { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string PhoneNumber { get; set; }
    //    public string Email { get; set; }
    //    public string TcNo { get; set; }
    //    public string City { get; set; }
    //    public string District { get; set; }
    //    public DateTime OrderDate { get; set; }
    //    public string Address { get; set; }
    //    public string DeliveryMode { get; set; }
    //    public string ServiceMode { get; set; }
    //    public DateTime DeliveryDate { get; set; }
    //    public string ShippingCompany { get; set; }
    //    public string ShippingDriver { get; set; }
    //    public string ShippingPhoneNumber { get; set; }
    //    public string FurnitureAssembler { get; set; }
    //    public decimal TotalPrice { get; set; }
    //    public decimal DiscountPercent { get; set; }
    //    public decimal DiscountPrice { get; set; }
    //    public decimal NetPrice { get; set; }
    //    public decimal CartDeposit { get; set; }
    //    public decimal CashDeposit { get; set; }
    //    public string Situation { get; set; }
    //    public bool HasSsh { get; set; }
    //    public string Note { get; set; }
    //    public string ProductName { get; set; }
    //}

    #endregion
}
