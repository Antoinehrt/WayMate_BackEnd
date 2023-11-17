using AutoMapper;
using Infrastructure.Ef.Car;

namespace Application.Services.Car;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public CarService(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public Domain.Entities.Car FetchById(int id)
    {
        var dbCar = _carRepository.FetchById(id);
        return _mapper.Map<Domain.Entities.Car>(dbCar);
    }
}