using Retail.Core.Utilities.Result;
using Retail.Entities.Dtos;
using Retail.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Business.Interfaces
{
    public interface IOrderService
    {
        Task<IDataResponse<ResponseOrderDto>> AddAsync(Order order);
        Task<IResponse> DeleteAsync(Order order);
        Task<IDataResponse<ResponseOrderDto>> GetByIdAsync(int orderId);
        Task<IDataResponse<List<Order>>> GetAllAsync();
        Task<IDataResponse<ResponseOrderDto>> UpdateAsync(Order order);
        Task<IDataResponse<ResponseOrderDetailDto>> GetOrderDetailDtosById(int orderId);
        Task<IDataResponse<List<OrderDetailDto>>> GetOrderListResponseDtos();
        Task<IResponse> DeleteByIdAsync(int id);
        Task<IDataResponse<List<ResponseOrderDto>>> GetAllByCustomerId(int id);
        Task<IDataResponse<ResponseOrderDto>> UpdateOrderSituation(UpdateOrderSituation updateOrderSituation);
    }
}
