using Microsoft.EntityFrameworkCore;
using RentCar.Database.Entities;

namespace RentCar.Database
{
    public class RentCarContext : DbContext
    {
        public RentCarContext(DbContextOptions<RentCarContext> options) : base(options) { }

        public DbSet<Brand> brands { get; set; }
        public DbSet<CarType> carTypes { get; set; }

        public DbSet<Model> models { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Brand>().ToTable(nameof(Brand));
            modelBuilder.Entity<Model>().ToTable(nameof(Model));
            modelBuilder.Entity<CarType>().ToTable(nameof(CarType));
        }

        public DbSet<RentCar.Database.Entities.Cars>? Cars { get; set; }

        public DbSet<RentCar.Database.Entities.Clients>? Clients { get; set; }

    }
}
