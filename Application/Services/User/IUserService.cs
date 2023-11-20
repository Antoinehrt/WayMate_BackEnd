namespace Application.Services.User;

public interface IUserService
{
    Domain.Entities.Users.User FetchById(int id);
}