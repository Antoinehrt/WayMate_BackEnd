using Application.UseCases.Trip;
using Application.UseCases.Trip.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/trip")]
public class TripController : ControllerBase
{
    private readonly UseCaseFetchAllTrip _useCaseFetchAllTrip;
    private readonly UseCaseCreateTrip _useCaseCreateTrip;
    private readonly UseCaseFetchTripById _useCaseFetchTripById;

    public TripController(UseCaseFetchAllTrip useCaseFetchAllTrip, 
        UseCaseCreateTrip useCaseCreateTrip, 
        UseCaseFetchTripById useCaseFetchTripById)
    {
        _useCaseFetchAllTrip = useCaseFetchAllTrip;
        _useCaseCreateTrip = useCaseCreateTrip;
        _useCaseFetchTripById = useCaseFetchTripById;
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputTrip> FetchById(int id)
    {
        try
        {
            return _useCaseFetchTripById.Execute(id);
        }
        catch (Exception e)
        {
            return NotFound(new
            {
                e.Message
            });
        }
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputTrip>> FetchAll()
    {
        return Ok(_useCaseFetchAllTrip.Execute());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputTrip> Create(DtoInputCreateTrip dto)
    {
        var output = _useCaseCreateTrip.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.Id },
            output
        );
    }
}