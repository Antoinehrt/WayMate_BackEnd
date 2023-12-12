using Application.UseCases.Users.Admin;
using Application.UseCases.Users.User;
using Application.UseCases.Users.User.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Users;

[ApiController]
[Route("api/v1/user")]
public class UserController : ControllerBase {
    private readonly UseCaseFetchAllUser _useCaseFetchAllUser;
    private readonly UseCaseFetchUserById _useCaseFetchUserById;
    private readonly UserCaseFetchUserByEmail _userCaseFetchUserByEmail;
    private readonly UseCaseDeleteUser _useCaseDeleteUser;
    private readonly UseCaseUpdateUser _useCaseUpdateUser;

    public UserController(
        UseCaseFetchAllUser useCaseFetchAllUser,
        UseCaseFetchUserById useCaseFetchUserById,
        UserCaseFetchUserByEmail userCaseFetchUserByEmail,
        UseCaseDeleteUser useCaseDeleteUser,
        UseCaseUpdateUser useCaseUpdateUser, UseCaseCreateAdmin useCaseCreateAdmin) {
        _useCaseFetchAllUser = useCaseFetchAllUser;
        _useCaseFetchUserById = useCaseFetchUserById;
        _userCaseFetchUserByEmail = userCaseFetchUserByEmail;
        _useCaseDeleteUser = useCaseDeleteUser;
        _useCaseUpdateUser = useCaseUpdateUser;
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
            return  Ok(_useCaseFetchUserById.Execute(id));
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
            return result != null ? Ok(result) : NotFound(new { Message = "User not found" });
    
        }
        catch (KeyNotFoundException e) {
            return NotFound(new {
                e.Message
            });
        }
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