using Retail.DataAcces.Conretes.EntityFramework;
using Retail.DataAccess.Interfaces;
using Retail.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.DataAccess.Concretes.EntityFramework
{
    public class EfOrderDetailDal : EntityRepositoryBase<OrderDetail,RetailDbContext> , IOrderDetailDal
    {

    }
}
