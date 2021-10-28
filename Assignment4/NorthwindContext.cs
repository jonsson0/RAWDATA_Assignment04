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

        // public DbSet<Order> Orders { get ;  set; }

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


            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("productid");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(x => x.CategoryId).HasColumnName("categoryid");

          //  modelBuilder.Entity<Order>().ToTable("orders");

        }
    }
}
