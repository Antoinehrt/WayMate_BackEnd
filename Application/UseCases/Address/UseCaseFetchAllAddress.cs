using Application.UseCases.Address.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef;
using Infrastructure.Ef.Address;

namespace Application.UseCases.Address;

public class UseCaseFetchAllAddress : IUseCaseQuery<IEnumerable<DtoOutputAddress>>
{
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;

    public UseCaseFetchAllAddress(IAddressRepository addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public IEnumerable<DtoOutputAddress> Execute()
    {
        var dbAddress = _addressRepository.FetchAll();
        return _mapper.Map<IEnumerable<DtoOutputAddress>>(dbAddress);
    }
}