using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApp.Models
{
    public class AuthenticationContext : IdentityDbContext
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .Property(a => a.FullName)
                .HasColumnType("nvarchar(150)");

            modelBuilder.Entity<CustomerModel>()
                .HasKey(c => c.CustomerID);

            modelBuilder.Entity<ItemModel>()
                .HasKey(i => i.ItemID);

            modelBuilder.Entity<OrderItemsModel>()
                .HasKey(o => o.OrderItemID);

            modelBuilder.Entity<OrderModel>()
                .HasKey(om => om.OrderID);


            modelBuilder.Entity<CustomerModel>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerID);

            modelBuilder.Entity<ItemModel>()
                .HasMany(i => i.OrderItems)
                .WithOne(o => o.Item)
                .HasForeignKey(i => i.ItemID);


            modelBuilder.Entity<OrderModel>()
                .HasMany(i => i.OrderItems)
                .WithOne(o => o.Order)
                .HasForeignKey(i => i.ItemID);



            base.OnModelCreating(modelBuilder);
        }

            public DbSet<ApplicationUser> ApplicationUsers { get; set; }
            public DbSet<CustomerModel> Customers { get; set; }
            public DbSet<ItemModel> Items { get; set; }
            public DbSet<OrderModel> Orders { get; set; }
            public DbSet<OrderItemsModel> OrderItems { get; set; }



    }
}
