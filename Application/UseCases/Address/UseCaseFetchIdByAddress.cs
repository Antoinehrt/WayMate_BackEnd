using Infrastructure.Ef.Address;

namespace Application.UseCases.Address;

public class UseCaseFetchIdByAddress
{
    private readonly IAddressRepository _addressRepository;

    public UseCaseFetchIdByAddress(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<int> GetIdByAddressAsync(string street, string postalCode, string city, string number, string country)
    {
        var id = await _addressRepository.GetIdByAddress(street, postalCode, city, number, country);

        return id;
    }
}