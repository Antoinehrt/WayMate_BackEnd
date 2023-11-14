using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef;

public class AddressRepository : IAddressRepository
{
    private readonly AddressContext _context;

    public AddressRepository(AddressContext context)
    {
        _context = context;
    }
    public IEnumerable<DbAddress> FetchAll()
    {
        return _context.Address.ToList();
    }

    public DbAddress FetchById(int id)
    {
        var address = _context.Address.FirstOrDefault(a => a.Id == id);
        
        if(address == null) throw new KeyNotFoundException($"Address with id{id} has not been found");

        return address;
    }

    public DbAddress Create(string street, string postalCode, string city, string number)
    {
        var address = new DbAddress { Street = street, PostalCode = postalCode, City = city, Number = number };
        _context.Address.Add(address);
        _context.SaveChanges();
        return address;
    }
}