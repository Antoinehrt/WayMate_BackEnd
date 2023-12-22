using Application.UseCases.Address;
using Application.UseCases.Address.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/address")]
public class AddressController : ControllerBase
{
    private readonly UseCaseCreateAddress _useCaseCreateAddress;
    private readonly UseCaseFetchAllAddress _useCaseFetchAllAddress;
    private readonly UseCaseFetchAddressById _useCaseFetchAddressById;
    private readonly UseCaseDeleteAddress _useCaseDeleteAddress;
    private readonly UseCaseUpdateAddress _useCaseUpdateAddress;
    private readonly UseCaseFetchIdByAddress _useCaseFetchIdByAddress;

    public AddressController(UseCaseCreateAddress useCaseCreateAddress, 
        UseCaseFetchAllAddress useCaseFetchAllAddress, 
        UseCaseFetchAddressById useCaseFetchAddressById, 
        UseCaseDeleteAddress useCaseDeleteAddress, UseCaseUpdateAddress useCaseUpdateAddress, UseCaseFetchIdByAddress useCaseFetchIdByAddress)
    {
        _useCaseCreateAddress = useCaseCreateAddress;
        _useCaseFetchAllAddress = useCaseFetchAllAddress;
        _useCaseFetchAddressById = useCaseFetchAddressById;
        _useCaseDeleteAddress = useCaseDeleteAddress;
        _useCaseUpdateAddress = useCaseUpdateAddress;
        _useCaseFetchIdByAddress = useCaseFetchIdByAddress;
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
    
    [HttpGet]
    [Route("get-id")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DtoOutputAddressId>> GetAddressId(
        [FromQuery] string street,
        [FromQuery] string postalCode,
        [FromQuery] string city,
        [FromQuery] string number,
        [FromQuery] string country)
    {
        try
        {
            int addressId = await _useCaseFetchIdByAddress.GetIdByAddressAsync(street, postalCode, city, number, country);

            var dto = new DtoOutputAddressId
            {
                Id = addressId
            };

            return Ok(dto);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
    }
}