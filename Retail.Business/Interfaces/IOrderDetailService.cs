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
    public interface IOrderDetailService
    {
        Task<IResponse> AddAsync(CreateOrderDto createOrderDto);
        Task<IResponse> DeleteAsync(DeleteOrderDetail deleteOrderDetail);
    }
}
