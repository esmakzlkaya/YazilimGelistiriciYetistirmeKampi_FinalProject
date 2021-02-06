using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // Context: DB tabloları ile proje classlarını ilişkilendirmek için
    public class NorthwindContext:DbContext
    {
        // Proje hangi veritabanı ile ilişkili bunu belirtmek için->
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        //Benim product nesnemi veritabanındaki products ile bağla
        public DbSet<Product> Products { get; set; }
        //Hangi class hangi tabloya karşılık geliyor onu belirliyoruz
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }




    }
}
