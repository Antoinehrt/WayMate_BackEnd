using Domain.Entities.Users;
using Domain.Enums;

namespace Domain.Entities; 

public class Booking {
    public string BookingDate { get; set; }
    public int NbBookedSeats { get; set; }
    public Trip Trip { get; set; }
    public List<User> Passengers { get; set; }
    

    public double CalculatePrice() {
        //TODO : il faut la liaison avec trip pour pouvoir faire le calcul
        return 0.0;
    }
    
    private void Add(User passenger) {
        if(passenger.UserType == UserType.Passenger)
            Passengers.Add(passenger);
    }

    private void AddRange(IEnumerable<User> passengers) {
        foreach (var p in passengers) {
            if(p.UserType == UserType.Passenger)
                Add(p);
        }
    }
}