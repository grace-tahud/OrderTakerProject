using Microsoft.EntityFrameworkCore;
using OrderTakerProject.Repository.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OrderTakerProject.Repository
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SKU> SKUs { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SKU>(entity => {
                entity.HasIndex(e => e.Code).IsUnique();
            });

            builder.Entity<SKU>(entity => {
                entity.HasIndex(e => e.Name).IsUnique();
            });
            builder.Entity<SKU>().Property(p => p.UnitPrice).HasColumnType("decimal(18,2)");

            builder.Entity<Customer>(entity => {
                entity.HasIndex(e => e.MobileNumber).IsUnique();
            });

            builder.Entity<Customer>(entity => {
                entity.HasIndex(e => e.FullName).IsUnique();
            });

            builder.Entity<PurchaseOrder>().Property(p => p.AmountDue).HasColumnType("decimal(18,2)");

            builder.Entity<PurchaseItem>().Property(p => p.Price).HasColumnType("decimal(18,2)");
        }
    }
}
