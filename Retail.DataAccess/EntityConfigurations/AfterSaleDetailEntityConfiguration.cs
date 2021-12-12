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
    public class AfterSaleDetailEntityConfiguration : IEntityTypeConfiguration<AfterSaleDetail>
    {
        public void Configure(EntityTypeBuilder<AfterSaleDetail> builder)
        {
            builder.ToTable("AfterSaleDetails");
        }
    }
}
