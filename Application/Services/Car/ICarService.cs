namespace Application.Services.Car;

public interface ICarService
{
    Domain.Entities.Car FetchById(string numberPlate);
}