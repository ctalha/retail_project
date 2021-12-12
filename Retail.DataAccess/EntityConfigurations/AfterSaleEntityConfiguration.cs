using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Retail.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.DataAccess.EntityConfigurations
{
    public class AfterSaleEntityConfiguration : IEntityTypeConfiguration<AfterSale>
    {
        public void Configure(EntityTypeBuilder<AfterSale> builder)
        {
            builder.ToTable("AfterSales");
     
            builder.HasKey(x => x.AfterSaleId);

            
        }
    }
}
