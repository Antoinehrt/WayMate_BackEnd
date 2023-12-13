using Application.UseCases.Address.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef.Address;
using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.Address;

public class UseCaseFetchAddressByAddress : IUseCaseParameterizeQuery<DtoOutputAddress, DtoInputFetchByAddress>
{
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;

    public UseCaseFetchAddressByAddress(IAddressRepository addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public DtoOutputAddress Execute(DtoInputFetchByAddress dto)
    {
        int? addressId = _addressRepository.FetchIdByValue(dto.Street, dto.PostalCode, dto.City, dto.Number);
        
        return _mapper.Map<DtoOutputAddress>(addressId);
    }
}