using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Users.Driver; 

public interface IDriverRepository {
    DbUser CreateDriver(string username, string password, string email, DateTime birthdate, bool isbanned, string phoneNumber,
        string lastName, string firstName, string gender, int addressId, string carPlate);
    DbUser UpdateDriver(int id, string username, string password, string email, DateTime birthdate, bool isbanned, string phoneNumber,
        string lastName, string firstName, string gender, int addressId, string carPlate);
}