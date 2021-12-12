using Autofac;
using Retail.Business.Concretes;
using Retail.Business.Interfaces;
using Retail.DataAccess.Concretes.EntityFramework;
using Retail.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Business.IoC.Autofac
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<CustomerService>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<OrderService>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();

            builder.RegisterType<EfAfterSaleDal>().As<IAfterSaleDal>().SingleInstance();
            builder.RegisterType<AfterSaleService>().As<IAfterSaleService>().SingleInstance();

            builder.RegisterType<EfOrderDetailDal>().As<IOrderDetailDal>().SingleInstance();
            builder.RegisterType<OrderDetailService>().As<IOrderDetailService>().SingleInstance();
        }
    }
}
