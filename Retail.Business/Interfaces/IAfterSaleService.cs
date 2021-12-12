using Retail.Core.Utilities.Result;
using Retail.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Business.Interfaces
{
    public interface IAfterSaleService
    {
        Task<IResponse> AddAsync(AfterSale afterSale);
        Task<IResponse> DeleteAsync(AfterSale afterSale);
        Task<IDataResponse<AfterSale>> GetByIdAsync(int afterSaleId);

        Task<IDataResponse<List<AfterSale>>> GetAllAsync();
        Task<IDataResponse<AfterSale>> UpdateAsync(AfterSale afterSale);
        Task<IResponse> DeleteByIdAsync(int id);
        Task<IDataResponse<List<AfterSale>>> GetAfterSaleByOrderId(int id);
    }
}
