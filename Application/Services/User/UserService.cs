using AutoMapper;
using Infrastructure.Ef.User;

namespace Application.Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public Domain.Entities.Users.User FetchById(int id)
    {
        var dbUser = _userRepository.FetchById(id);
        return _mapper.Map<Domain.Entities.Users.User>(dbUser);
    }
}