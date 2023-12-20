using Domain.Enums;
using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Car;

public interface ICarRepository
{
    IEnumerable<DbCar> FetchAll();
    DbCar FetchById(string numberPlate);
    DbCar Create(string numberPlate, string brand, string model, int nbSeats, FuelType fuelType, CarType carType, string color);
    bool Delete(string numberPlate);
    bool Update(string numberPlate, string brand, string model, int nbSeats, FuelType fuelType, CarType carType, string color);
}