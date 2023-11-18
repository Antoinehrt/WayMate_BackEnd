using Application.UseCases.Utils;
using Infrastructure.Ef;
using Infrastructure.Ef.Address;

namespace Application.UseCases.Address;

public class UseCaseDeleteAddress: IUseCaseParameterizeQuery<bool,int>
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