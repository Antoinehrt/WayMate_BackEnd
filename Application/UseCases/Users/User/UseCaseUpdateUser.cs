using Application.UseCases.Users.User.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef.Users.User;

namespace Application.UseCases.Users.User;

public class UseCaseUpdateUser : IUseCaseParameterizeQuery<bool, DtoInputUpdateUser>
{
    private readonly IUserRepository _userRepository;

    public UseCaseUpdateUser(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public bool Execute(DtoInputUpdateUser param)
    {
        return _userRepository.Update(param.Id, param.Username, param.Password, param.Email, param.Birthdate, param.IsBanned);
    }
}