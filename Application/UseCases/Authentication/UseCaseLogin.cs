using Application.UseCases.Authentication.Dtos;
using AutoMapper;
using Infrastructure.Ef.Authentication;
using Infrastructure.Ef.Users.User;

namespace Application.UseCases.Authentication; 

public class UseCaseLogin {
    // Cette classe devrait renvoyer le TOKEN JWT pour spécifier que l'utilisateur est connecté.

    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;

    public UseCaseLogin( IUserRepository userRepository, IPasswordHasher passwordHasher, IMapper mapper) {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
    }

    public DtoOutputLogin Execute(DtoInputLogin input) {
        var dbUser = _userRepository.FetchByEmail(input.Email);
        var result =  _passwordHasher.VerifyPwd(dbUser.Password, input.Password);

        return _mapper.Map<DtoOutputLogin>(result);
    }
}