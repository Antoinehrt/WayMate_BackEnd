namespace Application.UseCases.Trip.Dtos;

public class DtoOutputTrip
{
    public int Id { get; set; }
    public int IdDriver { get; set; }
    public bool Smoke { get; set; }
    public float PriceKm { get; set; }
    public bool Luggage { get; set; }
    public bool PetFriendly { get; set; }
    public DateTime Date { get; set; }
    public int OccupiedSeats { get; set; }
    public int IdStratingPoint { get; set; }
    public int IdDestination { get; set; }
}