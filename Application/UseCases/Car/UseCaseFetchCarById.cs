using Application.UseCases.Car.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef.Car;

namespace Application.UseCases.Car;

public class UseCaseFetchCarById : IUseCaseParameterizeQuery<DtoOutputCar, string>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public UseCaseFetchCarById(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public DtoOutputCar Execute(string numberPlate)
    {
        var dbCar = _carRepository.FetchById(numberPlate);
        return _mapper.Map<DtoOutputCar>(dbCar);
    }
}