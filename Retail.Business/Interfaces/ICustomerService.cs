using Retail.Core.Utilities.Result;
using Retail.Entities.Dtos;
using Retail.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retail.Business.Interfaces
{
    public interface ICustomerService
    {
        Task<IDataResponse<Customer>> AddAsync(CreateCustomerDto createCustomerDto);
        Task<IResponse> DeleteAsync(Customer customer);
        Task<IDataResponse<Customer>> GetByIdAsync(int customerId);
        Task<IDataResponse<List<Customer>>> GetAllAsync();
        Task<IDataResponse<Customer>> UpdateAsync(Customer customer);
        Task<IResponse> DeleteByIdAsync(int id);
    }
}
