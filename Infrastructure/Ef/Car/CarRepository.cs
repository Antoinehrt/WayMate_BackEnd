using Domain.Enums;
using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Car;

public class CarRepository : ICarRepository
{
    private readonly WaymateContext _context;

    public CarRepository(WaymateContext context)
    {
        _context = context;
    }

    public IEnumerable<DbCar> FetchAll()
    {
        throw new NotImplementedException();
    }

    public DbCar FetchById(int id)
    {
        throw new NotImplementedException();
    }

    public DbCar Create(string numberPlate, string brand, string model, int nbSeats, FuelType fuelType, CarType carType)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public bool Update(string numberPlate, string brand, string model, int nbSeats, FuelType fuelType, CarType carType)
    {
        throw new NotImplementedException();
    }
}