using Infrastructure.Ef;

namespace Application.UseCases.Address;

public class UseCaseDeleteAddress
{
    private readonly IAddressRepository _addressRepository;

    public UseCaseDeleteAddress(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public bool Execute(int id)
    {
        return _addressRepository.Delete(id);
    }
}