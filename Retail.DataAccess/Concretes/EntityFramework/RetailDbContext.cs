using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Retail.DataAcces.Conretes.EntityFramework;
using Retail.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail.DataAccess.Concretes.EntityFramework
{
    public class RetailDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        //public RetailDbContext()
        //{

        //}
        //public RetailDbContext(DbContextOptions<RetailDbContext> options) : base(options) 
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {//DESKTOP-JD85CFP   (localdb)\\MSSQLLocalDB
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-JD85CFP;Initial Catalog=RetailDataBasePro;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<AfterSale> AfterSales { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }

    }
}
