using Retail.Business.Interfaces;
using Retail.Core.Utilities.Result;
using Retail.DataAccess.Interfaces;
using Retail.Entities.Dtos;
using Retail.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Retail.Core.CustomExceptions;

namespace Retail.Business.Concretes
{
    // GENEL ORDER İŞLEMLERİ TEK BUTON İLE ORDER 
    public class OrderDetailService : IOrderDetailService
    {
        private IOrderDetailDal _orderDetailDal;
        private IOrderService _orderService;
        private IProductService _productService;
        private ICustomerService _customerService;
        public OrderDetailService(IOrderDetailDal orderDetailDal,IOrderService orderService, IProductService productService, ICustomerService customerService)
        {
            _orderDetailDal = orderDetailDal;
            _orderService = orderService;
            _productService = productService;
            _customerService = customerService;
        }
        public async Task<IResponse> AddAsync(CreateOrderDto createOrderDto)
        {
            if (createOrderDto != null)
            {
                //add order
                createOrderDto.order.CustomerId = createOrderDto.CustomerId;
                await _orderService.AddAsync(createOrderDto.order);


                // add product and order detail table 
                foreach (var createProductDto in createOrderDto.Products)
                {
                    var product = await _productService.AddAsync(createProductDto);
                    await _orderDetailDal.AddAsync(new OrderDetail
                    {
                        OrderId = createOrderDto.order.OrderId,
                        ProductId = product.Data.ProductId
                    });
                }

                return new SuccessResponse(true, "Order Eklendi");
            }
            throw new ResultException(true, "Order Eklenemdi");
        }

        public async Task<IResponse> DeleteAsync(DeleteOrderDetail deleteOrderDetail)
        {
            // delete order
            await _orderService.DeleteByIdAsync(deleteOrderDetail.OrderId);

            // delete products
            foreach (var id in deleteOrderDetail.ProductIds)
            {
                await _productService.DeleteByIdAsync(id);
            }

            // if the customer do not have any order, it will be deleted, otherwise will not be deleted 
            var result = await _orderService.GetAllByCustomerId(deleteOrderDetail.CustomerId);
            if (result.Data.Count > 0 ? false : true)
            {
                await _customerService.DeleteByIdAsync(deleteOrderDetail.CustomerId);
            }

            // delete all order detail rows using orderId
            var orderDetail = await _orderDetailDal.GetAllAsync(p => p.OrderId == deleteOrderDetail.OrderId);
            var isSuccess = _orderDetailDal.DeleteMultipleRowsAsync(orderDetail);


            if (await isSuccess)
            {
                return new SuccessResponse(true,"Order Silindi");
            }
            throw new ResultException(true, "Order Silinemedi");

        }

    }
}
