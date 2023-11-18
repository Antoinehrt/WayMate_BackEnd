using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Address;

public interface IAddressRepository
{
    IEnumerable<DbAddress> FetchAll();
    DbAddress FetchById(int id);
    DbAddress Create(string street, string postalCode, string city, string number);
    bool Delete(int id);
    bool Update(int id, string street, string postalCode, string city, string number);
}