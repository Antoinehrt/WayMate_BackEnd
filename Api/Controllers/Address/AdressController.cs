using Application.UseCases.Address;
using Application.UseCases.Address.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Address;

[ApiController]
[Route("api/v1/address")]
public class AdressController : ControllerBase
{
    private readonly UseCaseCreateAddress _useCaseCreateAddress;
    private readonly UseCaseFetchAllAddress _useCaseFetchAllAddress;
    private readonly UseCaseFetchAddressById _useCaseFetchAddressById;

    public AdressController(UseCaseCreateAddress useCaseCreateAddress, 
        UseCaseFetchAllAddress useCaseFetchAllAddress, 
        UseCaseFetchAddressById useCaseFetchAddressById)
    {
        _useCaseCreateAddress = useCaseCreateAddress;
        _useCaseFetchAllAddress = useCaseFetchAllAddress;
        _useCaseFetchAddressById = useCaseFetchAddressById;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputAddress>> FetchAll()
    {
        return Ok(_useCaseFetchAllAddress.Execute());
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputAddress> FetchById(int id)
    {
        try
        {
            return _useCaseFetchAddressById.Execute(id);
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
    public ActionResult<DtoOutputAddress> Create(DtoInputCreateAddress dto)
    {
        var output = _useCaseCreateAddress.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.Id },
            output
        );
    }
}