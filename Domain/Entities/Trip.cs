using Domain.Entities.Users;
using Domain.Enums;

namespace Domain.Entities; 

public class Trip {
    public string TripDate { get; set; }
    public int OccupiedSeats { get; set; }
    public double PriceKm { get; set; }
    public bool Luggage { get; set; }
    public bool Smoker { get; set; }
    public bool PetFriendly { get; set; }
    public Address StartAddress { get; set; }
    public Address DestinationAddress { get; set; }
    public Car Car { get; set; }
    public string DriverMessage { get; set; }
    public bool AirConditioning { get; set; }
    private User _driver;
    public int CalculateAvailableSeates() {
        //TODO : cette méthode
        return 0;
    }
    
}