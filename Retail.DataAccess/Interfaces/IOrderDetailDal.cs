using Retail.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.DataAccess.Interfaces
{
    public interface IOrderDetailDal : IEntityRepository<OrderDetail>
    {
    }
}
