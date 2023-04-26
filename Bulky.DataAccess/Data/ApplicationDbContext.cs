using Bulky.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet <Category> Categories { get; set; }
        public DbSet <Drugs> Drugs { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1,Name="Action",DisplayOrder=1 },
                 new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                  new Category { Id = 3, Name = "History", DisplayOrder = 3 }

                ) ;
           modelBuilder.Entity<Drugs>().HasData(
                new Drugs { Batch_Id = 1, Drug_Name = "Paracetamol", Quantity=10, Expired_Date=new DateOnly(2028,03,16),Price = 200 },
                 new Drugs { Batch_Id = 2, Drug_Name = "Ketoconazole", Quantity = 5, Expired_Date = new DateOnly(2025, 10, 19), Price = 500 },
                  new Drugs { Batch_Id = 3, Drug_Name = "Aspirin", Quantity = 6, Expired_Date = new DateOnly(2027, 09, 26), Price = 750 }


                );
        }
    }
}
