using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BulkyWebRazor_temp.Models;
using BulkyWeb.Models;

namespace BulkyWebRazor_temp.Data
{
    public class ApplicationDbContext : IdentityDbContext, DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                 new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                  new Category { Id = 3, Name = "History", DisplayOrder = 3 }

                );
        }
}