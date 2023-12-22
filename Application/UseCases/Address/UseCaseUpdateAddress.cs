using Application.UseCases.Address.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;
using Infrastructure.Ef.Address;

namespace Application.UseCases.Address;

public class UseCaseUpdateAddress: IUseCaseParameterizeQuery<bool,DtoInputUpdateAddress>
{
    private readonly IAddressRepository _addressRepository;

    public UseCaseUpdateAddress(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public bool Execute(DtoInputUpdateAddress param) {
        return _addressRepository.Update(param.Id, param.Street, param.PostalCode, param.City, param.Number, param.Country);
    }
}