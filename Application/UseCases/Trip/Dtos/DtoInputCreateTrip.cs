using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Trip.Dtos;

public class DtoInputCreateTrip
{
    [Required] public int IdDriver { get; set; }
    [Required] public bool Smoke { get; set; }
    [Required] public float PriceKm { get; set; }
    [Required] public bool Luggage { get; set; }
    [Required] public bool PetFriendly { get; set; }
    [Required] public DateTime Date { get; set; }
    [Required] public int OccupiedSeats { get; set; }
    [Required] public int IdStartingPoint { get; set; }
    [Required] public int IdDestination { get; set; }
}