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
    public DbSet<DbUser> Users { get; set; }
    public DbSet<DbTrip> Trip { get; set; }
    
    public DbSet<DbBooking> Booking { get; set; }

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
            entity.Property(c => c.Brand).HasColumnName("brand");
            entity.Property(c => c.CarType).HasColumnName("carType");
            entity.Property(c => c.FuelType).HasColumnName("fuelType");
            entity.Property(c => c.Color).HasColumnName("color");

        });
        
        modelBuilder.Entity<DbUser>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).HasColumnName("id");
            entity.Property(u => u.Username).HasColumnName("username");
            entity.Property(u => u.Password).HasColumnName("password");
            entity.Property(u => u.Email).HasColumnName("email");
            entity.Property(u => u.IsBanned).HasColumnName("isBanned");
            entity.Property(u => u.BirthDate).HasColumnName("birthdate");
            entity.Property(u => u.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(u => u.LastName).HasColumnName("lastName");
            entity.Property(u => u.FirstName).HasColumnName("firstName");
            entity.Property(u => u.Gender).HasColumnName("gender");
            entity.Property(u => u.AddressId).HasColumnName("addressId");
            entity.Property(u => u.CarPlate).HasColumnName("carPlate");
        });

        modelBuilder.Entity<DbTrip>(entity =>
        {
            entity.ToTable("trip");
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Id).HasColumnName("id");
            entity.Property(t => t.IdDriver).HasColumnName("idDriver");
            entity.Property(t => t.Smoke).HasColumnName("smoke");
            entity.Property(t => t.Price).HasColumnName("price");
            entity.Property(t => t.Luggage).HasColumnName("luggage");
            entity.Property(t => t.PetFriendly).HasColumnName("petFriendly");
            entity.Property(t => t.Date).HasColumnName("date");
            entity.Property(t => t.DriverMessage).HasColumnName("driverMessage");
            entity.Property(t => t.AirConditioning).HasColumnName("airConditioning");
            entity.Property(t => t.IdStartingPoint).HasColumnName("idStartingPoint");
            entity.Property(t => t.IdDestination).HasColumnName("idDestination");
        });
        
        modelBuilder.Entity<DbBooking>(entity =>
        {
            entity.ToTable("booking");
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Id).HasColumnName("id");
            entity.Property(b => b.Date).HasColumnName("date");
            entity.Property(b => b.ReservedSeats).HasColumnName("reservedSeats");
            entity.Property(b => b.IdPassenger).HasColumnName("idPassenger");
            entity.Property(b => b.IdTrip).HasColumnName("idTrip");
        });
    }
}