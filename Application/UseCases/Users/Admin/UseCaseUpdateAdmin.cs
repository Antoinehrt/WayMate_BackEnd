using Application.UseCases.Address.Dtos;
using Application.UseCases.Car.Dtos;
using Application.UseCases.Users.Admin.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef.Users.User;

namespace Application.UseCases.Users.Admin; 

public class UseCaseUpdateAdmin : IUseCaseWriter<DtoOutputAdmin, DtoInputUpdateAdmin> {
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UseCaseUpdateAdmin(IUserRepository userRepository, IMapper mapper) {
        _userRepository = userRepository;
        _mapper = mapper;
    }
   // bool Update(int id, string username, string password, string email, DateTime birthdate, bool isbanned, string phoneNumber,
     //   string lastName, string firstName, string gender, int addressId, string carPlate);
    public DtoOutputAdmin Execute(DtoInputUpdateAdmin input) {
        //var dbUser = _userRepository.Update(input.Id, input.Username, input.Email, input.Birthdate, input.IsBanned input.PhoneNumber);
        return null;
    }
}