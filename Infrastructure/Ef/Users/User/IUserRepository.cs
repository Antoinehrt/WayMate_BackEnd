using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Users.User;

public interface IUserRepository
{
    IEnumerable<DbUser> FetchAll();
    DbUser FetchById(int id);
    DbUser Create(string username, string password, string email, string birthdate, bool isbanned);
    bool Delete(int id);
    bool Update(int id, string username, string password, string email, string birthdate, bool isbanned);
}