using Microsoft.AspNetCore.Http;
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
    public class CustomerService : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerService(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public async Task<IDataResponse<Customer>> AddAsync(CreateCustomerDto createCustomerDto)
        {
            var customer = createCustomerDto.Adapt<Customer>();
            var result = _customerDal.AddAsync(customer);
            return new SuccessDataResponse<Customer>(await result,true, "Müşteri Başarılı bir Şekilde Eklendi");      
        }

        public async Task<IResponse> DeleteAsync(Customer customer)
        {
            var customerResult = await _customerDal.GetAsync(p => p.CustomerId == customer.CustomerId);
            if (customerResult != null)
            {
                await _customerDal.DeleteAsync(customer);
                return new SuccessResponse(true, "Müşteri Silindi");
            }
            return new ErrorResponse(true, "Müşteri bulunamadı");
        }

        public async Task<IResponse> DeleteByIdAsync(int id)
        {
            var customerResult = await _customerDal.GetAsync(p => p.CustomerId == id);
            if (customerResult != null)
            {
                var result = _customerDal.DeleteByIdAsync(new Customer { CustomerId = id });
                if (await result)
                {
                    return new SuccessResponse(true, "Müşteri silindi");
                }
                return new ErrorResponse(true, "Müşteri silinemedi");
            }
            throw new ResultException(true, "Müşteri bulunamadı");
        }

        public async Task<IDataResponse<List<Customer>>> GetAllAsync()
        {
            var result = await _customerDal.GetAllAsync();
            if (result != null)
            {
                return new SuccessDataResponse<List<Customer>>(result, true, "Müşteriler Listelendi");
            }
            return new ErrorDataResult<List<Customer>>(null,true, "Müşteri bulunamamaktadır");
        }

        public async Task<IDataResponse<Customer>> GetByIdAsync(int customerId)
        {
            var result = await _customerDal.GetAsync(p => p.CustomerId == customerId);
            if (result != null)
            {
                return new SuccessDataResponse<Customer>(result, true);
            }
            return new ErrorDataResult<Customer>(null, true, "Müşteri bulunamadı");
        }

        public async Task<IDataResponse<Customer>> UpdateAsync(Customer customer)
        {
            var result = await _customerDal.UpdateAsync(customer);
            if (result != null)
            {
                return new SuccessDataResponse<Customer>(result, true, "Müşteri Güncellendi");
            }
            return new ErrorDataResult<Customer>(null, true, "Müşteri Güncellenemedi");
        }
    }
}
