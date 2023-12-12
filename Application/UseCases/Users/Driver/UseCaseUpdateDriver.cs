using Application.UseCases.Users.Admin.Dtos;
using Application.UseCases.Users.Driver.Dto;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef.Users.Driver;

namespace Application.UseCases.Users.Driver; 

public class UseCaseUpdateDriver :IUseCaseWriter<DtoOuputDriver, DtoInputUpdateDriver> {
    private readonly IDriverRepository _driverRepository;
    private readonly IMapper _mapper;

    public UseCaseUpdateDriver(IDriverRepository driverRepository, IMapper mapper) {
        _driverRepository = driverRepository;
        _mapper = mapper;
    }

    public DtoOuputDriver Execute(DtoInputUpdateDriver input) {
        var dbDriver = _driverRepository.UpdateDriver(input.Id,input.Username, input.Password, input.Email, 
            input.Birthdate, input.IsBanned, input.PhoneNumber, input.LastName, input.FirstName, input.Gender, input.AddressId, input.CarPlate);
        return _mapper.Map<DtoOuputDriver>(dbDriver);
    }
}