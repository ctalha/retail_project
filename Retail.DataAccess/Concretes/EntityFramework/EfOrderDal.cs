using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Retail.Core.Utilities.Helpers.EnumHelpers;
using Retail.DataAcces.Conretes.EntityFramework;
using Retail.DataAccess.Interfaces;
using Retail.Entities.Dtos;
using Retail.Entities.Entities;
using Retail.Entities.Enums;

namespace Retail.DataAccess.Concretes.EntityFramework
{
    public class EfOrderDal : EntityRepositoryBase<Order, RetailDbContext>, IOrderDal
    {
        #region yeni
        public async Task<ResponseOrderDetailDto> GetOrderDetailDto(int orderId)
        {
            using (RetailDbContext context = new RetailDbContext())
            {

                var result = from o in context.Orders
                             join c in context.Customers on o.CustomerId equals c.CustomerId
                             where o.OrderId == orderId
                             select new ResponseOrderDetailDto
                             //OrderDetailDto
                             {
                                 Customer = c,
                                 Order = o
                                 //OrderId = o.OrderId,
                                 //CustomerId = c.CustomerId,
                                 //Address = o.Address,
                                 //TotalPrice = o.TotalPrice,
                                 //DiscountPrice = o.DiscountPrice,
                                 //DiscountPercent = o.DiscountPercent,
                                 //City = o.City,
                                 //District = o.District,
                                 //CartDeposit = o.CartDeposit,
                                 //CashDeposit = o.CashDeposit,
                                 //DeliveryDate = o.DeliveryDate,
                                 //DeliveryMode = Enumerations.GetEnumDescription(o.DeliveryMode),
                                 //ServiceMode = Enumerations.GetEnumDescription(o.ServiceMode),
                                 //Situation = Enumerations.GetEnumDescription(o.Situation),
                                 //Note = o.Note,
                                 //NetPrice = o.NetPrice,
                                 //OrderDate = o.OrderDate,

                                 //Customer = c,
                                 //Products= (from od in context.OrderDetails
                                 //          join p in context.Products on od.ProductId equals p.ProductId where od.OrderId == orderId select p)
                                 //          .ToList()
                             };
                
                return await result.SingleOrDefaultAsync();
            }
        }

        public async Task<List<OrderDetailDto>> GetOrderListResponseDtos()
        {
            using (RetailDbContext context = new RetailDbContext())
            {

                var result = from o in context.Orders
                             join c in context.Customers on o.CustomerId equals c.CustomerId
                             select new OrderDetailDto
                             {
                                 OrderId = o.OrderId,
                                 CustomerId = c.CustomerId,
                                 Address = o.Address,
                                 TotalPrice = o.TotalPrice,
                                 DiscountPrice = o.DiscountPrice,
                                 DiscountPercent = o.DiscountPercent,
                                 City = o.City,
                                 District = o.District,
                                 CartDeposit = o.CartDeposit,
                                 CashDeposit = o.CashDeposit,
                                 DeliveryDate = o.DeliveryDate,
                                 DeliveryMode = Enumerations.GetEnumDescription(o.DeliveryMode),
                                 ServiceMode = Enumerations.GetEnumDescription(o.ServiceMode),
                                 Situation = Enumerations.GetEnumDescription(o.Situation),
                                 Note = o.Note,
                                 NetPrice = o.NetPrice,
                                 OrderDate = o.OrderDate,

                                 Customer = c,
                                 Products = (from od in context.OrderDetails
                                             join p in context.Products on od.ProductId equals p.ProductId
                                             where od.OrderId == o.OrderId
                                             select p)
                                           .ToList()
                             };

                return await result.ToListAsync();
            }
        }
        #endregion
        #region Eski
        //public List<OrderDetailDto> GetOrderDetailDtos()
        //{
        //    using (RetailDbContext context = new RetailDbContext())
        //    {

        //        var result = from o in context.Orders
        //                     join c in context.Customers on o.CustomerId equals c.CustomerId
        //                     select new OrderDetailDto
        //                     {
        //                         Address = o.Address,
        //                         CartDeposit = o.CartDeposit,
        //                         CashDeposit = o.CashDeposit,
        //                         City = o.City,
        //                         DeliveryDate = o.DeliveryDate,
        //                         DeliveryMode = o.DeliveryMode.ToString(),
        //                         DiscountPercent = o.DiscountPercent,
        //                         DiscountPrice = o.DiscountPrice,
        //                         District = o.District,
        //                         Email = c.Email,
        //                         FirstName = c.FirstName,
        //                         FurnitureAssembler = o.FurnitureAssembler,
        //                         HasSsh = o.HasSsh,
        //                         LastName = c.LastName,
        //                         NetPrice = o.NetPrice,
        //                         Note = o.Note,
        //                         OrderDate = o.OrderDate,
        //                         OrderId = o.OrderId,
        //                         PhoneNumber = c.PhoneNumber,
        //                         ShippingPhoneNumber = o.ShippingPhoneNumber,
        //                         ServiceMode = o.ServiceMode.ToString(),
        //                         ShippingCompany = o.ShippingCompany,
        //                         ShippingDriver = o.ShippingDriver,
        //                         Situation = o.Situation.ToString(),
        //                         TcNo = c.TcNo,
        //                         TotalPrice = o.TotalPrice,

        //                     };

        //        return result.ToList();
        //    }
        //}

        #endregion


    }
}
