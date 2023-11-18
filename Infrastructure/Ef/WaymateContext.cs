using Infrastructure.Ef.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class WaymateContext : DbContext
{
    public WaymateContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<DbAddress> Address { get; set; }
    public DbSet<DbCar> Cars { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbAddress>(entity =>
        {
            entity.ToTable("address");
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id).HasColumnName("id");
            entity.Property(a => a.Street).HasColumnName("street");
            entity.Property(a => a.PostalCode).HasColumnName("postalCode");
            entity.Property(a => a.City).HasColumnName("city");
            entity.Property(a => a.Number).HasColumnName("number");
        });
        
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