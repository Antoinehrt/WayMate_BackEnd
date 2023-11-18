using Application.UseCases.Car.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef.Car;

namespace Application.UseCases.Car;

public class UseCaseFetchAllCar : IUseCaseQuery<IEnumerable<DtoOutputCar>>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public UseCaseFetchAllCar(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public IEnumerable<DtoOutputCar> Execute()
    {
        var dbCar = _carRepository.FetchAll();
        return _mapper.Map<IEnumerable<DtoOutputCar>>(dbCar);
    }
}