using Application.UseCases.Utils;
using Infrastructure.Ef.Car;

namespace Application.UseCases.Car;

public class UseCaseDeleteCar : IUseCaseParameterizeQuery<bool,string>
{
    private readonly ICarRepository _carRepository;

    public UseCaseDeleteCar(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }


    public bool Execute(string numberPlate)
    {
        return _carRepository.Delete(numberPlate);
    }
}