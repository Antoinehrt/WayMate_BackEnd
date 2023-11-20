using Application.UseCases.User.Dtos.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef.User;

namespace Application.UseCases.User.Dtos;

public class UseCaseCreateUser : IUseCaseWriter<DtoOutputUser, DtoInputCreateUser>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public DtoOutputUser Execute(DtoInputCreateUser input)
    {
        var dbUser = _userRepository.Create(input.Username, input.Password, input.Email, input.Birthdate, input.IsBanned);
        return _mapper.Map<DtoOutputUser>(dbUser);
    }
}