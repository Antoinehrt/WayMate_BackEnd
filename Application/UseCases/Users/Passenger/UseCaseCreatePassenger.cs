using Application.UseCases.Users.Admin.Dtos;
using Application.UseCases.Users.Passenger.Dto;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef.Authentication;
using Infrastructure.Ef.Users.Passenger;
using Infrastructure.Ef.Users.User;

namespace Application.UseCases.Users.Passenger;

public class UseCaseCreatePassenger : IUseCaseWriter<DtoOutputPassenger, DtoInputCreatePassenger> {
    private readonly IPassengerRepository _passengerRepository;
    private readonly IMapper _mapper;

    public UseCaseCreatePassenger(IPassengerRepository passengerRepository, IMapper mapper) {
        _passengerRepository = passengerRepository;
        _mapper = mapper;
    }

    public DtoOutputPassenger Execute(DtoInputCreatePassenger input) {
        var dbUser = _passengerRepository.CreatePassenger(input.Username, input.Password, input.Email, input.Birthdate,
            input.IsBanned, input.PhoneNumber, input.LastName, input.FirstName, input.Gender, input.AddressId);
        return _mapper.Map<DtoOutputPassenger>(dbUser);
    }
}