using Application.UseCases.Users.Admin;
using Application.UseCases.Users.Admin.Dtos;
using Application.UseCases.Users.User;
using Application.UseCases.Users.User.Dtos;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace Api.Controllers.Users;

[ApiController]
[Route("api/v1/admin")]
public class AdminController : ControllerBase {
    private readonly UseCaseCreateAdmin _useCaseCreateAdmin;
    private readonly UseCaseFetchUserById _useCaseFetchUserById;

    public AdminController(UseCaseCreateAdmin useCaseCreateAdmin,
        UseCaseFetchUserById useCaseFetchUserById) {
        _useCaseCreateAdmin = useCaseCreateAdmin;
        _useCaseFetchUserById = useCaseFetchUserById;
    }


    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputAdmin> FetchById(int id) {
        try {
            var userResult = _useCaseFetchUserById.Execute(id);

            if (userResult.UserType != UserType.Admin.ToString())
                return NotFound($"User with ID {id} is not an admin.");
            
            return new DtoOutputAdmin {
                Id = userResult.Id,
                UserType = userResult.UserType,
                Username = userResult.Username,
                Password = userResult.Password,
                Email = userResult.Email,
                Birthdate = userResult.Birthdate,
                IsBanned = userResult.IsBanned,
                PhoneNumber = userResult.PhoneNumber
            };
        }
        catch (KeyNotFoundException e) {
            return NotFound(new {
                e.Message
            });
        }
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