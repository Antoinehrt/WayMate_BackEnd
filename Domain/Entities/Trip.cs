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
    private User _driver;

    public User Driver
    {
        get => _driver;
        set
        {
            if (value.UserType == UserType.Driver)
                _driver = value;
            else throw new ArgumentException($"This user is not a driver.");
        }
    }

    public int CalculateAvailableSeates() {
        //TODO : cette méthode
        return 0;
    }
    
}