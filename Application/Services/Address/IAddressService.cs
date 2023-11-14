namespace Application.Services.Address;

public interface IAddressService
{
    Domain.Entities.Address FetchById(int id);
    
}