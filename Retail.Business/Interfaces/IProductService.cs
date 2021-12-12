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
    public interface IProductService
    {
        Task<IDataResponse<Product>> AddAsync(Product product);
        Task<IResponse> DeleteAsync(Product product);
        Task<IDataResponse<Product>> GetByIdAsync(int productId);
        Task<IDataResponse<List<Product>>> GetAllAsync();
        Task<IDataResponse<Product>> UpdateAsync(Product product);
        Task<IResponse> DeleteByIdAsync(int id);
        Task<IDataResponse<List<Product>>> GetProductsByOrderId(int orderId);
    }
}
