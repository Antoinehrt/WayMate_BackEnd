using Application.UseCases.Users.User.Dto;
using AutoMapper;
using Infrastructure.Ef.Users.User;

namespace Application.UseCases.Users.User; 

public class UserCaseFetchUserByEmail {
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserCaseFetchUserByEmail(IUserRepository userRepository, IMapper mapper) {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public DtoOutputUser Execute(string email) {
        var dbUser = _userRepository.FetchByEmail(email);
        return _mapper.Map<DtoOutputUser>(dbUser);
    }
}