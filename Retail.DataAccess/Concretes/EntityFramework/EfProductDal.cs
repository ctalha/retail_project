using Retail.DataAcces.Conretes.EntityFramework;
using Retail.DataAccess.Interfaces;
using Retail.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Retail.DataAccess.Concretes.EntityFramework
{
    public class EfProductDal : EntityRepositoryBase<Product, RetailDbContext>, IProductDal
    {
        public async Task<List<Product>> GetProductsByOrderId(int orderId)
        {
            using (RetailDbContext context = new RetailDbContext())
            {
                var result = (from p in context.Products
                              join od in context.OrderDetails on p.ProductId equals od.ProductId
                              where od.OrderId == orderId
                              select p).ToListAsync();

                return await result;
            }
        }
    }
}
