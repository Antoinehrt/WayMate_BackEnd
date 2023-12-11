using Application.UseCases.Users.User.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef.Users.User;

namespace Application.UseCases.Users.User;

public class UseCaseCreatePassenger : IUseCaseWriter<DtoOutputUser, DtoInputCreatePassenger>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UseCaseCreatePassenger(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public DtoOutputUser Execute(DtoInputCreatePassenger input)
    {
        var dbUser = _userRepository.CreatePassenger(input.Username, input.Password, input.Email, input.Birthdate, input.IsBanned, input.PhoneNumber,
            input.LastName, input.FirstName, input.Gender, input.AddressId);
        return _mapper.Map<DtoOutputUser>(dbUser);
    }
}