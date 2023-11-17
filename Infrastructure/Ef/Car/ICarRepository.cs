using Domain.Enums;
using Infrastructure.Ef.DbEntities;

namespace Infrastructure.Ef.Car;

public interface ICarRepository
{
    IEnumerable<DbCar> FetchAll();
    DbCar FetchById(int id);
    DbCar Create(string numberPlate, string brand, string model, int nbSeats, FuelType fuelType, CarType carType);
    bool Delete(int id);
    bool Update(int id, string numberPlate, string brand, string model, int nbSeats, FuelType fuelType, CarType carType);
}