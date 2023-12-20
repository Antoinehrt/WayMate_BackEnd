using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Application.UseCases.Car.Dtos;

public class DtoInputCreateCar
{
    [Required] public string NumberPlate { get; set; }
    [Required] public string Brand { get; set; }
    [Required] public string Model { get; set; }
    [Required] public int NbSeats { get; set; }
    [Required] public FuelType FuelType { get; set; }
    [Required] public CarType CarType { get; set; }
    [Required] public string Color { get; set; }
}