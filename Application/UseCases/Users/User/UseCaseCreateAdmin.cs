using Application.UseCases.Users.User.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef.Users.User;

namespace Application.UseCases.Users.User;

public class UseCaseCreateAdmin : IUseCaseWriter<DtoOutputUser, DtoInputCreateAdmin>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UseCaseCreateAdmin(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public DtoOutputUser Execute(DtoInputCreateAdmin input)
    {
        var dbUser = _userRepository.CreateAdmin(input.Username, input.Password, input.Email, input.Birthdate, input.IsBanned, input.PhoneNumber);
        return _mapper.Map<DtoOutputUser>(dbUser);
    }
}