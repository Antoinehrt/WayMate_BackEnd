using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Users.User;

public interface IUserRepository
{
    IEnumerable<DbUser> FetchAll();
    DbUser FetchById(int id);
    DbUser FetchByEmail(string email);

    DbUser Create(string username, string password, string email, DateTime birthdate, bool isbanned, string phoneNumber,
        string lastName, string firstName, string gender, int addressId, string carPlate);

    DbUser Update(int id, string username, string password, string email, DateTime birthdate, bool isbanned, string phoneNumber,
        string lastName, string firstName, string gender, int addressId, string carPlate);

    DbUser FetchByUsernameDbUser(string username);

    bool Delete(int id);
    bool FetchByUsername(string username);
    bool FetchByEmailBool(string email);
}