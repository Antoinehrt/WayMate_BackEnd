using Application.UseCases.Car.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef.Car;

namespace Application.UseCases.Car;

public class UseCaseCreateCar : IUseCaseWriter<DtoOutputCar, DtoInputCreateCar>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public UseCaseCreateCar(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public DtoOutputCar Execute(DtoInputCreateCar input)
    {
        var dbCar = _carRepository.Create(input.NumberPlate, input.Brand, input.Model, input.NbSeats, input.FuelType,
            input.CarType, input.Color);
        return _mapper.Map<DtoOutputCar>(dbCar);
        
    }
}