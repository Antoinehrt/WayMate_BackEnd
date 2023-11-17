using Domain.Enums;

namespace Application.UseCases.Car.Dtos;

public class DtoOutputCar
{
    public string NumberPlate { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int NbSeats { get; set; }
    public FuelType FuelType { get; set; }
    public CarType CarType { get; set; }
}