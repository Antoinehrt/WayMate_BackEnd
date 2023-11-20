using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.User;

public class UserRepository : IUserRepository
{
    private readonly WaymateContext _context;

    public UserRepository(WaymateContext context)
    {
        _context = context;
    }

    public IEnumerable<DbUser> FetchAll()
    {
        return _context.User.ToList();
    }

    public DbUser FetchById(int id)
    {
        var user = _context.User.FirstOrDefault(u => u.Id == id);

        if (user == null) throw new KeyNotFoundException($"User with id{id} has not been found");
    }

    public DbUser Create(string username, string password, string email, string birthdate, bool isbanned)
    {
        var user = new DbUser { Username = username, Password = password, Email = email, Birthdate = birthdate, IsBanned = isbanned };
        _context.User.Add(user);
        _context.SaveChanges();
        return user;
    }
}