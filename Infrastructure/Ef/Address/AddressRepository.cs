using Infrastructure.Ef.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef.Address;

public class AddressRepository : IAddressRepository
{
    private readonly WaymateContext _context;

    public AddressRepository(WaymateContext context)
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

    public DbAddress Create(string street, string postalCode, string city, string number, string country)
    {
        var address = new DbAddress { Street = street, PostalCode = postalCode, City = city, Number = number, Country = country};
        _context.Address.Add(address);
        _context.SaveChanges();
        return address;
    }
    public bool Delete(int id)
    {
        var addressToDelete = _context.Address.FirstOrDefault(a => a.Id == id);

        if (addressToDelete == null)
        {
            throw new KeyNotFoundException($"Address with id {id} has not been found");
        }

        _context.Address.Remove(addressToDelete);
        _context.SaveChanges();

        return true;
    }

    public bool Update(int id, string street, string postalCode, string city, string number, string country)
    {
        var addressToUpdate = _context.Address.FirstOrDefault(a => a.Id == id);
        if (addressToUpdate == null) return false;

        addressToUpdate.City = city;
        addressToUpdate.Street = street;
        addressToUpdate.PostalCode = postalCode;
        addressToUpdate.Number = number;
        addressToUpdate.Country = country;

        _context.SaveChanges();
        return true;
    }

    public async Task<int> GetIdByAddress(string street, string postalCode, string city, string number, string country)
    {
        var addressEntity = await _context.Address
            .FirstOrDefaultAsync(a =>
                a.Street == street &&
                a.PostalCode == postalCode &&
                a.City == city &&
                a.Number == number &&
                a.Country == country);

        return addressEntity?.Id ?? 0;
    }
}