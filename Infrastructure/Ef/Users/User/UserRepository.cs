using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Users.User;

public class UserRepository : IUserRepository
{
    private readonly WaymateContext _context;

    public UserRepository(WaymateContext context)
    {
        _context = context;
    }

    public IEnumerable<DbUser> FetchAll()
    {
        return _context.Users.ToList();
    }

    public DbUser FetchById(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);

        if (user == null) throw new KeyNotFoundException($"User with id{id} has not been found");
        
        return user;
    }

    public DbUser Create(string username, string password, string email, DateTime birthdate, bool isbanned)
    {
        var user = new DbUser { Username = username, Password = password, Email = email, BirthDate = birthdate, IsBanned = isbanned };
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public bool Delete(int id)
    {
        var userToDelete = _context.Users.FirstOrDefault(u => u.Id == id);

        if (userToDelete == null)
        {
            throw new KeyNotFoundException($"User with id {id} has not been found");
        }

        _context.Users.Remove(userToDelete);
        _context.SaveChanges();

        return true;
    }

    public bool Update(int id, string username, string password, string email, DateTime birthdate, bool isbanned)
    {
        var userToUpdate = _context.Users.FirstOrDefault(u => u.Id == id);

        if (userToUpdate == null)
        {
            throw new KeyNotFoundException($"User with id {id} has not been found");
        }

        userToUpdate.Username = username;
        userToUpdate.Password = password;
        userToUpdate.Email = email;
        userToUpdate.BirthDate = birthdate;
        userToUpdate.IsBanned = isbanned;

        _context.SaveChanges();
        return true;
    }
}