using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Users.Admin; 

public interface IAdminRespository {
    IEnumerable<DbUser> FectchAll();

    DbUser CreateAdmin(string username, string password, string email, DateTime birthdate, bool isBanned,
        string phoneNumber);

    DbUser UpdateUser(int id, string username, string password, string email, DateTime birthDate, bool isBanned,
        string phoneNumber);
}