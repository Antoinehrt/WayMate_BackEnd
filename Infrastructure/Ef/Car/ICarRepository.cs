using Domain.Enums;
using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Car;

public interface ICarRepository
{
    IEnumerable<DbCar> FetchAll();
    DbCar FetchById(int numberPlate);
    DbCar Create(string numberPlate, string brand, string model, int nbSeats, FuelType fuelType, CarType carType);
    bool Delete(int numberPlate);
    bool Update(string numberPlate, string brand, string model, int nbSeats, FuelType fuelType, CarType carType);
}