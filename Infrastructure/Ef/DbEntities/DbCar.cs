using Domain.Enums;

namespace Infrastructure.Ef.DbEntities;

public class DbCar
{
    public string NumberPlate { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int NbSeats { get; set; }
    public string? FuelType { get; set; }
    public string? CarType { get; set; }
    
    public string Color { get; set; }
}