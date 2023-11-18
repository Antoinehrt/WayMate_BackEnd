using Application.UseCases.Address.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef;
using Infrastructure.Ef.Address;

namespace Application.UseCases.Address;

public class UseCaseFetchAddressById : IUseCaseParameterizeQuery<DtoOutputAddress, int>
{
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;

    public UseCaseFetchAddressById(IAddressRepository addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public DtoOutputAddress Execute(int id)
    {
        var dbAddress = _addressRepository.FetchById(id);
        return _mapper.Map<DtoOutputAddress>(dbAddress);
    }
}