namespace Domain.Entities; 

public class Trip {
    private string _TripDate { get; set; }
    private int _occupiedSeats { get; set; }
    private double _priceKm { get; set; }
    private bool _luggage { get; set; }
    private bool _smoker { get; set; }
    private bool _petFriendly { get; set; }
    private Address _startAddress { get; set; }
    private Address _destinationAddress { get; set; }
    private Car _car { get; set; }
    private Driver _driver { get; set; }

    public int CalculateAvailableSeates() {
        //TODO : cette méthode
        return 0;
    }
    
}