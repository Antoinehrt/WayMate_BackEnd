using Domain.Entities.Users;
using Domain.Enums;

namespace Domain.Entities; 

public class Address {
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public string Number { get; set; }
    private User _passenger;

    public User Passenger
    {
        get => _passenger;

        set
        {
            if (value.UserType == UserType.Passenger)
                _passenger = value;
            else 
                throw new ArgumentException($"This user is not a passenger");
        }
    }
    
}