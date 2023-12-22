using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Users.Passenger; 

public interface IPassengerRepository {
    DbUser CreatePassenger(string username, string password, string email, DateTime birthdate, bool isbanned, string phoneNumber,
        string lastName, string firstName, string gender, int addressId);
    
    DbUser UpdatePassenger(int id, string username, string password, string email, DateTime birthdate, bool isbanned, string phoneNumber,
        string lastName, string firstName, string gender, int addressId);

    void ChangeUserType(int id);
}