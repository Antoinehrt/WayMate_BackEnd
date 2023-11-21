using Application.UseCases.Address;
using Application.UseCases.User;
using Application.UseCases.User.Dtos;
using Application.UseCases.User.Dtos.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User;

public class UserController : ControllerBase
{
    private readonly UseCaseCreateUser _useCaseCreateUser;
    private readonly UseCaseFetchAllAddress _useCaseFetchAllAddress;
    private readonly UseCaseFetchUserById _useCaseFetchUserById;
    private readonly UseCaseDeleteUser _useCaseDeleteUser;
    private readonly UseCaseUpdateUser _useCaseUpdateUser;

    public UserController(UseCaseCreateUser useCaseCreateUser, UseCaseFetchAllAddress useCaseFetchAllAddress, UseCaseFetchUserById useCaseFetchUserById, UseCaseDeleteUser useCaseDeleteUser, UseCaseUpdateUser useCaseUpdateUser)
    {
        _useCaseCreateUser = useCaseCreateUser;
        _useCaseFetchAllAddress = useCaseFetchAllAddress;
        _useCaseFetchUserById = useCaseFetchUserById;
        _useCaseDeleteUser = useCaseDeleteUser;
        _useCaseUpdateUser = useCaseUpdateUser;
    }

   /* [HttpGet]
    public Action<IEnumerable<DtoOutputUser>> FetchAll()
    {
        return Ok(_useCase)
    }*/
   [HttpGet]
   [Route("{id:int}")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   public ActionResult<DtoOutputUser> FetchById(int id)
   {
       try
       {
           return _useCaseFetchUserById.Execute(id);
       }
       catch (KeyNotFoundException e)
       {
           return NotFound(new
           {
               e.Message
           });
       }
   }

   
   [HttpPost]
   [ProducesResponseType(StatusCodes.Status201Created)]
   public ActionResult<DtoOutputUser> Create(DtoInputCreateUser dto)
   {
       var output = _useCaseCreateUser.Execute(dto);
       return CreatedAtAction(
           nameof(FetchById),
           new { id = output.Id },
           output
       );
   }

}