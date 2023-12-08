using Application.UseCases.Address;
using Application.UseCases.Users.User;
using Application.UseCases.Users.User.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Users.User;

[ApiController]
[Route("api/v1/user")]
public class UserController : ControllerBase {
    private readonly UseCaseCreatePassenger _useCaseCreatePassenger;
    private readonly UseCaseCreateAdmin _useCaseCreateAdmin;
    private readonly UseCaseFetchAllUser _useCaseFetchAllUser;
    private readonly UseCaseFetchUserById _useCaseFetchUserById;
    private readonly UserCaseFetchUserByEmail _userCaseFetchUserByEmail;
    private readonly UseCaseDeleteUser _useCaseDeleteUser;
    private readonly UseCaseUpdateUser _useCaseUpdateUser;

    public UserController(UseCaseCreatePassenger useCaseCreatePassenger,
        UseCaseFetchAllUser useCaseFetchAllUser,
        UseCaseFetchUserById useCaseFetchUserById,
        UserCaseFetchUserByEmail userCaseFetchUserByEmail,
        UseCaseDeleteUser useCaseDeleteUser,
        UseCaseUpdateUser useCaseUpdateUser, UseCaseCreateAdmin useCaseCreateAdmin) {
        _useCaseCreatePassenger = useCaseCreatePassenger;
        _useCaseFetchAllUser = useCaseFetchAllUser;
        _useCaseFetchUserById = useCaseFetchUserById;
        _userCaseFetchUserByEmail = userCaseFetchUserByEmail;
        _useCaseDeleteUser = useCaseDeleteUser;
        _useCaseUpdateUser = useCaseUpdateUser;
        _useCaseCreateAdmin = useCaseCreateAdmin;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputUser>> FetchAll() {
        return Ok(_useCaseFetchAllUser.Execute());
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputUser> FetchById(int id) {
        try {
            return _useCaseFetchUserById.Execute(id);
        }
        catch (KeyNotFoundException e) {
            return NotFound(new {
                e.Message
            });
        }
    }

    [HttpGet]
    [Route("{email}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputUser> FetchByEmail(string email) {
        try {
            var result = _userCaseFetchUserByEmail.Execute(email);
            if (result == null) return NotFound(new { Message = "User not found" });
            return result;
        }
        catch (KeyNotFoundException e) {
            return NotFound(new {
                e.Message
            });
        }
    }


    [HttpPost]
    [Route("passenger")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputUser> CreatePassenger(DtoInputCreatePassenger dto) {
        var output = _useCaseCreatePassenger.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.Id },
            output
        );
    }


    [HttpPost]
    [Route("admin")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputUser> CreateAdmin(DtoInputCreateAdmin dto) {
        var output = _useCaseCreateAdmin.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.Id },
            output
        );
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Delete(int id) {
        if (_useCaseDeleteUser.Execute(id)) return NoContent();
        return NotFound();
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Update(int id, [FromBody] DtoInputUpdateUser dto) {
        dto.Id = id;
        return _useCaseUpdateUser.Execute(dto) ? NoContent() : NotFound();
    }
}