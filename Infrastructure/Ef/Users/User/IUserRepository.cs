using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Users.User;

public interface IUserRepository
{
    IEnumerable<DbUser> FetchAll();
    DbUser FetchById(int id);
    DbUser FetchByEmail(string email);
    bool FetchByEmailBool(string email);
    bool FetchByUsername(string username);
    DbUser Create(string username, string password, string email, DateTime birthdate, bool isbanned);
    bool Delete(int id);
    bool Update(int id, string username, string password, string email, DateTime birthdate, bool isbanned);
}