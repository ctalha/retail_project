using Retail.Entities.Dtos;
using Retail.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.DataAccess.Interfaces
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        Task<ResponseOrderDetailDto> GetOrderDetailDto(int orderId);
        Task<List<OrderDetailDto>> GetOrderListResponseDtos();
    }
}
