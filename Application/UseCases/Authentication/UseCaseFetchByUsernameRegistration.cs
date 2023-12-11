using Application.UseCases.Authentication.Dtos;
using AutoMapper;
using Infrastructure.Ef.Users.User;

namespace Application.UseCases.Authentication;

public class UseCaseFetchByUsernameRegistration
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;


    public UseCaseFetchByUsernameRegistration(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public DtoOutputRegistration Execute(string email)
    {
        var dbUser = _userRepository.FetchByEmail(email);
        return _mapper.Map<DtoOutputRegistration>(dbUser);
    }
}