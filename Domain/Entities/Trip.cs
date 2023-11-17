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
    public Driver Driver { get; set; }

    public int CalculateAvailableSeates() {
        //TODO : cette méthode
        return 0;
    }
    
}