
using Mapster;
using Retail.Business.Interfaces;
using Retail.Business.Mapping.AutoMapper;
using Retail.Core.CustomExceptions;
using Retail.Core.Performance;
using Retail.Core.Utilities.Helpers.BusinessValidationEngine;
using Retail.Core.Utilities.Helpers.EnumHelpers;
using Retail.Core.Utilities.Result;
using Retail.DataAccess.Interfaces;
using Retail.Entities.Dtos;
using Retail.Entities.Entities;
using Retail.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;

namespace Retail.Business.Concretes
{

    public class OrderService : IOrderService
    {
        private IOrderDal _orderDal;

        public OrderService(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public async Task<IDataResponse<ResponseOrderDto>> AddAsync(Order order)
        {
            BusinessEngine.Run(CheckDeliveryDataOlderDataThanOrderData(order.DeliveryDate, order.OrderDate));

            var orderResult = await _orderDal.AddAsync(order);
            var result = ConvertEnumProperties<ResponseOrderDto>(orderResult);
            return new SuccessDataResponse<ResponseOrderDto>(result, true,"Order Eklendi");
        }

        public async Task<IResponse> DeleteAsync(Order order)
        {
            var orderExist = _orderDal.GetAsync(p => p.OrderId == order.OrderId);

            if (await orderExist != null)
            {
                await _orderDal.DeleteAsync(order);
                return new SuccessResponse(true, "Order Güncellendi");
            }
            throw new ResultException(true, "Böyle bir Sipariş Bulunamadı");
        }

        public async Task<IResponse> DeleteByIdAsync(int id)
        {
            var result = await _orderDal.DeleteByIdAsync(new Order { OrderId = id });
            if (result)
            {
                return new SuccessResponse(true, "Order Silindi");
            }
            throw new ResultException(true, "Order Silinemedi");
        }

        public async Task<IDataResponse<List<Order>>> GetAllAsync()
        {
            var orders = await _orderDal.GetAllAsync();
            return new SuccessDataResponse<List<Order>>(orders, true);
        }

        public async Task<IDataResponse<List<ResponseOrderDto>>> GetAllByCustomerId(int id)
        {
            var orderResult = await _orderDal.GetAllAsync(p => p.CustomerId == id);
            if (orderResult is not null)
            {
                List<ResponseOrderDto> responseOrderDto = new List<ResponseOrderDto>();
                foreach (var item in orderResult)
                {
                    var responseOrder = ConvertEnumProperties<ResponseOrderDto>(item);
                    responseOrderDto.Add(responseOrder);
                }
                return new SuccessDataResponse<List<ResponseOrderDto>>(responseOrderDto, true);
            }
            throw new ResultException(true, "Listelenecek Sipariş Bulunamadı");
        }
    
        public async Task<IDataResponse<ResponseOrderDto>> GetByIdAsync(int orderId)
        {
            var orderResult = await _orderDal.GetAsync(p => p.OrderId == orderId);
            if (orderResult != null)
            {
                var result = ConvertEnumProperties<ResponseOrderDto>(orderResult);
                return new SuccessDataResponse<ResponseOrderDto>(result, true, "Id ye göre order listelendi");
            }
            throw new ResultException(true, "Bu Kullanıcıya ait bir sipariş bulunamadı");
        }

        public async Task<IDataResponse<ResponseOrderDetailDto>> GetOrderDetailDtosById(int orderId)
        {
            var orderResult = await _orderDal.GetOrderDetailDto(orderId);
            if (orderResult != null)
            {
                return new SuccessDataResponse<ResponseOrderDetailDto>(orderResult, true);
            }
            throw new ResultException(true, "Böyle bir sipariş bulunamadı");            
        }

        public async Task<IDataResponse<List<OrderDetailDto>>> GetOrderListResponseDtos()
        {
            var orderResult = await _orderDal.GetOrderListResponseDtos();
            if (orderResult != null)
            {
                return new SuccessDataResponse<List<OrderDetailDto>>(orderResult, true);
            }
            throw new ResultException(true, "Sipariş Bulunamadı");
        }

        public async Task<IDataResponse<ResponseOrderDto>> UpdateAsync(Order order)
        {
            var orderResult = await _orderDal.UpdateAsync(order);
            var result = ConvertEnumProperties<ResponseOrderDto>(orderResult);
            return new SuccessDataResponse<ResponseOrderDto>(result,true,"Order güncellendi");
        }

        public async Task<IDataResponse<ResponseOrderDto>> UpdateOrderSituation(UpdateOrderSituation updateOrderSituation)
        {
            var order = await _orderDal.GetAsync(p => p.OrderId == updateOrderSituation.OrderId);
            if (order != null)
            {
                order.ServiceMode =  (ServiceMode)updateOrderSituation.ServiceMode;
                order.DeliveryMode = (DeliveryMode)updateOrderSituation.DeliveryMode;
                order.Situation = (Situation)updateOrderSituation.Situation;
                var orderResult = await _orderDal.UpdateAsync(order);

                if (orderResult != null)
                {
                    var result = ConvertEnumProperties<ResponseOrderDto>(orderResult);
                    return new SuccessDataResponse<ResponseOrderDto>(result, true, "Order güncellendi");
                }
                throw new ResultException(true, "Order güncellenemedi");
            }
            throw new ResultException(true, "Bir hata oluştu");
        }


        // Business Methods

        private IResponse CheckDeliveryDataOlderDataThanOrderData(DateTime deliveryDate, DateTime orderDate)
        {
            if (deliveryDate > orderDate )
            {
                return new SuccessResponse();
            }
            throw new ResultException(true, "Sipariş tarihi, teslimat tarihinden daha sonra olamaz");
        }
        private T ConvertEnumProperties<T>(Order order)
            where T:ResponseOrderDto
        {
            var mapping = order.Adapt<T>();
            mapping.DeliveryMode = Enumerations.GetEnumDescription(order.DeliveryMode);
            mapping.ServiceMode = Enumerations.GetEnumDescription(order.ServiceMode);
            mapping.Situation = Enumerations.GetEnumDescription(order.Situation);
            return mapping;
        }
   
    }
}
