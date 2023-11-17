using Domain.Entities.Users;

namespace Domain.Entities; 

public class Booking {
    public string BookingDate { get; set; }
    public int NbBookedSeats { get; set; }
    public Trip Trip { get; set; }
    public List<Passenger> Passengers { get; set; }
    

    public double CalculatePrice() {
        //TODO : il faut la liaison avec trip pour pouvoir faire le calcul
        return 0.0;
    }
    
    private void Add(Passenger passenger) {
        Passengers.Add(passenger);
    }

    private void AddRange(IEnumerable<Passenger> passengers) {
        foreach (var p in passengers) {
            Add(p);
        }
    }
}