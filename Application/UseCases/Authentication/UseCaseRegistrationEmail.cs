using Application.UseCases.Authentication.Dtos;
using AutoMapper;
using Infrastructure.Ef.Users.User;

namespace Application.UseCases.Authentication;

public class UseCaseRegistrationEmail
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UseCaseRegistrationEmail(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public DtoOutputRegistration Execute(string email)
    {
        var dbUser = _userRepository.FetchByEmailBool(email);

        return new DtoOutputRegistration { IsInDb = dbUser };
    }
}