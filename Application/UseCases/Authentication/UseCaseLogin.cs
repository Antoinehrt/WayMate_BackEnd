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

    public DtoOutputLogin Execute(string email, string password) {
        var dbUser = _userRepository.FetchByEmail(email);
        if (dbUser == null) return new DtoOutputLogin { IsLogged = false }; //Cette ligne pourrait aussi retourner une erreur
        if (string.IsNullOrEmpty(password)) return new DtoOutputLogin { IsLogged = false };
        
        var isPasswordValid =  _passwordHasher.VerifyPwd(dbUser.Password, password);

        return new DtoOutputLogin { IsLogged = isPasswordValid };
    }
}