//using EFCore.Configurations;
//using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder) =>
            optionBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=EfCore;Integrated Security=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecoredOfSale>().HasOne(r => r.Car).WithMany(c => c.SaleHistory).HasForeignKey(r => r.CarLicensePlate)
                .HasPrincipalKey(c => c.LicensePlate);
        }

        public DbSet<Car> Cars { get; set; }

    }
}

public class Car
{
    public int  CarId { get; set;}

    public string LicensePlate { get; set; }

    public string Make { get; set; }

    public string Model { get; set; }

    public List<RecoredOfSale> SaleHistory{ get; set; }

}

public class RecoredOfSale
{
    public int RecoredOfSaleId { get; set; }

    public DateTime DateSold { get; set; }

    public decimal Price { get; set; }

    public string CarLicensePlate { get; set;}

    public Car Car { get; set; }
}