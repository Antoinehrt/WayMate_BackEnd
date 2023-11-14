using Domain.Entities.Users;

namespace Domain.Entities; 

public class Booking {
    private string _BookingDate { get; set; }
    private int _nbBookedSeats { get; set; }
    private Trip _trip { get; set; }
    private List<Passenger> _passengers { get; set; }
    

    public double CalculatePrice() {
        //TODO : il faut la liaison avec trip pour pouvoir faire le calcul
        return 0.0;
    }
    
    private void Add(Passenger passenger) {
        _passengers.Add(passenger);
    }

    private void AddRange(IEnumerable<Passenger> passengers) {
        foreach (var p in passengers) {
            Add(p);
        }
    }
}