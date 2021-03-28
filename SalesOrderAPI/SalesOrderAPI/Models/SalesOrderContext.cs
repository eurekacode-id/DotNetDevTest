using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesOrderAPI.Models
{
    public class SalesOrderContext : DbContext
    {
        public SalesOrderContext(DbContextOptions<SalesOrderContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesItemPrice>()
                .HasOne(sip => sip.UoM)
                .WithMany(u => u.SalesItemPrices);

            modelBuilder.Entity<SalesItemPrice>()
                .HasOne(sip => sip.SalesItem)
                .WithMany(si => si.SalesItemPrices);

            modelBuilder.Entity<SalesOrder>()
                .HasOne(so => so.Customer)
                .WithMany(c => c.SalesOrders);

            modelBuilder.Entity<SalesOrderLine>()
                .HasOne(sol => sol.SalesOrder)
                .WithMany(so => so.SalesOrderLines);

            modelBuilder.Entity<SalesOrderLine>()
                .HasOne(sol => sol.SalesItemPrice)
                .WithMany(sip => sip.SalesOrderLines);
        }

        public DbSet<UoM> UoMs { get; set; }
        public DbSet<SalesItem> SalesItems { get; set; }
        public DbSet<SalesItemPrice> SalesItemPrices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderLine> SalesOrderLines { get; set; }
    }
}
