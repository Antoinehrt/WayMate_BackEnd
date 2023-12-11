using Application.UseCases.Authentication.Dtos;
using AutoMapper;
using Infrastructure.Ef.Users.User;

namespace Application.UseCases.Authentication;

public class UseCaseFetchByEmailRegistration
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;


    public UseCaseFetchByEmailRegistration(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public DtoOutputRegistration Execute(string username)
    {
        var dbUser = _userRepository.FetchByUsername(username);
        return _mapper.Map<DtoOutputRegistration>(dbUser);
    }
}