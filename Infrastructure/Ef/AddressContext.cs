using Infrastructure.Ef.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class AddressContext : DbContext
{
    public AddressContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<DbAddress> Address { get; set; }

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
    }
}