using Application.UseCases.Users.Admin;
using Application.UseCases.Users.Admin.Dtos;
using Application.UseCases.Users.User.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Users; 

[ApiController]
[Route("api/v1/admin")]
public class AdminController {
    private readonly UseCaseCreateAdmin _useCaseCreateAdmin;

    public AdminController(UseCaseCreateAdmin useCaseCreateAdmin) {
        _useCaseCreateAdmin = useCaseCreateAdmin;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputAdmin> Create(DtoInputCreateAdmin dto) {
        var output = _useCaseCreateAdmin.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.Id },
            output
        );
    }
    
}