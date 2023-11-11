using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentCar.Database.Entities;

namespace RentCar.Database
{
    public class RentCarContext : IdentityDbContext<User>
    {
        public RentCarContext(DbContextOptions<RentCarContext> options) : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarType> carTypes { get; set; }

        public DbSet<Model> models { get; set; }
        public DbSet<Cars> Cars { get; set; }

        public DbSet<Clients> Clients { get; set; }

        public DbSet<Fuel> Fuels { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Rent> Rents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Brand>().ToTable(nameof(Brand));
            modelBuilder.Entity<Model>().ToTable(nameof(Model));
            modelBuilder.Entity<CarType>().ToTable(nameof(CarType));
            //   modelBuilder.Entity<IdentityUser>().ToTable(nameof(IdentityUser));
            //  modelBuilder.Entity<IdentityRole>().ToTable(nameof(IdentityRole));

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "Usuario", NormalizedName = "USUARIO" }
            );

          
        }

       

    }
}
