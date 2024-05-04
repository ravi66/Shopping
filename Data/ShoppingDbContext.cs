using Microsoft.EntityFrameworkCore;
using Shopping.Data.Entities;

namespace Shopping.Data
{
    internal class ShoppingDbContext(DbContextOptions<ShoppingDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aisle>().HasData(new Aisle { AisleId = -1, AisleName = "Not set", Order = 0 });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionDb = $"Filename={DbPath.GetPath("Shopping.sqlite3")}";
            optionsBuilder.UseSqlite(connectionDb);

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Aisle> Aisles { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}