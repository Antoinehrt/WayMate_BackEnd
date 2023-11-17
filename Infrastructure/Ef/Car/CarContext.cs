using Infrastructure.Ef.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef.Car;

public class CarContext : DbContext
{
    public CarContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<DbCar> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbCar>(entity =>
        {
            entity.ToTable("car");
            entity.HasKey(c => c.NumberPlate);
            entity.Property(c => c.NumberPlate).HasColumnName("plateNumber");
            entity.Property(c => c.Model).HasColumnName("model");
            entity.Property(c => c.NbSeats).HasColumnName("nbSeats");
            entity.Property(c => c.FuelType).HasColumnName("fuelType");
            entity.Property(c => c.Brand).HasColumnName("brand");
            entity.Property(c => c.CarType).HasColumnName("carType");

        });
    }
}