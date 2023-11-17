using Domain.Enums;

namespace Infrastructure.Ef.DbEntities;

public class DbCar
{
    public string NumberPlate { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int NbSeats { get; set; }
    public FuelType FuelType { get; set; }
    public CarType CarType { get; set; }
}