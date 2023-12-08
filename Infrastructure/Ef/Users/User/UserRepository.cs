using Domain.Enums;
using Infrastructure.Ef.Authentication;
using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Users.User;

public class UserRepository : IUserRepository
{
    private readonly WaymateContext _context;
    private readonly IPasswordHasher _passwordHasher;
    public UserRepository(WaymateContext context, IPasswordHasher passwordHasher) {
        _context = context;
        _passwordHasher = passwordHasher;
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

    public DbUser FetchByEmail(string email) {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);

        if (user == null) throw new KeyNotFoundException($"User with email {email} has not been found");

        return user;
    }

    public DbUser CreateAdmin(string username, string password, string email, DateTime birthdate, bool isbanned, string phoneNumber) {
        
        var user = new DbUser {
            Username = username, 
            UserType = UserType.Admin.ToString(),
            Password = _passwordHasher.HashPwd(password), 
            Email = email, 
            BirthDate = birthdate, 
            IsBanned = isbanned,
            PhoneNumber = phoneNumber
        };
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }
        };
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

        if (userToUpdate == null) {
            throw new KeyNotFoundException($"User with id {id} has not been found");
        }

        userToUpdate.Username = username;
        userToUpdate.Password = _passwordHasher.HashPwd(password);
        userToUpdate.Email = email;
        userToUpdate.BirthDate = birthdate;
        userToUpdate.IsBanned = isbanned;

        _context.SaveChanges();
        return true;
    }
}