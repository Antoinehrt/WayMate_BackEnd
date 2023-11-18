using AutoMapper;
using Infrastructure.Ef;
using Infrastructure.Ef.Address;

namespace Application.Services.Address;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;

    public AddressService(IAddressRepository addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public Domain.Entities.Address FetchById(int id)
    {
        var dbAddress = _addressRepository.FetchById(id);
        return _mapper.Map<Domain.Entities.Address>(dbAddress);
    }
}