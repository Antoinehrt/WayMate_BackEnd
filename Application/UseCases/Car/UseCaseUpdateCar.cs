using Application.UseCases.Car.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef.Address;
using Infrastructure.Ef.Car;

namespace Application.UseCases.Car;

public class UseCaseUpdateCar : IUseCaseParameterizeQuery<bool, DtoInputUpdateCar>
{
    private readonly ICarRepository _carRepository;

    public UseCaseUpdateCar(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public bool Execute(DtoInputUpdateCar update)
    {
        return _carRepository.Update(update.NumberPlate, update.Brand, update.Model, update.NbSeats, update.FuelType, update.CarType, update.Color);
    }
}