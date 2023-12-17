using Infrastructure.Ef.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class WaymateContext : DbContext
{
    private readonly IConnectionStringProvider _connectionStringProvider;
  /*  public WaymateContext(DbContextOptions options) : base(options)
    {
    }*/
    
    public DbSet<DbAddress> Address { get; set; }
    public DbSet<DbCar> Cars { get; set; }
    public DbSet<DbUser> Users { get; set; }
    
    public WaymateContext(IConnectionStringProvider connectionStringProvider)
    {
        _connectionStringProvider = connectionStringProvider;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
           // optionsBuilder.UseSqlServer(_connectionStringProvider.GetConnectionString("DbRemote"));
        }
    }
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
            
            
        });
    }
}