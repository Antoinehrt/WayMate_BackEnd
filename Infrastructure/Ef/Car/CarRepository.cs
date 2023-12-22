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
        return _context.Cars.ToList();
    }

    public DbCar FetchById(string numberPlate)
    {
        var car = _context.Cars.FirstOrDefault((c => c.NumberPlate == numberPlate));
        if(car == null) throw new KeyNotFoundException($"Car with numberPlate{numberPlate} has not been found");
        return car;
    }

    public DbCar Create(string numberPlate, string brand, string model, int nbSeats, FuelType fuelType, CarType carType, string color)
    {
        var car = new DbCar
        {
            NumberPlate = numberPlate, Brand = brand, Model = model, NbSeats = nbSeats, FuelType = Enum.GetName(typeof(FuelType), fuelType),
            CarType = Enum.GetName(typeof(CarType), carType), Color = color
        };
        _context.Cars.Add(car);
        _context.SaveChanges();
        return car;
    }

    public bool Delete(string numberPlate)
    {
        var carToDelete = _context.Cars.FirstOrDefault(c => c.NumberPlate == numberPlate);
        if(carToDelete == null) throw new KeyNotFoundException($"Car with numberPlate{numberPlate} has not been found");
        _context.Cars.Remove(carToDelete);
        _context.SaveChanges();
        return true;
    }

    public bool Update(string numberPlate, string brand, string model, int nbSeats, FuelType fuelType, CarType carType, string color)
    {
        var carToUpdate = _context.Cars.FirstOrDefault(c => c.NumberPlate == numberPlate);
        if (carToUpdate == null) return false;

        carToUpdate.Brand = brand;
        carToUpdate.Model = model;
        carToUpdate.NbSeats = nbSeats;
        carToUpdate.FuelType = Enum.GetName(typeof(FuelType), fuelType);
        carToUpdate.CarType = Enum.GetName(typeof(CarType), carType);
        carToUpdate.Color = color;

        _context.SaveChanges();
        return true;
    }
}