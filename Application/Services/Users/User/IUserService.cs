namespace Application.Services.Users.User;

public interface IUserService
{
    Domain.Entities.Users.User FetchById(int id);
}