using Assignment4.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Assignment4
{
    //ass4
    public class NorthwindContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get ;  set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();

            //  optionsBuilder.UseNpgsql("host=rawdata.ruc.dk;db=raw14;uid=raw14;pwd=I.eSywI3");
            //  optionsBuilder.UseNpgsql("host=localhost;db=northwind;uid=postgres;pwd=XXXXXX");

            // Insted of one of the above we have our own
            // saved in a txt file that we then read from
            string connStringFromFile;

            using (StreamReader readtext = new StreamReader("C:/Login/Login.txt"))
            {
                connStringFromFile = readtext.ReadLine();
            }
            optionsBuilder.UseNpgsql(connStringFromFile);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(x => x.Id).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("categoryname");
            modelBuilder.Entity<Category>().Property(x => x.Description).HasColumnName("description");
            modelBuilder.Entity<Category>().HasMany(x => x.Product).WithOne(x => x.Category).IsRequired();




            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("productid");
            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired().HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(x => x.CategoryId).HasColumnName("categoryid");
            modelBuilder.Entity<Product>().Property(x => x.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<Product>().Property(x => x.QuantityPerUnit).HasColumnName("quantityperunit");
            modelBuilder.Entity<Product>().Property(x => x.UnitsInStock).HasColumnName("unitsinstock");
        //    modelBuilder.Entity<Product>().Property(x => x.CategoryName).HasColumnName("categoryname");
            modelBuilder.Entity<Product>()
            .HasOne(x => x.Category).WithMany(x => x.Product).HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<Product>()
            .HasMany(x => x.OrderDetails).WithOne(x => x.Product);









            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().Property(x => x.Id).HasColumnName("orderid");
            modelBuilder.Entity<Order>().Property(x => x.Date).HasColumnName("orderdate");
            modelBuilder.Entity<Order>().Property(x => x.Required).HasColumnName("requireddate");
            modelBuilder.Entity<Order>().Property(x => x.Freight).HasColumnName("freight");
            modelBuilder.Entity<Order>().Property(x => x.ShipName).HasColumnName("shipname");
            modelBuilder.Entity<Order>().Property(x => x.ShipCity).HasColumnName("shipcity");
            modelBuilder.Entity<Order>()
                .HasMany(x => x.OrderDetails).WithOne(x => x.Order);
            






            modelBuilder.Entity<OrderDetail>().ToTable("orderdetails");
            modelBuilder.Entity<OrderDetail>().Property(x => x.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<OrderDetail>().Property(x => x.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<OrderDetail>().Property(x => x.Discount).HasColumnName("discount");
            modelBuilder.Entity<OrderDetail>().Property(x => x.OrderId).HasColumnName("orderid");
            modelBuilder.Entity<OrderDetail>().Property(x => x.ProductId).HasColumnName("productid");
            modelBuilder.Entity<OrderDetail>()
                .HasKey(x => new {x.OrderId});
            modelBuilder.Entity<OrderDetail>()
                .HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);
            modelBuilder.Entity<OrderDetail>()
                .HasOne(x => x.Product).WithMany(x => x.OrderDetails).HasForeignKey(x=> x.OrderId);

        }
    }
}
