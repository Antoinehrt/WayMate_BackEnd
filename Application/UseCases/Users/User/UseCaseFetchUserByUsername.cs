using Application.UseCases.Users.User.Dtos;
using AutoMapper;
using Infrastructure.Ef.Users.User;

namespace Application.UseCases.Users.User;

public class UseCaseFetchUserByUsername
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UseCaseFetchUserByUsername(IUserRepository userRepository, IMapper mapper) {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public DtoOutputUser Execute(string username) {
        var dbUser = _userRepository.FetchByUsername(username);
        return _mapper.Map<DtoOutputUser>(dbUser);
    }
}