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
    public class ProductService : IProductService
    {
        private IProductDal _productDal;
        private readonly IOrderDetailDal _orderDetailDal;
        public ProductService(IProductDal productDal, IOrderDetailDal orderDetailDal)
        {
            _productDal = productDal;
            _orderDetailDal = orderDetailDal;
        }
        public async Task<IDataResponse<Product>> AddAsync(Product product)
        {
            return new SuccessDataResponse<Product>(await _productDal.AddAsync(product),true,"Product Eklendi");
        }
        public async Task<IResponse> DeleteAsync(Product product)
        {
            var productResult = await _productDal.GetAsync(p => p.ProductId == product.ProductId);
            if (productResult != null)
            {
                await _productDal.DeleteAsync(product);
                var orderDetail = await _orderDetailDal.GetAsync(p => p.ProductId == product.ProductId);
                await _orderDetailDal.DeleteAsync(orderDetail);
                return new SuccessResponse(true, "Product Silindi");
            }
            throw new ResultException(true, "Böyle bir ürün bulunamadı");
        }
        public async Task<IResponse> DeleteByIdAsync(int id)
        {
            var productResult = await _productDal.GetAsync(p => p.ProductId == id);
            if (productResult != null)
            {
                var result = await _productDal.DeleteByIdAsync(new Product { ProductId = id });
                if (result)
                {
                    return new SuccessResponse(true, "Product Silindi");
                }
                throw new ResultException(true, "Product Silinemedi");
            }
            throw new ResultException(true, "Böyle bir ürün bulunamadı");
        }
        public async Task<IDataResponse<List<Product>>> GetAllAsync()
        {
            var productResult = await _productDal.GetAllAsync();
            if (productResult != null)
            {
                return new SuccessDataResponse<List<Product>>(productResult, true);
            }
            return new ErrorDataResult<List<Product>>(null,true, "Listelenecek product bulunamadı");
        }
        public async Task<IDataResponse<Product>> GetByIdAsync(int productId)
        {
            var productResult = await _productDal.GetAsync(p => p.ProductId == productId);
            if (productResult != null)
            {
                return new SuccessDataResponse<Product>(productResult, true,"Ürün listelendi");
            }
            return new ErrorDataResult<Product>(null, true, "Ürün listelenemedi");
        }

        public async Task<IDataResponse<List<Product>>> GetProductsByOrderId(int orderId)
        {
            return new SuccessDataResponse<List<Product>>(await _productDal.GetProductsByOrderId(orderId), true, "Listelendi");
        }

        public async Task<IDataResponse<Product>> UpdateAsync(Product product)
        {
            var isExist = await _productDal.GetAsync(p => p.ProductId == product.ProductId);
            if (isExist != null)
            {
                return new SuccessDataResponse<Product>(await _productDal.UpdateAsync(product), true, "Product Güncellendi");
            }
            return new ErrorDataResult<Product>(null, true, "Ürün bulunamadı");
        }
    }
}
