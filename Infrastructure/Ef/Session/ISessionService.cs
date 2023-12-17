using Domain.Entities.Users;

namespace Infrastructure.Ef.Session;

public interface ISessionService
{
    string BuildToken(string key, string issuer, User user, string function);

    // string BuildTokenFunction(string key, string issuer, string role);
    
    string BuildTokenPublic(string key, string issuer, User user, int id, string function);

    bool IsTokenValid(string key, string issuer, string token);
}