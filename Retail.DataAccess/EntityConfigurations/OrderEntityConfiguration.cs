using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retail.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.DataAccess.EntityConfigurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(p => p.OrderId);

            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.OrderDate).IsRequired();
            builder.Property(p => p.DeliveryMode).IsRequired();
            builder.Property(p => p.ServiceMode).IsRequired();
            builder.Property(p => p.DeliveryDate).IsRequired();
            builder.Property(p => p.Situation).IsRequired();
        }
    }
}
