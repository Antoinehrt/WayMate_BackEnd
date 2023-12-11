using Application.UseCases.Users.Admin.Dtos;
using Application.UseCases.Users.User.Dtos;
using Application.UseCases.Utils;
using AutoMapper;
using Infrastructure.Ef.Users.Admin;
using Infrastructure.Ef.Users.User;

namespace Application.UseCases.Users.Admin;

public class UseCaseCreateAdmin : IUseCaseWriter<DtoOutputUser, DtoInputCreateAdmin>
{
    private readonly IAdminRepository _adminRepository;
    private readonly IMapper _mapper;

    public UseCaseCreateAdmin(IMapper mapper, IAdminRepository adminRepository)
    {
        _mapper = mapper;
        _adminRepository = adminRepository;
    }

    public DtoOutputUser Execute(DtoInputCreateAdmin input)
    {
        var dbUser = _adminRepository.CreateAdmin(input.Username, input.Password, input.Email, input.Birthdate, input.IsBanned, input.PhoneNumber);
        return _mapper.Map<DtoOutputUser>(dbUser);
    }
}