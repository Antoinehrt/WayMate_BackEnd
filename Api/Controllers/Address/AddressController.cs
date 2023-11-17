using Application.UseCases.Address;
using Application.UseCases.Address.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Address;

[ApiController]
[Route("api/v1/address")]
public class AddressController : ControllerBase
{
    private readonly UseCaseCreateAddress _useCaseCreateAddress;
    private readonly UseCaseFetchAllAddress _useCaseFetchAllAddress;
    private readonly UseCaseFetchAddressById _useCaseFetchAddressById;
    private readonly UseCaseDeleteAddress _useCaseDeleteAddress;
    private readonly UseCaseUpdateAddress _useCaseUpdateAddress;

    public AddressController(UseCaseCreateAddress useCaseCreateAddress, 
        UseCaseFetchAllAddress useCaseFetchAllAddress, 
        UseCaseFetchAddressById useCaseFetchAddressById, 
        UseCaseDeleteAddress useCaseDeleteAddress, UseCaseUpdateAddress useCaseUpdateAddress)
    {
        _useCaseCreateAddress = useCaseCreateAddress;
        _useCaseFetchAllAddress = useCaseFetchAllAddress;
        _useCaseFetchAddressById = useCaseFetchAddressById;
        _useCaseDeleteAddress = useCaseDeleteAddress;
        _useCaseUpdateAddress = useCaseUpdateAddress;
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

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Delete(int id)
    {
        if(_useCaseDeleteAddress.Execute(id)) return NoContent();
        return NotFound();
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Update(int id, [FromBody] DtoInputUpdateAddress dto)
    {
        dto.Id = id;
        return _useCaseUpdateAddress.Execute(dto) ? NoContent() : NotFound();
    }
}