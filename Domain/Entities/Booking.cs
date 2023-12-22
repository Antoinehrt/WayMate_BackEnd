using Domain.Entities.Users;
using Domain.Enums;

namespace Domain.Entities; 

public class Booking {
    public string BookingDate { get; set; }
    public int NbBookedSeats { get; set; }
    public Trip Trip { get; set; }
    public User User { get; set; }
 

    public double CalculatePrice() {
        //TODO : il faut la liaison avec trip pour pouvoir faire le calcul
        return 0.0;
    }


}