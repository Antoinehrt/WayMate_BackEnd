using Application.UseCases.Address.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef;

namespace Application.UseCases.Address;

public class UseCaseCreateAddress : IUseCaseWriter<DtoOutputAddress,DtoInputCreateAddress>
{
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;


    public UseCaseCreateAddress(IAddressRepository addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public DtoOutputAddress Execute(DtoInputCreateAddress input)
    {
        var dbAddress = _addressRepository.Create(input.Street, input.PostalCode, input.City, input.Number);
        return _mapper.Map<DtoOutputAddress>(dbAddress);
    }
}