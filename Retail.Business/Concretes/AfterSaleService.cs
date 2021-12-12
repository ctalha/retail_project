using Retail.Business.Interfaces;
using Retail.Core.CustomExceptions;
using Retail.Core.Utilities.Result;
using Retail.DataAccess.Interfaces;
using Retail.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Business.Concretes
{
    public class AfterSaleService : IAfterSaleService
    {
        private IAfterSaleDal _afterSaleDal;

        public AfterSaleService(IAfterSaleDal afterSaleDal)
        {
            _afterSaleDal = afterSaleDal;
        }
        public async Task<IResponse> AddAsync(AfterSale afterSale)
        {
            await _afterSaleDal.AddAsync(afterSale);
            return new SuccessResponse(true, "AfterSale Eklendi");
        }

        public async Task<IResponse> DeleteAsync(AfterSale afterSale)
        {
            await _afterSaleDal.DeleteAsync(afterSale);
            return new SuccessResponse(true, "AfterSale Silindi");
        }

        public async Task<IResponse> DeleteByIdAsync(int id)
        {
            var result = _afterSaleDal.DeleteByIdAsync(new AfterSale { AfterSaleId = id });
            if (await result)
            {
                return new SuccessResponse(true, "After Sale silindi");
            }
            throw new ResultException(true, "After Sale silinemedi");
        }

        public async Task<IDataResponse<List<AfterSale>>> GetAfterSaleByOrderId(int id)
        {
            var result  = _afterSaleDal.GetAllAsync(p => p.OrderId == id);
            return new SuccessDataResponse<List<AfterSale>>(await result, true, "After sale order ıd ye göre listelendi");
        }

        public async Task<IDataResponse<List<AfterSale>>> GetAllAsync()
        {
            return new SuccessDataResponse<List<AfterSale>>(await _afterSaleDal.GetAllAsync(), true);
        }

        public async Task<IDataResponse<AfterSale>> GetByIdAsync(int afterSaleId)
        {
            return new SuccessDataResponse<AfterSale>(await _afterSaleDal.GetAsync(p => p.AfterSaleId == afterSaleId), true);
        }

        public async Task<IDataResponse<AfterSale>> UpdateAsync(AfterSale afterSale)
        {
            
            return new SuccessDataResponse<AfterSale>(await _afterSaleDal.UpdateAsync(afterSale), true, "AfterSale Güncellendi");
        }
    }
}
