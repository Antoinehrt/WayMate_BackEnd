using Application.UseCases.Users.Passenger.Dto;
using AutoMapper;
using Infrastructure.Ef.Users.Passenger;

namespace Application.UseCases.Users.Passenger; 

public class UseCaseChangeUserTypeFromPassenger {
    private readonly IPassengerRepository _passengerRepository;

    public UseCaseChangeUserTypeFromPassenger(IPassengerRepository passengerRepository) {
        _passengerRepository = passengerRepository;
    }

    public void Execute(int id) {
        _passengerRepository.ChangeUserType(id);
    }
}