using Application.UseCases.Car;
using Application.UseCases.Car.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Address;

[ApiController]
[Route("api/v1/car")]
public class CarController : ControllerBase
{
    private readonly UseCaseCreateCar _useCaseCreateCar;
    private readonly UseCaseFetchCarById _useCaseFetchCarById;

    public CarController(UseCaseCreateCar useCaseCreateCar, UseCaseFetchCarById useCaseFetchCarById)
    {
        _useCaseCreateCar = useCaseCreateCar;
        _useCaseFetchCarById = useCaseFetchCarById;
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputCar> FetchById(int numberPlate)
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
}