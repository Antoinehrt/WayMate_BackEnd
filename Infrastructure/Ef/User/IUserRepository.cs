using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.User;

public interface IUserRepository
{
    IEnumerable<DbUser> FetchAll();
    DbUser FetchById(int id);
    DbUser Create(string username, string password, string email, string birthdate, bool isbanned);
}