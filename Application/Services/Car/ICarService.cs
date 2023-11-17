namespace Application.Services.Car;

public interface ICarService
{
    Domain.Entities.Car FetchById(int id);
}