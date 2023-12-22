using Application.UseCases.Car;
using Application.UseCases.Car.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/car")]
public class CarController : ControllerBase
{
    private readonly UseCaseCreateCar _useCaseCreateCar;
    private readonly UseCaseFetchCarById _useCaseFetchCarById;
    private readonly UseCaseFetchAllCar _useCaseFetchAllCar;
    private readonly UseCaseDeleteCar _useCaseDeleteCar;
    private readonly UseCaseUpdateCar _useCaseUpdateCar;

    public CarController(UseCaseCreateCar useCaseCreateCar, UseCaseFetchCarById useCaseFetchCarById, UseCaseFetchAllCar useCaseFetchAllCar, UseCaseDeleteCar useCaseDeleteCar, UseCaseUpdateCar useCaseUpdateCar)
    {
        _useCaseCreateCar = useCaseCreateCar;
        _useCaseFetchCarById = useCaseFetchCarById;
        _useCaseFetchAllCar = useCaseFetchAllCar;
        _useCaseDeleteCar = useCaseDeleteCar;
        _useCaseUpdateCar = useCaseUpdateCar;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputCar>> FetchAll()
    {
        return Ok(_useCaseFetchAllCar.Execute());
    }

    [HttpGet("getById/{numberPlate}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputCar> FetchById(string numberPlate)
    {
        try
        {
            return _useCaseFetchCarById.Execute(numberPlate);
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
    public ActionResult<DtoOutputCar> Create(DtoInputCreateCar dto)
    {
        var output = _useCaseCreateCar.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { numberPlate = output.NumberPlate }, 
            output
            );
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Delete(string numberPlate)
    {
        if(_useCaseDeleteCar.Execute(numberPlate)) return NoContent();
        return NotFound();
    }
    
    [HttpPut("update/{numberPlate}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Update(string numberPlate, [FromBody] DtoInputUpdateCar dto)
    {
        dto.NumberPlate = numberPlate;
        return _useCaseUpdateCar.Execute(dto) ? NoContent() : NotFound();
    }
    
}